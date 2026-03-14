using EasyScada.Core;
using EasyScada.Winforms.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scadaWinform
{
    public partial class Form1 : Form
    {
        private EasyDriverConnector _easyDriverConnector;
        private ConnectionStatus _easyStatus;

        private List<LocationConfigItem> _locationConfigItems = new List<LocationConfigItem>();
        private List<TemperaturePoint> _temperaturePoints = new List<TemperaturePoint>();

        private CancellationTokenSource _timerCts;
        private Task _timerTask;

        public Form1()
        {
            InitializeComponent();

            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
        }

        private async void Form1_Load(object sender, System.EventArgs e)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var config = await dbContext.RevoConfigs.FirstOrDefaultAsync();
                _locationConfigItems = JsonConvert.DeserializeObject<List<LocationConfigItem>>(config.C000);

                foreach (var item in _locationConfigItems)
                {
                    _temperaturePoints.Add(new TemperaturePoint()
                    {
                        Path = item.Path,
                        LocationId = item.Id,
                        Temperature = 0
                    });
                }
            }

            #region Khởi tạo easy drirver connector
            _easyDriverConnector = new EasyDriverConnector();
            _easyDriverConnector.ConnectionStatusChaged += _easyDriverConnector_ConnectionStatusChaged;
            _easyDriverConnector.BeginInit();
            _easyDriverConnector.EndInit();
            //_easyStatus = _easyDriverConnector.ConnectionStatus;

            _easyDriverConnector.Started += _easyDriverConnector_Started;
            if (_easyDriverConnector.IsStarted)
            {
                _easyDriverConnector_Started(null, null);
            }
            #endregion

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _easyDriverConnector.ConnectionStatusChaged -= _easyDriverConnector_ConnectionStatusChaged;
                _easyDriverConnector.Started -= _easyDriverConnector_Started;
                _easyDriverConnector.Stop();

                _timerCts.Cancel();
                _timerTask.Wait(1000);
            }
            catch
            {

            }
            finally
            {
                _timerCts?.Dispose();
                _timerTask = null;
            }
        }

        private void _easyDriverConnector_ConnectionStatusChaged(object sender, ConnectionStatusChangedEventArgs e)
        {
            _easyStatus = e.NewStatus;

            if (_easyDriverConnector.ConnectionStatus == ConnectionStatus.Connected)
            {
                _pnStatus.BackColor = Color.Green;
            }
            else
            {
                _pnStatus.BackColor = Color.Red;
            }
            //GlobalVariable.InvokeIfRequired(this, () =>
            //{
            //    _labSriverStatus.BackColor = GetConnectionStatusColor(e.NewStatus);
            //    _labSriverStatus.Text = $"TT kết nối easy driver: {_easyDriverConnector.ConnectionStatus.ToString()}";
            //});
        }

        private void _easyDriverConnector_Started(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);

            foreach (var item in _locationConfigItems)
            {
                _easyDriverConnector.GetTag($"{item.Path}/Tag1").QualityChanged += Tag1_QualityChanged;
                _easyDriverConnector.GetTag($"{item.Path}/Tag1").ValueChanged += Tag1_ValueChanged;
                //_easyDriverConnector.GetTag($"{item.Path}/Device1/Tag2").ValueChanged += Tag2_ValueChanged;

                Tag1_ValueChanged(_easyDriverConnector.GetTag($"{item.Path}/Tag1")
                    , new TagValueChangedEventArgs(_easyDriverConnector.GetTag($"{item.Path}/Tag1")
                    , "", _easyDriverConnector.GetTag($"{item.Path}/Tag1").Value));
                //Tag2_ValueChanged(_easyDriverConnector.GetTag($"{item.Path}/Device1/Tag2")
                //   , new TagValueChangedEventArgs(_easyDriverConnector.GetTag($"{item.Path}/Device1/Tag2")
                //   , "", _easyDriverConnector.GetTag($"{item.Path}/Device1/Tag2").Value));
            }
           

        }

        private async void Tag1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                var path = e.Tag.Parent.Path;
                var deviceName = e.Tag.Parent.Name;
                var al = deviceName.Substring(4);

                foreach (var item in _temperaturePoints)
                {
                    if (item.Path == path)
                    {
                        item.Temperature = Convert.ToDouble(e.NewValue);
                        //Debug.WriteLine($"Alarm description {item.OvenId}:{item.AlarmDescription}");
                        break;
                    }
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    var realTime =await dbContext.RealtimeDatas.FirstOrDefaultAsync();
                    if (realTime != null)
                    {
                        realTime.C00 = JsonConvert.SerializeObject(_temperaturePoints);
                        realTime.CreatedAt = DateTime.Now;
                        dbContext.Entry(realTime).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex) { /*Log.Error(ex, $"From TagValueChanged {e.Tag.Path}");*/ }
        }

        private async void Tag2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                var path = e.Tag.Parent.Path;
                var deviceName = e.Tag.Parent.Name;
                var al = deviceName.Substring(4);

                foreach (var item in _temperaturePoints)
                {
                    if (item.Path == path)
                    {
                        item.Temperature = Convert.ToDouble(e.NewValue);
                        //Debug.WriteLine($"Alarm description {item.OvenId}:{item.AlarmDescription}");
                        return;
                    }
                }

                using (var dbContext = new ApplicationDbContext())
                {
                    var realTime = await dbContext.RealtimeDatas.FirstOrDefaultAsync();
                    if (realTime != null)
                    {
                        realTime.C00 = JsonConvert.SerializeObject(_temperaturePoints);
                        dbContext.Entry(realTime).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex) { /*Log.Error(ex, $"From TagValueChanged {e.Tag.Path}");*/ }
        }

        private void Tag1_QualityChanged(object sender, TagQualityChangedEventArgs e)
        {
            //GlobalVariable.RevoRealtimeModel.PlcConnected = e.NewQuality == Quality.Good ? true : false;
        }
    }
}
