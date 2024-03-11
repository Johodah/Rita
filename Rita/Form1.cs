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

        }

        private void picture_box_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in draw) 
            
            {
                shape.Draw(e.Graphics);
            }
        }
    }
}
