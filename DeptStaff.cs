using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEIS400_ECS
{
    public class DeptStaff : Employee
    {
        public DeptStaff(string empID, string name, string email, string phone, EmpStatus status, string title, string passwordHash, string passwordSalt)
            : base(empID, name, email, phone, status, title, passwordHash, passwordSalt, Roles.DeptStaff, Roles.None)
        {

        }

        public static void CheckInEquip(ITrackable source, string recordID, Customer customer, Employee user)
        {
            // Role check for DeptStaff
            if (user.Role == Roles.DeptStaff || (user.SecondRole.HasValue && user.SecondRole == Roles.DeptStaff))
            {
                // find the record that matches
                var recordToClose = source.CheckoutRecords.FirstOrDefault(r => r.RecordID == recordID);

                if (recordToClose == null)
                {
                    MessageBox.Show("Error", "Checkout record not found.", MessageBoxButtons.OK);
                    return;
                }

                // If it matches close it
                source.CheckIn(recordToClose, customer); 
                MessageBox.Show("Success", "Check in successful.", MessageBoxButtons.OK);
            }
        }
        public static void CheckOutEquip(ITrackable source, Customer customer, Employee user)
        {
            // Ensure the user has DeptStaff role
            if (!(user.Role == Roles.DeptStaff || (user.SecondRole.HasValue && user.SecondRole == Roles.DeptStaff)))
            {
                MessageBox.Show("Denied", "User is not authorized to check out equipment", MessageBoxButtons.OK);
                return;
            }

            // Checks if customer is Active to checkout
            if (customer.Status != EmpStatus.Active)
            {
                string msg = customer.Status == EmpStatus.Hold
                    ? "Account on hold. Please see Supervisor for details"
                    : "Account removed";
                MessageBox.Show(msg, "Denied");
                return;
            }

            // Checks if tool requires Cert
            bool requiresCert = (source is Vehicle v && v.CertRequired) ||
                                (source is SpecialTool st && st.CertRequired);

            // Checks if customer has required Cert
            if (requiresCert && !customer.IsCertified(source))
            {
                MessageBox.Show("Not certified for checkout", "Denied", MessageBoxButtons.OK);
                return;
            }

            // If Everything is good, then check out
            switch (source)
            {
                case BasicTools bt:
                    bt.CheckOut(customer);
                    break;

                case SpecialTool s:
                    s.CheckOut(customer);
                    break;

                case Vehicle vt:
                    vt.CheckOut(customer);
                    break;
            }

            MessageBox.Show("Check out successful.", "Success", MessageBoxButtons.OK);
        }

        public void UpdateEquip(ITrackable source, List<ITrackable> equipList)
        {
            if (!(Role == Roles.DeptStaff || SecondRole.HasValue && SecondRole == Roles.DeptStaff))
            {
                return;
            }

            // Determine if source is BasicTool, SpecialTool or Vehilce
            ITrackable exisiting = equipList.FirstOrDefault(e =>
            (e is BasicTools bt && source is BasicTools sbt && bt.ToolID == sbt.ToolID) ||
            (e is SpecialTool st && source is SpecialTool sst && st.SToolID == sst.SToolID) ||
            (e is Vehicle v && source is Vehicle svt && v.VehicleID == svt.VehicleID));

            if (exisiting != null)
            {
                // If the source exists at all update the common ITrackable attributes
                exisiting.Status = source.Status;
                exisiting.InDate = source.InDate;
                exisiting.OutDate = source.OutDate;
                exisiting.CheckoutRecords = source.CheckoutRecords;

                // If its a BasicTool update sub-class attributes
                if (exisiting is BasicTools b && source is BasicTools updatedB)
                {
                    b.Name = updatedB.Name;
                    b.Remarks = updatedB.Remarks;
                    b.Included = updatedB.Included;
                }

                // If it is a SpecialTool update sub-class attributes
                else if (exisiting is SpecialTool s && source is SpecialTool updatedS)
                {
                    s.Type = updatedS.Type;
                    s.CalDate = updatedS.CalDate;
                    s.CalDue = updatedS.CalDue;
                    s.Remarks = updatedS.Remarks;
                    s.Included = updatedS.Included;
                    s.CertRequired = updatedS.CertRequired;
                }

                // If it is a Vehilce update sub-class attributes
                else if (exisiting is Vehicle v && source is Vehicle updatedV)
                {
                    v.Make = updatedV.Make;
                    v.Model = updatedV.Model;
                    v.Year = updatedV.Year;
                    v.SerialNum = updatedV.SerialNum;
                    v.CertRequired = updatedV.CertRequired;
                    v.Remarks = updatedV.Remarks;
                }
            }
            // General for updating inventory
            // Could be checked out/in for Repairs/Serrvice
        }
    }
}
