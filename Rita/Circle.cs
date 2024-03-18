using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Drawing;

namespace Rita
{
    public class Circle : Shape //subclass för Shape som skapar cirkeln
    {
        public Circle()
        {
            Type = ShapeType.Circle;
        }

        public int Radius {  get; set; } //storleken baseras på radius av cirkel
   

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(Colour))
            {
                g.FillEllipse(brush, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
            } 
        }

    }
}
