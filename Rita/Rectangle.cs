using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rita
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            Type = ShapeType.Rectangle;
        }

        public int Length { get; set; }
        public int Height { get; set; }

        
        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(Colour))
            {
                g.FillRectangle(brush, Position.X - (Length / 2), Position.Y - (Height / 2), Length, Height);
            }

            //Center.X - (Width / 2),
            //Center.Y - (Height / 2),
           // g.DrawRectangle(pen, Center.X - Length, Center.Y - Height);
        }

    }
}
