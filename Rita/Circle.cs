using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rita
{
    public class Circle : Shape
    {
        public class Circle()
        {
            TypeID = "Circle";
        }
        
    }

    public int Radius {  get; set; }
}
