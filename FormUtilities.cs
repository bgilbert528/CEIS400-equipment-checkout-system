using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEIS400_ECS
{
    public class FormUtilities
    {
        // Main Tab lists
        public static void LoadEmpMainList(ref BindingList<Employee> employees, Form1 form)
        {
            // Load out Employees on main page listview
            form.listViewEmpsMain.Items.Clear();

            foreach (Employee e in employees)
            {
                ListViewItem item = new ListViewItem(e.EmpID);
                item.SubItems.Add(e.Name);
                item.SubItems.Add(e.Status.ToString());
                item.Tag = e;
                form.listViewEmpsMain.Items.Add(item);
            }
        }

        public static void LoadEquipMainLIst(ref BindingList<ITrackable> trackables, Form1 form)
        {
            // load equipment on main page list view
            form.listViewEquipMain.Items.Clear();
            
            foreach (ITrackable t in trackables)
            {
                switch(t)
                {
                   case BasicTools bt:
                        ListViewItem item = new ListViewItem(bt.Name);
                        item.SubItems.Add(bt.Status.ToString());
                        item.SubItems.Add(bt.InDate?.ToString("d") ?? string.Empty);
                        item.SubItems.Add(bt.OutDate?.ToString("d") ?? string.Empty);
                        item.SubItems.Add(bt.Remarks);
                        item.Tag = bt;
                        form.listViewEquipMain.Items.Add(item);
                        break;

                    case SpecialTool st:
                        ListViewItem itemST = new ListViewItem(st.Name);
                        itemST.SubItems.Add(st.Status.ToString());
                        itemST.SubItems.Add(st.InDate?.ToString("d") ?? string.Empty);
                        itemST.SubItems.Add(st.OutDate?.ToString("d") ?? string.Empty);
                        itemST.SubItems.Add(st.Remarks);
                        itemST.Tag = st;
                        form.listViewEquipMain.Items.Add(itemST);
                        break;

                    case Vehicle v:
                        string vehicleName = $"{v.Make} {v.Model}";
                        ListViewItem itemV = new ListViewItem(vehicleName);
                        itemV.SubItems.Add(v.Status.ToString());
                        itemV.SubItems.Add(v.InDate?.ToString("d") ?? string.Empty);
                        itemV.SubItems.Add(v.OutDate?.ToString("d") ?? string.Empty);
                        itemV.SubItems.Add(v.Remarks);
                        itemV.Tag = v;
                        form.listViewEquipMain.Items.Add(itemV);
                        break;
                }
            }
        }

        public static void LoadInventoryList(ref BindingList<ITrackable> trackables, Form1 form)
        {
            // load the inventory list in the ListBox
            form.listBoxInventory.DataSource = null; 
            form.listBoxInventory.DataSource = trackables;
            form.listBoxInventory.DisplayMember = "Name"; 
        }

        public static void LoadCheckoutsInventory(ITrackable trackable, Form1 form)
        {
            // Load the checkout records for each equip
            form.listViewCheckouts.Items.Clear();
            foreach (CheckoutRecord record in trackable.CheckoutRecords)
            {
                ListViewItem item = new ListViewItem(record.EmpID);
                item.SubItems.Add(record.DateIn?.ToString("d") ?? string.Empty);
                item.SubItems.Add(record.DateOut?.ToString("d") ?? string.Empty);
                item.SubItems.Add(record.Condition);
                item.Tag = record;
                form.listViewCheckouts.Items.Add(item);
            }
        }

        public static CheckoutRecord GetOpenRecord(ITrackable t)
        {
            // Help us find the open record 
            return t.CheckoutRecords?
                    .OrderByDescending(r => r.DateOut)
                    .FirstOrDefault(r => r.DateIn == null);
        }

        public static InvStatus GetSelectedStatus(Form1 form)
        {
            // Gets the status from the ComboBox
            if (form.comboBoxEQStatus.SelectedItem is InvStatus s) return s;

            var val = form.comboBoxEQStatus.SelectedValue;
            return val is InvStatus es
                ? es
                : (InvStatus)Enum.Parse(typeof(InvStatus), val.ToString());
        }


        public static bool ValidateCheckIn(ITrackable trackable, CheckoutRecord record, Employee currentUser)
        {
            // Validate our check in to make sure we have the right tool, record and employee
            DateTime now = DateTime.Now;
            trackable.InDate = now;
            trackable.OutDate = null;

            if (record == null || record.DateIn != null)
            {
                var lastRec = trackable.CheckoutRecords
                                       .OrderByDescending(r => r.DateOut)
                                       .FirstOrDefault();

                // It could have been checked out Manaully for Service, New Hire, Vendor, etc.
                if (lastRec != null &&
                    (lastRec.EmpID == "System" || lastRec.EmpID == currentUser.EmpID))
                {
                    MessageBox.Show(
                        "This item was manually checked out by the system or current user.\n" +
                        "It must be manually checked in.",
                        "Manual Check-In Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return false; // stop the process
                }

                // If wasn't manually entered then there's no record at all
                MessageBox.Show("No valid open checkout record found.",
                                "Check-In Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // Normal check-in case: close record
            record.DateIn = now;
            return true;
        }
    }
}
