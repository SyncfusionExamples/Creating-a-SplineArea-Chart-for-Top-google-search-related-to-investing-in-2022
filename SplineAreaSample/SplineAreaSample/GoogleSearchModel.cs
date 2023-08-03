using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplineAreaSample
{
    public class GoogleSearchModel
    {
        public DateTime Year { get; set; }
        public double Value { get; set; }

        public GoogleSearchModel(DateTime year, double value)
        {
            Year = year;
            Value = value;
        }
    }
}
