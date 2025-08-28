using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CEIS400_ECS
{
    public class DatabaseAccess
    {
        private string _connection;

        // Constructor to create a DB instance and connect to the SQL DB
        public DatabaseAccess()
        {
            _connection = CONST.DB_CONN;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connection);
        }

        public BindingList<Employee> LoadEmployees(BindingList<ITrackable> trackables)
        {
            var list = new BindingList<Employee>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(CONST.SQL_LOAD_EMPLOYEES, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Roles roleCheck = System.Enum.TryParse(reader["Role"]?.ToString(), out Roles parsedRole)
                            ? parsedRole
                            : Roles.None;

                        Roles? secondRole = null;
                        if (!reader.IsDBNull(reader.GetOrdinal("SecondRole")))
                        {
                            if (System.Enum.TryParse(reader["SecondRole"].ToString(), out Roles parsedSecondRole))
                                secondRole = parsedSecondRole;
                        }

                        // Read password hash and salt directly as strings
                        string passwordHash = !reader.IsDBNull(reader.GetOrdinal("Password"))
                            ? reader.GetString(reader.GetOrdinal("Password"))
                            : string.Empty;

                        string passwordSalt = !reader.IsDBNull(reader.GetOrdinal("PasswordSalt"))
                            ? reader.GetString(reader.GetOrdinal("PasswordSalt"))
                            : string.Empty;

                        var baseEmp = new Employee
                        {
                            EmpID = reader["EmpID"]?.ToString() ?? string.Empty,
                            Name = reader["Name"]?.ToString() ?? string.Empty,
                            Email = reader["Email"]?.ToString() ?? string.Empty,
                            Phone = reader["Phone"]?.ToString() ?? string.Empty,
                            Title = reader["Title"]?.ToString() ?? string.Empty,
                            Status = System.Enum.TryParse(reader["Status"]?.ToString(), out EmpStatus empStatus)
                                ? empStatus
                                : EmpStatus.Terminated,
                            Role = roleCheck,
                            SecondRole = secondRole ?? null,
                            PasswordHash = passwordHash,
                            PasswordSalt = passwordSalt
                        };

                        // Customer-specific
                        if (roleCheck == Roles.Customer)
                        {
                            var cust = new Customer(
                                baseEmp.EmpID,
                                baseEmp.Name,
                                baseEmp.Email,
                                baseEmp.Phone,
                                baseEmp.Status,
                                baseEmp.Title,
                                baseEmp.PasswordHash,
                                baseEmp.PasswordSalt,
                                null,
                                null);

                            // Certs
                            string certsRaw = reader["Certs"]?.ToString() ?? "";
                            List<string> certsID = certsRaw.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            cust.Certs = trackables.Where(t => certsID.Contains(t.Source)).ToList();

                            // OutItems
                            string outItemsRaw = reader["OutItems"]?.ToString() ?? "";
                            List<string> outItemsID = outItemsRaw.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            cust.OutItems = trackables.Where(t => outItemsID.Contains(t.Source)).ToList();

                            list.Add(cust);
                        }
                        else
                        {
                            list.Add(baseEmp);
                        }
                    }
                }
            }

            return list;
        }

        public BindingList<ITrackable> LoadTrackables()
        {
            var items = new BindingList<ITrackable>();
            using (var conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(CONST.SQL_LOAD_TRACKABLES, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sourceID = reader["TrackableID"].ToString();
                    var checkoutRecords = LoadCheckoutRecords(sourceID);

                    ITrackable trackable = null;

                    if (!reader.IsDBNull(reader.GetOrdinal("BasicToolID")))
                    {
                        trackable = new BasicTools
                        {
                            SourceID = sourceID,
                            ToolID = reader["BasicToolID"].ToString(),
                            Name = reader["BasicToolName"]?.ToString() ?? "",
                            Included = reader["BasicToolIncluded"] == DBNull.Value
                                ? new List<string>()
                                : reader["BasicToolIncluded"].ToString().Split(',').ToList(),
                            Remarks = reader["BasicToolRemarks"]?.ToString() ?? "",
                            InDate = reader["BasicToolInDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["BasicToolInDate"]),
                            OutDate = reader["BasicToolOutDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["BasicToolOutDate"]),
                            Status = (InvStatus)System.Enum.Parse(typeof(InvStatus), reader["BasicToolStatus"].ToString()),
                            CheckoutRecords = checkoutRecords
                        };
                    }
                    else if (!reader.IsDBNull(reader.GetOrdinal("SpecialToolID")))
                    {
                        trackable = new SpecialTool
                        {
                            SourceID = sourceID,
                            SToolID = reader["SpecialToolID"].ToString(),
                            Name = reader["SpecialToolName"]?.ToString() ?? "",
                            Type = reader["SpecialToolType"]?.ToString() ?? "",
                            Status = (InvStatus)System.Enum.Parse(typeof(InvStatus), reader["SpecialToolStatus"].ToString()),
                            InDate = reader["SpecialToolInDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SpecialToolInDate"]),
                            OutDate = reader["SpecialToolOutDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SpecialToolOutDate"]),
                            Remarks = reader["SpecialToolRemarks"]?.ToString() ?? "",
                            CalDate = reader["SpecialToolCalDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SpecialToolCalDate"]),
                            CalDue = reader["SpecialToolCalDue"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["SpecialToolCalDue"]),
                            CertRequired = reader["SpecialToolCertRequired"] != DBNull.Value && Convert.ToBoolean(reader["SpecialToolCertRequired"]),
                            Included = reader["SpecialToolIncluded"] == DBNull.Value
                                ? new List<string>()
                                : reader["SpecialToolIncluded"].ToString().Split(',').ToList(),
                            CheckoutRecords = checkoutRecords
                        };
                    }
                    else if (!reader.IsDBNull(reader.GetOrdinal("VehicleID")))
                    {
                        trackable = new Vehicle
                        {
                            SourceID = sourceID,
                            VehicleID = reader["VehicleID"].ToString(),
                            Make = reader["VehicleMake"]?.ToString() ?? "",
                            Model = reader["VehicleModel"]?.ToString() ?? "",
                            Year = reader["VehicleYear"] == DBNull.Value ? 0 : Convert.ToInt32(reader["VehicleYear"]),
                            SerialNum = reader["VehicleSerialNum"]?.ToString() ?? "",
                            Status = (InvStatus)System.Enum.Parse(typeof(InvStatus), reader["VehicleStatus"].ToString()),
                            InDate = reader["VehicleInDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["VehicleInDate"]),
                            OutDate = reader["VehicleOutDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["VehicleOutDate"]),
                            Remarks = reader["VehicleRemarks"]?.ToString() ?? "",
                            CertRequired = reader["VehicleCertRequired"] != DBNull.Value && Convert.ToBoolean(reader["VehicleCertRequired"]),
                            CheckoutRecords = checkoutRecords
                        };
                    }

                    if (trackable != null)
                    {
                        trackable.ReLinkCheckoutRecords();
                        items.Add(trackable);
                    }
                }
            }
            return items;
        }


        public void SaveTrackables(BindingList<ITrackable> items)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                foreach (var t in items)
                {
                    string trackableID;

                    if (t is BasicTools bt)
                    {
                        if (string.IsNullOrEmpty(bt.ToolID))
                            bt.ToolID = bt.GenerateID();
                        trackableID = bt.ToolID;
                    }
                    else if (t is SpecialTool st)
                    {
                        if (string.IsNullOrEmpty(st.SToolID))
                            st.SToolID = st.GenerateID();
                        trackableID = st.SToolID;
                    }
                    else if (t is Vehicle v)
                    {
                        if (string.IsNullOrEmpty(v.VehicleID))
                            v.VehicleID = v.GenerateID();
                        trackableID = v.VehicleID;
                    }
                    else
                    {
                        throw new Exception("Unknown trackable type");
                    }

                    t.SourceID = trackableID;

                    // Save trackable data
                    string jsonCheckouts = JsonSerializer.Serialize(t.CheckoutRecords.Select(r =>
                    {
                        if (string.IsNullOrEmpty(r.RecordID))
                            r.RecordID = Guid.NewGuid().ToString();

                        return new
                        {
                            r.RecordID,
                            r.EmpID,
                            r.DateOut,
                            r.DateIn,
                            r.Condition
                        };
                    }));

                    using (var cmd = new MySqlCommand(CONST.SAVE_SQL_TRACKABLES, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", trackableID);
                        cmd.Parameters.AddWithValue("@Source", t.Source ?? trackableID);
                        cmd.Parameters.AddWithValue("@Barcode", t.Barcode ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CheckoutRecords", jsonCheckouts);
                        cmd.ExecuteNonQuery();
                    }

                    // Save child-specific tables
                    switch (t)
                    {
                        case BasicTools b:
                            using (var cmd = new MySqlCommand(CONST.SAVE_SQL_BASIC, conn))
                            {
                                cmd.Parameters.AddWithValue("@ID", b.ToolID);
                                cmd.Parameters.AddWithValue("@Name", b.Name);
                                cmd.Parameters.AddWithValue("@Included", b.Included != null ? string.Join(",", b.Included) : "");
                                cmd.Parameters.AddWithValue("@Remarks", b.Remarks);
                                cmd.Parameters.AddWithValue("@InDate", b.InDate);
                                cmd.Parameters.AddWithValue("@OutDate", b.OutDate);
                                cmd.Parameters.AddWithValue("@Status", b.Status.ToString());
                                cmd.ExecuteNonQuery();
                            }
                            break;

                        case SpecialTool s:
                            using (var cmd = new MySqlCommand(CONST.SAVE_SQL_SPECIAL, conn))
                            {
                                cmd.Parameters.AddWithValue("@ID", s.SToolID);
                                cmd.Parameters.AddWithValue("@Name", s.Name);
                                cmd.Parameters.AddWithValue("@Type", s.Type);
                                cmd.Parameters.AddWithValue("@Included", s.Included != null ? string.Join(",", s.Included) : "");
                                cmd.Parameters.AddWithValue("@Remarks", s.Remarks);
                                cmd.Parameters.AddWithValue("@InDate", s.InDate);
                                cmd.Parameters.AddWithValue("@OutDate", s.OutDate);
                                cmd.Parameters.AddWithValue("@Status", s.Status.ToString());
                                cmd.Parameters.AddWithValue("@CalDate", s.CalDate);
                                cmd.Parameters.AddWithValue("@CalDue", s.CalDue);
                                cmd.Parameters.AddWithValue("@CertRequired", s.CertRequired);
                                cmd.ExecuteNonQuery();
                            }
                            break;

                        case Vehicle ve:
                            using (var cmd = new MySqlCommand(CONST.SAVE_SQL_VEHICLES, conn))
                            {
                                cmd.Parameters.AddWithValue("@ID", ve.VehicleID);
                                cmd.Parameters.AddWithValue("@Make", ve.Make);
                                cmd.Parameters.AddWithValue("@Model", ve.Model);
                                cmd.Parameters.AddWithValue("@Year", ve.Year);
                                cmd.Parameters.AddWithValue("@SerialNum", ve.SerialNum);
                                cmd.Parameters.AddWithValue("@Remarks", ve.Remarks);
                                cmd.Parameters.AddWithValue("@CertRequired", ve.CertRequired);
                                cmd.Parameters.AddWithValue("@InDate", ve.InDate);
                                cmd.Parameters.AddWithValue("@OutDate", ve.OutDate);
                                cmd.Parameters.AddWithValue("@Status", ve.Status.ToString());
                                cmd.ExecuteNonQuery();
                            }
                            break;
                    }

                    // Save checkout records last
                    SaveCheckoutRecords(t);
                }
            }
        }


        private BindingList<CheckoutRecord> LoadCheckoutRecords(string trackableID)
        {
            var records = new BindingList<CheckoutRecord>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM checkoutrecords WHERE Source = @TrackableID";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TrackableID", trackableID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            records.Add(new CheckoutRecord
                            {
                                RecordID = reader["RecordID"].ToString(),
                                EmpID = reader["EmpID"].ToString(),
                                DateOut = reader["DateOut"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateOut"]),
                                DateIn = reader["DateIn"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DateIn"]),
                                Condition = reader["Condition"] == DBNull.Value ? "" : reader["Condition"].ToString(),
                                // Source is set later to avoid cycles
                            });
                        }
                    }
                }
            }

            return records;
        }

        private void SaveCheckoutRecords(ITrackable trackable)
        {
            if (trackable == null || trackable.CheckoutRecords == null) return;

            using (var conn = GetConnection())
            {
                conn.Open();

                foreach (var record in trackable.CheckoutRecords)
                {
                    if (string.IsNullOrEmpty(record.RecordID))
                        record.RecordID = Guid.NewGuid().ToString();

                    string sql = @"
                INSERT INTO checkoutrecords (RecordID, Source, EmpID, `Condition`, DateOut, DateIn)
VALUES (@RecordID, @Source, @EmpID, @Condition, @DateOut, @DateIn)
ON DUPLICATE KEY UPDATE
    EmpID = @EmpID,
    DateOut = @DateOut,
    DateIn = @DateIn,
    `Condition` = @Condition;
            ";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RecordID", record.RecordID);
                        cmd.Parameters.AddWithValue("@Source", trackable.SourceID);
                        cmd.Parameters.AddWithValue("@EmpID", record.EmpID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DateOut", record.DateOut ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DateIn", record.DateIn ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Condition", record.Condition ?? "");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void SaveEmployees(BindingList<Employee> emp)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                foreach (var e in emp)
                {
                    using (var cmd = new MySqlCommand(CONST.SAVE_SQL_EMPLOYEES, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpID", e.EmpID);
                        cmd.Parameters.AddWithValue("@Name", e.Name);
                        cmd.Parameters.AddWithValue("@Email", e.Email);
                        cmd.Parameters.AddWithValue("@Phone", e.Phone);
                        cmd.Parameters.AddWithValue("@Status", e.Status.ToString());
                        cmd.Parameters.AddWithValue("@Title", e.Title);
                        cmd.Parameters.AddWithValue("@Password", e.PasswordHash);
                        cmd.Parameters.AddWithValue("@PasswordSalt", e.PasswordSalt);
                        cmd.Parameters.AddWithValue("@Role", e.Role.ToString());
                        cmd.Parameters.AddWithValue("@SecondRole",  e.SecondRole.ToString() ?? (object)DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    // If Customer
                    if (e is Customer cust)
                    {
                        using (var cmd = new MySqlCommand(CONST.SAVE_SQL_CUSTOMER, conn))
                        {
                            cmd.Parameters.AddWithValue("@Certs", JsonSerializer.Serialize(cust.Certs.Select(t => t.Source.ToString())));
                            cmd.Parameters.AddWithValue("@OutItems", JsonSerializer.Serialize(cust.OutItems.Select(t => t.Source.ToString())));
                        }
                    }
                }
                
            }
        }

        public void DeleteTrackable(ITrackable item)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand("DELETE FROM trackable WHERE ID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", item.SourceID);
                    cmd.ExecuteNonQuery();
                }

                // Optionally delete from subtype tables
                if (item is BasicTools bt)
                {
                    using (var cmd = new MySqlCommand("DELETE FROM basictools WHERE ToolID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", bt.ToolID);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (item is SpecialTool st)
                {
                    using (var cmd = new MySqlCommand("DELETE FROM specialtools WHERE SToolID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", st.SToolID);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (item is Vehicle v)
                {
                    using (var cmd = new MySqlCommand("DELETE FROM vehicles WHERE VehicleID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", v.VehicleID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Query method that only requires the SQL code as a string
        // example use db.Query("SELECT * FROM Employees")
        // Can be used with any SQL Query
        public static DataTable RunQuery(string sql)
        {
            using (MySqlConnection connection = new MySqlConnection(CONST.DB_CONN))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataTable dTable = new DataTable();
                adapter.Fill(dTable);
                return dTable;
            }
        }
        // Excute method performs INSERT, UPDATE and DELETE SQL functions
        // example use db.Execute("INSERT INTO Employees (EmpID, Name, Email) VALUES ('10001', 'John Doe', 'john@gamil.com')");
        public int Execute(string sql)
        {
            using (MySqlConnection connection = new MySqlConnection(_connection))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}