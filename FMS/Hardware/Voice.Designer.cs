
namespace FMS.Hardware
{
    partial class Voice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Voice));
            this.recording = new Guna.UI2.WinForms.Guna2GradientButton();
            this.stopRecording = new Guna.UI2.WinForms.Guna2GradientButton();
            this.playRecording = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SuspendLayout();
            // 
            // recording
            // 
            this.recording.BorderRadius = 20;
            this.recording.CheckedState.Parent = this.recording;
            this.recording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recording.CustomImages.Parent = this.recording;
            this.recording.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.recording.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.recording.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.recording.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.recording.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.recording.DisabledState.Parent = this.recording;
            this.recording.FillColor = System.Drawing.Color.Teal;
            this.recording.FillColor2 = System.Drawing.Color.DarkCyan;
            this.recording.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recording.ForeColor = System.Drawing.Color.White;
            this.recording.HoverState.Parent = this.recording;
            this.recording.Image = ((System.Drawing.Image)(resources.GetObject("recording.Image")));
            this.recording.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.recording.ImageSize = new System.Drawing.Size(30, 30);
            this.recording.Location = new System.Drawing.Point(685, 12);
            this.recording.Name = "recording";
            this.recording.ShadowDecoration.Parent = this.recording;
            this.recording.Size = new System.Drawing.Size(180, 45);
            this.recording.TabIndex = 0;
            this.recording.Text = "تسجيل";
            this.recording.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.recording.Click += new System.EventHandler(this.recording_Click);
            // 
            // stopRecording
            // 
            this.stopRecording.BorderRadius = 20;
            this.stopRecording.CheckedState.Parent = this.stopRecording;
            this.stopRecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopRecording.CustomImages.Parent = this.stopRecording;
            this.stopRecording.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.stopRecording.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.stopRecording.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.stopRecording.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.stopRecording.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.stopRecording.DisabledState.Parent = this.stopRecording;
            this.stopRecording.Enabled = false;
            this.stopRecording.FillColor = System.Drawing.Color.Teal;
            this.stopRecording.FillColor2 = System.Drawing.Color.DarkCyan;
            this.stopRecording.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopRecording.ForeColor = System.Drawing.Color.White;
            this.stopRecording.HoverState.Parent = this.stopRecording;
            this.stopRecording.Image = ((System.Drawing.Image)(resources.GetObject("stopRecording.Image")));
            this.stopRecording.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stopRecording.ImageSize = new System.Drawing.Size(30, 30);
            this.stopRecording.Location = new System.Drawing.Point(359, 12);
            this.stopRecording.Name = "stopRecording";
            this.stopRecording.ShadowDecoration.Parent = this.stopRecording;
            this.stopRecording.Size = new System.Drawing.Size(180, 45);
            this.stopRecording.TabIndex = 0;
            this.stopRecording.Text = "ايقاف";
            this.stopRecording.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.stopRecording.Click += new System.EventHandler(this.stopRecording_Click);
            // 
            // playRecording
            // 
            this.playRecording.BorderRadius = 20;
            this.playRecording.CheckedState.Parent = this.playRecording;
            this.playRecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playRecording.CustomImages.Parent = this.playRecording;
            this.playRecording.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.playRecording.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.playRecording.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.playRecording.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.playRecording.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.playRecording.DisabledState.Parent = this.playRecording;
            this.playRecording.Enabled = false;
            this.playRecording.FillColor = System.Drawing.Color.Teal;
            this.playRecording.FillColor2 = System.Drawing.Color.DarkCyan;
            this.playRecording.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playRecording.ForeColor = System.Drawing.Color.White;
            this.playRecording.HoverState.Parent = this.playRecording;
            this.playRecording.Image = ((System.Drawing.Image)(resources.GetObject("playRecording.Image")));
            this.playRecording.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.playRecording.ImageSize = new System.Drawing.Size(30, 30);
            this.playRecording.Location = new System.Drawing.Point(33, 12);
            this.playRecording.Name = "playRecording";
            this.playRecording.ShadowDecoration.Parent = this.playRecording;
            this.playRecording.Size = new System.Drawing.Size(180, 45);
            this.playRecording.TabIndex = 0;
            this.playRecording.Text = "تشغيل";
            this.playRecording.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.playRecording.Click += new System.EventHandler(this.playRecording_Click);
            // 
            // Voice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 70);
            this.Controls.Add(this.playRecording);
            this.Controls.Add(this.stopRecording);
            this.Controls.Add(this.recording);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Voice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voice";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton recording;
        private Guna.UI2.WinForms.Guna2GradientButton stopRecording;
        private Guna.UI2.WinForms.Guna2GradientButton playRecording;
    }
}