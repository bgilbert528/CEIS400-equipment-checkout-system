using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEIS400_ECS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            // Initialize DB connection
            DatabaseAccess db = new DatabaseAccess();

            // Load DB Data
            BindingList<ITrackable> trackables = db.LoadTrackables();
            BindingList<Employee> employees = db.LoadEmployees(trackables);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // This is for when the user closes, the program will save to the DB
            Login login = new Login(db, trackables, employees);
            if (login.ShowDialog() == DialogResult.OK)
            {
                Form1 form = new Form1(login.loggedInUser, db, trackables, employees);
                Application.Run(form);
            }
        }
    }
}
