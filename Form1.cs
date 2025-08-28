using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CEIS400_ECS
{
    public partial class Form1 : Form
    {
        BindingList<ITrackable> trackables;
        BindingList<Employee> employees;
        Employee currentUser;
        DatabaseAccess db;
        private int currentUserIndex = 0;
        private int currentEquipIndex = 0;
        private List<ITrackable> deletedTrackables;
        public static Form1 Instance { get; private set; }

        public Form1(Employee emp, DatabaseAccess db, BindingList<ITrackable> trackables, BindingList<Employee> employees)
        {
            // Builds the program and connects to DB, creates binding lists, loads UI data
            InitializeComponent();

            this.trackables = trackables;
            this.employees = employees;
            this.db = db;
            currentUser = emp;
            Instance = this;
            FormUtilities.LoadEmpMainList(ref employees, Instance);
            FormUtilities.LoadEquipMainLIst(ref trackables, Instance);
            currentUser.Login();
            FormUtilities.LoadInventoryList(ref trackables, Instance);
            foreach (ITrackable trackable in trackables)
            {
                FormUtilities.LoadCheckoutsInventory(trackable, Instance);
            }
            EnumHelper.BindToComboBox<InvStatus>(comboBoxEQStatus);
            EnumHelper.BindToComboBox<ReportType>(comboBoxReports);
            listBoxInventory.DataSource = trackables;
            this.FormClosing += MainForm_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    // Main tab
        private void listViewEmpsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Makes sure correct data is displayed in UI by object class
            if (listViewEmpsMain.SelectedItems.Count > 0)
            {
                var selectedEmp = (Employee)listViewEmpsMain.SelectedItems[0].Tag;
                currentUserIndex = employees.IndexOf(selectedEmp);
                textBoxEmpIDMain.Text = selectedEmp.EmpID;
                textBoxEmpNameMain.Text = selectedEmp.Name;
                textBoxEmpStatusMain.Text = selectedEmp.Status.ToString();
            }
        }

        private void listViewEquipMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Makes sure correct data is displayed in UI by object class
            if (listViewEquipMain.SelectedItems.Count > 0)
            {
                var selectedEquip = (ITrackable)listViewEquipMain.SelectedItems[0].Tag;
                currentEquipIndex = trackables.IndexOf(selectedEquip);

                switch (selectedEquip)
                {
                    case BasicTools bt:
                        textBoxEquipIdMain.Text = bt.Name;
                        textBoxEquipStatusMain.Text = bt.Status.ToString();
                        textBoxEquipInMain.Text = bt.InDate?.ToString("d");
                        textBoxEquipOutMain.Text = bt.OutDate?.ToString("d");
                        bt.GenerateBarcode();
                        pictureBoxBarcode.Image = bt.Barcode.BarcodeImage;
                        break;

                    case SpecialTool st:
                        textBoxEquipIdMain.Text = st.Name;
                        textBoxEquipStatusMain.Text = st.Status.ToString();
                        textBoxEquipInMain.Text = st.InDate?.ToString("d");
                        textBoxEquipOutMain.Text = st.OutDate?.ToString("d");
                        st.GenerateBarcode();
                        pictureBoxBarcode.Image = st.Barcode.BarcodeImage;
                        break;

                    case Vehicle v:
                        string vName = $"{v.Make} {v.Model}";
                        textBoxEquipIdMain.Text = vName;
                        textBoxEquipStatusMain.Text = v.Status.ToString();
                        textBoxEquipInMain.Text = v.InDate?.ToString("d");
                        textBoxEquipOutMain.Text = v.OutDate?.ToString("d");
                        v.GenerateBarcode();
                        pictureBoxBarcode.Image = v.Barcode.BarcodeImage;
                        break;
                }

            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Check out equipment
            var equip = trackables[currentEquipIndex];
            var currentEmp = employees[currentUserIndex];

            if (currentEmp is Customer customer) // Make sure we have a customer selected
            {
                try
                { // Check out to customer
                    DeptStaff.CheckOutEquip(equip, customer, currentUser);
                    FormUtilities.LoadEmpMainList(ref employees, Instance);
                    FormUtilities.LoadEquipMainLIst(ref trackables, Instance);
                    FormUtilities.LoadCheckoutsInventory(equip, Instance);
                    FormUtilities.LoadInventoryList(ref trackables, Instance);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Checkout Failed", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Only customers can check out equipment.", "Invalid user", MessageBoxButtons.OK);
            }
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            // Check in equipment
            var equip = trackables[currentEquipIndex];
            var currentEmp = employees[currentUserIndex];

            // Makes sure the correct customer is selected
            if (currentEmp is Customer customer)
            {
                // checks for correct record that matches tool and customer
                var record = equip.CheckoutRecords
                                  .FirstOrDefault(r => r.DateIn == null && r.EmpID == customer.EmpID);

                if (!(FormUtilities.ValidateCheckIn(equip, record, currentUser)))
                {
                    // validation failed → stop here
                    return;
                }

                // Ask for condition after successful validation
                // Opens new windo so this isn't missed
                using (var conditionForm = new ConditionPromptcs(equip, record.RecordID))
                {
                    if (conditionForm.ShowDialog() == DialogResult.OK)
                    {
                        DeptStaff.CheckInEquip(equip, record.RecordID, customer, currentUser);

                        FormUtilities.LoadEmpMainList(ref employees, Instance);
                        FormUtilities.LoadEquipMainLIst(ref trackables, Instance);
                        FormUtilities.LoadCheckoutsInventory(equip, Instance);
                        FormUtilities.LoadInventoryList(ref trackables, Instance);
                    }
                }
            }
            else
            {
                MessageBox.Show("Only customers can check in equipment.",
                                "Invalid user",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // For now it just takes to the Inventory page and displays the item from the Main page to be updated
            if (listViewEquipMain.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an equipment item to update.", "No Selection", MessageBoxButtons.OK);
                return;
            }

            var selectedItem = listViewEquipMain.SelectedItems[0];
            if (selectedItem.Tag is ITrackable equipToUpdate)
            {
                listBoxInventory.SelectedItem = equipToUpdate; // highlight in inventory
                tabControlMain.SelectedTab = invTab;          // switch tab
            }
            else
            {
                MessageBox.Show("Invalid selection. Could not find trackable data.", "Error", MessageBoxButtons.OK);
            }
        }

        // Inventory tab
        private void listBoxInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This makes sure we display the class information correctly for the item we selected from the list
            currentEquipIndex = listBoxInventory.SelectedIndex;
            if (listBoxInventory.SelectedItem is ITrackable selectedEquip)
            {
                switch (selectedEquip)
                {
                    case BasicTools bt:
                        textBoxEQID.Text = bt.SourceID;
                        textBoxEQName.Text = bt.Name;
                        comboBoxEQStatus.SelectedValue = bt.Status;
                        richTextBoxRemarks.Text = bt.Remarks;
                        if (bt.isIncluded())
                        {
                            checkBoxEQIncluded.Checked = true;
                            string includedString = string.Join(",", bt.Included);
                            richTextBoxIncluded.Text = includedString;
                        }
                        else
                        {
                            checkBoxEQIncluded.Checked = false;
                            richTextBoxIncluded.Clear();
                        }
                        checkBoxCal.Checked = false;
                        checkBoxVehicle.Checked = false;
                        checkBoxCert.Checked = false;
                        checkBoxCal.Checked = false;
                        FormUtilities.LoadCheckoutsInventory(selectedEquip, Instance);
                        break;

                    case SpecialTool sti:
                        textBoxEQID.Text = sti.SourceID;
                        textBoxEQName.Text = sti.Name;
                        comboBoxEQStatus.SelectedValue = sti.Status;
                        richTextBoxRemarks.Text = sti.Remarks;
                        if (sti.IsIncluded())
                        {
                            checkBoxEQIncluded.Checked = true;
                            string includedString = string.Join(",", sti.Included);
                            richTextBoxIncluded.Text = includedString;
                        }
                        else
                        {
                            checkBoxEQIncluded.Checked = false;
                            richTextBoxIncluded.Clear();
                        }
                        if (sti.CalDate.HasValue)
                        {
                            checkBoxCal.Checked = true;
                            dateTimePickerCalDate.Value = sti.CalDate.Value;
                            dateTimePickerCalDue.Value = sti.CalDue.Value;
                        }
                        else
                        {
                            checkBoxCal.Checked = false;
                        }
                        if (sti.CertRequired)
                        {
                            checkBoxCert.Checked = true;
                        }
                        else
                        {
                            checkBoxCert.Checked = false;
                        }
                        checkBoxVehicle.Checked = false;
                        textBoxMake.Clear();
                        textBoxModel.Clear();
                        textBoxYear.Clear();
                        textBoxSN.Clear();
                        FormUtilities.LoadCheckoutsInventory(selectedEquip, Instance);
                        break;

                    case Vehicle v:
                        textBoxEQID.Text = v.SourceID;
                        textBoxEQName.Text = v.Name;
                        comboBoxEQStatus.SelectedValue = v.Status;
                        richTextBoxRemarks.Text = v.Remarks;
                        if (v.CertRequired)
                        {
                            checkBoxCert.Checked = true;
                        }
                        else
                        {
                            checkBoxCert.Checked = false;
                        }
                        checkBoxCal.Checked = false;
                        checkBoxVehicle.Checked = true;
                        textBoxMake.Text = v.Make;
                        textBoxModel.Text = v.Model;
                        textBoxYear.Text = Convert.ToString(v.Year);
                        textBoxSN.Text = v.SerialNum;
                        checkBoxCal.Checked = false;
                        checkBoxVehicle.Checked = true;
                        checkBoxEQIncluded.Checked = false;
                        richTextBoxIncluded.Clear();
                        FormUtilities.LoadCheckoutsInventory(selectedEquip, Instance);
                        break;
                }
            }

            buttonUpdateEQ.Enabled = true;
            btnDelete.Enabled = true;
            buttonAddEQ.Enabled = false;
        }

        private void checkBoxEQIncluded_CheckedChanged(object sender, EventArgs e)
        {
            // Only for Basic and Special Tools
            // Could be a toolbox full of tools or a multi piece set
            if (checkBoxEQIncluded.Checked)
            {
                richTextBoxIncluded.Enabled = true;
            }
            else
            {
                richTextBoxIncluded.Enabled = false;
                richTextBoxIncluded.Clear();
            }
        }

        private void checkBoxCal_CheckedChanged(object sender, EventArgs e)
        {
            // Specialtools are tools that need calibration or certification
            if (checkBoxCal.Checked)
            {
                dateTimePickerCalDate.Enabled = true;
                dateTimePickerCalDue.Enabled = true;
            }
            else
            {
                dateTimePickerCalDate.Enabled = false;
                dateTimePickerCalDue.Enabled = false;
            }
        }

        private void checkBoxCert_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxVehicle_CheckedChanged(object sender, EventArgs e)
        {
            // Vehicles don't have a Name variable
            // This make sure the input are correct for Vehicle
            // ToString method will convert info to show Name
            if (checkBoxVehicle.Checked)
            {
                textBoxMake.Enabled = true;
                textBoxModel.Enabled = true;
                textBoxYear.Enabled = true;
                textBoxSN.Enabled = true;
                textBoxEQName.ReadOnly = true;
            }
            else
            {
                textBoxMake.Enabled = false;
                textBoxMake.Clear();
                textBoxModel.Enabled = false;
                textBoxModel.Clear();
                textBoxYear.Enabled = false;
                textBoxYear.Clear();
                textBoxSN.Enabled = false;
                textBoxSN.Clear();
                textBoxEQName.ReadOnly = false;
            }
        }

        private void buttonNewEQ_Click(object sender, EventArgs e)
        {
            // Clears all boxes so they are ready for Input to add new inventory
            textBoxEQID.Text = "";
            textBoxEQName.Text = "";
            comboBoxEQStatus.SelectedItem = InvStatus.In;
            richTextBoxRemarks.Text = "";

            buttonAddEQ.Enabled = true;
            buttonUpdateEQ.Enabled = false;
            btnDelete.Enabled = false;
            checkBoxEQIncluded.Checked = false;
            richTextBoxIncluded.Clear();
            checkBoxCal.Checked = false;
            checkBoxVehicle.Checked = false;
            textBoxMake.Clear();
            textBoxModel.Clear();
            textBoxYear.Clear();
            textBoxSN.Clear();

            listViewCheckouts.Items.Clear();
        }

        private void buttonAddEQ_Click(object sender, EventArgs e)
        {
            ITrackable newEquip = null; // declaration to build object on

            List<string> included = checkBoxEQIncluded.Checked // null check
                ? richTextBoxIncluded.Text.Split(',').Select(s => s.Trim()).ToList()
                : new List<string>();

            bool needCert = checkBoxCert.Checked;

            if (!string.IsNullOrWhiteSpace(textBoxEQName.Text) || checkBoxVehicle.Checked)
            {
                if (checkBoxVehicle.Checked) // checkBoxes determine which class object our trackable is
                {
                    var vehicle = new Vehicle
                    {
                        Make = textBoxMake.Text.Trim(),
                        Model = textBoxModel.Text.Trim(),
                        Year = Convert.ToInt32(textBoxYear.Text),
                        SerialNum = textBoxSN.Text.Trim(),
                        Status = InvStatus.In,
                        InDate = DateTime.Now,
                        OutDate = null,
                        Remarks = richTextBoxRemarks.Text,
                        CertRequired = needCert,
                        CheckoutRecords = new BindingList<CheckoutRecord>()
                    };
                    vehicle.VehicleID = vehicle.GenerateID();
                    newEquip = vehicle;
                }
                else if (checkBoxCal.Checked)
                {
                    var special = new SpecialTool
                    {
                        Name = textBoxEQName.Text.Trim(),
                        Type = "General",
                        Status = InvStatus.In,
                        InDate = DateTime.Now,
                        OutDate = null,
                        Remarks = richTextBoxRemarks.Text,
                        CalDate = dateTimePickerCalDate.Value,
                        CalDue = dateTimePickerCalDue.Value,
                        CertRequired = needCert,
                        Included = included,
                        CheckoutRecords = new BindingList<CheckoutRecord>()
                    };
                    special.SToolID = special.GenerateID();
                    newEquip = special;
                }
                else
                {
                    var basic = new BasicTools
                    {
                        Name = textBoxEQName.Text.Trim(),
                        Status = InvStatus.In,
                        InDate = DateTime.Now,
                        OutDate = null,
                        Remarks = richTextBoxRemarks.Text,
                        Included = included,
                        CheckoutRecords = new BindingList<CheckoutRecord>()
                    };
                    basic.ToolID = basic.GenerateID();
                    newEquip = basic;
                }

                // Create initial checkout record showing "In" status
                var initialRecord = new CheckoutRecord
                {
                    RecordID = Guid.NewGuid().ToString(),
                    EmpID = currentUser.EmpID,       // default user for initial record
                    DateOut = null,
                    DateIn = DateTime.Now,
                    Condition = "Good"
                };
                newEquip.CheckoutRecords.Add(initialRecord);

                // Add to trackables
                trackables.Add(newEquip);

                // Refresh inventory list
                FormUtilities.LoadInventoryList(ref trackables, Instance);
                FormUtilities.LoadEquipMainLIst(ref trackables, Instance);
                listBoxInventory.SelectedItem = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxInventory.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            if (listBoxInventory.SelectedItem is ITrackable selected)
            {
                // Make sure deletedTrackables list is not empty
                if (deletedTrackables == null)
                    deletedTrackables = new List<ITrackable>();

                // Make sure trackables is not empty
                if (trackables == null)
                {
                    MessageBox.Show("Inventory list is not loaded.");
                    return;
                }

                // Remove from active list
                trackables.Remove(selected);

                // Add to deleted list
                deletedTrackables.Add(selected);

                // Refresh UI
                FormUtilities.LoadInventoryList(ref trackables, this);
                FormUtilities.LoadEquipMainLIst(ref trackables, Instance);
                MessageBox.Show("Equipment and Records successfully removed", "Deleted", MessageBoxButtons.OK);
            }
        }

        private void buttonUpdateEQ_Click(object sender, EventArgs e)
        {
            if (listBoxInventory.SelectedItem == null) // make sure we have something selected
            {
                MessageBox.Show("No item selected.", "Error");
                return;
            }
            if (currentUser == null) // Make sure we have the correct user
            {
                MessageBox.Show("Current user not set.", "Error");
                return;
            }
            if (trackables == null) // Make sure there is something in the list
            {
                MessageBox.Show("Trackables list is null.", "Error");
                return;
            }
            if (db == null) // Make we connected to a DB
            {
                MessageBox.Show("Database object is null.", "Error");
                return;
            }

            var trackableSelected = listBoxInventory.SelectedItem as ITrackable;
            if (trackableSelected == null) // Makes sure its a piece of equip
            {
                MessageBox.Show("Selected item is not a valid trackable.", "Error");
                return;
            }

            if (trackableSelected.CheckoutRecords == null) // if no record exist we make some so the program doesn't crash
            {
                trackableSelected.CheckoutRecords = new BindingList<CheckoutRecord>();
            }


            var included = checkBoxEQIncluded.Checked // More null checks and empty list building
                ? richTextBoxIncluded.Text.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).ToList()
                : new List<string>();

            bool needCert = checkBoxCert.Checked;

            if (!(listBoxInventory.SelectedItem is ITrackable selected)) return;

            var newStatus = FormUtilities.GetSelectedStatus(Instance);

            switch (selected)
            {
                case BasicTools ubt:
                    {
                        var open = FormUtilities.GetOpenRecord(ubt);

                        ubt.Name = textBoxEQName.Text.Trim();
                        ubt.Status = newStatus;
                        ubt.Remarks = richTextBoxRemarks.Text;
                        ubt.Included = included;

                        if (ubt.Status == InvStatus.Missing || ubt.Status == InvStatus.OutForService)
                        {
                            // keep last known OutDate if any
                            ubt.InDate = null;
                            ubt.OutDate = open?.DateOut;
                        }
                        else if (ubt.Status == InvStatus.Out)
                        {
                            // already out? keep the original DateOut; otherwise create a new checkout
                            if (open == null)
                            {
                                var now = DateTime.Now;
                                var newRec = new CheckoutRecord
                                {
                                    RecordID = Guid.NewGuid().ToString(),
                                    EmpID = currentUser?.EmpID ?? "System",
                                    DateOut = now,
                                    DateIn = null,
                                    Condition = $"Checked out to {currentUser?.Name ?? "System"}"
                                };
                                ubt.CheckoutRecords.Add(newRec);
                                ubt.OutDate = now;
                            }
                            else
                            {
                                ubt.OutDate = open.DateOut;
                            }
                            ubt.InDate = null;
                        }
                        else // In
                        {
                            var now = DateTime.Now;
                            ubt.InDate = now;
                            ubt.OutDate = null;
                            if (open != null) open.DateIn = now; // close the open record
                        }
                        break;
                    }

                case SpecialTool ust:
                    {
                        var open = FormUtilities.GetOpenRecord(ust);

                        ust.Name = textBoxEQName.Text.Trim();
                        ust.Type = "General";
                        ust.Status = newStatus;
                        ust.Remarks = richTextBoxRemarks.Text;
                        ust.CalDate = dateTimePickerCalDate.Value;
                        ust.CalDue = dateTimePickerCalDue.Value;
                        ust.CertRequired = needCert;
                        ust.Included = included;

                        if (ust.Status == InvStatus.Missing || ust.Status == InvStatus.OutForService)
                        {
                            ust.InDate = null;
                            ust.OutDate = open?.DateOut;
                        }
                        else if (ust.Status == InvStatus.Out)
                        {
                            if (open == null)
                            {
                                var now = DateTime.Now;
                                var newRec = new CheckoutRecord
                                {
                                    RecordID = Guid.NewGuid().ToString(),
                                    EmpID = currentUser?.EmpID ?? "System",
                                    DateOut = now,
                                    DateIn = null,
                                    Condition = $"Checked out to {currentUser?.Name ?? "System"}"
                                };
                                ust.CheckoutRecords.Add(newRec);
                                ust.OutDate = now;
                            }
                            else
                            {
                                ust.OutDate = open.DateOut;
                            }
                            ust.InDate = null;
                        }
                        else
                        {
                            var now = DateTime.Now;
                            ust.InDate = now;
                            ust.OutDate = null;
                            if (open != null) open.DateIn = now;
                        }
                        break;
                    }

                case Vehicle uvt:
                    {
                        var open = FormUtilities.GetOpenRecord(uvt);

                        uvt.Make = textBoxMake.Text.Trim();
                        uvt.Model = textBoxModel.Text.Trim();
                        uvt.Year = int.TryParse(textBoxYear.Text, out var y) ? y : 0;
                        uvt.SerialNum = textBoxSN.Text.Trim();
                        uvt.Status = newStatus;
                        uvt.Remarks = richTextBoxRemarks.Text;
                        uvt.CertRequired = needCert;

                        if (uvt.Status == InvStatus.Missing || uvt.Status == InvStatus.OutForService)
                        {
                            uvt.InDate = null;
                            uvt.OutDate = open?.DateOut;
                        }
                        else if (uvt.Status == InvStatus.Out)
                        {
                            if (open == null)
                            {
                                var now = DateTime.Now;
                                var newRec = new CheckoutRecord
                                {
                                    RecordID = Guid.NewGuid().ToString(),
                                    EmpID = currentUser?.EmpID ?? "System",
                                    DateOut = now,
                                    DateIn = null,
                                    Condition = $"Checked out to {currentUser?.Name ?? "System"}"
                                };
                                uvt.CheckoutRecords.Add(newRec);
                                uvt.OutDate = now;
                            }
                            else
                            {
                                uvt.OutDate = open.DateOut;
                            }
                            uvt.InDate = null;
                        }
                        else
                        {
                            var now = DateTime.Now;
                            uvt.InDate = now;
                            uvt.OutDate = null;
                            if (open != null) open.DateIn = now;
                        }
                        break;
                    }
            }

            // Refresh UI and keep selection
            var previouslySelected = listBoxInventory.SelectedItem;
            FormUtilities.LoadInventoryList(ref trackables, Instance);
            FormUtilities.LoadEquipMainLIst(ref trackables, Instance);
            FormUtilities.LoadCheckoutsInventory(selected, Instance);
            listBoxInventory.SelectedItem = previouslySelected;
        }

        // User Tab

        // Reports tab
        private void comboBoxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supervisor sup = null;

            if (currentUser.Role == Roles.Supervisor) // Make sure the current User is a supervisor
            {
                sup = new Supervisor( // Build Supervisor object to allow access to reports
                    currentUser.EmpID,
                    currentUser.Name,
                    currentUser.Email,
                    currentUser.Phone,
                    currentUser.Status,
                    currentUser.Title,
                    currentUser.PasswordHash,
                    currentUser.PasswordSalt
                );
            }

            if (sup == null)
            {
                MessageBox.Show("You must be a supervisor to generate reports.");
                return;
            }

            var selectedReport = comboBoxReports.SelectedItem as EnumItem<ReportType>; // Convert the combobox item to ReportType

            if (selectedReport != null)
            {
                ReportType reportType = selectedReport.Value;
                richTextBoxReports.Text = sup.GenerateReports(reportType);
            }
        }

        // Admin tab

        // When we close the application
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save session/logout info before the app closes
            if (UserSession.Instance.CurrentUser != null)
            {
                if (trackables != null)
                    db.SaveTrackables(trackables);

                if (employees != null)
                    db.SaveEmployees(employees);

                if (deletedTrackables != null && deletedTrackables.Count > 0)
                {
                    foreach (var deleted in deletedTrackables)
                    {
                        db.DeleteTrackable(deleted);
                    }
                    deletedTrackables.Clear();
                }

                // Clear user session (check before calling)
                if (currentUser != null)
                    currentUser.LogOut();
            }
        }


    }
}

