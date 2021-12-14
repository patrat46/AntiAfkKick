using System;

namespace AntiAfkKick
{
    partial class AntiAFK
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AntiAFK));
            this.Reset = new System.Windows.Forms.Button();
            this.Ignore = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeRemaining = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Reset
            // 
            this.Reset.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Reset.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Reset.Location = new System.Drawing.Point(80, 111);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(105, 23);
            this.Reset.TabIndex = 0;
            this.Reset.Text = "Reset AFK Timer";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Ignore
            // 
            this.Ignore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.Ignore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Ignore.Location = new System.Drawing.Point(202, 111);
            this.Ignore.Name = "Ignore";
            this.Ignore.Size = new System.Drawing.Size(75, 23);
            this.Ignore.TabIndex = 1;
            this.Ignore.Text = "Close";
            this.Ignore.UseVisualStyleBackColor = false;
            this.Ignore.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Green;
            this.progressBar1.Location = new System.Drawing.Point(80, 85);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(202, 10);
            this.progressBar1.Step = 60;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Maximum = 1800;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(312, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Click Reset AFK Timer to send Left Control to all FFXIV windows.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeRemaining
            // 
            this.TimeRemaining.AutoSize = true;
            this.TimeRemaining.Location = new System.Drawing.Point(80, 67);
            this.TimeRemaining.Name = "TimeRemaining";
            this.TimeRemaining.Size = new System.Drawing.Size(81, 13);
            this.TimeRemaining.TabIndex = 4;
            this.TimeRemaining.Text = "Time Remaing: ";
            this.TimeRemaining.Click += new System.EventHandler(this.label2_Click);
            // 
            // AntiAFK
            // 
            this.AcceptButton = this.Reset;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.CancelButton = this.Ignore;
            this.ClientSize = new System.Drawing.Size(356, 156);
            this.Controls.Add(this.TimeRemaining);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Ignore);
            this.Controls.Add(this.Reset);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AntiAFK";
            this.Text = "Anti-AFK Kicker";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Ignore;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TimeRemaining;
    }
}