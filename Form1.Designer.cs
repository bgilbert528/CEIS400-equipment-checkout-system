using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CEIS400_ECS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.mainTab = new System.Windows.Forms.TabPage();
            this.listViewEquipMain = new System.Windows.Forms.ListView();
            this.colEquip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToolStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOutDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewEmpsMain = new System.Windows.Forms.ListView();
            this.colEmpID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmpName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmpStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.pictureBoxBarcode = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.gbEquip = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lableEquipIDMain = new System.Windows.Forms.Label();
            this.textBoxEquipOutMain = new System.Windows.Forms.TextBox();
            this.textBoxEquipInMain = new System.Windows.Forms.TextBox();
            this.textBoxEquipStatusMain = new System.Windows.Forms.TextBox();
            this.textBoxEquipIdMain = new System.Windows.Forms.TextBox();
            this.gbCust = new System.Windows.Forms.GroupBox();
            this.textBoxEmpStatusMain = new System.Windows.Forms.TextBox();
            this.textBoxEmpNameMain = new System.Windows.Forms.TextBox();
            this.textBoxEmpIDMain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.invTab = new System.Windows.Forms.TabPage();
            this.groupBoxVehicle = new System.Windows.Forms.GroupBox();
            this.textBoxSN = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxMake = new System.Windows.Forms.TextBox();
            this.labelSN = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelMake = new System.Windows.Forms.Label();
            this.checkBoxVehicle = new System.Windows.Forms.CheckBox();
            this.groupBoxCert = new System.Windows.Forms.GroupBox();
            this.checkBoxCert = new System.Windows.Forms.CheckBox();
            this.groupBoxEQCal = new System.Windows.Forms.GroupBox();
            this.checkBoxCal = new System.Windows.Forms.CheckBox();
            this.dateTimePickerCalDue = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCalDate = new System.Windows.Forms.DateTimePicker();
            this.labelCalDue = new System.Windows.Forms.Label();
            this.labelCalDate = new System.Windows.Forms.Label();
            this.groupBoxEQIncluded = new System.Windows.Forms.GroupBox();
            this.checkBoxEQIncluded = new System.Windows.Forms.CheckBox();
            this.richTextBoxIncluded = new System.Windows.Forms.RichTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.buttonUpdateEQ = new System.Windows.Forms.Button();
            this.buttonAddEQ = new System.Windows.Forms.Button();
            this.buttonNewEQ = new System.Windows.Forms.Button();
            this.listViewCheckouts = new System.Windows.Forms.ListView();
            this.colEmpCO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateInCO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluDateOutCO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConditionCO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxInvDetails = new System.Windows.Forms.GroupBox();
            this.comboBoxEQStatus = new System.Windows.Forms.ComboBox();
            this.textBoxEQName = new System.Windows.Forms.TextBox();
            this.textBoxEQID = new System.Windows.Forms.TextBox();
            this.richTextBoxRemarks = new System.Windows.Forms.RichTextBox();
            this.labelEQRemarks = new System.Windows.Forms.Label();
            this.labelEQStatus = new System.Windows.Forms.Label();
            this.labelEQName = new System.Windows.Forms.Label();
            this.labelEQID = new System.Windows.Forms.Label();
            this.listBoxInventory = new System.Windows.Forms.ListBox();
            this.usersTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.reportsTab = new System.Windows.Forms.TabPage();
            this.richTextBoxReports = new System.Windows.Forms.RichTextBox();
            this.labelReports = new System.Windows.Forms.Label();
            this.comboBoxReports = new System.Windows.Forms.ComboBox();
            this.adminTab = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basicToolsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.gbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarcode)).BeginInit();
            this.gbEquip.SuspendLayout();
            this.gbCust.SuspendLayout();
            this.invTab.SuspendLayout();
            this.groupBoxVehicle.SuspendLayout();
            this.groupBoxCert.SuspendLayout();
            this.groupBoxEQCal.SuspendLayout();
            this.groupBoxEQIncluded.SuspendLayout();
            this.groupBoxInvDetails.SuspendLayout();
            this.usersTab.SuspendLayout();
            this.reportsTab.SuspendLayout();
            this.adminTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicToolsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.tabControlMain);
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(986, 562);
            this.flowLayoutPanelMain.TabIndex = 0;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlMain.Controls.Add(this.mainTab);
            this.tabControlMain.Controls.Add(this.invTab);
            this.tabControlMain.Controls.Add(this.usersTab);
            this.tabControlMain.Controls.Add(this.reportsTab);
            this.tabControlMain.Controls.Add(this.adminTab);
            this.tabControlMain.Location = new System.Drawing.Point(3, 2);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(983, 559);
            this.tabControlMain.TabIndex = 0;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.listViewEquipMain);
            this.mainTab.Controls.Add(this.listViewEmpsMain);
            this.mainTab.Controls.Add(this.gbControls);
            this.mainTab.Controls.Add(this.gbEquip);
            this.mainTab.Controls.Add(this.gbCust);
            this.mainTab.Location = new System.Drawing.Point(25, 4);
            this.mainTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainTab.Size = new System.Drawing.Size(954, 551);
            this.mainTab.TabIndex = 0;
            this.mainTab.Text = "Main";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // listViewEquipMain
            // 
            this.listViewEquipMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEquip,
            this.colToolStatus,
            this.colInDate,
            this.colOutDate,
            this.colRemarks});
            this.listViewEquipMain.FullRowSelect = true;
            this.listViewEquipMain.GridLines = true;
            this.listViewEquipMain.HideSelection = false;
            this.listViewEquipMain.Location = new System.Drawing.Point(345, 261);
            this.listViewEquipMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewEquipMain.Name = "listViewEquipMain";
            this.listViewEquipMain.Size = new System.Drawing.Size(598, 288);
            this.listViewEquipMain.TabIndex = 4;
            this.listViewEquipMain.UseCompatibleStateImageBehavior = false;
            this.listViewEquipMain.View = System.Windows.Forms.View.Details;
            this.listViewEquipMain.SelectedIndexChanged += new System.EventHandler(this.listViewEquipMain_SelectedIndexChanged);
            // 
            // colEquip
            // 
            this.colEquip.Text = "Equip";
            this.colEquip.Width = 80;
            // 
            // colToolStatus
            // 
            this.colToolStatus.Text = "Status";
            this.colToolStatus.Width = 80;
            // 
            // colInDate
            // 
            this.colInDate.Text = "In Date";
            this.colInDate.Width = 80;
            // 
            // colOutDate
            // 
            this.colOutDate.Text = "Out Date";
            this.colOutDate.Width = 80;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 200;
            // 
            // listViewEmpsMain
            // 
            this.listViewEmpsMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmpID,
            this.colEmpName,
            this.colEmpStatus});
            this.listViewEmpsMain.FullRowSelect = true;
            this.listViewEmpsMain.GridLines = true;
            this.listViewEmpsMain.HideSelection = false;
            this.listViewEmpsMain.Location = new System.Drawing.Point(7, 261);
            this.listViewEmpsMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewEmpsMain.Name = "listViewEmpsMain";
            this.listViewEmpsMain.Size = new System.Drawing.Size(332, 293);
            this.listViewEmpsMain.TabIndex = 3;
            this.listViewEmpsMain.UseCompatibleStateImageBehavior = false;
            this.listViewEmpsMain.View = System.Windows.Forms.View.Details;
            this.listViewEmpsMain.SelectedIndexChanged += new System.EventHandler(this.listViewEmpsMain_SelectedIndexChanged);
            // 
            // colEmpID
            // 
            this.colEmpID.Text = "EmpID";
            this.colEmpID.Width = 100;
            // 
            // colEmpName
            // 
            this.colEmpName.Text = "Name";
            this.colEmpName.Width = 100;
            // 
            // colEmpStatus
            // 
            this.colEmpStatus.Text = "Status";
            this.colEmpStatus.Width = 80;
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.btnCheckin);
            this.gbControls.Controls.Add(this.pictureBoxBarcode);
            this.gbControls.Controls.Add(this.btnUpdate);
            this.gbControls.Controls.Add(this.btnCheckout);
            this.gbControls.Location = new System.Drawing.Point(640, 5);
            this.gbControls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbControls.Name = "gbControls";
            this.gbControls.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbControls.Size = new System.Drawing.Size(306, 252);
            this.gbControls.TabIndex = 2;
            this.gbControls.TabStop = false;
            // 
            // btnCheckin
            // 
            this.btnCheckin.Location = new System.Drawing.Point(196, 27);
            this.btnCheckin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(94, 23);
            this.btnCheckin.TabIndex = 3;
            this.btnCheckin.Text = "Check-in";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // pictureBoxBarcode
            // 
            this.pictureBoxBarcode.Location = new System.Drawing.Point(24, 105);
            this.pictureBoxBarcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxBarcode.Name = "pictureBoxBarcode";
            this.pictureBoxBarcode.Size = new System.Drawing.Size(266, 143);
            this.pictureBoxBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxBarcode.TabIndex = 2;
            this.pictureBoxBarcode.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(106, 74);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 27);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(21, 27);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(94, 23);
            this.btnCheckout.TabIndex = 0;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // gbEquip
            // 
            this.gbEquip.Controls.Add(this.label7);
            this.gbEquip.Controls.Add(this.label6);
            this.gbEquip.Controls.Add(this.label5);
            this.gbEquip.Controls.Add(this.lableEquipIDMain);
            this.gbEquip.Controls.Add(this.textBoxEquipOutMain);
            this.gbEquip.Controls.Add(this.textBoxEquipInMain);
            this.gbEquip.Controls.Add(this.textBoxEquipStatusMain);
            this.gbEquip.Controls.Add(this.textBoxEquipIdMain);
            this.gbEquip.Location = new System.Drawing.Point(345, 5);
            this.gbEquip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbEquip.Name = "gbEquip";
            this.gbEquip.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbEquip.Size = new System.Drawing.Size(289, 252);
            this.gbEquip.TabIndex = 1;
            this.gbEquip.TabStop = false;
            this.gbEquip.Text = "Equipment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Out Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "In Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Status";
            // 
            // lableEquipIDMain
            // 
            this.lableEquipIDMain.AutoSize = true;
            this.lableEquipIDMain.Location = new System.Drawing.Point(29, 35);
            this.lableEquipIDMain.Name = "lableEquipIDMain";
            this.lableEquipIDMain.Size = new System.Drawing.Size(58, 16);
            this.lableEquipIDMain.TabIndex = 5;
            this.lableEquipIDMain.Text = "Equip ID";
            // 
            // textBoxEquipOutMain
            // 
            this.textBoxEquipOutMain.Location = new System.Drawing.Point(118, 203);
            this.textBoxEquipOutMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEquipOutMain.Name = "textBoxEquipOutMain";
            this.textBoxEquipOutMain.ReadOnly = true;
            this.textBoxEquipOutMain.Size = new System.Drawing.Size(152, 22);
            this.textBoxEquipOutMain.TabIndex = 4;
            // 
            // textBoxEquipInMain
            // 
            this.textBoxEquipInMain.Location = new System.Drawing.Point(118, 145);
            this.textBoxEquipInMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEquipInMain.Name = "textBoxEquipInMain";
            this.textBoxEquipInMain.ReadOnly = true;
            this.textBoxEquipInMain.Size = new System.Drawing.Size(152, 22);
            this.textBoxEquipInMain.TabIndex = 3;
            // 
            // textBoxEquipStatusMain
            // 
            this.textBoxEquipStatusMain.Location = new System.Drawing.Point(118, 90);
            this.textBoxEquipStatusMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEquipStatusMain.Name = "textBoxEquipStatusMain";
            this.textBoxEquipStatusMain.ReadOnly = true;
            this.textBoxEquipStatusMain.Size = new System.Drawing.Size(152, 22);
            this.textBoxEquipStatusMain.TabIndex = 1;
            // 
            // textBoxEquipIdMain
            // 
            this.textBoxEquipIdMain.Location = new System.Drawing.Point(118, 29);
            this.textBoxEquipIdMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEquipIdMain.Name = "textBoxEquipIdMain";
            this.textBoxEquipIdMain.ReadOnly = true;
            this.textBoxEquipIdMain.Size = new System.Drawing.Size(152, 22);
            this.textBoxEquipIdMain.TabIndex = 0;
            // 
            // gbCust
            // 
            this.gbCust.Controls.Add(this.textBoxEmpStatusMain);
            this.gbCust.Controls.Add(this.textBoxEmpNameMain);
            this.gbCust.Controls.Add(this.textBoxEmpIDMain);
            this.gbCust.Controls.Add(this.label3);
            this.gbCust.Controls.Add(this.label2);
            this.gbCust.Controls.Add(this.label1);
            this.gbCust.Location = new System.Drawing.Point(6, 5);
            this.gbCust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCust.Name = "gbCust";
            this.gbCust.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbCust.Size = new System.Drawing.Size(333, 252);
            this.gbCust.TabIndex = 0;
            this.gbCust.TabStop = false;
            this.gbCust.Text = "Customer";
            // 
            // textBoxEmpStatusMain
            // 
            this.textBoxEmpStatusMain.Location = new System.Drawing.Point(88, 161);
            this.textBoxEmpStatusMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEmpStatusMain.Name = "textBoxEmpStatusMain";
            this.textBoxEmpStatusMain.ReadOnly = true;
            this.textBoxEmpStatusMain.Size = new System.Drawing.Size(207, 22);
            this.textBoxEmpStatusMain.TabIndex = 5;
            // 
            // textBoxEmpNameMain
            // 
            this.textBoxEmpNameMain.Location = new System.Drawing.Point(88, 95);
            this.textBoxEmpNameMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEmpNameMain.Name = "textBoxEmpNameMain";
            this.textBoxEmpNameMain.ReadOnly = true;
            this.textBoxEmpNameMain.Size = new System.Drawing.Size(207, 22);
            this.textBoxEmpNameMain.TabIndex = 4;
            // 
            // textBoxEmpIDMain
            // 
            this.textBoxEmpIDMain.Location = new System.Drawing.Point(88, 26);
            this.textBoxEmpIDMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEmpIDMain.Name = "textBoxEmpIDMain";
            this.textBoxEmpIDMain.ReadOnly = true;
            this.textBoxEmpIDMain.Size = new System.Drawing.Size(207, 22);
            this.textBoxEmpIDMain.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "EmpID";
            // 
            // invTab
            // 
            this.invTab.Controls.Add(this.groupBoxVehicle);
            this.invTab.Controls.Add(this.groupBoxCert);
            this.invTab.Controls.Add(this.groupBoxEQCal);
            this.invTab.Controls.Add(this.groupBoxEQIncluded);
            this.invTab.Controls.Add(this.btnDelete);
            this.invTab.Controls.Add(this.buttonUpdateEQ);
            this.invTab.Controls.Add(this.buttonAddEQ);
            this.invTab.Controls.Add(this.buttonNewEQ);
            this.invTab.Controls.Add(this.listViewCheckouts);
            this.invTab.Controls.Add(this.groupBoxInvDetails);
            this.invTab.Controls.Add(this.listBoxInventory);
            this.invTab.Location = new System.Drawing.Point(25, 4);
            this.invTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.invTab.Name = "invTab";
            this.invTab.Size = new System.Drawing.Size(954, 551);
            this.invTab.TabIndex = 3;
            this.invTab.Text = "Inventory";
            this.invTab.UseVisualStyleBackColor = true;
            // 
            // groupBoxVehicle
            // 
            this.groupBoxVehicle.Controls.Add(this.textBoxSN);
            this.groupBoxVehicle.Controls.Add(this.textBoxYear);
            this.groupBoxVehicle.Controls.Add(this.textBoxModel);
            this.groupBoxVehicle.Controls.Add(this.textBoxMake);
            this.groupBoxVehicle.Controls.Add(this.labelSN);
            this.groupBoxVehicle.Controls.Add(this.labelYear);
            this.groupBoxVehicle.Controls.Add(this.labelModel);
            this.groupBoxVehicle.Controls.Add(this.labelMake);
            this.groupBoxVehicle.Controls.Add(this.checkBoxVehicle);
            this.groupBoxVehicle.Location = new System.Drawing.Point(695, 133);
            this.groupBoxVehicle.Name = "groupBoxVehicle";
            this.groupBoxVehicle.Size = new System.Drawing.Size(247, 166);
            this.groupBoxVehicle.TabIndex = 10;
            this.groupBoxVehicle.TabStop = false;
            // 
            // textBoxSN
            // 
            this.textBoxSN.Enabled = false;
            this.textBoxSN.Location = new System.Drawing.Point(58, 137);
            this.textBoxSN.Name = "textBoxSN";
            this.textBoxSN.Size = new System.Drawing.Size(169, 22);
            this.textBoxSN.TabIndex = 8;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Enabled = false;
            this.textBoxYear.Location = new System.Drawing.Point(58, 104);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(169, 22);
            this.textBoxYear.TabIndex = 7;
            // 
            // textBoxModel
            // 
            this.textBoxModel.Enabled = false;
            this.textBoxModel.Location = new System.Drawing.Point(58, 73);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(169, 22);
            this.textBoxModel.TabIndex = 6;
            // 
            // textBoxMake
            // 
            this.textBoxMake.Enabled = false;
            this.textBoxMake.Location = new System.Drawing.Point(58, 41);
            this.textBoxMake.Name = "textBoxMake";
            this.textBoxMake.Size = new System.Drawing.Size(169, 22);
            this.textBoxMake.TabIndex = 5;
            // 
            // labelSN
            // 
            this.labelSN.AutoSize = true;
            this.labelSN.Location = new System.Drawing.Point(7, 143);
            this.labelSN.Name = "labelSN";
            this.labelSN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSN.Size = new System.Drawing.Size(30, 16);
            this.labelSN.TabIndex = 4;
            this.labelSN.Text = "S/N";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(7, 111);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(36, 16);
            this.labelYear.TabIndex = 3;
            this.labelYear.Text = "Year";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(6, 79);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(45, 16);
            this.labelModel.TabIndex = 2;
            this.labelModel.Text = "Model";
            // 
            // labelMake
            // 
            this.labelMake.AutoSize = true;
            this.labelMake.Location = new System.Drawing.Point(7, 47);
            this.labelMake.Name = "labelMake";
            this.labelMake.Size = new System.Drawing.Size(41, 16);
            this.labelMake.TabIndex = 1;
            this.labelMake.Text = "Make";
            // 
            // checkBoxVehicle
            // 
            this.checkBoxVehicle.AutoSize = true;
            this.checkBoxVehicle.Location = new System.Drawing.Point(6, 16);
            this.checkBoxVehicle.Name = "checkBoxVehicle";
            this.checkBoxVehicle.Size = new System.Drawing.Size(74, 20);
            this.checkBoxVehicle.TabIndex = 0;
            this.checkBoxVehicle.Text = "Vehicle";
            this.checkBoxVehicle.UseVisualStyleBackColor = true;
            this.checkBoxVehicle.CheckedChanged += new System.EventHandler(this.checkBoxVehicle_CheckedChanged);
            // 
            // groupBoxCert
            // 
            this.groupBoxCert.Controls.Add(this.checkBoxCert);
            this.groupBoxCert.Location = new System.Drawing.Point(458, 235);
            this.groupBoxCert.Name = "groupBoxCert";
            this.groupBoxCert.Size = new System.Drawing.Size(230, 64);
            this.groupBoxCert.TabIndex = 9;
            this.groupBoxCert.TabStop = false;
            // 
            // checkBoxCert
            // 
            this.checkBoxCert.AutoSize = true;
            this.checkBoxCert.Location = new System.Drawing.Point(10, 25);
            this.checkBoxCert.Name = "checkBoxCert";
            this.checkBoxCert.Size = new System.Drawing.Size(157, 20);
            this.checkBoxCert.TabIndex = 0;
            this.checkBoxCert.Text = "Certification Required";
            this.checkBoxCert.UseVisualStyleBackColor = true;
            this.checkBoxCert.CheckedChanged += new System.EventHandler(this.checkBoxCert_CheckedChanged);
            // 
            // groupBoxEQCal
            // 
            this.groupBoxEQCal.Controls.Add(this.checkBoxCal);
            this.groupBoxEQCal.Controls.Add(this.dateTimePickerCalDue);
            this.groupBoxEQCal.Controls.Add(this.dateTimePickerCalDate);
            this.groupBoxEQCal.Controls.Add(this.labelCalDue);
            this.groupBoxEQCal.Controls.Add(this.labelCalDate);
            this.groupBoxEQCal.Location = new System.Drawing.Point(458, 133);
            this.groupBoxEQCal.Name = "groupBoxEQCal";
            this.groupBoxEQCal.Size = new System.Drawing.Size(230, 102);
            this.groupBoxEQCal.TabIndex = 8;
            this.groupBoxEQCal.TabStop = false;
            // 
            // checkBoxCal
            // 
            this.checkBoxCal.AutoSize = true;
            this.checkBoxCal.Location = new System.Drawing.Point(10, 16);
            this.checkBoxCal.Name = "checkBoxCal";
            this.checkBoxCal.Size = new System.Drawing.Size(93, 20);
            this.checkBoxCal.TabIndex = 4;
            this.checkBoxCal.Text = "Calibration";
            this.checkBoxCal.UseVisualStyleBackColor = true;
            this.checkBoxCal.CheckedChanged += new System.EventHandler(this.checkBoxCal_CheckedChanged);
            // 
            // dateTimePickerCalDue
            // 
            this.dateTimePickerCalDue.Enabled = false;
            this.dateTimePickerCalDue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCalDue.Location = new System.Drawing.Point(72, 74);
            this.dateTimePickerCalDue.Name = "dateTimePickerCalDue";
            this.dateTimePickerCalDue.Size = new System.Drawing.Size(113, 22);
            this.dateTimePickerCalDue.TabIndex = 3;
            // 
            // dateTimePickerCalDate
            // 
            this.dateTimePickerCalDate.Enabled = false;
            this.dateTimePickerCalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCalDate.Location = new System.Drawing.Point(72, 42);
            this.dateTimePickerCalDate.Name = "dateTimePickerCalDate";
            this.dateTimePickerCalDate.Size = new System.Drawing.Size(113, 22);
            this.dateTimePickerCalDate.TabIndex = 2;
            // 
            // labelCalDue
            // 
            this.labelCalDue.AutoSize = true;
            this.labelCalDue.Location = new System.Drawing.Point(7, 80);
            this.labelCalDue.Name = "labelCalDue";
            this.labelCalDue.Size = new System.Drawing.Size(64, 16);
            this.labelCalDue.TabIndex = 1;
            this.labelCalDue.Text = "Due Date";
            // 
            // labelCalDate
            // 
            this.labelCalDate.AutoSize = true;
            this.labelCalDate.Location = new System.Drawing.Point(7, 47);
            this.labelCalDate.Name = "labelCalDate";
            this.labelCalDate.Size = new System.Drawing.Size(59, 16);
            this.labelCalDate.TabIndex = 0;
            this.labelCalDate.Text = "Cal Date";
            // 
            // groupBoxEQIncluded
            // 
            this.groupBoxEQIncluded.Controls.Add(this.checkBoxEQIncluded);
            this.groupBoxEQIncluded.Controls.Add(this.richTextBoxIncluded);
            this.groupBoxEQIncluded.Location = new System.Drawing.Point(457, 8);
            this.groupBoxEQIncluded.Name = "groupBoxEQIncluded";
            this.groupBoxEQIncluded.Size = new System.Drawing.Size(384, 125);
            this.groupBoxEQIncluded.TabIndex = 7;
            this.groupBoxEQIncluded.TabStop = false;
            // 
            // checkBoxEQIncluded
            // 
            this.checkBoxEQIncluded.AutoSize = true;
            this.checkBoxEQIncluded.Location = new System.Drawing.Point(7, 16);
            this.checkBoxEQIncluded.Name = "checkBoxEQIncluded";
            this.checkBoxEQIncluded.Size = new System.Drawing.Size(80, 20);
            this.checkBoxEQIncluded.TabIndex = 1;
            this.checkBoxEQIncluded.Text = "Included";
            this.checkBoxEQIncluded.UseVisualStyleBackColor = true;
            this.checkBoxEQIncluded.CheckedChanged += new System.EventHandler(this.checkBoxEQIncluded_CheckedChanged);
            // 
            // richTextBoxIncluded
            // 
            this.richTextBoxIncluded.Enabled = false;
            this.richTextBoxIncluded.Location = new System.Drawing.Point(6, 42);
            this.richTextBoxIncluded.Name = "richTextBoxIncluded";
            this.richTextBoxIncluded.Size = new System.Drawing.Size(372, 77);
            this.richTextBoxIncluded.TabIndex = 0;
            this.richTextBoxIncluded.Text = "";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(867, 95);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseCompatibleTextRendering = true;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // buttonUpdateEQ
            // 
            this.buttonUpdateEQ.Enabled = false;
            this.buttonUpdateEQ.Location = new System.Drawing.Point(867, 66);
            this.buttonUpdateEQ.Name = "buttonUpdateEQ";
            this.buttonUpdateEQ.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateEQ.TabIndex = 5;
            this.buttonUpdateEQ.Text = "Update";
            this.buttonUpdateEQ.UseVisualStyleBackColor = true;
            this.buttonUpdateEQ.Click += new System.EventHandler(this.buttonUpdateEQ_Click);
            // 
            // buttonAddEQ
            // 
            this.buttonAddEQ.Enabled = false;
            this.buttonAddEQ.Location = new System.Drawing.Point(867, 37);
            this.buttonAddEQ.Name = "buttonAddEQ";
            this.buttonAddEQ.Size = new System.Drawing.Size(75, 23);
            this.buttonAddEQ.TabIndex = 4;
            this.buttonAddEQ.Text = "Add";
            this.buttonAddEQ.UseVisualStyleBackColor = true;
            this.buttonAddEQ.Click += new System.EventHandler(this.buttonAddEQ_Click);
            // 
            // buttonNewEQ
            // 
            this.buttonNewEQ.Location = new System.Drawing.Point(867, 8);
            this.buttonNewEQ.Name = "buttonNewEQ";
            this.buttonNewEQ.Size = new System.Drawing.Size(75, 23);
            this.buttonNewEQ.TabIndex = 3;
            this.buttonNewEQ.Text = "New";
            this.buttonNewEQ.UseVisualStyleBackColor = true;
            this.buttonNewEQ.Click += new System.EventHandler(this.buttonNewEQ_Click);
            // 
            // listViewCheckouts
            // 
            this.listViewCheckouts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmpCO,
            this.colDateInCO,
            this.coluDateOutCO,
            this.colConditionCO});
            this.listViewCheckouts.FullRowSelect = true;
            this.listViewCheckouts.GridLines = true;
            this.listViewCheckouts.HideSelection = false;
            this.listViewCheckouts.Location = new System.Drawing.Point(179, 305);
            this.listViewCheckouts.Name = "listViewCheckouts";
            this.listViewCheckouts.Size = new System.Drawing.Size(763, 243);
            this.listViewCheckouts.TabIndex = 2;
            this.listViewCheckouts.UseCompatibleStateImageBehavior = false;
            this.listViewCheckouts.View = System.Windows.Forms.View.Details;
            // 
            // colEmpCO
            // 
            this.colEmpCO.Text = "EmpID";
            this.colEmpCO.Width = 100;
            // 
            // colDateInCO
            // 
            this.colDateInCO.Text = "Date In";
            this.colDateInCO.Width = 100;
            // 
            // coluDateOutCO
            // 
            this.coluDateOutCO.Text = "Date Out";
            this.coluDateOutCO.Width = 100;
            // 
            // colConditionCO
            // 
            this.colConditionCO.Text = "Condition";
            this.colConditionCO.Width = 200;
            // 
            // groupBoxInvDetails
            // 
            this.groupBoxInvDetails.Controls.Add(this.comboBoxEQStatus);
            this.groupBoxInvDetails.Controls.Add(this.textBoxEQName);
            this.groupBoxInvDetails.Controls.Add(this.textBoxEQID);
            this.groupBoxInvDetails.Controls.Add(this.richTextBoxRemarks);
            this.groupBoxInvDetails.Controls.Add(this.labelEQRemarks);
            this.groupBoxInvDetails.Controls.Add(this.labelEQStatus);
            this.groupBoxInvDetails.Controls.Add(this.labelEQName);
            this.groupBoxInvDetails.Controls.Add(this.labelEQID);
            this.groupBoxInvDetails.Location = new System.Drawing.Point(179, 8);
            this.groupBoxInvDetails.Name = "groupBoxInvDetails";
            this.groupBoxInvDetails.Size = new System.Drawing.Size(272, 291);
            this.groupBoxInvDetails.TabIndex = 1;
            this.groupBoxInvDetails.TabStop = false;
            this.groupBoxInvDetails.Text = "Equipment Details";
            // 
            // comboBoxEQStatus
            // 
            this.comboBoxEQStatus.FormattingEnabled = true;
            this.comboBoxEQStatus.Location = new System.Drawing.Point(57, 116);
            this.comboBoxEQStatus.Name = "comboBoxEQStatus";
            this.comboBoxEQStatus.Size = new System.Drawing.Size(121, 24);
            this.comboBoxEQStatus.TabIndex = 7;
            // 
            // textBoxEQName
            // 
            this.textBoxEQName.Location = new System.Drawing.Point(57, 66);
            this.textBoxEQName.Name = "textBoxEQName";
            this.textBoxEQName.Size = new System.Drawing.Size(201, 22);
            this.textBoxEQName.TabIndex = 6;
            // 
            // textBoxEQID
            // 
            this.textBoxEQID.Location = new System.Drawing.Point(57, 19);
            this.textBoxEQID.Name = "textBoxEQID";
            this.textBoxEQID.ReadOnly = true;
            this.textBoxEQID.Size = new System.Drawing.Size(205, 22);
            this.textBoxEQID.TabIndex = 5;
            // 
            // richTextBoxRemarks
            // 
            this.richTextBoxRemarks.Location = new System.Drawing.Point(6, 192);
            this.richTextBoxRemarks.Name = "richTextBoxRemarks";
            this.richTextBoxRemarks.Size = new System.Drawing.Size(252, 80);
            this.richTextBoxRemarks.TabIndex = 4;
            this.richTextBoxRemarks.Text = "";
            // 
            // labelEQRemarks
            // 
            this.labelEQRemarks.AutoSize = true;
            this.labelEQRemarks.Location = new System.Drawing.Point(7, 164);
            this.labelEQRemarks.Name = "labelEQRemarks";
            this.labelEQRemarks.Size = new System.Drawing.Size(62, 16);
            this.labelEQRemarks.TabIndex = 3;
            this.labelEQRemarks.Text = "Remarks";
            // 
            // labelEQStatus
            // 
            this.labelEQStatus.AutoSize = true;
            this.labelEQStatus.Location = new System.Drawing.Point(7, 124);
            this.labelEQStatus.Name = "labelEQStatus";
            this.labelEQStatus.Size = new System.Drawing.Size(44, 16);
            this.labelEQStatus.TabIndex = 2;
            this.labelEQStatus.Text = "Status";
            // 
            // labelEQName
            // 
            this.labelEQName.AutoSize = true;
            this.labelEQName.Location = new System.Drawing.Point(7, 72);
            this.labelEQName.Name = "labelEQName";
            this.labelEQName.Size = new System.Drawing.Size(44, 16);
            this.labelEQName.TabIndex = 1;
            this.labelEQName.Text = "Name";
            // 
            // labelEQID
            // 
            this.labelEQID.AutoSize = true;
            this.labelEQID.Location = new System.Drawing.Point(7, 22);
            this.labelEQID.Name = "labelEQID";
            this.labelEQID.Size = new System.Drawing.Size(20, 16);
            this.labelEQID.TabIndex = 0;
            this.labelEQID.Text = "ID";
            // 
            // listBoxInventory
            // 
            this.listBoxInventory.DisplayMember = "\"Name\"";
            this.listBoxInventory.FormattingEnabled = true;
            this.listBoxInventory.ItemHeight = 16;
            this.listBoxInventory.Location = new System.Drawing.Point(4, 4);
            this.listBoxInventory.Name = "listBoxInventory";
            this.listBoxInventory.Size = new System.Drawing.Size(165, 548);
            this.listBoxInventory.TabIndex = 0;
            this.listBoxInventory.SelectedIndexChanged += new System.EventHandler(this.listBoxInventory_SelectedIndexChanged);
            // 
            // usersTab
            // 
            this.usersTab.Controls.Add(this.label4);
            this.usersTab.Location = new System.Drawing.Point(25, 4);
            this.usersTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usersTab.Name = "usersTab";
            this.usersTab.Size = new System.Drawing.Size(954, 551);
            this.usersTab.TabIndex = 4;
            this.usersTab.Text = "Users";
            this.usersTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(415, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Coming Soon";
            // 
            // reportsTab
            // 
            this.reportsTab.Controls.Add(this.richTextBoxReports);
            this.reportsTab.Controls.Add(this.labelReports);
            this.reportsTab.Controls.Add(this.comboBoxReports);
            this.reportsTab.Location = new System.Drawing.Point(25, 4);
            this.reportsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportsTab.Name = "reportsTab";
            this.reportsTab.Size = new System.Drawing.Size(954, 551);
            this.reportsTab.TabIndex = 2;
            this.reportsTab.Text = "Reports";
            this.reportsTab.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReports
            // 
            this.richTextBoxReports.Location = new System.Drawing.Point(18, 57);
            this.richTextBoxReports.Name = "richTextBoxReports";
            this.richTextBoxReports.ReadOnly = true;
            this.richTextBoxReports.Size = new System.Drawing.Size(915, 476);
            this.richTextBoxReports.TabIndex = 2;
            this.richTextBoxReports.Text = "";
            this.richTextBoxReports.WordWrap = false;
            // 
            // labelReports
            // 
            this.labelReports.AutoSize = true;
            this.labelReports.Location = new System.Drawing.Point(254, 20);
            this.labelReports.Name = "labelReports";
            this.labelReports.Size = new System.Drawing.Size(55, 16);
            this.labelReports.TabIndex = 1;
            this.labelReports.Text = "Reports";
            // 
            // comboBoxReports
            // 
            this.comboBoxReports.FormattingEnabled = true;
            this.comboBoxReports.Location = new System.Drawing.Point(324, 17);
            this.comboBoxReports.Name = "comboBoxReports";
            this.comboBoxReports.Size = new System.Drawing.Size(319, 24);
            this.comboBoxReports.TabIndex = 0;
            this.comboBoxReports.SelectedIndexChanged += new System.EventHandler(this.comboBoxReports_SelectedIndexChanged);
            // 
            // adminTab
            // 
            this.adminTab.Controls.Add(this.label8);
            this.adminTab.Location = new System.Drawing.Point(25, 4);
            this.adminTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adminTab.Name = "adminTab";
            this.adminTab.Size = new System.Drawing.Size(954, 551);
            this.adminTab.TabIndex = 5;
            this.adminTab.Text = "Admin";
            this.adminTab.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(407, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Coming Soon";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(CEIS400_ECS.Employee);
            // 
            // vehicleBindingSource
            // 
            this.vehicleBindingSource.DataSource = typeof(CEIS400_ECS.Vehicle);
            // 
            // basicToolsBindingSource
            // 
            this.basicToolsBindingSource.DataSource = typeof(CEIS400_ECS.BasicTools);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(992, 574);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Name = "Form1";
            this.Text = "Equipment Checkout System";
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.gbControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarcode)).EndInit();
            this.gbEquip.ResumeLayout(false);
            this.gbEquip.PerformLayout();
            this.gbCust.ResumeLayout(false);
            this.gbCust.PerformLayout();
            this.invTab.ResumeLayout(false);
            this.groupBoxVehicle.ResumeLayout(false);
            this.groupBoxVehicle.PerformLayout();
            this.groupBoxCert.ResumeLayout(false);
            this.groupBoxCert.PerformLayout();
            this.groupBoxEQCal.ResumeLayout(false);
            this.groupBoxEQCal.PerformLayout();
            this.groupBoxEQIncluded.ResumeLayout(false);
            this.groupBoxEQIncluded.PerformLayout();
            this.groupBoxInvDetails.ResumeLayout(false);
            this.groupBoxInvDetails.PerformLayout();
            this.usersTab.ResumeLayout(false);
            this.usersTab.PerformLayout();
            this.reportsTab.ResumeLayout(false);
            this.reportsTab.PerformLayout();
            this.adminTab.ResumeLayout(false);
            this.adminTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicToolsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelMain;
        public TabControl tabControlMain;
        public TabPage mainTab;
        public TabPage reportsTab;
        public TabPage invTab;
        public TabPage usersTab;
        public TabPage adminTab;
        private BindingSource basicToolsBindingSource;
        private BindingSource employeeBindingSource;
        private GroupBox gbControls;
        private GroupBox gbCust;
        private BindingSource vehicleBindingSource;
        public ListView listViewEmpsMain;
        public ColumnHeader colEmpID;
        public ColumnHeader colEmpName;
        private ColumnHeader colEmpStatus;
        public ColumnHeader colEquip;
        public ColumnHeader colToolStatus;
        public ColumnHeader colInDate;
        public ColumnHeader colOutDate;
        public ColumnHeader colRemarks;
        public ListView listViewEquipMain;
        public GroupBox gbEquip;
        public Button btnCheckout;
        public Button btnCheckin;
        public Button btnUpdate;
        public PictureBox pictureBoxBarcode;
        private Label label3;
        private Label label2;
        private Label label1;
        public TextBox textBoxEmpIDMain;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label lableEquipIDMain;
        public TextBox textBoxEmpStatusMain;
        public TextBox textBoxEmpNameMain;
        public TextBox textBoxEquipIdMain;
        public TextBox textBoxEquipStatusMain;
        public TextBox textBoxEquipInMain;
        public TextBox textBoxEquipOutMain;
        private ImageList imageList1;
        private GroupBox groupBoxInvDetails;
        public ListBox listBoxInventory;
        public ListView listViewCheckouts;
        public ColumnHeader colEmpCO;
        public ColumnHeader colDateInCO;
        public ColumnHeader coluDateOutCO;
        public ColumnHeader colConditionCO;
        private Label labelEQID;
        private TextBox textBoxEQID;
        private Label labelEQRemarks;
        private Label labelEQStatus;
        private Label labelEQName;
        public RichTextBox richTextBoxRemarks;
        public TextBox textBoxEQName;
        public ComboBox comboBoxEQStatus;
        public GroupBox groupBoxEQCal;
        public GroupBox groupBoxEQIncluded;
        public CheckBox checkBoxEQIncluded;
        private RichTextBox richTextBoxIncluded;
        public DateTimePicker dateTimePickerCalDue;
        public DateTimePicker dateTimePickerCalDate;
        private Label labelCalDate;
        public CheckBox checkBoxCal;
        public Label labelCalDue;
        private GroupBox groupBoxCert;
        public CheckBox checkBoxCert;
        public GroupBox groupBoxVehicle;
        private Label labelSN;
        private Label labelYear;
        private Label labelModel;
        private Label labelMake;
        public CheckBox checkBoxVehicle;
        public TextBox textBoxSN;
        public TextBox textBoxYear;
        public TextBox textBoxModel;
        public TextBox textBoxMake;
        public Button buttonUpdateEQ;
        public Button buttonAddEQ;
        public Button buttonNewEQ;
        public Button btnDelete;
        private Label label4;
        public RichTextBox richTextBoxReports;
        private Label labelReports;
        public ComboBox comboBoxReports;
        private Label label8;
    }
}