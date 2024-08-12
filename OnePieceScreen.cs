using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gmanga
{
    public partial class OnePieceScreen : Screen
    {
        public OnePieceScreen()
        {
            InitializeComponent();

        }

        List <string>paths;

        static  string projectDirectory = 
            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

        string pathDirectory = Path.Combine(projectDirectory, "Gmanga", "Storage", "one piece", "1119");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(Path.Combine(pathDirectory, "1119.txt"));

                string line;

                paths = new List<string>();

                while ((line = reader.ReadLine())!= null) 
                {
                    paths.Add(line);
                }
            }
            catch (FileNotFoundException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            if (paths.Count > 0) 
            {
                flowLayoutPanel1.Controls.Clear();

                flowLayoutPanel1.Dock = DockStyle.None;
               
                flowLayoutPanel1.AutoScroll = true;
                

                int imageHeight = 1200;
                int imageWidth = 1150;
                int space = 50;
                int x = 177, y = 30;

               

                foreach (string path in paths) 
                {
                    PictureBox picture = new PictureBox();

                    picture.Size = new Size(imageWidth, imageHeight);
                    picture.SizeMode = PictureBoxSizeMode.StretchImage;

                    picture.Location = new Point(x, y);

                    picture.Margin = new Padding(x, 0, 0, space);
                    picture.Image = Image.FromFile(Path.Combine(pathDirectory , path));


                    y += imageHeight + space;




                    flowLayoutPanel1.Controls.Add(picture);


                }
            }

            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
