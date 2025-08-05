using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ECS
{
    public interface IHasBarcode
    {
        Barcode Barcode { get; }
        void GenerateBarcode();
    }
}
