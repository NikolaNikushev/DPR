﻿namespace StrategyPattern
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
            this.trackBarRequest = new System.Windows.Forms.TrackBar();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCurrentRequest = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRequest)).BeginInit();
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
            this.lbRequests.Enabled = false;
            this.lbRequests.FormattingEnabled = true;
            this.lbRequests.Location = new System.Drawing.Point(412, 36);
            this.lbRequests.Name = "lbRequests";
            this.lbRequests.Size = new System.Drawing.Size(133, 342);
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
            // trackBarRequest
            // 
            this.trackBarRequest.LargeChange = 1;
            this.trackBarRequest.Location = new System.Drawing.Point(200, 30);
            this.trackBarRequest.Maximum = 100;
            this.trackBarRequest.Name = "trackBarRequest";
            this.trackBarRequest.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarRequest.Size = new System.Drawing.Size(45, 500);
            this.trackBarRequest.TabIndex = 5;
            this.trackBarRequest.Scroll += new System.EventHandler(this.trackBarRequest_Scroll);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current request";
            // 
            // tbCurrentRequest
            // 
            this.tbCurrentRequest.Enabled = false;
            this.tbCurrentRequest.Location = new System.Drawing.Point(162, 6);
            this.tbCurrentRequest.Name = "tbCurrentRequest";
            this.tbCurrentRequest.Size = new System.Drawing.Size(100, 20);
            this.tbCurrentRequest.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 537);
            this.Controls.Add(this.tbCurrentRequest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.rbSCAN);
            this.Controls.Add(this.rbSSTF);
            this.Controls.Add(this.rbFCFS);
            this.Controls.Add(this.lbRequests);
            this.Controls.Add(this.btnGnrtReq);
            this.Controls.Add(this.trackBarRequest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRequest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGnrtReq;
        private System.Windows.Forms.ListBox lbRequests;
        private System.Windows.Forms.RadioButton rbFCFS;
        private System.Windows.Forms.RadioButton rbSSTF;
        private System.Windows.Forms.RadioButton rbSCAN;
        private System.Windows.Forms.TrackBar trackBarRequest;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCurrentRequest;
    }
}

