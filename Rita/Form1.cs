using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft;

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

        private Stack<Shape> drawHistory = new Stack<Shape>();

        private Stack<Shape> redoHistory = new Stack<Shape>();
        Color SelectedColor;

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
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,

            };

            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var jsonFil = JsonConvert.SerializeObject(drawHistory, jsonSerializerSettings);

                File.WriteAllText(saveFileDialog1.FileName, jsonFil);
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string jsonContent = File.ReadAllText(ofd.FileName);
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All,
                };

                Stack<Shape> loadedShapes = JsonConvert.DeserializeObject<Stack<Shape>>(jsonContent, jsonSerializerSettings);

                drawHistory.Clear();

                foreach (Shape shape in loadedShapes)
                {
                    drawHistory.Push(shape);
                }
                picture_box.Refresh();
            }

        }
        private void btn_saveImage_Click(object sender, EventArgs e)
        {
            using (var saveImage = new SaveFileDialog())
            {
                saveImage.Filter = "JPEG Image| *.jpg|PNG Image|*.png";
                if (saveImage.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(picture_box.Width, picture_box.Height);

                    picture_box.DrawToBitmap(bmp, picture_box.ClientRectangle);

                    bmp.Save(saveImage.FileName);

                }
            }
        }
    
        private void btn_clear_Click(object sender, EventArgs e)
        {

            drawHistory.Clear();
            picture_box.Refresh();
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            if (drawHistory.Count > 0)
            {
                Shape lastShape = drawHistory.Pop();
                redoHistory.Push(lastShape);
                picture_box.Refresh();
            }
        }

        private void picture_box_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in drawHistory)
            {
                shape.Draw(e.Graphics);

                //using (var brush = new SolidBrush(shape.Colour))
                //{
                //    switch (shape.Type)
                //    {
                //        case Shape.ShapeType.Circle:
                //            e.Graphics.FillEllipse(brush, shape.Position.X, shape.Position.Y, shape.Size, shape.Size);
                //            break;
                //        case Shape.ShapeType.Triangle:
                //            Point top = new Point(shape.Position.X, shape.Position.Y - 30);
                //            Point left = new Point(shape.Position.X - 25, shape.Position.Y + 15);
                //            Point right = new Point(shape.Position.X + 25, shape.Position.Y + 15);
                //            Point[] triangel = { top, left, right };
                //            e.Graphics.FillPolygon(brush, triangel);
                //            break;
                //        case Shape.ShapeType.Rectangle:
                //            e.Graphics.FillRectangle(brush, shape.Position.X, shape.Position.Y, shape.Size, shape.Size);
                //            break;
                //    }
                //}
            }
            //foreach (var shape in shapes)

            //{
            //    using (var brush = new SolidBrush(shape.colour()))
            //    {
            //        switch (shape.TypeID)
            //        {
            //            case Shape.TypeID;
            //        }
            //    }
            //}
        }

        private void picture_box_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawCircle)
            {
                Circle newCircle = new Circle
                {
                    Type = Shape.ShapeType.Circle,
                    Position = e.Location,
                    Colour = SelectedColor,
                    Radius = 25,
                };

                drawHistory.Push(newCircle);
                drawCircle = false;

            }


            //    var circle = new Circle()
            //    {
            //        Colour = Color.Azure,
            //        Radius = 15,
            //        Center = mouse.Location
            //    };
            //    draw.Push(circle);
            //    redo.Clear();

            //    drawCircle = false;
            //}

            else if (drawRectangle)
            {

                Rectangle newRectangle = new Rectangle
                {
                    Type = Shape.ShapeType.Rectangle,
                    Position = e.Location,
                    Colour = SelectedColor,
                    Length = 35,
                    Height = 20,
                };
                drawHistory.Push(newRectangle);
                drawRectangle = false;

            }
            //var mouse = (MouseEventArgs)e;
            //var rectangle = new Rectangle()
            //{
            //    Colour = Color.OrangeRed,
            //    Center = mouse.Location,
            //    Height = 15,
            //    Length = 10,
            //};

            //draw.Push(rectangle);
            //redo.Clear();
            //drawRectangle = false;

            else if (drawTriangle)
            {
                Triangle newTriangle = new Triangle
                {
                    Type = Shape.ShapeType.Triangle,
                    Position = e.Location,
                    Colour = SelectedColor,
                    Top = new Point(e.Location.X, e.Location.Y - 30),
                    Left = new Point(e.Location.X - 25, e.Location.Y + 15),
                    Right = new Point(e.Location.X + 25, e.Location.Y - 15),



                };
                drawHistory.Push(newTriangle);
                drawTriangle = false;

            }

            picture_box.Refresh();
            //var mouse = (MouseEventArgs)e;
            //var triangle = new Triangle()
            //{
            //    Colour = Color.PaleGreen,
            //    Center = mouse.Location
            //};
            //draw.Push(triangle);
            //redo.Clear();
            //drawTriangle = false;
        }




        private void btn_colors_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (btn_colors.SelectedItem.ToString())
            {
                case
                    "Green":
                    SelectedColor = Color.Green;
                    break;
                case
                    "Blue":
                    SelectedColor = Color.Blue;
                    break;
                case
                    "Red":
                    SelectedColor = Color.Red;
                    break;
                case
                    "Orange":
                    SelectedColor = Color.Orange;
                    break;
                case
                    "Purple":
                    SelectedColor = Color.Purple;
                    break;
                case
                    "Pink":
                    SelectedColor = Color.Pink;
                    break;
                case
                    "Cyan":
                    SelectedColor = Color.DarkCyan;
                    break;

                default:
                    break;
            }

        }

        
    }
}
