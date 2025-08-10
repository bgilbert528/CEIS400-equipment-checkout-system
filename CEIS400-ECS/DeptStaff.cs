using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
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
            source.CheckIn(ref records, index, customer);
        }
        // Add that equip back into the system
    }

    public void CheckOutEquip(ITrackable source, Customer customer)
    {
        // Checks for DeptStaff role
        if (Role == Roles.DeptStaff || SecondRole.HasValue && SecondRole == Roles.DeptStaff)
        {
            // Checks if customer is Active to checkout
            if (customer.Status == EmpStatus.Active)
            {
                // Checks if the item is a vehicle
                if (source is Vehicle vehicle)
                {
                    // Checks if the vehicle requires a cert to checkout
                    if (vehicle.CertRequired == true)
                    {
                        // Checks if customer has required cert
                        bool certified = customer.IsCertified(vehicle);
                        if (certified)
                        {
                            source.CheckOut(customer);
                        }
                        else
                        {
                            MessageBox.Show("Denied", "Not certified for checkout", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        source.CheckOut(customer);
                    }
                }

                if (source is SpecialTool specialTool)
                {
                    if (specialTool.CertRequired == true)
                    {
                        bool certified = customer.IsCertified(specialTool);
                        if (certified)
                        {
                            source.CheckOut(customer);
                        }
                        else
                        {
                            MessageBox.Show("Denied", "Not certified for checkout", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        source.CheckOut(customer);
                    }
                }

                if (source is BasicTools basicTool)
                {
                    source.CheckOut(customer);
                }
            }
            else if (customer.Status == EmpStatus.Hold)
            {
                MessageBox.Show("Denied", "Account on hold. Please see Supervisor for details");
            }
            else
            {
                MessageBox.Show("Denied", "Account removed");
            }
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
