using Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAvto_10
{
    class ColorComparer : IComparer<Car>
    {
        public int Compare(Car c, Car c1)
        {
            return c.Color.CompareTo(c1.Color);
        }
    }
}
