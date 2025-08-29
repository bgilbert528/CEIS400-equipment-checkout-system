using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public class CheckoutRecord
    {
        // attributes
        protected string _recordID;
        protected string _empID;
        protected DateTime? _dateOut;
        protected DateTime? _dateIn;
        protected string _condition;
        protected ITrackable _source;
        protected string _sourceID;

        // constructors
        public CheckoutRecord()
        {
            _recordID = Guid.NewGuid().ToString();
            _empID = "";
            _dateOut = null;
            _dateIn = null;
            _condition = "";
            _source = null;
            _sourceID = "";
        }

        public CheckoutRecord(string recordID, string empID, DateTime? dateOut, DateTime? dateIn, string condition, ITrackable source)
        {
            RecordID = recordID;
            EmpID = empID;
            DateOut = dateOut;
            DateIn = dateIn;
            Condition = condition;
            Source = source;
            SourceID = source?.SourceID ?? string.Empty;
        }

        // behaviors

        // properties
        public string RecordID { get { return _recordID; } set { _recordID = value; } }
        public string EmpID { get { return _empID; } set { _empID = value; } }
        public DateTime? DateOut { get { return _dateOut; } set { _dateOut = value; } }
        public DateTime? DateIn { get { return _dateIn; } set { _dateIn = value; } }
        public string Condition { get { return _condition; } set { _condition = value; } }
        public string SourceID { get { return _sourceID; } set { _sourceID = value; } }
        
        [JsonIgnore] // Prevent recursive loop of adding full source data to CheckoutRecords when saved
        public ITrackable Source { get { return _source; } set { _source = value; } }
    }
}
