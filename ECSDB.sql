USE team3ecs;

-- -----------------------
-- Clear tables safely
-- -----------------------
SET FOREIGN_KEY_CHECKS = 0;

TRUNCATE TABLE checkoutrecords;
TRUNCATE TABLE customer;
TRUNCATE TABLE trackable;
TRUNCATE TABLE basictools;
TRUNCATE TABLE specialtools;
TRUNCATE TABLE vehicles;
TRUNCATE TABLE employees;

SET FOREIGN_KEY_CHECKS = 1;

-- -----------------------
-- Insert Employees
-- -----------------------
INSERT INTO employees (EmpID, Name, Email, Phone, Status, Title, Password, PasswordSalt, Role, SecondRole) VALUES
('Admin01', 'Test', 'Admin@company.com', '555-324-1234', 'Active', "Administrator", 'FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==', 'gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=', 'Admin', 'Admin'),
('Sup01', 'Test', 'Sup@company.com', '555-789-4563', 'Active', 'Supervisor', 'FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==', 'gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=','Supervisor', 'DeptStaff'),
('Sup02', 'Test', 'Sup2@company.com', '555-159-7536', 'Active', 'Assistant Supervisor', 'FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==', 'gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=', 'Supervisor', 'Admin'),
('DepStaff01', 'Test', 'staff01@company.com', '555-963-8521', 'Active', 'Staff', 'FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==', 'gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=','DeptStaff', 'DeptStaff'),
('Cust01', 'Test', 'cust01@company.com', '555-789-6543', 'Active', 'Employee', 'FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==', 'gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=','Customer', 'Customer'),
('Cust02', 'Test', 'cust02@company.com', '555-456-1236', 'Hold', 'Vendor', 'FNkcoo8jUhak+/xQw9cIV2E3OxYU1pfsUwIyk+5Hs8z6o4+fCOi7/dDMBBWqAG4QPYh2y6D8hRb3J4Bu93SuZg==', 'gibDzAukbMHu8aOSn8qhAwPVKO2R20dH7CouBAm/CZQ2xPq1iwBAkydgo5A1d1gX+o/8otVGXI54qCf+4wT4XCOBGsqu6CQUrnd0zdR9QEnVHY5Bu6C+IBjc5p3ekjVAUpaYz25mbee/gTt/8emat3dkK+svGHAY/D3fsrX91Gs=', 'Customer', 'Customer');

-- -----------------------
-- Insert BasicTools
-- -----------------------
INSERT INTO BasicTools (ToolID, Name, Included, Remarks, InDate, OutDate, Status)
VALUES
(UUID(), 'Hammer', NULL, 'Standard hammer', NOW(), NULL, 'In'),
(UUID(), 'Screwdriver Set', 'Flathead, Philips, Case', 'Includes flathead and Philips', NOW(), NOW(), 'Out'),
(UUID(), 'Wrench Set', 'Metric Wrenches, SAE Wrenches, Case', 'Metric and SAE sizes', NOW(), NULL, 'OutForService'),
(UUID(), 'Pliers', NULL, 'Standard pliers', NOW(), NULL, 'In'),
(UUID(), 'Tape Measure', 'Tape, Case', '25ft', NOW(), NULL, 'In'),
(UUID(), 'Level', '24-inch Level, Carry Bag', '24-inch', NOW(), NOW(), 'Out'),
(UUID(), 'Chisel', 'Wood Chisel, Handle', 'Wood chisel', NOW(), NULL, 'In'),
(UUID(), 'Handsaw', 'Crosscut Saw, Blade Cover', 'Crosscut saw', NOW(), NOW(), 'Out'),
(UUID(), 'Utility Knife', 'Knife, Extra Blades', 'Retractable', NOW(), NULL, 'In'),
(UUID(), 'Clamp', 'C-Clamp, Screws', 'C-clamp', NOW(), NULL, 'In'),
(UUID(), 'Crowbar', 'Crowbar, Grip', '16-inch', NOW(), NOW(), 'Out'),
(UUID(), 'Wire Cutter', NULL, 'Electrical', NOW(), NULL, 'In'),
(UUID(), 'Hex Key Set', 'Metric Keys, SAE Keys', 'Metric/SAE', NOW(), NULL, 'In'),
(UUID(), 'Socket Set', 'Sockets, Ratchet, Extensions', '1/4" and 3/8"', NOW(), NULL, 'In'),
(UUID(), 'Adjustable Wrench', NULL, '12-inch', NOW(), NULL, 'In'),
(UUID(), 'Gloves', 'Pair of Gloves', 'Safety', NOW(), NULL, 'In'),
(UUID(), 'Safety Glasses', 'Glasses, Case', 'Eye protection', NOW(), NULL, 'In'),
(UUID(), 'Tape', NULL, 'Electrical tape', NOW(), NULL, 'In'),
(UUID(), 'Marker', NULL, 'Permanent marker', NOW(), NULL, 'In'),
(UUID(), 'Brush', NULL, 'Paint brush', NOW(), NULL, 'In');

