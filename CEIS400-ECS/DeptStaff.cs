using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public class DeptStaff : Employee
    {
        public DeptStaff(string empID, string name, string email, string phone, EmpStatus status, string title, string passwordHash, string passwordSalt)
            : base(empID, name, email, phone, status, title, passwordHash, passwordSalt, Roles.DeptStaff)
        {

        }

        public void CheckInEquip(ITrackable source, string recordID, Customer customer)
        {
            if (Role == Roles.DeptStaff || SecondRole.HasValue && SecondRole == Roles.DeptStaff)
            {
                BindingList<CheckoutRecord> records = source.CheckoutRecords;
                CheckoutRecord recordToClose = null;
                recordToClose = records.FirstOrDefault(r => r.RecordID == recordID);
                int index = source.CheckoutRecords.IndexOf(recordToClose);
                source.CheckIn(ref records, index , customer);
            }
            // Add that equip back into the system
        }

        public void CheckOutEquip()
        {
            if (Role == Roles.DeptStaff || SecondRole.HasValue && SecondRole == Roles.DeptStaff)
            {

            }
            // Add checks for certs and account status
            // Add check for equip status
        }

        public void UpdateEquip()
        {
            if (Role == Roles.DeptStaff || SecondRole.HasValue && SecondRole == Roles.DeptStaff)
            {

            }
            // General for updating inventory
            // Could be checked out/in for Repairs/Serrvice
        }
    }
}
