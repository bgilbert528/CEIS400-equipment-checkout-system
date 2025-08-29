using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEIS400_ECS
{
    public partial class Login : Form
    {
        public BindingList<Employee> employees;
        public Employee loggedInUser;
        public DatabaseAccess db;
        public BindingList<ITrackable> trackables;
        public Login(DatabaseAccess db, BindingList<ITrackable> trackables, BindingList<Employee> employees)
        {
            // Load the Login screen
            InitializeComponent();
            this.employees = employees;
            this.db = db;
            this.trackables = trackables;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Logs in the user
            string username = textBoxUN.Text.Trim();
            string password = maskedTextBoxPass.Text.Trim();

            Employee emp = employees.FirstOrDefault(employee => employee.EmpID == username);

            // Make sure we have the right username and password
            // Checks against the Database
            if (emp != null && PasswordControl.VerifyPassword(password, emp.PasswordHash, emp.PasswordSalt))
            {
                loggedInUser = emp;
                Form1 form = new Form1(loggedInUser, db, trackables, employees);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username and/or password", "Invalid", MessageBoxButtons.OK);
            }
        }
    }
}
