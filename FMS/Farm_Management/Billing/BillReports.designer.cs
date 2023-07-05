namespace FMS.Farm_Management.Billing
{
    partial class BillReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillReports));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolTip = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.batteryStatus = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.excelExporter = new Guna.UI2.WinForms.Guna2Button();
            this.Spec_Bill = new Guna.UI2.WinForms.Guna2Button();
            this.printing = new Guna.UI2.WinForms.Guna2Button();
            this.cheque_display = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.xuiBatteryPercentageAPI = new XanderUI.XUIBatteryPercentageAPI();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.saveExcel = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.datePanel = new System.Windows.Forms.Label();
            this.xuiClock1 = new XanderUI.XUIClock();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2GradientPanel4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.bottomPanelTables = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelLoader = new System.Windows.Forms.Panel();
            this.CloseWorker = new MaterialSkin.Controls.MaterialButton();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txt_loader = new System.Windows.Forms.Label();
            this.tableB = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.totalBills = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bill_type = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.connection = new System.Windows.Forms.NotifyIcon(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.guna2GradientPanel4.SuspendLayout();
            this.bottomPanelTables.SuspendLayout();
            this.panelLoader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableB)).BeginInit();
            this.guna2GradientPanel3.SuspendLayout();
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
            this.excelExporter.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
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
            this.excelExporter.Location = new System.Drawing.Point(9, 372);
            this.excelExporter.Name = "excelExporter";
            this.excelExporter.ShadowDecoration.Parent = this.excelExporter;
            this.excelExporter.Size = new System.Drawing.Size(168, 52);
            this.excelExporter.TabIndex = 46;
            this.excelExporter.Text = "تصدير لإكسيل";
            this.excelExporter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.excelExporter, "لإكسيل تصدير");
            this.excelExporter.UseTransparentBackground = true;
            this.excelExporter.Click += new System.EventHandler(this.guna2Button3_Click_2);
            // 
            // Spec_Bill
            // 
            this.Spec_Bill.BackColor = System.Drawing.Color.Transparent;
            this.Spec_Bill.BorderRadius = 24;
            this.Spec_Bill.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.Spec_Bill.CheckedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.Spec_Bill.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.Spec_Bill.CheckedState.ForeColor = System.Drawing.Color.White;
            this.Spec_Bill.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.Spec_Bill.CheckedState.Parent = this.Spec_Bill;
            this.Spec_Bill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Spec_Bill.CustomImages.Parent = this.Spec_Bill;
            this.Spec_Bill.DisabledState.Parent = this.Spec_Bill;
            this.Spec_Bill.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.Spec_Bill.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Spec_Bill.ForeColor = System.Drawing.Color.White;
            this.Spec_Bill.HoverState.Parent = this.Spec_Bill;
            this.Spec_Bill.Image = ((System.Drawing.Image)(resources.GetObject("Spec_Bill.Image")));
            this.Spec_Bill.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Spec_Bill.Location = new System.Drawing.Point(8, 479);
            this.Spec_Bill.Name = "Spec_Bill";
            this.Spec_Bill.ShadowDecoration.Parent = this.Spec_Bill;
            this.Spec_Bill.Size = new System.Drawing.Size(169, 52);
            this.Spec_Bill.TabIndex = 40;
            this.Spec_Bill.Text = "تحديد فواتير";
            this.Spec_Bill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.Spec_Bill, "طباعة");
            this.Spec_Bill.UseTransparentBackground = true;
            this.Spec_Bill.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // printing
            // 
            this.printing.BackColor = System.Drawing.Color.Transparent;
            this.printing.BorderRadius = 24;
            this.printing.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.printing.CheckedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.printing.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.printing.CheckedState.ForeColor = System.Drawing.Color.White;
            this.printing.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
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
            this.printing.Location = new System.Drawing.Point(8, 586);
            this.printing.Name = "printing";
            this.printing.ShadowDecoration.Parent = this.printing;
            this.printing.Size = new System.Drawing.Size(169, 52);
            this.printing.TabIndex = 39;
            this.printing.Text = "طباعة";
            this.printing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.printing, "طباعة");
            this.printing.UseTransparentBackground = true;
            this.printing.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // cheque_display
            // 
            this.cheque_display.BackColor = System.Drawing.Color.Transparent;
            this.cheque_display.BorderRadius = 24;
            this.cheque_display.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.cheque_display.CheckedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.cheque_display.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.cheque_display.CheckedState.ForeColor = System.Drawing.Color.White;
            this.cheque_display.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.cheque_display.CheckedState.Parent = this.cheque_display;
            this.cheque_display.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cheque_display.CustomImages.Parent = this.cheque_display;
            this.cheque_display.DisabledState.Parent = this.cheque_display;
            this.cheque_display.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cheque_display.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cheque_display.ForeColor = System.Drawing.Color.White;
            this.cheque_display.HoverState.Parent = this.cheque_display;
            this.cheque_display.Image = ((System.Drawing.Image)(resources.GetObject("cheque_display.Image")));
            this.cheque_display.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.cheque_display.Location = new System.Drawing.Point(8, 265);
            this.cheque_display.Name = "cheque_display";
            this.cheque_display.ShadowDecoration.Parent = this.cheque_display;
            this.cheque_display.Size = new System.Drawing.Size(168, 52);
            this.cheque_display.TabIndex = 37;
            this.cheque_display.Text = "عرض الجدول";
            this.cheque_display.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.cheque_display, "الجدول عرض");
            this.cheque_display.UseTransparentBackground = true;
            this.cheque_display.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 25;
            this.guna2Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button2.Checked = true;
            this.guna2Button2.CheckedState.BorderColor = System.Drawing.Color.White;
            this.guna2Button2.CheckedState.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.guna2Button2.CheckedState.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.DisabledState.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.Location = new System.Drawing.Point(8, 153);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(169, 60);
            this.guna2Button2.TabIndex = 35;
            this.guna2Button2.Text = "الرئيسية";
            this.guna2Button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTip.SetToolTip(this.guna2Button2, "الرئيسية");
            this.guna2Button2.UseTransparentBackground = true;
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
            this.panel1.Controls.Add(this.guna2GradientPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 697);
            this.panel1.TabIndex = 34;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 20;
            this.guna2GradientPanel1.Controls.Add(this.excelExporter);
            this.guna2GradientPanel1.Controls.Add(this.Spec_Bill);
            this.guna2GradientPanel1.Controls.Add(this.printing);
            this.guna2GradientPanel1.Controls.Add(this.cheque_display);
            this.guna2GradientPanel1.Controls.Add(this.pictureBox2);
            this.guna2GradientPanel1.Controls.Add(this.guna2Button2);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(12, 11);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(180, 656);
            this.guna2GradientPanel1.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(35, 10);
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
            this.guna2GradientPanel2.Controls.Add(this.label7);
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
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(364, 14);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(154, 31);
            this.label7.TabIndex = 44;
            this.label7.Text = "تقارير الفواتير";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.panel4.Location = new System.Drawing.Point(205, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1125, 8);
            this.panel4.TabIndex = 52;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(205, 689);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1125, 8);
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
            this.guna2GradientPanel4.Controls.Add(this.bottomPanelTables);
            this.guna2GradientPanel4.Controls.Add(this.guna2GradientPanel3);
            this.guna2GradientPanel4.Controls.Add(this.guna2GradientPanel2);
            this.guna2GradientPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel4.FillColor = System.Drawing.Color.LightBlue;
            this.guna2GradientPanel4.FillColor2 = System.Drawing.Color.LightBlue;
            this.guna2GradientPanel4.Location = new System.Drawing.Point(205, 8);
            this.guna2GradientPanel4.Name = "guna2GradientPanel4";
            this.guna2GradientPanel4.ShadowDecoration.Parent = this.guna2GradientPanel4;
            this.guna2GradientPanel4.Size = new System.Drawing.Size(1117, 681);
            this.guna2GradientPanel4.TabIndex = 41;
            // 
            // bottomPanelTables
            // 
            this.bottomPanelTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanelTables.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanelTables.BorderRadius = 20;
            this.bottomPanelTables.Controls.Add(this.panelLoader);
            this.bottomPanelTables.Controls.Add(this.tableB);
            this.bottomPanelTables.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bottomPanelTables.FillColor = System.Drawing.Color.White;
            this.bottomPanelTables.FillColor2 = System.Drawing.Color.White;
            this.bottomPanelTables.Location = new System.Drawing.Point(8, 242);
            this.bottomPanelTables.Name = "bottomPanelTables";
            this.bottomPanelTables.ShadowDecoration.Parent = this.bottomPanelTables;
            this.bottomPanelTables.Size = new System.Drawing.Size(1100, 433);
            this.bottomPanelTables.TabIndex = 45;
            // 
            // panelLoader
            // 
            this.panelLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.panelLoader.Controls.Add(this.CloseWorker);
            this.panelLoader.Controls.Add(this.guna2PictureBox2);
            this.panelLoader.Controls.Add(this.txt_loader);
            this.panelLoader.Location = new System.Drawing.Point(0, 0);
            this.panelLoader.Name = "panelLoader";
            this.panelLoader.Size = new System.Drawing.Size(1100, 433);
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
            this.CloseWorker.Location = new System.Drawing.Point(1056, 6);
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
            this.guna2PictureBox2.Location = new System.Drawing.Point(445, 124);
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
            this.txt_loader.Location = new System.Drawing.Point(508, 80);
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
            this.tableB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableB.RowHeadersVisible = false;
            this.tableB.RowTemplate.Height = 30;
            this.tableB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableB.Size = new System.Drawing.Size(1090, 406);
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
            this.tableB.ThemeStyle.ReadOnly = false;
            this.tableB.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tableB.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tableB.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.tableB.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tableB.ThemeStyle.RowsStyle.Height = 30;
            this.tableB.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Gainsboro;
            this.tableB.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tableB.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tableB_DataError);
            this.tableB.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tableB_RowsAdded);
            this.tableB.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.tableB_RowsRemoved);
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel3.BorderRadius = 20;
            this.guna2GradientPanel3.Controls.Add(this.label3);
            this.guna2GradientPanel3.Controls.Add(this.totalBills);
            this.guna2GradientPanel3.Controls.Add(this.label1);
            this.guna2GradientPanel3.Controls.Add(this.bill_type);
            this.guna2GradientPanel3.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel3.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel3.Location = new System.Drawing.Point(20, 127);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.ShadowDecoration.Parent = this.guna2GradientPanel3;
            this.guna2GradientPanel3.Size = new System.Drawing.Size(1080, 109);
            this.guna2GradientPanel3.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(283, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 28);
            this.label3.TabIndex = 31;
            this.label3.Text = "إجمالي الفواتير";
            // 
            // totalBills
            // 
            this.totalBills.Animated = true;
            this.totalBills.BorderRadius = 7;
            this.totalBills.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.totalBills.DefaultText = "0";
            this.totalBills.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.totalBills.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.totalBills.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.totalBills.DisabledState.Parent = this.totalBills;
            this.totalBills.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.totalBills.FillColor = System.Drawing.Color.LightBlue;
            this.totalBills.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.totalBills.FocusedState.Parent = this.totalBills;
            this.totalBills.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.totalBills.ForeColor = System.Drawing.Color.Black;
            this.totalBills.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.totalBills.HoverState.Parent = this.totalBills;
            this.totalBills.Location = new System.Drawing.Point(57, 29);
            this.totalBills.Margin = new System.Windows.Forms.Padding(6);
            this.totalBills.Name = "totalBills";
            this.totalBills.PasswordChar = '\0';
            this.totalBills.PlaceholderForeColor = System.Drawing.Color.Black;
            this.totalBills.PlaceholderText = "";
            this.totalBills.ReadOnly = true;
            this.totalBills.SelectedText = "";
            this.totalBills.SelectionStart = 1;
            this.totalBills.ShadowDecoration.Parent = this.totalBills;
            this.totalBills.Size = new System.Drawing.Size(206, 46);
            this.totalBills.TabIndex = 30;
            this.totalBills.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(929, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 28);
            this.label1.TabIndex = 29;
            this.label1.Text = "اختر نوع الفاتورة";
            // 
            // bill_type
            // 
            this.bill_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.bill_type.Animated = true;
            this.bill_type.BackColor = System.Drawing.Color.Transparent;
            this.bill_type.BorderRadius = 5;
            this.bill_type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bill_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bill_type.FillColor = System.Drawing.Color.LightBlue;
            this.bill_type.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bill_type.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bill_type.FocusedState.Parent = this.bill_type;
            this.bill_type.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bill_type.ForeColor = System.Drawing.Color.Black;
            this.bill_type.HoverState.Parent = this.bill_type;
            this.bill_type.IntegralHeight = false;
            this.bill_type.ItemHeight = 40;
            this.bill_type.Items.AddRange(new object[] {
            "فواتير البضائع",
            "فواتير الحيوانات البرية",
            "فواتير الأدوية"});
            this.bill_type.ItemsAppearance.Parent = this.bill_type;
            this.bill_type.Location = new System.Drawing.Point(609, 29);
            this.bill_type.Name = "bill_type";
            this.bill_type.ShadowDecoration.Parent = this.bill_type;
            this.bill_type.Size = new System.Drawing.Size(287, 46);
            this.bill_type.TabIndex = 28;
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
            // BillReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(1330, 697);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillReports";
            this.helpProvider.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقارير الفواتير";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BillReports_FormClosed);
            this.Load += new System.EventHandler(this.employees_mangement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BillReports_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.guna2GradientPanel4.ResumeLayout(false);
            this.bottomPanelTables.ResumeLayout(false);
            this.panelLoader.ResumeLayout(false);
            this.panelLoader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableB)).EndInit();
            this.guna2GradientPanel3.ResumeLayout(false);
            this.guna2GradientPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
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
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button printing;
        private Guna.UI2.WinForms.Guna2Button cheque_display;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel4;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private Guna.UI2.WinForms.Guna2ComboBox bill_type;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox totalBills;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button Spec_Bill;
        private Guna.UI2.WinForms.Guna2Button excelExporter;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2GradientPanel bottomPanelTables;
        private System.Windows.Forms.Panel panelLoader;
        private MaterialSkin.Controls.MaterialButton CloseWorker;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label txt_loader;
        private Guna.UI2.WinForms.Guna2DataGridView tableB;
        private System.Windows.Forms.NotifyIcon connection;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}