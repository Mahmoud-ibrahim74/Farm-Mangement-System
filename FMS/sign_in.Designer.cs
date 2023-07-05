namespace FMS
{
    partial class sign_in
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sign_in));
            this.BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panelRight = new System.Windows.Forms.Panel();
            this.CloseFrm = new Guna.UI2.WinForms.Guna2Button();
            this.userType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.username = new Guna.UI2.WinForms.Guna2TextBox();
            this.remeberMe = new MaterialSkin.Controls.MaterialCheckbox();
            this.logo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.loader = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.gotoLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2ToggleSwitch1 = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label4 = new System.Windows.Forms.Label();
            this.password = new Guna.UI2.WinForms.Guna2TextBox();
            this.connection = new System.Windows.Forms.NotifyIcon(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderlessForm
            // 
            this.BorderlessForm.AnimateWindow = true;
            this.BorderlessForm.AnimationInterval = 100;
            this.BorderlessForm.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.BorderlessForm.BorderRadius = 20;
            this.BorderlessForm.ContainerControl = this;
            this.BorderlessForm.ResizeForm = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.userType);
            this.panelRight.Controls.Add(this.username);
            this.panelRight.Controls.Add(this.remeberMe);
            this.panelRight.Controls.Add(this.gotoLogin);
            this.panelRight.Controls.Add(this.guna2ToggleSwitch1);
            this.panelRight.Controls.Add(this.password);
            this.panelRight.Location = new System.Drawing.Point(0, 168);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(626, 356);
            this.panelRight.TabIndex = 2;
            // 
            // CloseFrm
            // 
            this.CloseFrm.Animated = true;
            this.CloseFrm.AutoRoundedCorners = true;
            this.CloseFrm.BorderRadius = 12;
            this.CloseFrm.CheckedState.Parent = this.CloseFrm;
            this.CloseFrm.CustomImages.Parent = this.CloseFrm;
            this.CloseFrm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloseFrm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloseFrm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloseFrm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloseFrm.DisabledState.Parent = this.CloseFrm;
            this.CloseFrm.FillColor = System.Drawing.Color.Transparent;
            this.CloseFrm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseFrm.ForeColor = System.Drawing.Color.Black;
            this.CloseFrm.HoverState.Parent = this.CloseFrm;
            this.CloseFrm.Location = new System.Drawing.Point(589, 5);
            this.CloseFrm.Name = "CloseFrm";
            this.CloseFrm.ShadowDecoration.Parent = this.CloseFrm;
            this.CloseFrm.Size = new System.Drawing.Size(30, 26);
            this.CloseFrm.TabIndex = 73;
            this.CloseFrm.Text = "X";
            this.CloseFrm.Click += new System.EventHandler(this.CloseFrm_Click);
            // 
            // userType
            // 
            this.userType.BackColor = System.Drawing.Color.Transparent;
            this.userType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.userType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.userType.FocusedState.Parent = this.userType;
            this.userType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.userType.ForeColor = System.Drawing.Color.Gray;
            this.userType.HoverState.Parent = this.userType;
            this.userType.ItemHeight = 40;
            this.userType.Items.AddRange(new object[] {
            "Select User Type",
            "Admin",
            "Employee"});
            this.userType.ItemsAppearance.Parent = this.userType;
            this.userType.Location = new System.Drawing.Point(107, 14);
            this.userType.Name = "userType";
            this.userType.ShadowDecoration.Parent = this.userType;
            this.userType.Size = new System.Drawing.Size(413, 46);
            this.userType.StartIndex = 0;
            this.userType.TabIndex = 72;
            this.userType.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // username
            // 
            this.username.Animated = true;
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.DefaultText = "";
            this.username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.DisabledState.Parent = this.username;
            this.username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.username.FocusedState.Parent = this.username;
            this.username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.username.HoverState.Parent = this.username;
            this.username.IconLeft = ((System.Drawing.Image)(resources.GetObject("username.IconLeft")));
            this.username.Location = new System.Drawing.Point(107, 97);
            this.username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.username.PlaceholderText = "Username";
            this.username.SelectedText = "";
            this.username.ShadowDecoration.Parent = this.username;
            this.username.Size = new System.Drawing.Size(413, 46);
            this.username.TabIndex = 71;
            this.username.TextOffset = new System.Drawing.Point(15, 0);
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // remeberMe
            // 
            this.remeberMe.AutoSize = true;
            this.remeberMe.Depth = 0;
            this.remeberMe.Location = new System.Drawing.Point(107, 234);
            this.remeberMe.Margin = new System.Windows.Forms.Padding(0);
            this.remeberMe.MouseLocation = new System.Drawing.Point(-1, -1);
            this.remeberMe.MouseState = MaterialSkin.MouseState.HOVER;
            this.remeberMe.Name = "remeberMe";
            this.remeberMe.Ripple = true;
            this.remeberMe.Size = new System.Drawing.Size(123, 37);
            this.remeberMe.TabIndex = 69;
            this.remeberMe.Text = "Remeber Me";
            this.remeberMe.UseVisualStyleBackColor = true;
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.ImageRotate = 0F;
            this.logo.Location = new System.Drawing.Point(7, 42);
            this.logo.Name = "logo";
            this.logo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.logo.ShadowDecoration.Parent = this.logo;
            this.logo.Size = new System.Drawing.Size(119, 115);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 66;
            this.logo.TabStop = false;
            // 
            // loader
            // 
            this.loader.AnimationSpeed = 90;
            this.loader.AutoStart = true;
            this.loader.BackColor = System.Drawing.Color.Transparent;
            this.loader.Location = new System.Drawing.Point(228, 5);
            this.loader.Name = "loader";
            this.loader.ProgressColor = System.Drawing.Color.SteelBlue;
            this.loader.ShadowDecoration.Parent = this.loader;
            this.loader.Size = new System.Drawing.Size(168, 157);
            this.loader.TabIndex = 65;
            this.loader.Visible = false;
            // 
            // gotoLogin
            // 
            this.gotoLogin.Animated = true;
            this.gotoLogin.AutoRoundedCorners = true;
            this.gotoLogin.BorderRadius = 29;
            this.gotoLogin.CheckedState.Parent = this.gotoLogin;
            this.gotoLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gotoLogin.CustomImages.Parent = this.gotoLogin;
            this.gotoLogin.DisabledState.Parent = this.gotoLogin;
            this.gotoLogin.FillColor = System.Drawing.Color.SteelBlue;
            this.gotoLogin.FillColor2 = System.Drawing.Color.SteelBlue;
            this.gotoLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gotoLogin.ForeColor = System.Drawing.Color.White;
            this.gotoLogin.HoverState.FillColor = System.Drawing.Color.SlateBlue;
            this.gotoLogin.HoverState.FillColor2 = System.Drawing.Color.SlateBlue;
            this.gotoLogin.HoverState.ForeColor = System.Drawing.Color.White;
            this.gotoLogin.HoverState.Parent = this.gotoLogin;
            this.gotoLogin.Image = ((System.Drawing.Image)(resources.GetObject("gotoLogin.Image")));
            this.gotoLogin.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gotoLogin.Location = new System.Drawing.Point(140, 288);
            this.gotoLogin.Name = "gotoLogin";
            this.gotoLogin.ShadowDecoration.Parent = this.gotoLogin;
            this.gotoLogin.Size = new System.Drawing.Size(337, 60);
            this.gotoLogin.TabIndex = 60;
            this.gotoLogin.Text = "Login";
            this.gotoLogin.Click += new System.EventHandler(this.gotoLogin_Click);
            // 
            // guna2ToggleSwitch1
            // 
            this.guna2ToggleSwitch1.Animated = true;
            this.guna2ToggleSwitch1.BackColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.CheckedState.Parent = this.guna2ToggleSwitch1;
            this.guna2ToggleSwitch1.Location = new System.Drawing.Point(475, 193);
            this.guna2ToggleSwitch1.Name = "guna2ToggleSwitch1";
            this.guna2ToggleSwitch1.ShadowDecoration.Parent = this.guna2ToggleSwitch1;
            this.guna2ToggleSwitch1.Size = new System.Drawing.Size(35, 20);
            this.guna2ToggleSwitch1.TabIndex = 6;
            this.guna2ToggleSwitch1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch1.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.UncheckedState.Parent = this.guna2ToggleSwitch1;
            this.guna2ToggleSwitch1.CheckedChanged += new System.EventHandler(this.guna2ToggleSwitch1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 37);
            this.label4.TabIndex = 1;
            this.label4.Text = "Login Form";
            // 
            // password
            // 
            this.password.Animated = true;
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.DefaultText = "";
            this.password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.DisabledState.Parent = this.password;
            this.password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password.FocusedState.Parent = this.password;
            this.password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password.HoverState.Parent = this.password;
            this.password.IconLeft = ((System.Drawing.Image)(resources.GetObject("password.IconLeft")));
            this.password.Location = new System.Drawing.Point(107, 180);
            this.password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.password.Name = "password";
            this.password.PasswordChar = '●';
            this.password.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.password.PlaceholderText = "Password";
            this.password.SelectedText = "";
            this.password.ShadowDecoration.Parent = this.password;
            this.password.Size = new System.Drawing.Size(413, 46);
            this.password.TabIndex = 71;
            this.password.TextOffset = new System.Drawing.Point(15, 0);
            this.password.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // connection
            // 
            this.connection.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.connection.Icon = ((System.Drawing.Icon)(resources.GetObject("connection.Icon")));
            this.connection.Text = "Connection State";
            this.connection.Visible = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // sign_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(626, 528);
            this.Controls.Add(this.CloseFrm);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.loader);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "sign_in";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGN IN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.sign_in_FormClosed);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm BorderlessForm;
        private System.Windows.Forms.Panel panelRight;
        private Guna.UI2.WinForms.Guna2GradientButton gotoLogin;
        private Guna.UI2.WinForms.Guna2ToggleSwitch guna2ToggleSwitch1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon connection;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private Guna.UI2.WinForms.Guna2CirclePictureBox logo;
        private MaterialSkin.Controls.MaterialCheckbox remeberMe;
        private Guna.UI2.WinForms.Guna2ProgressIndicator loader;
        private Guna.UI2.WinForms.Guna2TextBox username;
        private Guna.UI2.WinForms.Guna2TextBox password;
        private Guna.UI2.WinForms.Guna2ComboBox userType;
        private Guna.UI2.WinForms.Guna2Button CloseFrm;
    }
}