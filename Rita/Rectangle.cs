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
            TypeID = "rectangle";
        }

        public int Length { get; set; }
        public int Height { get; set; }

        public Color Colour { get; set; }
        public Point Center { get; set; }

        [JsonIgnore]
        public double Circumference 
        { 
            get
            {
               return Height + Length;
            }
        }
        [JsonIgnore]
        public double Area
        {
            get
            {
                return Height * Length;
            }
        }


        public override void Draw(Graphics g)
        {
            var pen = new Pen(Colour);

           // g.DrawRectangle(pen, Center.X - Length, Center.Y - Height);
        }

    }
}
