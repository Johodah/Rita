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


        private int radius {  get; set; }
        public int Radius  {
            
            get { return radius; }
            set 
            {
                if (value >= 0)
                    radius = value;
                else
                    throw new ArgumentException("Radius must be positive number");
            } 
        }
        public Color Colour { get; set; }
        public Point Center { get; set; }

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
            using (var pen = new Pen(Colour))
            {
                g.DrawEllipse(pen, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            } 
        }

    }
}
