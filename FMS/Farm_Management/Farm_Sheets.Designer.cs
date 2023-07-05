namespace FMS.Farm_Management
{
    partial class Farm_Sheets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Farm_Sheets));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolTip = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.printing = new Guna.UI2.WinForms.Guna2Button();
            this.batteryStatus = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.excelExporter = new Guna.UI2.WinForms.Guna2Button();
            this.confirm = new Guna.UI2.WinForms.Guna2Button();
            this.xuiBatteryPercentageAPI = new XanderUI.XUIBatteryPercentageAPI();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.saveExcel = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSlider = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.Report_List = new Guna.UI2.WinForms.Guna2ComboBox();
            this.search = new Guna.UI2.WinForms.Guna2TextBox();
            this.resetData = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.datePanel = new System.Windows.Forms.Label();
            this.xuiClock1 = new XanderUI.XUIClock();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2GradientPanel4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.confirmPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.closeConPanel = new System.Windows.Forms.Button();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.confirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.bottomPanelTables = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelLoader = new System.Windows.Forms.Panel();
            this.CloseWorker = new MaterialSkin.Controls.MaterialButton();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txt_loader = new System.Windows.Forms.Label();
            this.tableB = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.connection = new System.Windows.Forms.NotifyIcon(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            this.panelSlider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.guna2GradientPanel4.SuspendLayout();
            this.confirmPanel.SuspendLayout();
            this.bottomPanelTables.SuspendLayout();
            this.panelLoader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableB)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolTip
            // 
            this.ToolTip.AllowLinksHandling = true;
            this.ToolTip.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // printing
            // 
            this.printing.BackColor = System.Drawing.Color.Transparent;
            this.printing.BorderRadius = 24;
            this.printing.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.printing.CheckedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.printing.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.printing.CheckedState.ForeColor = System.Drawing.Color.White;
            this.printing.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.printing.CheckedState.Parent = this.printing;
            this.printing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printing.CustomImages.Parent = this.printing;
            this.printing.DisabledState.Parent = this.printing;
            this.printing.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.printing.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.printing.ForeColor = System.Drawing.Color.White;
            this.printing.HoverState.Parent = this.printing;
            this.printing.Image = ((System.Drawing.Image)(resources.GetObject("printing.Image")));
            this.printing.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.printing.Location = new System.Drawing.Point(8, 487);
            this.printing.Name = "printing";
            this.printing.ShadowDecoration.Parent = this.printing;
            this.printing.Size = new System.Drawing.Size(217, 52);
            this.printing.TabIndex = 39;
            this.printing.Text = "طباعة";
            this.ToolTip.SetToolTip(this.printing, "طباعة");
            this.printing.UseTransparentBackground = true;
            this.printing.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // batteryStatus
            // 
            this.batteryStatus.AnimationSpeed = 0.9F;
            this.batteryStatus.BackColor = System.Drawing.Color.Transparent;
            this.batteryStatus.FillColor = System.Drawing.Color.RoyalBlue;
            this.batteryStatus.FillOffset = 20;
            this.batteryStatus.FillThickness = 10;
            this.batteryStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batteryStatus.ForeColor = System.Drawing.Color.Black;
            this.batteryStatus.Location = new System.Drawing.Point(36, 7);
            this.batteryStatus.Minimum = 0;
            this.batteryStatus.Name = "batteryStatus";
            this.batteryStatus.ProgressColor = System.Drawing.Color.Crimson;
            this.batteryStatus.ProgressColor2 = System.Drawing.Color.SkyBlue;
            this.batteryStatus.ProgressThickness = 10;
            this.batteryStatus.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.batteryStatus.ShadowDecoration.Parent = this.batteryStatus;
            this.batteryStatus.ShowPercentage = true;
            this.batteryStatus.Size = new System.Drawing.Size(94, 94);
            this.batteryStatus.TabIndex = 2;
            this.ToolTip.SetToolTip(this.batteryStatus, "Battery Status");
            // 
            // excelExporter
            // 
            this.excelExporter.BackColor = System.Drawing.Color.Transparent;
            this.excelExporter.BorderRadius = 24;
            this.excelExporter.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.excelExporter.CheckedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.excelExporter.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.excelExporter.CheckedState.ForeColor = System.Drawing.Color.White;
            this.excelExporter.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.excelExporter.CheckedState.Parent = this.excelExporter;
            this.excelExporter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.excelExporter.CustomImages.Parent = this.excelExporter;
            this.excelExporter.DisabledState.Parent = this.excelExporter;
            this.excelExporter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.excelExporter.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.excelExporter.ForeColor = System.Drawing.Color.White;
            this.excelExporter.HoverState.Parent = this.excelExporter;
            this.excelExporter.Image = ((System.Drawing.Image)(resources.GetObject("excelExporter.Image")));
            this.excelExporter.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.excelExporter.Location = new System.Drawing.Point(8, 394);
            this.excelExporter.Name = "excelExporter";
            this.excelExporter.ShadowDecoration.Parent = this.excelExporter;
            this.excelExporter.Size = new System.Drawing.Size(217, 52);
            this.excelExporter.TabIndex = 46;
            this.excelExporter.Text = "تصدير لإكسيل";
            this.ToolTip.SetToolTip(this.excelExporter, "لإكسيل تصدير");
            this.excelExporter.UseTransparentBackground = true;
            this.excelExporter.Click += new System.EventHandler(this.guna2Button3_Click_2);
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.Transparent;
            this.confirm.BorderRadius = 24;
            this.confirm.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.confirm.CheckedState.BorderColor = System.Drawing.Color.White;
            this.confirm.CheckedState.FillColor = System.Drawing.Color.Purple;
            this.confirm.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.confirm.CheckedState.Parent = this.confirm;
            this.confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirm.CustomImages.Parent = this.confirm;
            this.confirm.DisabledState.Parent = this.confirm;
            this.confirm.Enabled = false;
            this.confirm.FillColor = System.Drawing.Color.White;
            this.confirm.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.confirm.ForeColor = System.Drawing.Color.Black;
            this.confirm.HoverState.Parent = this.confirm;
            this.confirm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.confirm.Location = new System.Drawing.Point(88, 198);
            this.confirm.Name = "confirm";
            this.confirm.ShadowDecoration.Parent = this.confirm;
            this.confirm.Size = new System.Drawing.Size(217, 52);
            this.confirm.TabIndex = 49;
            this.confirm.Text = "تأكيد";
            this.ToolTip.SetToolTip(this.confirm, "تاكيد كلمة المرور");
            this.confirm.UseTransparentBackground = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // xuiBatteryPercentageAPI
            // 
            this.xuiBatteryPercentageAPI.Enabled = true;
            this.xuiBatteryPercentageAPI.Interval = 3000;
            this.xuiBatteryPercentageAPI.Tick += new System.EventHandler(this.xuiBatteryPercentageAPI_Tick);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // saveExcel
            // 
            this.saveExcel.FileName = "Sheet(1)";
            this.saveExcel.Filter = "Excel files (*.xlsx)|*.xlsx;";
            this.saveExcel.Title = "Save As Excel File";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.panelSlider);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 697);
            this.panel1.TabIndex = 34;
            // 
            // panelSlider
            // 
            this.panelSlider.BorderRadius = 20;
            this.panelSlider.Controls.Add(this.Report_List);
            this.panelSlider.Controls.Add(this.search);
            this.panelSlider.Controls.Add(this.resetData);
            this.panelSlider.Controls.Add(this.excelExporter);
            this.panelSlider.Controls.Add(this.printing);
            this.panelSlider.Controls.Add(this.pictureBox2);
            this.panelSlider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.panelSlider.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.panelSlider.Location = new System.Drawing.Point(0, 11);
            this.panelSlider.Name = "panelSlider";
            this.panelSlider.ShadowDecoration.Parent = this.panelSlider;
            this.panelSlider.Size = new System.Drawing.Size(228, 656);
            this.panelSlider.TabIndex = 4;
            // 
            // Report_List
            // 
            this.Report_List.BackColor = System.Drawing.Color.Transparent;
            this.Report_List.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Report_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Report_List.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.Report_List.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Report_List.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Report_List.FocusedState.Parent = this.Report_List;
            this.Report_List.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Report_List.ForeColor = System.Drawing.Color.White;
            this.Report_List.HoverState.Parent = this.Report_List;
            this.Report_List.IntegralHeight = false;
            this.Report_List.ItemHeight = 35;
            this.Report_List.Items.AddRange(new object[] {
            "اختر التقرير",
            "بيان بالحيوانات الموجودة بالمزرعة",
            "بيان بمشتريات الحيوانات",
            "بيانات بمبيعات الحيوانات",
            "بيانات بشراء الأدوية",
            "بيان بصرف الأدوية",
            "بيان بمشتريات البضاعة",
            "بيان بصرف البضاعة",
            "بيان بتوريد الخزينة",
            "بيان بصرف الخزينة",
            "بيان بتوريد الشيكات",
            "بيان بصرف الشيكات"});
            this.Report_List.ItemsAppearance.Parent = this.Report_List;
            this.Report_List.Location = new System.Drawing.Point(3, 132);
            this.Report_List.Name = "Report_List";
            this.Report_List.ShadowDecoration.Parent = this.Report_List;
            this.Report_List.Size = new System.Drawing.Size(222, 41);
            this.Report_List.StartIndex = 0;
            this.Report_List.TabIndex = 48;
            this.Report_List.TextOffset = new System.Drawing.Point(10, 0);
            this.Report_List.SelectedIndexChanged += new System.EventHandler(this.Report_List_SelectedIndexChanged);
            // 
            // search
            // 
            this.search.Animated = true;
            this.search.BorderRadius = 10;
            this.search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search.DefaultText = "";
            this.search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.DisabledState.Parent = this.search;
            this.search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.FocusedState.Parent = this.search;
            this.search.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.HoverState.Parent = this.search;
            this.search.IconLeft = ((System.Drawing.Image)(resources.GetObject("search.IconLeft")));
            this.search.Location = new System.Drawing.Point(8, 295);
            this.search.Name = "search";
            this.search.PasswordChar = '\0';
            this.search.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.search.PlaceholderText = "search with ID";
            this.search.SelectedText = "";
            this.search.ShadowDecoration.Parent = this.search;
            this.search.Size = new System.Drawing.Size(217, 48);
            this.search.TabIndex = 47;
            this.search.TextOffset = new System.Drawing.Point(10, 0);
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // resetData
            // 
            this.resetData.BackColor = System.Drawing.Color.Transparent;
            this.resetData.BorderRadius = 24;
            this.resetData.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.resetData.CheckedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.resetData.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.resetData.CheckedState.ForeColor = System.Drawing.Color.White;
            this.resetData.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.resetData.CheckedState.Parent = this.resetData;
            this.resetData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetData.CustomImages.Parent = this.resetData;
            this.resetData.DisabledState.Parent = this.resetData;
            this.resetData.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.resetData.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.resetData.ForeColor = System.Drawing.Color.White;
            this.resetData.HoverState.Parent = this.resetData;
            this.resetData.Image = ((System.Drawing.Image)(resources.GetObject("resetData.Image")));
            this.resetData.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.resetData.Location = new System.Drawing.Point(8, 573);
            this.resetData.Name = "resetData";
            this.resetData.ShadowDecoration.Parent = this.resetData;
            this.resetData.Size = new System.Drawing.Size(217, 52);
            this.resetData.TabIndex = 46;
            this.resetData.Text = "محو جميع البيانات";
            this.resetData.UseTransparentBackground = true;
            this.resetData.Click += new System.EventHandler(this.resetData_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(59, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(103, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel2.BorderRadius = 20;
            this.guna2GradientPanel2.Controls.Add(this.label2);
            this.guna2GradientPanel2.Controls.Add(this.guna2Separator1);
            this.guna2GradientPanel2.Controls.Add(this.datePanel);
            this.guna2GradientPanel2.Controls.Add(this.xuiClock1);
            this.guna2GradientPanel2.Controls.Add(this.batteryStatus);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(106, 13);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.ShadowDecoration.Parent = this.guna2GradientPanel2;
            this.guna2GradientPanel2.Size = new System.Drawing.Size(868, 104);
            this.guna2GradientPanel2.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(372, 17);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(130, 30);
            this.label2.TabIndex = 45;
            this.label2.Text = "تقارير المزرعة";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator1.FillColor = System.Drawing.Color.Black;
            this.guna2Separator1.Location = new System.Drawing.Point(331, 53);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(200, 10);
            this.guna2Separator1.TabIndex = 43;
            // 
            // datePanel
            // 
            this.datePanel.AutoSize = true;
            this.datePanel.BackColor = System.Drawing.Color.Transparent;
            this.datePanel.Font = new System.Drawing.Font("Impact", 14.25F);
            this.datePanel.ForeColor = System.Drawing.Color.Black;
            this.datePanel.Location = new System.Drawing.Point(343, 71);
            this.datePanel.Name = "datePanel";
            this.datePanel.Size = new System.Drawing.Size(46, 23);
            this.datePanel.TabIndex = 41;
            this.datePanel.Text = "date";
            // 
            // xuiClock1
            // 
            this.xuiClock1.BackColor = System.Drawing.Color.White;
            this.xuiClock1.CircleThickness = 6;
            this.xuiClock1.DisplayFormat = XanderUI.XUIClock.HourFormat.TwelveHour;
            this.xuiClock1.FilledHourColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(190)))), ((int)(((byte)(155)))));
            this.xuiClock1.FilledMinuteColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.xuiClock1.FilledSecondColor = System.Drawing.Color.DarkOrchid;
            this.xuiClock1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuiClock1.HexagonColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.xuiClock1.Location = new System.Drawing.Point(703, 7);
            this.xuiClock1.Name = "xuiClock1";
            this.xuiClock1.ShowAmPm = true;
            this.xuiClock1.ShowHexagon = true;
            this.xuiClock1.ShowMinutesCircle = true;
            this.xuiClock1.ShowSecondsCircle = true;
            this.xuiClock1.Size = new System.Drawing.Size(151, 85);
            this.xuiClock1.TabIndex = 3;
            this.xuiClock1.Text = "xuiClock1";
            this.xuiClock1.UnfilledHourColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.xuiClock1.UnfilledMinuteColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.xuiClock1.UnfilledSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(231, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1099, 8);
            this.panel4.TabIndex = 52;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(231, 689);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1099, 8);
            this.panel5.TabIndex = 53;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.panel2.Controls.Add(this.guna2GradientPanel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1330, 697);
            this.panel2.TabIndex = 2;
            // 
            // guna2GradientPanel4
            // 
            this.guna2GradientPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.guna2GradientPanel4.BorderRadius = 20;
            this.guna2GradientPanel4.Controls.Add(this.confirmPanel);
            this.guna2GradientPanel4.Controls.Add(this.bottomPanelTables);
            this.guna2GradientPanel4.Controls.Add(this.guna2GradientPanel2);
            this.guna2GradientPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel4.FillColor = System.Drawing.Color.LightBlue;
            this.guna2GradientPanel4.FillColor2 = System.Drawing.Color.LightBlue;
            this.guna2GradientPanel4.Location = new System.Drawing.Point(231, 8);
            this.guna2GradientPanel4.Name = "guna2GradientPanel4";
            this.guna2GradientPanel4.ShadowDecoration.Parent = this.guna2GradientPanel4;
            this.guna2GradientPanel4.Size = new System.Drawing.Size(1091, 681);
            this.guna2GradientPanel4.TabIndex = 41;
            // 
            // confirmPanel
            // 
            this.confirmPanel.BackColor = System.Drawing.Color.White;
            this.confirmPanel.BorderRadius = 20;
            this.confirmPanel.Controls.Add(this.closeConPanel);
            this.confirmPanel.Controls.Add(this.lblConfirm);
            this.confirmPanel.Controls.Add(this.confirm);
            this.confirmPanel.Controls.Add(this.confirmPassword);
            this.confirmPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.confirmPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.confirmPanel.Location = new System.Drawing.Point(329, 256);
            this.confirmPanel.Name = "confirmPanel";
            this.confirmPanel.ShadowDecoration.Parent = this.confirmPanel;
            this.confirmPanel.Size = new System.Drawing.Size(381, 260);
            this.confirmPanel.TabIndex = 46;
            this.confirmPanel.Visible = false;
            // 
            // closeConPanel
            // 
            this.closeConPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.closeConPanel.FlatAppearance.BorderSize = 0;
            this.closeConPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeConPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeConPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeConPanel.Location = new System.Drawing.Point(336, 7);
            this.closeConPanel.Name = "closeConPanel";
            this.closeConPanel.Size = new System.Drawing.Size(36, 31);
            this.closeConPanel.TabIndex = 51;
            this.closeConPanel.Text = "X";
            this.closeConPanel.UseVisualStyleBackColor = false;
            this.closeConPanel.Click += new System.EventHandler(this.closeConPanel_Click);
            // 
            // lblConfirm
            // 
            this.lblConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblConfirm.ForeColor = System.Drawing.Color.White;
            this.lblConfirm.Location = new System.Drawing.Point(83, 36);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblConfirm.Size = new System.Drawing.Size(215, 60);
            this.lblConfirm.TabIndex = 50;
            this.lblConfirm.Text = "برجاء ادخال\r\n كلمة المرور لتأكيد الأمر";
            this.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirmPassword
            // 
            this.confirmPassword.Animated = true;
            this.confirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.confirmPassword.BorderRadius = 10;
            this.confirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.confirmPassword.DefaultText = "";
            this.confirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.confirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.confirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.confirmPassword.DisabledState.Parent = this.confirmPassword;
            this.confirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.confirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.confirmPassword.FocusedState.Parent = this.confirmPassword;
            this.confirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.confirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.confirmPassword.HoverState.Parent = this.confirmPassword;
            this.confirmPassword.Location = new System.Drawing.Point(50, 126);
            this.confirmPassword.Name = "confirmPassword";
            this.confirmPassword.PasswordChar = '●';
            this.confirmPassword.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.confirmPassword.PlaceholderText = "Password";
            this.confirmPassword.SelectedText = "";
            this.confirmPassword.ShadowDecoration.Parent = this.confirmPassword;
            this.confirmPassword.Size = new System.Drawing.Size(299, 48);
            this.confirmPassword.TabIndex = 48;
            this.confirmPassword.TextOffset = new System.Drawing.Point(10, 0);
            this.confirmPassword.TextChanged += new System.EventHandler(this.confirmPassword_TextChanged);
            // 
            // bottomPanelTables
            // 
            this.bottomPanelTables.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanelTables.BorderRadius = 20;
            this.bottomPanelTables.Controls.Add(this.panelLoader);
            this.bottomPanelTables.Controls.Add(this.tableB);
            this.bottomPanelTables.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bottomPanelTables.FillColor = System.Drawing.Color.White;
            this.bottomPanelTables.FillColor2 = System.Drawing.Color.White;
            this.bottomPanelTables.Location = new System.Drawing.Point(14, 135);
            this.bottomPanelTables.Name = "bottomPanelTables";
            this.bottomPanelTables.ShadowDecoration.Parent = this.bottomPanelTables;
            this.bottomPanelTables.Size = new System.Drawing.Size(1062, 524);
            this.bottomPanelTables.TabIndex = 46;
            // 
            // panelLoader
            // 
            this.panelLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panelLoader.Controls.Add(this.CloseWorker);
            this.panelLoader.Controls.Add(this.guna2PictureBox2);
            this.panelLoader.Controls.Add(this.txt_loader);
            this.panelLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoader.Location = new System.Drawing.Point(0, 0);
            this.panelLoader.Name = "panelLoader";
            this.panelLoader.Size = new System.Drawing.Size(1062, 524);
            this.panelLoader.TabIndex = 37;
            this.panelLoader.Visible = false;
            // 
            // CloseWorker
            // 
            this.CloseWorker.AutoSize = false;
            this.CloseWorker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CloseWorker.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CloseWorker.Depth = 0;
            this.CloseWorker.HighEmphasis = true;
            this.CloseWorker.Icon = null;
            this.CloseWorker.Location = new System.Drawing.Point(1018, 6);
            this.CloseWorker.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CloseWorker.MouseState = MaterialSkin.MouseState.HOVER;
            this.CloseWorker.Name = "CloseWorker";
            this.CloseWorker.Size = new System.Drawing.Size(40, 27);
            this.CloseWorker.TabIndex = 3;
            this.CloseWorker.Text = "X";
            this.CloseWorker.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CloseWorker.UseAccentColor = false;
            this.CloseWorker.UseVisualStyleBackColor = true;
            this.CloseWorker.Click += new System.EventHandler(this.CloseWorker_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(415, 174);
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
            this.txt_loader.Location = new System.Drawing.Point(458, 131);
            this.txt_loader.Name = "txt_loader";
            this.txt_loader.Size = new System.Drawing.Size(111, 25);
            this.txt_loader.TabIndex = 1;
            this.txt_loader.Text = "جاري التحميل";
            this.txt_loader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableB
            // 
            this.tableB.AllowUserToAddRows = false;
            this.tableB.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableB.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tableB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableB.BackgroundColor = System.Drawing.Color.White;
            this.tableB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableB.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tableB.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tableB.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableB.DefaultCellStyle = dataGridViewCellStyle3;
            this.tableB.EnableHeadersVisualStyles = false;
            this.tableB.GridColor = System.Drawing.Color.DimGray;
            this.tableB.Location = new System.Drawing.Point(3, 11);
            this.tableB.Name = "tableB";
            this.tableB.ReadOnly = true;
            this.tableB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableB.RowHeadersVisible = false;
            this.tableB.RowTemplate.Height = 30;
            this.tableB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tableB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableB.Size = new System.Drawing.Size(1046, 505);
            this.tableB.TabIndex = 38;
            this.tableB.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.tableB.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tableB.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tableB.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableB.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Gainsboro;
            this.tableB.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableB.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tableB.ThemeStyle.GridColor = System.Drawing.Color.DimGray;
            this.tableB.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableB.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tableB.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tableB.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tableB.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tableB.ThemeStyle.HeaderStyle.Height = 40;
            this.tableB.ThemeStyle.ReadOnly = true;
            this.tableB.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tableB.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tableB.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tableB.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tableB.ThemeStyle.RowsStyle.Height = 30;
            this.tableB.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Gainsboro;
            this.tableB.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tableB.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tableB_DataError);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1322, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 681);
            this.panel3.TabIndex = 54;
            // 
            // connection
            // 
            this.connection.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.connection.Icon = ((System.Drawing.Icon)(resources.GetObject("connection.Icon")));
            this.connection.Text = "Connection State";
            this.connection.Visible = true;
            // 
            // Farm_Sheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(1330, 697);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Farm_Sheets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقارير المزرعة";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Farm_Sheets_FormClosed);
            this.Load += new System.EventHandler(this.employees_mangement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Farm_Sheets_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panelSlider.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.guna2GradientPanel4.ResumeLayout(false);
            this.confirmPanel.ResumeLayout(false);
            this.confirmPanel.PerformLayout();
            this.bottomPanelTables.ResumeLayout(false);
            this.panelLoader.ResumeLayout(false);
            this.panelLoader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlToolTip ToolTip;
        private XanderUI.XUIBatteryPercentageAPI xuiBatteryPercentageAPI;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.SaveFileDialog saveExcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label datePanel;
        private XanderUI.XUIClock xuiClock1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar batteryStatus;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2GradientPanel panelSlider;
        private Guna.UI2.WinForms.Guna2Button printing;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel4;
        private Guna.UI2.WinForms.Guna2Button excelExporter;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GradientPanel bottomPanelTables;
        private System.Windows.Forms.Panel panelLoader;
        private MaterialSkin.Controls.MaterialButton CloseWorker;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label txt_loader;
        private Guna.UI2.WinForms.Guna2DataGridView tableB;
        private System.Windows.Forms.NotifyIcon connection;
        private Guna.UI2.WinForms.Guna2ComboBox Report_List;
        private System.Windows.Forms.HelpProvider helpProvider;
        private Guna.UI2.WinForms.Guna2Button resetData;
        private Guna.UI2.WinForms.Guna2GradientPanel confirmPanel;
        private Guna.UI2.WinForms.Guna2TextBox search;
        private System.Windows.Forms.Label lblConfirm;
        private Guna.UI2.WinForms.Guna2Button confirm;
        private Guna.UI2.WinForms.Guna2TextBox confirmPassword;
        private System.Windows.Forms.Button closeConPanel;
    }
}