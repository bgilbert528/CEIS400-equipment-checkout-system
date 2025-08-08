using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public class BasicTools : ITrackable, IHasBarcode
    {
        // Attributes
        protected string _toolID;
        protected string _name;
        protected DateTime? _inDate;
        protected DateTime? _outDate;
        protected InvStatus _status;
        protected List<string> _included;
        protected string _remarks;
        protected BindingList<CheckoutRecord> _checkoutRecords;

        public string Source => ToolID;
        public Barcode Barcode { get; private set; }

        // constructors
        public BasicTools()
        {
            _toolID = "";
            _name = "";
            _inDate = null;
            _outDate = null;
            _status = InvStatus.In;
            _included = new List<string>();
            _remarks = "";
            _checkoutRecords = new BindingList<CheckoutRecord>();
            Barcode = new Barcode();
        }

        public BasicTools(string toolID, string name, DateTime? inDate, DateTime? outDate, List<string> included, string remarks, BindingList<CheckoutRecord> checkoutRecords)
        {
            ToolID = toolID;
            Name = name;
            InDate = inDate;
            OutDate = outDate;
            Included = included;
            Remarks = remarks;
            CheckoutRecords = checkoutRecords;
        }

        // behaviors

        // -- Class specific --
        public bool isIncluded()
        {
            return true;
        }

        public override string ToString()
        {
            return "temp text";
        }

        // -- Interface methods --

        // <-- IHasBarcode Interface methods -->
        public void GenerateBarcode()
        {
            Barcode.Generate(ToolID);
        }

        // <-- ITrackable Interface methods -->
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
            return true;
        }

        // properties
        public string ToolID { get { return _toolID; } set { _toolID = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public DateTime? InDate { get { return _inDate; } set { _inDate = value; } }
        public DateTime? OutDate { get { return _outDate; } set { _outDate = value; } }
        public InvStatus Status { get { return _status; } set { _status = value; } }
        public List<string> Included { get { return _included; } set { _included = value; } }
        public string Remarks { get { return _remarks; } set { _remarks = value; } }
        public BindingList<CheckoutRecord> CheckoutRecords { get { return _checkoutRecords; } set { _checkoutRecords = value; } }

    }
}
