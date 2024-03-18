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

        private Stack<Shape> drawHistory = new Stack<Shape>(); //Stacken f�r historik

        private Stack<Shape> redoHistory = new Stack<Shape>(); //stacken f�r att �ngra "undo"
        Color SelectedColor;

        private void btn_draw_circle_Click(object sender, EventArgs e)
        {
            drawCircle = true;
            drawTriangle = false;
            drawRectangle = false;
        }

        private void btn_draw_rectangle_Click(object sender, EventArgs e)
        {
            drawRectangle = true;
            drawTriangle = false;
            drawCircle = false;
        }

        private void btn_draw_triangle_Click(object sender, EventArgs e) //om en form blir true �r de andra false = den ska ritas ut
        {
            drawTriangle = true;
            drawCircle = false;
            drawRectangle = false;
        }

        private void btn_savefile_Click(object sender, EventArgs e) //metod f�r att spara txt fil
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

        private void btn_load_Click(object sender, EventArgs e) //metod f�r att hitta filen och ladda in den i programmet
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files|*.*"; //S�ker efter alla typer av filer ist�llet f�r specifik typ
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
        private void btn_saveImage_Click(object sender, EventArgs e) //Spara ritning som bild ist�llet f�r text format
        {
            using (var saveImage = new SaveFileDialog())
            {
                saveImage.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
                if (saveImage.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(picture_box.Width, picture_box.Height);

                    picture_box.DrawToBitmap(bmp, picture_box.ClientRectangle);

                    bmp.Save(saveImage.FileName);

                }
            }
        }
    
        private void btn_clear_Click(object sender, EventArgs e) //rensa rutan
        {

            drawHistory.Clear();
            picture_box.Refresh();
        }

        private void btn_undo_Click(object sender, EventArgs e) //�ngra sig
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
  
            }           
        }

        private void picture_box_MouseDown(object sender, MouseEventArgs e) //vad som ska h�nda n�r man klickar p� ritytan, "d�r ska formen ritas och i detta format".
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
              
            }

            else if (drawRectangle)
            {

                Rectangle newRectangle = new Rectangle
                {
                    Type = Shape.ShapeType.Rectangle,
                    Position = e.Location, //e.location inneb�r d�r man klickar
                    Colour = SelectedColor, 
                    Length = 50,
                    Height = 30, //val av storlek
                };
                drawHistory.Push(newRectangle);
            }

            else if (drawTriangle)
            {
                Triangle newTriangle = new Triangle
                {
                    Type = Shape.ShapeType.Triangle,
                    Position = e.Location,
                    Colour = SelectedColor,
                    Top = new Point(e.Location.X, e.Location.Y - 30),
                    Left = new Point(e.Location.X - 25, e.Location.Y + 15),
                    Right = new Point(e.Location.X + 25, e.Location.Y + 15),



                };
                drawHistory.Push(newTriangle);

            }

            picture_box.Refresh();
        }

        private void btn_colors_SelectedIndexChanged(object sender, EventArgs e) //Knappen f�r att byta f�rg
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
