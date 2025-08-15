using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CEIS400_ECS
{
    public class Reports
    {
        private string _connection = "Add SQL Server/DB here";

        private List<ITrackable> GetEquipFromDB()
        {
            // Needs SQL Commands to be added
            List<ITrackable> equipment = new List<ITrackable>();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Add SQl Query herey"); // <--- Needs to completed with SQL commands
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string type = reader["Source"].ToString();
                    ITrackable equipmentItem;

                    switch (type)
                    {
                        // BasicTools
                        case "BasicTools":
                            equipmentItem = new BasicTools
                            {
                                ToolID = reader.GetString(0), // <--- These columns numbers can be replaced with the actual column names in DB
                                Name = reader.GetString(1),
                                InDate = reader.GetDateTime(2),
                                OutDate = reader.GetDateTime(3),
                                Status = (InvStatus)reader.GetValue(reader.GetOrdinal("Status")),
                                Included = reader.GetString(4).Split(',').ToList(),
                                Remarks = reader.GetString(5),
                                CheckoutRecords = JsonSerializer.Deserialize<BindingList<CheckoutRecord>>(reader.GetString(reader.GetOrdinal("CheckoutRecords")))
                            };
                            break;

                        // Special Tools
                        case "SpecialTool":
                            equipmentItem = new SpecialTool
                            {
                                SToolID = reader.GetString(0),
                                Name = reader.GetString(1),
                                Type = reader.GetString(2),
                                Status = (InvStatus)reader.GetValue(reader.GetOrdinal("Status")),
                                InDate = reader.GetDateTime(4),
                                OutDate = reader.GetDateTime(5),
                                Remarks = reader.GetString(6),
                                CalDate = reader.GetDateTime(7),
                                CalDue = reader.GetDateTime(8),
                                CertRequired = reader.GetBoolean(9),
                                Included = reader.GetString(10).Split(',').ToList(),
                                CheckoutRecords = JsonSerializer.Deserialize<BindingList<CheckoutRecord>>(reader.GetString(reader.GetOrdinal("CheckoutRecords")))
                            };
                            break;

                        // Vehicle
                        case "Vehicle":
                            equipmentItem = new Vehicle
                            {
                                VehicleID = reader.GetString(0),
                                Make = reader.GetString(1),
                                Model = reader.GetString(2),
                                Year = reader.GetInt32(3),
                                SerialNum = reader.GetString(4),
                                Status = (InvStatus)reader.GetValue(reader.GetOrdinal("Status")),
                                InDate = reader.GetDateTime(6),
                                OutDate = reader.GetDateTime(7),
                                Remarks = reader.GetString(8),
                                CertRequired = reader.GetBoolean(9),
                                CheckoutRecords = JsonSerializer.Deserialize<BindingList<CheckoutRecord>>(reader.GetString(reader.GetOrdinal("CheckoutRecords")))
                            };
                            break;

                        // Default
                        default:
                            continue;
                    }

                    equipment.Add(equipmentItem);
                }

                return equipment;
            }            
        }

        // Methods for generating reports
        // These can be modified or other report methods can be added
        public List<ITrackable> GetOverDueItems()
        {
            var equip = GetEquipFromDB();
            return equip.Where(e => (DateTime.Now - e.OutDate.Value).TotalDays >= CONST.DAYS_LATE_FLAG).ToList();
        }

        public List<ITrackable> GetMissingItems()
        {
            var equip = GetEquipFromDB();
            return equip.Where(e => e.Status == InvStatus.Missing).ToList();
        }

        public List<ITrackable> GetOutForServiceItems()
        {
            var equip = GetEquipFromDB();
            return equip.Where(e => e.Status == InvStatus.OutForService).ToList();
        }

        public List<SpecialTool> GetCalDueItems()
        {
            return GetEquipFromDB().OfType<SpecialTool>().Where(st => st.DueForCalibration() == true).ToList();
        }
    }
}
