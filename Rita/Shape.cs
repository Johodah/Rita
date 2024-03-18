using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rita
{
    public abstract class Shape //grundegenskaperna för alla typer av former sparas i Shape
    {
        public enum ShapeType { Circle, Triangle, Rectangle }
        public ShapeType Type { get; set; }
        public Point Position { get; set; }
        public Color Colour { get; set; }
        public int Size { get; set; }

        public abstract void Draw(Graphics g);
    }
}
