using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEIS400_ECS
{
    public class Supervisor : Employee
    {
        public Supervisor(string empID, string name, string email, string phone, EmpStatus status, string title, string passwordHash, string passwordSalt)
            : base(empID, name, email, phone, status, title, passwordHash, passwordSalt, Roles.Supervisor, Roles.None)
        {
            
        }

        private void IsSupervisor() // Make sure logged in user is supervisor
        {
            if (Role != Roles.Supervisor)
            {
                throw new UnauthorizedAccessException("Only a supervisor can perform this action");
            }
        }

        public string GenerateReports(ReportType reportType) // Supervisor generates reports
        {
            IsSupervisor();

            string sql = string.Empty;

            switch (reportType) // Report type enum links to SQL queries in Reports class
            {
                case ReportType.Missing:
                    sql = Reports.GetMissingItems();
                    break;

                case ReportType.OutForService:
                    sql = Reports.GetOutForServiceItems();
                    break;

                case ReportType.Overdue:
                    sql = Reports.GetOverdueItems();
                    break;

                case ReportType.DueCal:
                    sql = Reports.GetCalDueItems();
                    break;

                default:
                    throw new Exception("Unknown report type");
            }

            var dt = DatabaseAccess.RunQuery(sql); // Run the Query

            var result = FormatDataTable(dt); // Build the data table

            return result;
        }

        private string FormatDataTable(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return "No records found.";

            int colCount = dt.Columns.Count;
            int[] colWidths = new int[colCount];

            // Calculate max width for each column (including header)
            for (int i = 0; i < colCount; i++)
            {
                int maxWidth = dt.Columns[i].ColumnName.Length;
                foreach (DataRow row in dt.Rows)
                {
                    object val = row[i];
                    string str;
                    if (val == DBNull.Value || val == null)
                        str = "NULL";
                    else if (val is DateTime dtVal)
                        str = dtVal.ToString("MM/dd/yyyy");
                    else
                        str = val.ToString();

                    if (str.Length > maxWidth)
                        maxWidth = str.Length;
                }
                colWidths[i] = maxWidth + 2; // Add padding
            }

            var sb = new StringBuilder();

            // Header row
            sb.Append("|");
            for (int i = 0; i < colCount; i++)
                sb.Append(" " + dt.Columns[i].ColumnName.PadRight(colWidths[i] - 1) + "|");
            sb.AppendLine();

            // Separator row
            sb.Append("|");
            for (int i = 0; i < colCount; i++)
                sb.Append(new string('-', colWidths[i]) + "|");
            sb.AppendLine();

            // Data rows
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("|");
                for (int i = 0; i < colCount; i++)
                {
                    object val = row[i];
                    string str;
                    if (val == DBNull.Value || val == null)
                        str = "NULL";
                    else if (val is DateTime dtVal)
                        str = dtVal.ToString("MM/dd/yyyy");
                    else
                        str = val.ToString();

                    sb.Append(" " + str.PadRight(colWidths[i] - 1) + "|");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void PlaceHold(Employee employee)
        {
            IsSupervisor();
            employee.Status = EmpStatus.Hold;
        }

        public void AssignCerts(Customer employee, ITrackable certToAdd)
        {
            IsSupervisor();
            // Assign Certs to customer accounts
            if (!employee.Certs.Contains(certToAdd))
            {
                employee.Certs.Add(certToAdd);
                MessageBox.Show("Success", $"{certToAdd} added to {employee.Name}");
            }
            else
            {
                MessageBox.Show("Attention", "Employee currently has certification", MessageBoxButtons.OK);
            }
        }

        public void UpdateCerts()
        {
            IsSupervisor();
            // Update certs to customer accounts. Cert could be suspended or pending.
            // For future use, May require Certification class to manage expiration dates, certified date, etc.
        }

        public void RevokeCerts(Customer employee, ITrackable certToRemove)
        {
            IsSupervisor();
            // Delete cert from customer account
            if (employee.Certs.Contains(certToRemove))
            {
                employee.Certs.Remove(certToRemove);
            }
            else
            {
                MessageBox.Show("Attention", "Employee currently does not have certification", MessageBoxButtons.OK);
            }
        }
    }
}
