using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public interface ITrackable
    {
        // Unique database-safe ID
        string SourceID { get; set; }

        // Original Source identifier
        string Source { get; }

        InvStatus Status { get; set; }
        DateTime? InDate { get; set; }
        DateTime? OutDate { get; set; }
        Barcode Barcode { get; }
        BindingList<CheckoutRecord> CheckoutRecords { get; set; }

        // Methods
        bool CheckStock();
        void CheckIn(CheckoutRecord record, Customer customer);
        void CheckOut(Customer customer);
        bool IsMissing();
        string GenerateID();

        // Relink CheckoutRecords back to the parent
        void ReLinkCheckoutRecords();
    }
}