-- -----------------------
-- Insert SpecialTools
-- -----------------------
INSERT INTO SpecialTools (SToolID, Name, Type, Remarks, CalDate, CalDue, Included, CertRequired, InDate, OutDate, Status)
VALUES
(UUID(), 'Digital Multimeter', 'Electronic', 'Voltage/current measurements', NOW(), DATE_ADD(NOW(), INTERVAL 1 YEAR), 'Meter, Probes, Case', 1, NOW(), NULL, 'In'),
(UUID(), 'Thermal Camera', 'Imaging', 'Check hotspots', NOW(), DATE_ADD(NOW(), INTERVAL 6 MONTH), 'Camera, Lens, Case', 1, NOW(), NOW(), 'OutForService'),
(UUID(), 'Pressure Gauge', 'Mechanical', 'Calibrate monthly', NOW(), DATE_ADD(NOW(), INTERVAL 3 MONTH), 'Gauge, Hose, Case', 0, NOW(), NOW(), 'Out'),
(UUID(), 'Sound Level Meter', 'Electronic', 'Noise measurements', NOW(), DATE_ADD(NOW(), INTERVAL 1 YEAR), 'Meter, Tripod, Case', 1, NOW(), NULL, 'In'),
(UUID(), 'Gas Detector', 'Electronic', 'Safety', NOW(), DATE_ADD(NOW(), INTERVAL 6 MONTH), 'Detector, Battery, Case', 1, NOW(), NULL, 'In'),
(UUID(), 'Moisture Meter', 'Electronic', 'For wood and concrete', NOW(), DATE_ADD(NOW(), INTERVAL 1 YEAR), 'Meter, Probes, Case', 0, NOW(), NULL, 'In'),
(UUID(), 'Laser Distance Meter', 'Electronic', 'Measure distances', NOW(), DATE_ADD(NOW(), INTERVAL 1 YEAR), 'Meter, Battery, Case', 0, NOW(), NULL, 'In'),
(UUID(), 'Vibration Meter', 'Electronic', 'Machines monitoring', NOW(), DATE_ADD(NOW(), INTERVAL 1 YEAR), 'Meter, Tripod, Case', 1, NOW(), NOW(), 'OutForService'),
(UUID(), 'Torque Wrench', 'Mechanical', 'Calibrate bolts', NOW(), DATE_ADD(NOW(), INTERVAL 6 MONTH), 'Wrench, Calibration Weights, Case', 0, NOW(), NULL, 'In'),
(UUID(), 'Data Logger', 'Electronic', 'Monitor equipment', NOW(), DATE_ADD(NOW(), INTERVAL 1 YEAR), 'Logger, Cables, Case', 1, NOW(), NOW(), 'Out');

