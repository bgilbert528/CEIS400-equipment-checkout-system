using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public class CONST
    {
        // A list of all Constants for the ECS program
        // Limits
        public const int DAYS_LATE_FLAG = 2;

        //MySql DB
        public const string DB_CONN = "Server=localhost;Database=team3ecs;User=root;Password=P@ssw0rd!!!;SslMode=none;";

        // sql queries
        public const string SQL_LOAD_EMPLOYEES = @"
            SELECT e.*, c.Certs, c.OutItems
            FROM employees e
            LEFT JOIN customer c ON e.EmpID = c.EmpID;
        ";

        public const string SQL_LOAD_TRACKABLES = @"
SELECT
    t.ID AS TrackableID,
    t.Source,
    t.Barcode,

    -- BasicTools: pick latest or first
    bt.ToolID AS BasicToolID,
    bt.Name AS BasicToolName,
    bt.Included AS BasicToolIncluded,
    bt.Remarks AS BasicToolRemarks,
    bt.InDate AS BasicToolInDate,
    bt.OutDate AS BasicToolOutDate,
    bt.Status AS BasicToolStatus,

    -- SpecialTools: pick latest or first
    st.SToolID AS SpecialToolID,
    st.Name AS SpecialToolName,
    st.Type AS SpecialToolType,
    st.Included AS SpecialToolIncluded,
    st.Remarks AS SpecialToolRemarks,
    st.CalDate AS SpecialToolCalDate,
    st.CalDue AS SpecialToolCalDue,
    st.CertRequired AS SpecialToolCertRequired,
    st.InDate AS SpecialToolInDate,
    st.OutDate AS SpecialToolOutDate,
    st.Status AS SpecialToolStatus,

    -- Vehicles: pick latest or first
    v.VehicleID AS VehicleID,
    v.Make AS VehicleMake,
    v.Model AS VehicleModel,
    v.Year AS VehicleYear,
    v.SerialNum AS VehicleSerialNum,
    v.Remarks AS VehicleRemarks,
    v.CertRequired AS VehicleCertRequired,
    v.InDate AS VehicleInDate,
    v.OutDate AS VehicleOutDate,
    v.Status AS VehicleStatus

FROM trackable t
LEFT JOIN (
    SELECT bt1.* 
    FROM basictools bt1
    INNER JOIN (
        SELECT ToolID, MAX(InDate) AS MaxInDate
        FROM basictools
        GROUP BY ToolID
    ) bt2 ON bt1.ToolID = bt2.ToolID AND bt1.InDate = bt2.MaxInDate
) bt ON bt.ToolID = t.Source
LEFT JOIN (
    SELECT st1.*
    FROM specialtools st1
    INNER JOIN (
        SELECT StoolID, MAX(InDate) AS MaxInDate
        FROM specialtools
        GROUP BY StoolID
    ) st2 ON st1.SToolID = st2.StoolID AND st1.InDate = st2.MaxInDate
) st ON st.SToolID = t.Source
LEFT JOIN (
    SELECT v1.*
    FROM vehicles v1
    INNER JOIN (
        SELECT VehicleID, MAX(InDate) AS MaxInDate
        FROM vehicles
        GROUP BY VehicleID
    ) v2 ON v1.VehicleID = v2.VehicleID AND v1.InDate = v2.MaxInDate
) v ON v.VehicleID = t.Source;";

        public const string SAVE_SQL_TRACKABLES = @"INSERT INTO trackable (ID, Source, Barcode, CheckoutRecords)
    VALUES (@ID, @Source, @Barcode, @CheckoutRecords)
    ON DUPLICATE KEY UPDATE
        Source = @Source,
        Barcode = @Barcode,
        CheckoutRecords = @CheckoutRecords;";

        public const string SAVE_SQL_BASIC = @"INSERT INTO basictools (ToolID, Name, Included, Remarks, InDate, OutDate, Status)
    VALUES (@ID, @Name, @Included, @Remarks, @InDate, @OutDate, @Status)
    ON DUPLICATE KEY UPDATE
        Name = @Name,
        Included = @Included,
        Remarks = @Remarks,
        InDate = @InDate,
        OutDate = @OutDate,
        Status = @Status;";

        public const string SAVE_SQL_SPECIAL = @"
    INSERT INTO specialtools (SToolID, Name, Type, Included, Remarks, InDate, OutDate, Status, CalDate, CalDue, CertRequired)
    VALUES (@ID, @Name, @Type, @Included, @Remarks, @InDate, @OutDate, @Status, @CalDate, @CalDue, @CertRequired)
    ON DUPLICATE KEY UPDATE
        Name = @Name,
        Type = @Type,
        Included = @Included,
        Remarks = @Remarks,
        InDate = @InDate,
        OutDate = @OutDate,
        Status = @Status,
        CalDate = @CalDate,
        CalDue = @CalDue,
        CertRequired = @CertRequired;";

        public const string SAVE_SQL_VEHICLES = @"INSERT INTO vehicles (VehicleID, Make, Model, Year, SerialNum, Remarks, CertRequired, InDate, OutDate, Status)
    VALUES (@ID, @Make, @Model, @Year, @SerialNum, @Remarks, @CertRequired, @InDate, @OutDate, @Status)
    ON DUPLICATE KEY UPDATE
        Make = @Make,
        Model = @Model,
        Year = @Year,
        SerialNum = @SerialNum,
        Remarks = @Remarks,
        CertRequired = @CertRequired,
        InDate = @InDate,
        OutDate = @OutDate,
        Status = @Status;";

        public const string SAVE_SQL_EMPLOYEES = @"
    INSERT INTO employees 
        (EmpID, Name, Email, Phone, Status, Title, Password, PasswordSalt, Role, SecondRole)
    VALUES 
        (@EmpID, @Name, @Email, @Phone, @Status, @Title, @Password, @PasswordSalt, @Role, @SecondRole)
    ON DUPLICATE KEY UPDATE
        Name = VALUES(Name),
        Email = VALUES(Email),
        Phone = VALUES(Phone),
        Status = VALUES(Status),
        Title = VALUES(Title),
        Password = VALUES(Password),
        PasswordSalt = VALUES(PasswordSalt),
        Role = VALUES(Role),
        SecondRole = VALUES(SecondRole);
        ";

        public const string SAVE_SQL_CUSTOMER = @"
    INSERT INTO customer 
        (EmpID, Certs, OutItems)
    VALUES 
        (@EmpID, @Certs, @OutItems)
    ON DUPLICATE KEY UPDATE
        Certs = VALUES(Certs),
        OutItems = VALUES(OutItems);
            ";

        public const string GET_EQUIP_FROM_DB = @"
SELECT 
            t.ID AS TrackableID,
            t.Source,
            t.Barcode,
            CASE
                WHEN b.ToolID IS NOT NULL THEN 'BasicTools'
                WHEN s.SToolID IS NOT NULL THEN 'SpecialTool'
                WHEN v.VehicleID IS NOT NULL THEN 'Vehicle'
                ELSE 'Unknown'
            END AS Type,
            b.ToolID, b.Name AS BasicToolName, b.Included AS BasicToolIncluded,
            b.Remarks AS BasicToolRemarks, b.InDate AS BasicToolInDate, b.OutDate AS BasicToolOutDate,
            b.Status AS BasicToolStatus,
            s.SToolID, s.Name AS SpecialToolName, s.Type AS SpecialToolType,
            s.Included AS SpecialToolIncluded, s.Remarks AS SpecialToolRemarks,
            s.InDate AS SpecialToolInDate, s.OutDate AS SpecialToolOutDate,
            s.Status AS SpecialToolStatus, s.CalDate AS SpecialToolCalDate, s.CalDue AS SpecialToolCalDue,
            s.CertRequired AS SpecialToolCertRequired,
            v.VehicleID, v.Make AS VehicleMake, v.Model AS VehicleModel, v.Year AS VehicleYear,
            v.SerialNum AS SerialNum, v.Remarks AS VehicleRemarks, v.CertRequired AS VehicleCertRequired,
            v.InDate AS VehicleInDate, v.OutDate AS VehicleOutDate, v.Status AS VehicleStatus,
            t.CheckoutRecords
        FROM Trackable t
        LEFT JOIN BasicTools b ON t.Source = b.ToolID
        LEFT JOIN SpecialTools s ON t.Source = s.SToolID
        LEFT JOIN Vehicles v ON t.Source = v.VehicleID;";
    }
}
