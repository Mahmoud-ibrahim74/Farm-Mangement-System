namespace FMS.Gallery
{
    partial class ImageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageView));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolTip = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.Upload = new Guna.UI2.WinForms.Guna2Button();
            this.UploadServer = new Guna.UI2.WinForms.Guna2Button();
            this.downlodServer = new Guna.UI2.WinForms.Guna2Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.imageContainer = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelLoader = new System.Windows.Forms.Panel();
            this.ProgressIndicator = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.CloseWorker = new MaterialSkin.Controls.MaterialButton();
            this.CircleProgressBar = new XanderUI.XUICircleProgressBar();
            this.txt_loader = new System.Windows.Forms.Label();
            this.SelectedImage = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.imageCounter = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.imageList = new System.Windows.Forms.ListView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.imageContainer.SuspendLayout();
            this.panelLoader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedImage)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // ToolTip
            // 
            this.ToolTip.AllowLinksHandling = true;
            this.ToolTip.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // Upload
            // 
            this.Upload.Animated = true;
            this.Upload.BackColor = System.Drawing.Color.Transparent;
            this.Upload.BorderRadius = 24;
            this.Upload.CheckedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.Upload.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.Upload.CheckedState.ForeColor = System.Drawing.Color.White;
            this.Upload.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.Upload.CheckedState.Parent = this.Upload;
            this.Upload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Upload.CustomImages.Parent = this.Upload;
            this.Upload.DisabledState.Parent = this.Upload;
            this.Upload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.Upload.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.Upload.ForeColor = System.Drawing.Color.White;
            this.Upload.HoverState.Parent = this.Upload;
            this.Upload.Image = ((System.Drawing.Image)(resources.GetObject("Upload.Image")));
            this.Upload.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Upload.ImageSize = new System.Drawing.Size(30, 30);
            this.Upload.Location = new System.Drawing.Point(241, 608);
            this.Upload.Name = "Upload";
            this.Upload.ShadowDecoration.Parent = this.Upload;
            this.Upload.Size = new System.Drawing.Size(264, 52);
            this.Upload.TabIndex = 44;
            this.Upload.Text = "رفع صورة";
            this.Upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.Upload, "الصور رفع");
            this.Upload.UseTransparentBackground = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // UploadServer
            // 
            this.UploadServer.Animated = true;
            this.UploadServer.BackColor = System.Drawing.Color.Transparent;
            this.UploadServer.BorderRadius = 24;
            this.UploadServer.CheckedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.UploadServer.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.UploadServer.CheckedState.ForeColor = System.Drawing.Color.White;
            this.UploadServer.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.UploadServer.CheckedState.Parent = this.UploadServer;
            this.UploadServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UploadServer.CustomImages.Parent = this.UploadServer;
            this.UploadServer.DisabledState.Parent = this.UploadServer;
            this.UploadServer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.UploadServer.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.UploadServer.ForeColor = System.Drawing.Color.White;
            this.UploadServer.HoverState.Parent = this.UploadServer;
            this.UploadServer.Image = ((System.Drawing.Image)(resources.GetObject("UploadServer.Image")));
            this.UploadServer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UploadServer.ImageSize = new System.Drawing.Size(30, 30);
            this.UploadServer.Location = new System.Drawing.Point(627, 608);
            this.UploadServer.Name = "UploadServer";
            this.UploadServer.ShadowDecoration.Parent = this.UploadServer;
            this.UploadServer.Size = new System.Drawing.Size(270, 52);
            this.UploadServer.TabIndex = 45;
            this.UploadServer.Text = "رفع الصور علي الخادم";
            this.UploadServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.UploadServer, "الصور رفع");
            this.UploadServer.UseTransparentBackground = true;
            this.UploadServer.Click += new System.EventHandler(this.UploadServer_Click);
            // 
            // downlodServer
            // 
            this.downlodServer.Animated = true;
            this.downlodServer.BackColor = System.Drawing.Color.Transparent;
            this.downlodServer.BorderRadius = 24;
            this.downlodServer.CheckedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.downlodServer.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.downlodServer.CheckedState.ForeColor = System.Drawing.Color.White;
            this.downlodServer.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.downlodServer.CheckedState.Parent = this.downlodServer;
            this.downlodServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.downlodServer.CustomImages.Parent = this.downlodServer;
            this.downlodServer.DisabledState.Parent = this.downlodServer;
            this.downlodServer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.downlodServer.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.downlodServer.ForeColor = System.Drawing.Color.White;
            this.downlodServer.HoverState.Parent = this.downlodServer;
            this.downlodServer.Image = ((System.Drawing.Image)(resources.GetObject("downlodServer.Image")));
            this.downlodServer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.downlodServer.ImageSize = new System.Drawing.Size(30, 30);
            this.downlodServer.Location = new System.Drawing.Point(1044, 608);
            this.downlodServer.Name = "downlodServer";
            this.downlodServer.ShadowDecoration.Parent = this.downlodServer;
            this.downlodServer.Size = new System.Drawing.Size(270, 52);
            this.downlodServer.TabIndex = 46;
            this.downlodServer.Text = "تنزيل الصور من الخادم";
            this.downlodServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.downlodServer, "الصور تحميل");
            this.downlodServer.UseTransparentBackground = true;
            this.downlodServer.Click += new System.EventHandler(this.downlodServer_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // imageContainer
            // 
            this.imageContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.imageContainer.BorderRadius = 20;
            this.imageContainer.Controls.Add(this.panelLoader);
            this.imageContainer.Controls.Add(this.SelectedImage);
            this.imageContainer.FillColor = System.Drawing.Color.LightBlue;
            this.imageContainer.FillColor2 = System.Drawing.Color.LightBlue;
            this.imageContainer.Location = new System.Drawing.Point(211, 12);
            this.imageContainer.Name = "imageContainer";
            this.imageContainer.ShadowDecoration.Parent = this.imageContainer;
            this.imageContainer.Size = new System.Drawing.Size(1107, 581);
            this.imageContainer.TabIndex = 42;
            // 
            // panelLoader
            // 
            this.panelLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panelLoader.Controls.Add(this.ProgressIndicator);
            this.panelLoader.Controls.Add(this.CloseWorker);
            this.panelLoader.Controls.Add(this.CircleProgressBar);
            this.panelLoader.Controls.Add(this.txt_loader);
            this.panelLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoader.Location = new System.Drawing.Point(0, 0);
            this.panelLoader.Name = "panelLoader";
            this.panelLoader.Size = new System.Drawing.Size(1107, 581);
            this.panelLoader.TabIndex = 40;
            this.panelLoader.Visible = false;
            // 
            // ProgressIndicator
            // 
            this.ProgressIndicator.AnimationSpeed = 90;
            this.ProgressIndicator.AutoStart = true;
            this.ProgressIndicator.CircleSize = 20F;
            this.ProgressIndicator.Location = new System.Drawing.Point(387, 188);
            this.ProgressIndicator.Name = "ProgressIndicator";
            this.ProgressIndicator.ShadowDecoration.Parent = this.ProgressIndicator;
            this.ProgressIndicator.Size = new System.Drawing.Size(302, 258);
            this.ProgressIndicator.TabIndex = 6;
            this.ProgressIndicator.Visible = false;
            // 
            // CloseWorker
            // 
            this.CloseWorker.AutoSize = false;
            this.CloseWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CloseWorker.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CloseWorker.Depth = 0;
            this.CloseWorker.HighEmphasis = true;
            this.CloseWorker.Icon = null;
            this.CloseWorker.Location = new System.Drawing.Point(1063, 3);
            this.CloseWorker.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CloseWorker.MouseState = MaterialSkin.MouseState.HOVER;
            this.CloseWorker.Name = "CloseWorker";
            this.CloseWorker.Size = new System.Drawing.Size(40, 27);
            this.CloseWorker.TabIndex = 5;
            this.CloseWorker.Text = "X";
            this.CloseWorker.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CloseWorker.UseAccentColor = false;
            this.CloseWorker.UseVisualStyleBackColor = true;
            this.CloseWorker.Click += new System.EventHandler(this.CloseWorker_Click);
            // 
            // CircleProgressBar
            // 
            this.CircleProgressBar.AnimationSpeed = 5;
            this.CircleProgressBar.FilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.CircleProgressBar.FilledColorAlpha = 130;
            this.CircleProgressBar.FilledThickness = 40;
            this.CircleProgressBar.IsAnimated = false;
            this.CircleProgressBar.Location = new System.Drawing.Point(372, 176);
            this.CircleProgressBar.Name = "CircleProgressBar";
            this.CircleProgressBar.Percentage = 0;
            this.CircleProgressBar.ShowText = true;
            this.CircleProgressBar.Size = new System.Drawing.Size(300, 300);
            this.CircleProgressBar.TabIndex = 2;
            this.CircleProgressBar.TextColor = System.Drawing.Color.Gray;
            this.CircleProgressBar.TextSize = 25;
            this.CircleProgressBar.UnFilledColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.CircleProgressBar.UnfilledThickness = 24;
            // 
            // txt_loader
            // 
            this.txt_loader.AutoSize = true;
            this.txt_loader.BackColor = System.Drawing.Color.Transparent;
            this.txt_loader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loader.ForeColor = System.Drawing.Color.Black;
            this.txt_loader.Location = new System.Drawing.Point(474, 122);
            this.txt_loader.Name = "txt_loader";
            this.txt_loader.Size = new System.Drawing.Size(111, 25);
            this.txt_loader.TabIndex = 1;
            this.txt_loader.Text = "جاري التحميل";
            this.txt_loader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SelectedImage
            // 
            this.SelectedImage.BackColor = System.Drawing.Color.LightBlue;
            this.SelectedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedImage.Location = new System.Drawing.Point(0, 0);
            this.SelectedImage.Name = "SelectedImage";
            this.SelectedImage.Size = new System.Drawing.Size(1107, 581);
            this.SelectedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SelectedImage.TabIndex = 0;
            this.SelectedImage.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.panel6.Controls.Add(this.imageCounter);
            this.panel6.Controls.Add(this.pictureBox2);
            this.panel6.Controls.Add(this.guna2GradientPanel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(212, 677);
            this.panel6.TabIndex = 43;
            // 
            // imageCounter
            // 
            this.imageCounter.AutoSize = true;
            this.imageCounter.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageCounter.ForeColor = System.Drawing.Color.White;
            this.imageCounter.Location = new System.Drawing.Point(115, 86);
            this.imageCounter.Name = "imageCounter";
            this.imageCounter.Size = new System.Drawing.Size(68, 20);
            this.imageCounter.TabIndex = 5;
            this.imageCounter.Text = "0 Photos";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(107, 101);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.AutoScroll = true;
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.imageList);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 115);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(205, 559);
            this.guna2GradientPanel1.TabIndex = 4;
            // 
            // imageList
            // 
            this.imageList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.imageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageList.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageList.ForeColor = System.Drawing.Color.White;
            this.imageList.Location = new System.Drawing.Point(0, 0);
            this.imageList.MultiSelect = false;
            this.imageList.Name = "imageList";
            this.imageList.Size = new System.Drawing.Size(205, 559);
            this.imageList.TabIndex = 0;
            this.imageList.UseCompatibleStateImageBehavior = false;
            this.imageList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.imageList_ItemSelectionChanged);
            this.imageList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imageList_KeyDown);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Images";
            this.openFileDialog.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Upload Image";
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1330, 677);
            this.Controls.Add(this.downlodServer);
            this.Controls.Add(this.UploadServer);
            this.Controls.Add(this.Upload);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.imageContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImageView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عرض الصور";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.imageContainer.ResumeLayout(false);
            this.panelLoader.ResumeLayout(false);
            this.panelLoader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedImage)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Guna.UI2.WinForms.Guna2HtmlToolTip ToolTip;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label imageCounter;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.ListView imageList;
        private Guna.UI2.WinForms.Guna2GradientPanel imageContainer;
        private System.Windows.Forms.PictureBox SelectedImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Guna.UI2.WinForms.Guna2Button Upload;
        private Guna.UI2.WinForms.Guna2Button UploadServer;
        private System.Windows.Forms.Panel panelLoader;
        private System.Windows.Forms.Label txt_loader;
        private XanderUI.XUICircleProgressBar CircleProgressBar;
        private MaterialSkin.Controls.MaterialButton CloseWorker;
        private Guna.UI2.WinForms.Guna2Button downlodServer;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator ProgressIndicator;
    }
}