using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CEIS400_ECS
{
    public class SpecialTool : ITrackable, IHasBarcode
    {
        // Attributes
        protected string _sToolID;
        protected string _name;
        protected string _type;
        protected InvStatus _status;
        protected DateTime? _inDate;
        protected DateTime? _outDate;
        protected string _remarks;
        protected DateTime? _calDate;
        protected DateTime? _calDue;
        protected bool _certRequired;
        protected List<string> _included;
        protected BindingList<CheckoutRecord> _checkoutRecords;
        public string Source => _sToolID;
        public Barcode Barcode { get; private set; }

        // Constructors
        public SpecialTool()
        {
            _sToolID = "";
            _name = "";
            _type = "";
            _status = InvStatus.In;
            _inDate = null;
            _outDate = null;
            _remarks = "";
            _calDate = null;
            _calDue = null;
            _certRequired = false;
            _included = new List<string>();
            _checkoutRecords = new BindingList<CheckoutRecord>();
            Barcode = new Barcode();
        }

        public SpecialTool(string sToolID, string name, string type, InvStatus status, DateTime? inDate, DateTime? outDate, string remarks, DateTime? calDate, DateTime? calDue, bool certRequired, List<string> included, BindingList<CheckoutRecord> checkoutRecords)
        {
            SToolID = sToolID;
            Name = name;
            Type = type;
            Status = status;
            InDate = inDate;
            OutDate = outDate;
            Remarks = remarks;
            CalDate = calDate;
            CalDue = calDue;
            CertRequired = certRequired;
            Included = included;
            CheckoutRecords = checkoutRecords;
        }

        // Behaviors
        // -- Class specific --
        public bool IsIncluded()
        {
            return false;
        }

        public bool DueForCalibration()
        {
            return false;
        }

        public override string ToString()
        {
            return "temp text";
        }

        // -- Interface methods --
        // <-- IHasBarcode methods -->
        public void GenerateBarcode()
        {
            Barcode.Generate(SToolID);
        }

        // <-- ITrackable methods -->
        public void GenerateID()
        {
            // generate code
        }

        public bool CheckStock()
        {
            // generate code
            return true;
        }

        public void CheckIn()
        {
            // generate code
        }

        public void CheckOut()
        {
            // generate code
        }

        public bool IsMissing()
        {
            // generate code
            return false;
        }

        // Properties
        public string SToolID { get { return _sToolID; } set { _sToolID = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public InvStatus Status { get { return _status; } set {_status = value; } }
        public DateTime? InDate { get { return _inDate; } set { _inDate = value; } }
        public DateTime? OutDate { get { return _outDate; } set { _outDate = value; } }
        public string Remarks { get { return _remarks; } set { _remarks = value; } }
        public DateTime? CalDate { get { return _calDate; } set { _calDate = value; } }
        public DateTime? CalDue { get { return _calDue; } set { _calDue = value; } }
        public bool CertRequired { get { return _certRequired; } set { _certRequired = value; } }
        public List<string> Included { get { return _included; } set { _included = value; } }
        public BindingList<CheckoutRecord> CheckoutRecords { get { return _checkoutRecords; } set { _checkoutRecords = value; } }

    }
}
