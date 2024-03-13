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
            Type = ShapeType.Triangle;
        }

        public Point Top {  get; set; }
        public Point Left { get; set; }
        public Point Right { get; set; }

        public override void Draw(Graphics g)
        {
            Point[] trianglePoints = { Top, Left, Right };
            using (var brush = new SolidBrush(Colour))
            {
                g.FillPolygon(brush, trianglePoints);
            }
        }

    }
}
