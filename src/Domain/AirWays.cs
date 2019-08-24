using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum AirWays
    {
        [Description("Flight Way is Arrivals")]
        A,

        [Description("Flight Way is Deviate")]
        D
    }
}