-- -----------------------
-- Insert Vehicles
-- -----------------------
INSERT INTO Vehicles (VehicleID, Make, Model, Year, SerialNum, Remarks, CertRequired, InDate, OutDate, Status)
VALUES
(UUID(), 'Ford', 'Transit', 2020, 'SN10001', 'Delivery van', 1, NOW(), NULL, 'In'),
(UUID(), 'Toyota', 'Hilux', 2018, 'SN10002', 'Pickup truck', 1, NOW(), NOW(), 'OutForService'),
(UUID(), 'Chevy', 'Express', 2019, 'SN10003', 'Service van', 1, NOW(), NOW(), 'Out'),
(UUID(), 'Mercedes', 'Sprinter', 2021, 'SN10004', 'Cargo van', 1, NOW(), NULL, 'In'),
(UUID(), 'Ford', 'F-150', 2017, 'SN10005', 'Pickup', 1, NOW(), NULL, 'In'),
(UUID(), 'Ram', '1500', 2019, 'SN10006', 'Pickup', 1, NOW(), NULL, 'In'),
(UUID(), 'Nissan', 'NV200', 2020, 'SN10007', 'Van', 1, NOW(), NULL, 'In'),
(UUID(), 'Volkswagen', 'Crafter', 2018, 'SN10008', 'Cargo van', 1, NOW(), NULL, 'In'),
(UUID(), 'Toyota', 'Tacoma', 2021, 'SN10009', 'Pickup', 1, NOW(), NOW(), 'Out'),
(UUID(), 'Ford', 'Transit Connect', 2019, 'SN10010', 'Delivery van', 1, NOW(), NULL, 'In');

-- -----------------------
-- Insert Trackables (avoid duplicates)
-- -----------------------
INSERT INTO Trackable (ID, Source, Barcode)
SELECT UUID(), bt.ToolID, NULL
FROM BasicTools bt
WHERE NOT EXISTS (SELECT 1 FROM Trackable t WHERE t.Source = bt.ToolID);

INSERT INTO Trackable (ID, Source, Barcode)
SELECT UUID(), st.SToolID, NULL
FROM SpecialTools st
WHERE NOT EXISTS (SELECT 1 FROM Trackable t WHERE t.Source = st.SToolID);

INSERT INTO Trackable (ID, Source, Barcode)
SELECT UUID(), v.VehicleID, NULL
FROM Vehicles v
WHERE NOT EXISTS (SELECT 1 FROM Trackable t WHERE t.Source = v.VehicleID);

-- -----------------------
-- Insert Checkout Records
-- -----------------------
INSERT INTO checkoutrecords (RecordID, Source, EmpID, DateOut, DateIn, `Condition`)
SELECT 
    UUID() AS RecordID,
    t.ID AS Source,
    (SELECT EmpID FROM employees ORDER BY RAND() LIMIT 1) AS EmpID,
    DATE_SUB(NOW(), INTERVAL FLOOR(RAND()*30) DAY) AS DateOut,
    CASE
        WHEN RAND() < 0.7 THEN DATE_SUB(NOW(), INTERVAL FLOOR(RAND()*10) DAY)
        ELSE NULL
    END AS DateIn,
    CASE
        WHEN RAND() < 0.8 THEN 'Good'
        WHEN RAND() < 0.9 THEN 'Needs Calibration'
        ELSE 'Damaged'
    END AS `Condition`
FROM Trackable t
ORDER BY RAND()
LIMIT 40;

-- -----------------------
-- Insert Customers
-- -----------------------
INSERT INTO customer (EmpID, Certs, OutItems)
VALUES
('Cust01', 
 (SELECT GROUP_CONCAT(ID) FROM Trackable WHERE Source IN (
    SELECT SToolID FROM SpecialTools WHERE Name IN ('Digital Multimeter','Thermal Camera')
    UNION
    SELECT VehicleID FROM Vehicles WHERE Make IN ('Ford','Toyota')
  )), 
 NULL
),
('Cust02', 
 (SELECT GROUP_CONCAT(ID) FROM Trackable WHERE Source IN (
    SELECT SToolID FROM SpecialTools WHERE Name IN ('Digital Multimeter','Thermal Camera')
    UNION
    SELECT VehicleID FROM Vehicles WHERE Make = 'Ford'
  )),
 (SELECT GROUP_CONCAT(ID) FROM Trackable WHERE Source IN (
    SELECT ToolID FROM BasicTools WHERE Name IN ('Hammer','Screwdriver Set','Wrench Set','Pliers','Tape Measure')
  ))
);

-- -----------------------
-- Verify
-- -----------------------
SELECT * FROM employees;
SELECT * FROM trackable;
SELECT * FROM basictools;
SELECT * FROM specialtools;
SELECT * FROM vehicles;
SELECT * FROM checkoutrecords;
SELECT * FROM customer;
