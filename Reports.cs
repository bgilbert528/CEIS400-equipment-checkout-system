using MySql.Data.MySqlClient;
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CEIS400_ECS
{
    public class Reports
    {
        private static string _connection = CONST.DB_CONN;


        // Methods for generating reports
        // These can be modified or other report methods can be added
        public static string GetOverdueItems()
        {
            string sql = $@"
        SELECT bt.ToolID AS ID, bt.Name, bt.Included, bt.Remarks, bt.InDate, bt.OutDate, bt.Status,
               DATEDIFF(NOW(), bt.OutDate) AS DaysOut
        FROM basictools bt
        WHERE bt.Status = 'Out' AND DATEDIFF(NOW(), bt.OutDate) >= {CONST.DAYS_LATE_FLAG}
            UNION ALL
        SELECT st.SToolID AS ID, st.Name, st.Included, st.Remarks, st.InDate, st.OutDate, st.Status,
               DATEDIFF(NOW(), st.OutDate) AS DaysOut
        FROM specialtools st
        WHERE st.Status = 'Out' AND DATEDIFF(NOW(), st.OutDate) >= {CONST.DAYS_LATE_FLAG}
            UNION ALL
        SELECT v.VehicleID AS ID, v.Make AS Name, v.Model AS Included, v.Remarks, v.InDate, v.OutDate, v.Status,
               DATEDIFF(NOW(), v.OutDate) AS DaysOut
        FROM vehicles v
        WHERE v.Status = 'Out' AND DATEDIFF(NOW(), v.OutDate) >= {CONST.DAYS_LATE_FLAG}
            ;" ;

            return sql;
        }

        public static string GetMissingItems()
        {
            string sql = @"
        SELECT bt.ToolID AS ID, bt.Name, bt.OutDate, bt.Status
        FROM basictools bt
        WHERE bt.Status = 'Missing'
        UNION ALL
        SELECT st.SToolID AS ID, st.Name, st.OutDate, st.Status
        FROM specialtools st
        WHERE st.Status = 'Missing'
        UNION ALL
        SELECT v.VehicleID AS ID, v.Make AS Name, v.OutDate, v.Status
        FROM vehicles v
        WHERE v.Status = 'Missing';";
            return sql;
        }

        public static string GetOutForServiceItems()
        {
            string sql = @"SELECT bt.Name, bt.Included, bt.Remarks, bt.InDate, bt.OutDate, bt.Status
        FROM basictools bt
        WHERE bt.Status = 'OutForService'
        UNION ALL
        SELECT st.Name, st.Included, st.Remarks, st.InDate, st.OutDate, st.Status
        FROM specialtools st
        WHERE st.Status = 'OutForService'
        UNION ALL
        SELECT v.Make AS Name, v.Model AS Included, v.Remarks, v.InDate, v.OutDate, v.Status
        FROM vehicles v
        WHERE v.Status = 'OutForService';";
            return sql;
        }

        public static string GetCalDueItems()
        {
            string sql = @"
        SELECT SToolID AS ID, Name, Type, Remarks, CalDate, CalDue, Included, CertRequired, InDate, OutDate, Status
        FROM specialtools
        WHERE CalDue <= NOW();";
            return sql;
        }
    }
}
