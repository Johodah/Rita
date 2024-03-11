using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rita
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            TypeID = "rectangle";
        }

        public int Length { get; set; }
        public int Height { get; set; }

    }
}
