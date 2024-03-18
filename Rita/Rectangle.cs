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

        public int Length { get; set; } //Använder bara bredden och höjden för att räkna ut rektangel, storlek anges i Form1.cs
        public int Height { get; set; }

        
        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(Colour))
            {
                g.FillRectangle(brush, Position.X - (Length / 2), Position.Y - (Height / 2), Length, Height); //uträkning för formen
            }
        }

    }
}
