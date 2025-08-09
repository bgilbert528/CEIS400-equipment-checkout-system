using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public class Supervisor : Employee
    {
        public Supervisor(string empID, string name, string email, string phone, EmpStatus status, string title, string passwordHash, string passwordSalt)
            : base(empID, name, email, phone, status, title, passwordHash, passwordSalt, Roles.Supervisor)
        {

        }

        private void IsSupervisor()
        {
            if (Role != Roles.Supervisor)
            {
                throw new UnauthorizedAccessException("Only a supervisor can perform this action");
            }
        }

        public void GenerateReports()
        {

        }

        public void PlaceHold() 
        {
            IsSupervisor();
            // place holds on accounts
        }

        public void AssignCerts()
        {
            IsSupervisor();
            // Assign Certs to customer accounts
        }

        public void UpdateCerts()
        {
            IsSupervisor();
            // Update certs to customer accounts. Cert could be suspended or pending.
        }

        public void RevokeCerts()
        {
            IsSupervisor();
            // Delete cert from customer account
        }
    }
}
