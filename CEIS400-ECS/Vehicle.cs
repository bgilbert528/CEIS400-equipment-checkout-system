using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ECS
{
    public class Vehicle : ITrackable, IHasBarcode
    {
        // Attributes
        protected string _vehicleID;
        protected string _make;
        protected string _model;
        protected int _year;
        protected string _serialNum;
        protected InvStatus _status;
        protected DateTime? _inDate;
        protected DateTime? _outDate;
        protected string _remarks;
        protected bool _certRequired;
        protected BindingList<CheckoutRecord> _checkoutRecords;
        public string Source => VehicleID;
        public Barcode Barcode { get; private set; }

        // Constructors
        public Vehicle() 
        {
            _vehicleID = "";
            _make = "";
            _model = "";
            _year = 0000;
            _serialNum = "";
            _status = InvStatus.In;
            _inDate = null;
            _outDate = null;
            _remarks = "";
            _certRequired = false;
            _checkoutRecords = new BindingList<CheckoutRecord>();
            Barcode = new Barcode();
        }

        public Vehicle(string vehicleID, string make, string model, int year, string serialNum, InvStatus status, DateTime? inDate, DateTime? outDate, string remarks, bool certRequired, BindingList<CheckoutRecord> checkoutRecords) 
        {
            VehicleID = vehicleID;
            Make = make;
            Model = model;
            Year = year;
            SerialNum = serialNum;
            Status = status;
            InDate = inDate;
            OutDate = outDate;
            Remarks = remarks;
            CertRequired = certRequired;
            CheckoutRecords = checkoutRecords;
        }

        // Behaviors

        // -- Class Specific --
        public override string ToString()
        {
            return "temp text";
        }

        // -- Interface methods -- 

        // <-- IHasBarcode methods -->
        public void GenerateBarcode()
        {
            Barcode.Generate(VehicleID);
        }

        // <-- ITrackable methods -->
        public void GenerateID()
        {
            // generate code
        }

        public void CheckIn()
        {
            // generate code
        }

        public void CheckOut()
        {
            // generate code
        }

        public bool CheckStock()
        {
            // generate code
            return true;
        }

        public bool IsMissing()
        {
            // generate code
            return false;
        }

        // Properties
        public string VehicleID { get {  return _vehicleID; } set { _vehicleID = value; } }
        public string Make { get { return _make; } set { _make = value; } }
        public string Model { get { return _model; } set { _model = value; } }
        public int Year { get { return _year; } set { _year = value; } }
        public string SerialNum { get { return _serialNum; } set { _serialNum = value; } }
        public InvStatus Status { get { return _status; } set { _status = value; } }
        public DateTime? InDate { get { return _inDate; } set { _inDate = value; } }
        public DateTime? OutDate { get { return _outDate; } set { _outDate = value; } }
        public string Remarks { get { return _remarks; } set { _remarks = value; } }
        public bool CertRequired { get { return _certRequired; } set { _certRequired = value; } }
        public BindingList<CheckoutRecord> CheckoutRecords { get { return _checkoutRecords; } set { _checkoutRecords = value; } }
    }
}
