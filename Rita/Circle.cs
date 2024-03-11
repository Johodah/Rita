using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rita
{
    public class Circle : Shape
    {
        public Circle()
        {
            TypeID = "circle";
        }



        public int Radius { get; set; }
        public Color Colour { get; set; }
        public Point Center { get; set; }

        [JsonIgnore]

        public int Diameter
        {
            get
            {
                return Radius * 2;
            }
        }
        [JsonIgnore]
        public double Circumference
        {
            get
            {
                return Radius * Math.PI * 2;

            }
        }
        [JsonIgnore]
        public double Area
        { 
            get
            {
                return Radius * Radius * Math.PI; 
            }          
        }

        public override void Draw(Graphics g)
        {
            var pen = new Pen(Colour);

            g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Diameter, Diameter);
        }

    }
}
