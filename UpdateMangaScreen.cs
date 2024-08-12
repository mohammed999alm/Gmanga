using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gmanga
{
    public partial class UpdateMangaScreen : UploadMangaForm
    {
        public UpdateMangaScreen()
        {
            InitializeComponent();
        }

        private void UpdateMangaScreen_Load(object sender, EventArgs e)
        {

        }

        static string mainPagePath;

        const string dataFile = "manga list.txt";

        string pagePath;

        string summeryStory;

        string imagePath;

        const string summeryFile = "summery story.txt";
        public void showUpdateMangaScreen(string path, string title) 
        {
            chapterNumberBox.Text = title;

            mainPagePath = path;

            pagePath = Path.Combine(mainPagePath, title);

            //string imageFile = Path.Combine(path, title, $"{title}.jpg");

            try
            {
                using (Image image = Image.FromFile(Path.Combine(path, title, title + ".jpg")))
                {
                    pictureBox1.Image = new Bitmap(image);
                }
            }

            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                using (StreamReader read = new StreamReader(Path.Combine(path, title, "summery story.txt")))
                {
                    richTextBox1.Text = read.ReadToEnd();

                    summeryStory = richTextBox1.Text;
                }
            }

            catch (IOException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileHandle = new OpenFileDialog();

            fileHandle.Filter = "Image files (*.jpg, *.png) | *.jpg;*.png;";


            if (fileHandle.ShowDialog() == DialogResult.OK)
            {

                foreach (string path in fileHandle.FileNames)
                {
                    imagePath = path;

                    using (Image image = Image.FromFile(imagePath))
                    {
                        pictureBox1.Image = new Bitmap(image);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderName = chapterNumberBox.Text;

            if (MessageBox.Show("Are you sure you want to update manga ?", "Update Manga", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        string fileName = Path.GetFileName(imagePath);

                        string extention = Path.GetExtension(imagePath);

                        string newFileName = $"{folderName}{extention}";

                        string detinationPath = Path.Combine(pagePath, newFileName);


                        File.Copy(imagePath, detinationPath, true);
                    }

                    if (richTextBox1.Text != summeryStory)
                    {
                        using (StreamWriter write = new StreamWriter(Path.Combine(pagePath, summeryFile)))
                        {
                            write.WriteLine(richTextBox1.Text);
                        }
                    }

                    this.Close();
                }

                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

 
    }
}
