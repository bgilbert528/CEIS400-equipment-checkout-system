using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public class DatabaseAccess
    {
        private string _connection;

        // Constructor to create a DB instance and connect to the SQL DB
        public DatabaseAccess(string connection)
        {
            _connection = connection;
        }

        // Query method that only requires the SQL code as a string
        // example use db.Query("SELECT * FROM Employees")
        // Can be used with any SQL Query
        public DataTable Query(string sql)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable dTable = new DataTable();
                adapter.Fill(dTable);
                return dTable;
            }
        }

        // Excute method performs INSERT, UPDATE and DELETE SQL functions
        // example use db.Execute("INSERT INTO Employees (EmpID, Name, Email) VALUES ('10001', 'John Doe', 'john@gamil.com')");
        public int Execute(string sql)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
