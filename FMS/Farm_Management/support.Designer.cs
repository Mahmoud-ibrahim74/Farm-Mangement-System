namespace FMS.Farm_Management
{
    partial class support
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(support));
            this.fromEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.subject = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.setPath = new System.Windows.Forms.Label();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.panelRecord = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.panelLoader = new System.Windows.Forms.Panel();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txt_loader = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bodyMessage = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.makeRecord = new Guna.UI2.WinForms.Guna2Button();
            this.closeRecord = new Guna.UI2.WinForms.Guna2Button();
            this.checkRecord = new Guna.UI2.WinForms.Guna2CheckBox();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.panelLoader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // fromEmail
            // 
            this.fromEmail.Animated = true;
            this.fromEmail.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.fromEmail.BorderRadius = 1;
            this.fromEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fromEmail.DefaultText = "zedanelmasry3@gmail.com";
            this.fromEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.fromEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.fromEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fromEmail.DisabledState.Parent = this.fromEmail;
            this.fromEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fromEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.fromEmail.FocusedState.Parent = this.fromEmail;
            this.fromEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.fromEmail.ForeColor = System.Drawing.Color.Black;
            this.fromEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.fromEmail.HoverState.Parent = this.fromEmail;
            this.fromEmail.Location = new System.Drawing.Point(126, 56);
            this.fromEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fromEmail.Name = "fromEmail";
            this.fromEmail.PasswordChar = '\0';
            this.fromEmail.PlaceholderText = "";
            this.fromEmail.ReadOnly = true;
            this.fromEmail.SelectedText = "";
            this.fromEmail.SelectionStart = 23;
            this.fromEmail.ShadowDecoration.Parent = this.fromEmail;
            this.fromEmail.Size = new System.Drawing.Size(626, 36);
            this.fromEmail.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 29;
            this.label1.Text = "From  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 21);
            this.label2.TabIndex = 30;
            this.label2.Text = "To :";
            // 
            // toEmail
            // 
            this.toEmail.Animated = true;
            this.toEmail.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.toEmail.BorderRadius = 1;
            this.toEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.toEmail.DefaultText = "";
            this.toEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.toEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.toEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.toEmail.DisabledState.Parent = this.toEmail;
            this.toEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.toEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toEmail.FocusedState.Parent = this.toEmail;
            this.toEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toEmail.ForeColor = System.Drawing.Color.Black;
            this.toEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toEmail.HoverState.Parent = this.toEmail;
            this.toEmail.Location = new System.Drawing.Point(126, 102);
            this.toEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toEmail.Name = "toEmail";
            this.toEmail.PasswordChar = '\0';
            this.toEmail.PlaceholderText = "";
            this.toEmail.SelectedText = "";
            this.toEmail.ShadowDecoration.Parent = this.toEmail;
            this.toEmail.Size = new System.Drawing.Size(626, 36);
            this.toEmail.TabIndex = 31;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(273, 76);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(71, 63);
            this.guna2PictureBox1.TabIndex = 32;
            this.guna2PictureBox1.TabStop = false;
            // 
            // subject
            // 
            this.subject.Animated = true;
            this.subject.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.subject.BorderRadius = 1;
            this.subject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.subject.DefaultText = "";
            this.subject.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.subject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.subject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.subject.DisabledState.Parent = this.subject;
            this.subject.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.subject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.subject.FocusedState.Parent = this.subject;
            this.subject.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.subject.ForeColor = System.Drawing.Color.Black;
            this.subject.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.subject.HoverState.Parent = this.subject;
            this.subject.Location = new System.Drawing.Point(126, 148);
            this.subject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subject.Name = "subject";
            this.subject.PasswordChar = '\0';
            this.subject.PlaceholderText = "";
            this.subject.SelectedText = "";
            this.subject.ShadowDecoration.Parent = this.subject;
            this.subject.Size = new System.Drawing.Size(626, 42);
            this.subject.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 34;
            this.label4.Text = "Subject :";
            // 
            // openFile
            // 
            this.openFile.FileName = "All Files";
            this.openFile.Filter = "All files (*.*)|*.*";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel1.Location = new System.Drawing.Point(720, 401);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(137, 32);
            this.linkLabel1.TabIndex = 35;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Upload File";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // setPath
            // 
            this.setPath.AutoSize = true;
            this.setPath.BackColor = System.Drawing.Color.Transparent;
            this.setPath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setPath.ForeColor = System.Drawing.Color.White;
            this.setPath.Location = new System.Drawing.Point(16, 403);
            this.setPath.Name = "setPath";
            this.setPath.Size = new System.Drawing.Size(20, 21);
            this.setPath.TabIndex = 36;
            this.setPath.Text = "d";
            this.setPath.Visible = false;
            // 
            // guna2Button3
            // 
            this.guna2Button3.Animated = true;
            this.guna2Button3.BorderRadius = 1;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.DisabledState.Parent = this.guna2Button3;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Location = new System.Drawing.Point(717, 607);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(162, 46);
            this.guna2Button3.TabIndex = 37;
            this.guna2Button3.Text = "Send";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // panelRecord
            // 
            this.panelRecord.BackColor = System.Drawing.Color.Transparent;
            this.panelRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRecord.Location = new System.Drawing.Point(0, 0);
            this.panelRecord.Name = "panelRecord";
            this.panelRecord.Size = new System.Drawing.Size(900, 70);
            this.panelRecord.TabIndex = 3;
            this.panelRecord.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(350, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(267, 30);
            this.label7.TabIndex = 40;
            this.label7.Text = "Welcome to Send Reports";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderThickness = 5;
            this.guna2Panel2.Controls.Add(this.panelLoader);
            this.guna2Panel2.Controls.Add(this.label5);
            this.guna2Panel2.Controls.Add(this.bodyMessage);
            this.guna2Panel2.Controls.Add(this.toEmail);
            this.guna2Panel2.Controls.Add(this.fromEmail);
            this.guna2Panel2.Controls.Add(this.setPath);
            this.guna2Panel2.Controls.Add(this.linkLabel1);
            this.guna2Panel2.Controls.Add(this.subject);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(2);
            this.guna2Panel2.Location = new System.Drawing.Point(12, 155);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(867, 442);
            this.guna2Panel2.TabIndex = 49;
            // 
            // panelLoader
            // 
            this.panelLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panelLoader.Controls.Add(this.guna2PictureBox2);
            this.panelLoader.Controls.Add(this.txt_loader);
            this.panelLoader.Location = new System.Drawing.Point(0, 0);
            this.panelLoader.Name = "panelLoader";
            this.panelLoader.Size = new System.Drawing.Size(867, 442);
            this.panelLoader.TabIndex = 42;
            this.panelLoader.Visible = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(311, 146);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(216, 202);
            this.guna2PictureBox2.TabIndex = 2;
            this.guna2PictureBox2.TabStop = false;
            // 
            // txt_loader
            // 
            this.txt_loader.AutoSize = true;
            this.txt_loader.BackColor = System.Drawing.Color.Transparent;
            this.txt_loader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loader.ForeColor = System.Drawing.Color.Black;
            this.txt_loader.Location = new System.Drawing.Point(371, 98);
            this.txt_loader.Name = "txt_loader";
            this.txt_loader.Size = new System.Drawing.Size(80, 25);
            this.txt_loader.TabIndex = 1;
            this.txt_loader.Text = "Loading";
            this.txt_loader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 41;
            this.label5.Text = "Message :";
            // 
            // bodyMessage
            // 
            this.bodyMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bodyMessage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bodyMessage.Location = new System.Drawing.Point(126, 198);
            this.bodyMessage.Name = "bodyMessage";
            this.bodyMessage.Size = new System.Drawing.Size(626, 188);
            this.bodyMessage.TabIndex = 40;
            this.bodyMessage.Text = "Type Your Message ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 30);
            this.label3.TabIndex = 50;
            this.label3.Text = "Message Content";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // makeRecord
            // 
            this.makeRecord.Animated = true;
            this.makeRecord.BorderRadius = 1;
            this.makeRecord.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.makeRecord.CheckedState.Parent = this.makeRecord;
            this.makeRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.makeRecord.CustomImages.Parent = this.makeRecord;
            this.makeRecord.DisabledState.Parent = this.makeRecord;
            this.makeRecord.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.makeRecord.ForeColor = System.Drawing.Color.White;
            this.makeRecord.HoverState.Parent = this.makeRecord;
            this.makeRecord.Location = new System.Drawing.Point(12, 607);
            this.makeRecord.Name = "makeRecord";
            this.makeRecord.ShadowDecoration.Parent = this.makeRecord;
            this.makeRecord.Size = new System.Drawing.Size(210, 46);
            this.makeRecord.TabIndex = 37;
            this.makeRecord.Text = "Open Record";
            this.makeRecord.Click += new System.EventHandler(this.makeRecord_Click);
            // 
            // closeRecord
            // 
            this.closeRecord.Animated = true;
            this.closeRecord.BorderRadius = 1;
            this.closeRecord.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.closeRecord.CheckedState.Parent = this.closeRecord;
            this.closeRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeRecord.CustomImages.Parent = this.closeRecord;
            this.closeRecord.DisabledState.Parent = this.closeRecord;
            this.closeRecord.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.closeRecord.ForeColor = System.Drawing.Color.White;
            this.closeRecord.HoverState.Parent = this.closeRecord;
            this.closeRecord.Location = new System.Drawing.Point(346, 607);
            this.closeRecord.Name = "closeRecord";
            this.closeRecord.ShadowDecoration.Parent = this.closeRecord;
            this.closeRecord.Size = new System.Drawing.Size(210, 46);
            this.closeRecord.TabIndex = 51;
            this.closeRecord.Text = "Close Record";
            this.closeRecord.Click += new System.EventHandler(this.closeRecord_Click);
            // 
            // checkRecord
            // 
            this.checkRecord.Animated = true;
            this.checkRecord.AutoSize = true;
            this.checkRecord.BackColor = System.Drawing.Color.Transparent;
            this.checkRecord.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkRecord.CheckedState.BorderRadius = 0;
            this.checkRecord.CheckedState.BorderThickness = 0;
            this.checkRecord.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.checkRecord.ForeColor = System.Drawing.Color.White;
            this.checkRecord.Location = new System.Drawing.Point(726, 102);
            this.checkRecord.Name = "checkRecord";
            this.checkRecord.Size = new System.Drawing.Size(152, 20);
            this.checkRecord.TabIndex = 53;
            this.checkRecord.Text = "ارسال بالتسجيل الصوتي   ";
            this.checkRecord.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkRecord.UncheckedState.BorderRadius = 0;
            this.checkRecord.UncheckedState.BorderThickness = 0;
            this.checkRecord.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkRecord.UseVisualStyleBackColor = false;
            this.checkRecord.CheckedChanged += new System.EventHandler(this.checkRecord_CheckedChanged);
            // 
            // support
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 661);
            this.Controls.Add(this.panelRecord);
            this.Controls.Add(this.checkRecord);
            this.Controls.Add(this.closeRecord);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.makeRecord);
            this.Controls.Add(this.guna2Button3);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "support";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Reports";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.support_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.panelLoader.ResumeLayout(false);
            this.panelLoader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox fromEmail;
        private Guna.UI2.WinForms.Guna2TextBox toEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox subject;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private System.Windows.Forms.Label setPath;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox bodyMessage;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Panel panelLoader;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label txt_loader;
        private Guna.UI2.WinForms.Guna2Button makeRecord;
        private Guna.UI2.WinForms.Guna2Button closeRecord;
        private System.Windows.Forms.Panel panelRecord;
        private Guna.UI2.WinForms.Guna2CheckBox checkRecord;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}