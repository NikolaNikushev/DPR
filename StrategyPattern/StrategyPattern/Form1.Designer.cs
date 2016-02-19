namespace StrategyPattern
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
            this.btnGnrtReq = new System.Windows.Forms.Button();
            this.lbRequests = new System.Windows.Forms.ListBox();
            this.rbFCFS = new System.Windows.Forms.RadioButton();
            this.rbSSTF = new System.Windows.Forms.RadioButton();
            this.rbSCAN = new System.Windows.Forms.RadioButton();
            this.tbReq = new System.Windows.Forms.TrackBar();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbReq)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGnrtReq
            // 
            this.btnGnrtReq.Location = new System.Drawing.Point(412, 384);
            this.btnGnrtReq.Name = "btnGnrtReq";
            this.btnGnrtReq.Size = new System.Drawing.Size(133, 38);
            this.btnGnrtReq.TabIndex = 0;
            this.btnGnrtReq.Text = "Generate Request";
            this.btnGnrtReq.UseVisualStyleBackColor = true;
            this.btnGnrtReq.Click += new System.EventHandler(this.btnGnrtReq_Click);
            // 
            // lbRequests
            // 
            this.lbRequests.FormattingEnabled = true;
            this.lbRequests.Location = new System.Drawing.Point(345, 32);
            this.lbRequests.Name = "lbRequests";
            this.lbRequests.Size = new System.Drawing.Size(200, 342);
            this.lbRequests.TabIndex = 1;
            // 
            // rbFCFS
            // 
            this.rbFCFS.AutoSize = true;
            this.rbFCFS.Location = new System.Drawing.Point(12, 32);
            this.rbFCFS.Name = "rbFCFS";
            this.rbFCFS.Size = new System.Drawing.Size(51, 17);
            this.rbFCFS.TabIndex = 2;
            this.rbFCFS.TabStop = true;
            this.rbFCFS.Text = "FCFS";
            this.rbFCFS.UseVisualStyleBackColor = true;
            // 
            // rbSSTF
            // 
            this.rbSSTF.AutoSize = true;
            this.rbSSTF.Location = new System.Drawing.Point(12, 55);
            this.rbSSTF.Name = "rbSSTF";
            this.rbSSTF.Size = new System.Drawing.Size(52, 17);
            this.rbSSTF.TabIndex = 3;
            this.rbSSTF.TabStop = true;
            this.rbSSTF.Text = "SSTF";
            this.rbSSTF.UseVisualStyleBackColor = true;
            // 
            // rbSCAN
            // 
            this.rbSCAN.AutoSize = true;
            this.rbSCAN.Location = new System.Drawing.Point(12, 78);
            this.rbSCAN.Name = "rbSCAN";
            this.rbSCAN.Size = new System.Drawing.Size(54, 17);
            this.rbSCAN.TabIndex = 4;
            this.rbSCAN.TabStop = true;
            this.rbSCAN.Text = "SCAN";
            this.rbSCAN.UseVisualStyleBackColor = true;
            // 
            // tbReq
            // 
            this.tbReq.Enabled = false;
            this.tbReq.LargeChange = 1;
            this.tbReq.Location = new System.Drawing.Point(197, 32);
            this.tbReq.Maximum = 100;
            this.tbReq.Name = "tbReq";
            this.tbReq.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbReq.Size = new System.Drawing.Size(45, 493);
            this.tbReq.TabIndex = 5;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 177);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(133, 38);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 230);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(133, 38);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 537);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbReq);
            this.Controls.Add(this.rbSCAN);
            this.Controls.Add(this.rbSSTF);
            this.Controls.Add(this.rbFCFS);
            this.Controls.Add(this.lbRequests);
            this.Controls.Add(this.btnGnrtReq);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tbReq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGnrtReq;
        private System.Windows.Forms.ListBox lbRequests;
        private System.Windows.Forms.RadioButton rbFCFS;
        private System.Windows.Forms.RadioButton rbSSTF;
        private System.Windows.Forms.RadioButton rbSCAN;
        private System.Windows.Forms.TrackBar tbReq;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
    }
}

