namespace scadaWinform
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.easyTextBox1 = new EasyScada.Winforms.Controls.EasyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.easyTextBox2 = new EasyScada.Winforms.Controls.EasyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._labSriverStatus = new System.Windows.Forms.Label();
            this._pnStatus = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.easyTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyTextBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // easyTextBox1
            // 
            this.easyTextBox1.DropDownBackColor = System.Drawing.SystemColors.Control;
            this.easyTextBox1.DropDownBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.easyTextBox1.DropDownDirection = EasyScada.Winforms.Controls.DropDownDirection.None;
            this.easyTextBox1.DropDownFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyTextBox1.DropDownForeColor = System.Drawing.SystemColors.ControlText;
            this.easyTextBox1.HightLightStatusTime = 3;
            this.easyTextBox1.Location = new System.Drawing.Point(111, 39);
            this.easyTextBox1.Name = "easyTextBox1";
            this.easyTextBox1.Role = null;
            this.easyTextBox1.Size = new System.Drawing.Size(100, 20);
            this.easyTextBox1.StringFormat = null;
            this.easyTextBox1.TabIndex = 0;
            this.easyTextBox1.TagPath = "Local Station/Channel1/Device1/Tag1";
            this.easyTextBox1.Text = "easyTextBox1";
            this.easyTextBox1.WriteDelay = 200;
            this.easyTextBox1.WriteTrigger = EasyScada.Core.WriteTrigger.OnEnter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Temp_1";
            // 
            // easyTextBox2
            // 
            this.easyTextBox2.DropDownBackColor = System.Drawing.SystemColors.Control;
            this.easyTextBox2.DropDownBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.easyTextBox2.DropDownDirection = EasyScada.Winforms.Controls.DropDownDirection.None;
            this.easyTextBox2.DropDownFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyTextBox2.DropDownForeColor = System.Drawing.SystemColors.ControlText;
            this.easyTextBox2.HightLightStatusTime = 3;
            this.easyTextBox2.Location = new System.Drawing.Point(111, 78);
            this.easyTextBox2.Name = "easyTextBox2";
            this.easyTextBox2.Role = null;
            this.easyTextBox2.Size = new System.Drawing.Size(100, 20);
            this.easyTextBox2.StringFormat = null;
            this.easyTextBox2.TabIndex = 0;
            this.easyTextBox2.TagPath = "Local Station/Channel1/Device1/Tag2";
            this.easyTextBox2.Text = "easyTextBox1";
            this.easyTextBox2.WriteDelay = 200;
            this.easyTextBox2.WriteTrigger = EasyScada.Core.WriteTrigger.OnEnter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Temp_2";
            // 
            // _labSriverStatus
            // 
            this._labSriverStatus.AutoSize = true;
            this._labSriverStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labSriverStatus.Location = new System.Drawing.Point(30, 407);
            this._labSriverStatus.Name = "_labSriverStatus";
            this._labSriverStatus.Size = new System.Drawing.Size(98, 20);
            this._labSriverStatus.TabIndex = 6;
            this._labSriverStatus.Text = "Driver status";
            // 
            // _pnStatus
            // 
            this._pnStatus.Location = new System.Drawing.Point(184, 398);
            this._pnStatus.Name = "_pnStatus";
            this._pnStatus.Size = new System.Drawing.Size(123, 40);
            this._pnStatus.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._pnStatus);
            this.Controls.Add(this._labSriverStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.easyTextBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.easyTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.easyTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyTextBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EasyScada.Winforms.Controls.EasyTextBox easyTextBox1;
        private System.Windows.Forms.Label label1;
        private EasyScada.Winforms.Controls.EasyTextBox easyTextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _labSriverStatus;
        private System.Windows.Forms.Panel _pnStatus;
    }
}

