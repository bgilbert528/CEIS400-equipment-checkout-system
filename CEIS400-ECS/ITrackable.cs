using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public interface ITrackable
    {
        string Source { get; }
        bool CheckStock();
        void CheckIn();
        void CheckOut();
        bool IsMissing();
        void GenerateID();
    }
}