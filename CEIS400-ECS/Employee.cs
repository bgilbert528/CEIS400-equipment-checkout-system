using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ECS
{
    public class Employee
    {
        // Attributes
        protected string _empID;
        protected string _name;
        protected string _email;
        protected string _phone;
        protected EmpStatus _status;
        protected string _title;
        protected string _passwordHash;
        protected string _passwordSalt;

        // Constructors
        public Employee()
        {
            _empID = "";
            _name = "";
            _email = "";
            _phone = "";
            _status = EmpStatus.Active;
            _title = "";
            _passwordHash = Convert.ToBase64String(new byte[0]);
            _passwordSalt = "";
        }

        public Employee(string empID, string name, string email, string phone, EmpStatus status, string title, string passwordHash, string passwordSalt)
        {
            EmpID = empID;
            Name = name;
            Email = email;
            Phone = phone;
            Status = status;
            Title = title;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        // Behaviors
        public bool Login()
        {
            // generate code
            return true;
        }

        public void LogOut()
        {
            // generate code
        }


        // Properties
        public string EmpID { get { return _empID; } set { _empID = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public EmpStatus Status { get { return _status; } set { _status = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string PasswordHash { get { return _passwordHash; } set { _passwordHash = value; } }
        public string PasswordSalt { get { return _passwordSalt; } set { _passwordSalt = value; } }
    }
}
