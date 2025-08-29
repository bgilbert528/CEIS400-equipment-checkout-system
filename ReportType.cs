using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public enum ReportType
    {
        [Description("Missing Items")]
        Missing,
        [Description("Overdue Items")]
        Overdue,
        [Description("Out For Service")]
        OutForService,
        [Description("Due For Calibration")]
        DueCal
    }
}
