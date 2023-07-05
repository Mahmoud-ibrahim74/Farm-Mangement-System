namespace FMS.Hardware
{
    partial class MusicPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayer));
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            this.pause = new Guna.UI2.WinForms.Guna2Button();
            this.nextMusic = new Guna.UI2.WinForms.Guna2Button();
            this.PreviousMusic = new Guna.UI2.WinForms.Guna2Button();
            this.openMusic = new Guna.UI2.WinForms.Guna2Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.coverImagesMusic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.Transition = new Guna.UI2.WinForms.Guna2Transition();
            ((System.ComponentModel.ISupportInitialize)(this.coverImagesMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // pause
            // 
            this.pause.Animated = true;
            this.pause.AutoRoundedCorners = true;
            this.pause.BackColor = System.Drawing.Color.Transparent;
            this.pause.BorderRadius = 44;
            this.pause.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.pause.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.pause.CheckedState.FillColor = System.Drawing.Color.White;
            this.pause.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.pause.CheckedState.Parent = this.pause;
            this.pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause.CustomImages.Parent = this.pause;
            this.Transition.SetDecoration(this.pause, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pause.DisabledState.Parent = this.pause;
            this.pause.FillColor = System.Drawing.Color.White;
            this.pause.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.pause.ForeColor = System.Drawing.Color.White;
            this.pause.HoverState.Parent = this.pause;
            this.pause.Image = ((System.Drawing.Image)(resources.GetObject("pause.Image")));
            this.pause.ImageOffset = new System.Drawing.Point(2, 0);
            this.pause.ImageSize = new System.Drawing.Size(60, 60);
            this.pause.Location = new System.Drawing.Point(421, 304);
            this.pause.Name = "pause";
            this.pause.ShadowDecoration.Parent = this.pause;
            this.pause.Size = new System.Drawing.Size(90, 90);
            this.pause.TabIndex = 1;
            this.toolTip.SetToolTip(this.pause, "ايقاف مؤقت");
            this.pause.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // nextMusic
            // 
            this.nextMusic.Animated = true;
            this.nextMusic.AutoRoundedCorners = true;
            this.nextMusic.BackColor = System.Drawing.Color.Transparent;
            this.nextMusic.BorderRadius = 29;
            this.nextMusic.CheckedState.Parent = this.nextMusic;
            this.nextMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextMusic.CustomImages.Parent = this.nextMusic;
            this.Transition.SetDecoration(this.nextMusic, Guna.UI2.AnimatorNS.DecorationType.None);
            this.nextMusic.DisabledState.Parent = this.nextMusic;
            this.nextMusic.FillColor = System.Drawing.Color.White;
            this.nextMusic.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.nextMusic.ForeColor = System.Drawing.Color.White;
            this.nextMusic.HoverState.Parent = this.nextMusic;
            this.nextMusic.Image = ((System.Drawing.Image)(resources.GetObject("nextMusic.Image")));
            this.nextMusic.ImageOffset = new System.Drawing.Point(1, 0);
            this.nextMusic.Location = new System.Drawing.Point(645, 322);
            this.nextMusic.Name = "nextMusic";
            this.nextMusic.ShadowDecoration.Parent = this.nextMusic;
            this.nextMusic.Size = new System.Drawing.Size(60, 60);
            this.nextMusic.TabIndex = 3;
            this.toolTip.SetToolTip(this.nextMusic, "التالي");
            this.nextMusic.Click += new System.EventHandler(this.nextMusic_Click);
            // 
            // PreviousMusic
            // 
            this.PreviousMusic.Animated = true;
            this.PreviousMusic.AutoRoundedCorners = true;
            this.PreviousMusic.BackColor = System.Drawing.Color.Transparent;
            this.PreviousMusic.BorderRadius = 29;
            this.PreviousMusic.CheckedState.Parent = this.PreviousMusic;
            this.PreviousMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousMusic.CustomImages.Parent = this.PreviousMusic;
            this.Transition.SetDecoration(this.PreviousMusic, Guna.UI2.AnimatorNS.DecorationType.None);
            this.PreviousMusic.DisabledState.Parent = this.PreviousMusic;
            this.PreviousMusic.FillColor = System.Drawing.Color.White;
            this.PreviousMusic.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.PreviousMusic.ForeColor = System.Drawing.Color.White;
            this.PreviousMusic.HoverState.Parent = this.PreviousMusic;
            this.PreviousMusic.Image = ((System.Drawing.Image)(resources.GetObject("PreviousMusic.Image")));
            this.PreviousMusic.ImageOffset = new System.Drawing.Point(-1, 0);
            this.PreviousMusic.Location = new System.Drawing.Point(227, 322);
            this.PreviousMusic.Name = "PreviousMusic";
            this.PreviousMusic.ShadowDecoration.Parent = this.PreviousMusic;
            this.PreviousMusic.Size = new System.Drawing.Size(60, 60);
            this.PreviousMusic.TabIndex = 4;
            this.toolTip.SetToolTip(this.PreviousMusic, "السابق");
            this.PreviousMusic.Click += new System.EventHandler(this.PreviousMusic_Click);
            // 
            // openMusic
            // 
            this.openMusic.Animated = true;
            this.openMusic.AutoRoundedCorners = true;
            this.openMusic.BackColor = System.Drawing.Color.Transparent;
            this.openMusic.BorderRadius = 29;
            this.openMusic.CheckedState.Parent = this.openMusic;
            this.openMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openMusic.CustomImages.Parent = this.openMusic;
            this.Transition.SetDecoration(this.openMusic, Guna.UI2.AnimatorNS.DecorationType.None);
            this.openMusic.DisabledState.Parent = this.openMusic;
            this.openMusic.FillColor = System.Drawing.Color.White;
            this.openMusic.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.openMusic.ForeColor = System.Drawing.Color.White;
            this.openMusic.HoverState.Parent = this.openMusic;
            this.openMusic.Image = ((System.Drawing.Image)(resources.GetObject("openMusic.Image")));
            this.openMusic.Location = new System.Drawing.Point(839, 322);
            this.openMusic.Name = "openMusic";
            this.openMusic.ShadowDecoration.Parent = this.openMusic;
            this.openMusic.Size = new System.Drawing.Size(60, 60);
            this.openMusic.TabIndex = 5;
            this.toolTip.SetToolTip(this.openMusic, "فتح موسيقي");
            this.openMusic.Click += new System.EventHandler(this.openMusic_Click);
            // 
            // openFile
            // 
            this.openFile.Filter = resources.GetString("openFile.Filter");
            this.openFile.Multiselect = true;
            // 
            // coverImagesMusic
            // 
            this.coverImagesMusic.BackColor = System.Drawing.Color.Transparent;
            this.Transition.SetDecoration(this.coverImagesMusic, Guna.UI2.AnimatorNS.DecorationType.None);
            this.coverImagesMusic.ImageRotate = 0F;
            this.coverImagesMusic.Location = new System.Drawing.Point(357, 83);
            this.coverImagesMusic.Name = "coverImagesMusic";
            this.coverImagesMusic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.coverImagesMusic.ShadowDecoration.Parent = this.coverImagesMusic;
            this.coverImagesMusic.Size = new System.Drawing.Size(234, 200);
            this.coverImagesMusic.TabIndex = 8;
            this.coverImagesMusic.TabStop = false;
            // 
            // guna2Button2
            // 
            this.guna2Button2.Animated = true;
            this.guna2Button2.AutoRoundedCorners = true;
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 29;
            this.guna2Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.guna2Button2.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.Transition.SetDecoration(this.guna2Button2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Button2.DisabledState.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.Location = new System.Drawing.Point(33, 322);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(60, 60);
            this.guna2Button2.TabIndex = 10;
            this.toolTip.SetToolTip(this.guna2Button2, "كتم الصوت");
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // Transition
            // 
            this.Transition.AnimationType = Guna.UI2.AnimatorNS.AnimationType.VertSlide;
            this.Transition.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.Transition.DefaultAnimation = animation1;
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(935, 427);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.coverImagesMusic);
            this.Controls.Add(this.openMusic);
            this.Controls.Add(this.PreviousMusic);
            this.Controls.Add(this.nextMusic);
            this.Controls.Add(this.pause);
            this.Transition.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MusicPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مشغل الوسائط";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MusicPlayer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.coverImagesMusic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button pause;
        private Guna.UI2.WinForms.Guna2Button nextMusic;
        private Guna.UI2.WinForms.Guna2Button PreviousMusic;
        private Guna.UI2.WinForms.Guna2Button openMusic;
        private System.Windows.Forms.OpenFileDialog openFile;
        private Guna.UI2.WinForms.Guna2CirclePictureBox coverImagesMusic;
        private System.Windows.Forms.ToolTip toolTip;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Transition Transition;
    }
}