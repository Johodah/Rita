using System.Diagnostics.Eventing.Reader;

namespace Rita
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool drawCircle = false;
        private bool drawRectangle = false;
        private bool drawTriangle = false;

        private Stack<Shape> draw = new Stack<Shape>();

        private Stack<Shape> redo = new Stack<Shape>();

        private void btn_draw_circle_Click(object sender, EventArgs e)
        {
            drawCircle = true;
        }

        private void btn_draw_rectangle_Click(object sender, EventArgs e)
        {
            drawRectangle = true;
        }

        private void btn_draw_triangle_Click(object sender, EventArgs e)
        {
            drawTriangle = true;
        }

        private void btn_savefile_Click(object sender, EventArgs e)
        {

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            SwitchElement(draw, redo);
        }

        private void SwitchElement(Stack<Shape> giver, Stack<Shape> receiver)
        {
            if (giver.Any())
            {
                receiver.Push(giver.Pop());
                picture_box.Refresh();
            }
        }

        private void picture_box_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in draw)

            {
                shape.Draw(e.Graphics);
            }
        }

        private void picture_box_Click(object sender, EventArgs e)
        {
            if (drawCircle)
            {
                var mouse = (MouseEventArgs)e;

                var circle = new Circle()
                {
                    Colour = Color.Azure,
                    Radius = 15,
                    Center = mouse.Location
                };
                draw.Push(circle);
                redo.Clear();

                drawCircle = false;
            }

            else if (drawRectangle)
            {
                var mouse = (MouseEventArgs)e;
                var rectangle = new Rectangle()
                {
                    Colour = Color.OrangeRed,
                    Center = mouse.Location,
                    Height = 15,
                    Length = 10,
                };

                draw.Push(rectangle);
                redo.Clear();
                drawRectangle = false;

            }

            else if (drawTriangle)
            {
                var mouse = (MouseEventArgs)e;
                var triangle = new Triangle()
                {
                    Colour = Color.PaleGreen,
                    Center = mouse.Location
                };
                draw.Push(triangle);
                redo.Clear();
                drawTriangle = false;
            }

            picture_box.Refresh();
        
        }
    }
}
