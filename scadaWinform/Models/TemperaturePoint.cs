using System;

namespace scadaWinform
{
    /// <summary>
    /// Giá trị nhiệt độ tại một điểm (lưu trong C00 của RealtimeData).
    /// </summary>
    public class TemperaturePoint
    {
        public Guid LocationId { get; set; }
        public double Temperature { get; set; }

        public string Path { get; set; }
    }
}
