using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rita
{
    public class Triangle : Shape
    {
        public Triangle() 
        {
            TypeID = "triangle";
        }

        public Color Colour { get; set; }
        public Point Center { get; set; }


        public override void Draw(Graphics g)
        {
            var pen = new Pen(Colour);

           // g.DrawEllipse(p
        }

    }
}
