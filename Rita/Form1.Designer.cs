namespace Rita
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picture_box = new PictureBox();
            btn_clear = new Button();
            btn_undo = new Button();
            btn_savefile = new Button();
            btn_draw_circle = new Button();
            btn_draw_rectangle = new Button();
            btn_draw_triangle = new Button();
            btn_colors = new ComboBox();
            saveFileDialog1 = new SaveFileDialog();
            btn_load = new Button();
            btn_saveImage = new Button();
            ((System.ComponentModel.ISupportInitialize)picture_box).BeginInit();
            SuspendLayout();
            // 
            // picture_box
            // 
            picture_box.BackColor = SystemColors.ControlLightLight;
            picture_box.Location = new Point(0, 0);
            picture_box.Name = "picture_box";
            picture_box.Size = new Size(1010, 375);
            picture_box.TabIndex = 0;
            picture_box.TabStop = false;
            picture_box.Paint += picture_box_Paint;
            picture_box.MouseClick += picture_box_MouseDown;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(887, 404);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(94, 29);
            btn_clear.TabIndex = 1;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // btn_undo
            // 
            btn_undo.Location = new Point(887, 466);
            btn_undo.Name = "btn_undo";
            btn_undo.Size = new Size(94, 29);
            btn_undo.TabIndex = 2;
            btn_undo.Text = "Undo";
            btn_undo.UseVisualStyleBackColor = true;
            btn_undo.Click += btn_undo_Click;
            // 
            // btn_savefile
            // 
            btn_savefile.Location = new Point(756, 404);
            btn_savefile.Name = "btn_savefile";
            btn_savefile.Size = new Size(94, 29);
            btn_savefile.TabIndex = 3;
            btn_savefile.Text = "Save as file";
            btn_savefile.UseVisualStyleBackColor = true;
            btn_savefile.Click += btn_savefile_Click;
            // 
            // btn_draw_circle
            // 
            btn_draw_circle.Location = new Point(12, 404);
            btn_draw_circle.Name = "btn_draw_circle";
            btn_draw_circle.Size = new Size(94, 29);
            btn_draw_circle.TabIndex = 4;
            btn_draw_circle.Text = "Circle";
            btn_draw_circle.UseVisualStyleBackColor = true;
            btn_draw_circle.Click += btn_draw_circle_Click;
            // 
            // btn_draw_rectangle
            // 
            btn_draw_rectangle.Location = new Point(139, 404);
            btn_draw_rectangle.Name = "btn_draw_rectangle";
            btn_draw_rectangle.Size = new Size(94, 29);
            btn_draw_rectangle.TabIndex = 5;
            btn_draw_rectangle.Text = "Rectangle";
            btn_draw_rectangle.UseVisualStyleBackColor = true;
            btn_draw_rectangle.Click += btn_draw_rectangle_Click;
            // 
            // btn_draw_triangle
            // 
            btn_draw_triangle.Location = new Point(12, 466);
            btn_draw_triangle.Name = "btn_draw_triangle";
            btn_draw_triangle.Size = new Size(94, 29);
            btn_draw_triangle.TabIndex = 6;
            btn_draw_triangle.Text = "Triangle";
            btn_draw_triangle.UseVisualStyleBackColor = true;
            btn_draw_triangle.Click += btn_draw_triangle_Click;
            // 
            // btn_colors
            // 
            btn_colors.FormattingEnabled = true;
            btn_colors.Items.AddRange(new object[] { "Green", "Blue", "Red", "Orange", "Purple", "Yellow", "Pink", "Cyan" });
            btn_colors.Location = new Point(382, 405);
            btn_colors.Name = "btn_colors";
            btn_colors.Size = new Size(142, 28);
            btn_colors.TabIndex = 7;
            btn_colors.Text = "Available Colors";
            btn_colors.SelectedIndexChanged += btn_colors_SelectedIndexChanged;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "Shape YrkeshogskolaN|.syn|Alla filer|*.*";
            // 
            // btn_load
            // 
            btn_load.Location = new Point(756, 466);
            btn_load.Name = "btn_load";
            btn_load.Size = new Size(94, 29);
            btn_load.TabIndex = 8;
            btn_load.Text = "Load file";
            btn_load.UseVisualStyleBackColor = true;
            btn_load.Click += btn_load_Click;
            // 
            // btn_saveImage
            // 
            btn_saveImage.Location = new Point(571, 466);
            btn_saveImage.Name = "btn_saveImage";
            btn_saveImage.Size = new Size(118, 29);
            btn_saveImage.TabIndex = 9;
            btn_saveImage.Text = "Save as image";
            btn_saveImage.UseVisualStyleBackColor = true;
            btn_saveImage.Click += btn_saveImage_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1010, 518);
            Controls.Add(btn_saveImage);
            Controls.Add(btn_load);
            Controls.Add(btn_colors);
            Controls.Add(btn_draw_triangle);
            Controls.Add(btn_draw_rectangle);
            Controls.Add(btn_draw_circle);
            Controls.Add(btn_savefile);
            Controls.Add(btn_undo);
            Controls.Add(btn_clear);
            Controls.Add(picture_box);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picture_box).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picture_box;
        private Button btn_clear;
        private Button btn_undo;
        private Button btn_savefile;
        private Button btn_draw_circle;
        private Button btn_draw_rectangle;
        private Button btn_draw_triangle;
        private ComboBox btn_colors;
        private SaveFileDialog saveFileDialog1;
        private Button btn_load;
        private Button btn_saveImage;
    }
}
