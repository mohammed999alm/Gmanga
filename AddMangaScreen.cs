using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Gmanga.Properties;

namespace Gmanga
{
    public partial class AddMangaScreen : UploadMangaForm
    {
        public AddMangaScreen()
        {
            InitializeComponent();
        }

        static string mainPagePath;

        static string dataFile = "manga list.txt";

        List<string> mangaDataList;

        protected string imagePath;

        public void  showAddMangaScreen(string path) 
        {
            mainPagePath = path;

            loadDataFromFile();
        }

        private void mangaTitleBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void loadDataFromFile() 
        {
            mangaDataList = new List<string>();

            using (StreamReader read = new StreamReader(Path.Combine(mainPagePath, dataFile)))
            {
                string line;

                while (!string.IsNullOrEmpty(line = read.ReadLine()))
                {
                    mangaDataList.Add(line);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadImage();
        }

        protected void loadImage() 
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

            if (mangaDataList == null)
            {
                return;
            }

            if (MessageBox.Show("Save Manga ? ", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string folderName = chapterNumberBox.Text;

                string folderPath = Path.Combine(mainPagePath, folderName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                try
                {
                    string fileName = Path.GetFileName(imagePath);

                    string fileExtention = Path.GetExtension(fileName);

                    string newImageName = $"{folderName}{fileExtention}";

                    string destinationPath = Path.Combine(folderPath, newImageName);
                    File.Copy(imagePath, destinationPath, true);

                    using (StreamWriter write = new StreamWriter(Path.Combine(folderPath, "summery story.txt")))
                    {
                        write.WriteLine(richTextBox1.Text);
                    }



                    if (!mangaDataList.Contains(folderName))
                    {
                        using (StreamWriter write = new StreamWriter(Path.Combine(mainPagePath, dataFile), true))
                        {
                            write.WriteLine(folderName);
                        }

                    }
                }


                catch (Exception ex)
                {

                    string errorMessage = "An error occurred while saving the manga.";

                    if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                    {
                        errorMessage = "Please select valid image file for the manga cover.";
                    }
                    else 
                    {
                        errorMessage = "The path for image file  might be invalid or the file could not be found";
                    }

                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                this.Close();
            }  
        }

        private void mangaTitleBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mangaDataList == null) 
            {
                return;
            }

            if (mangaDataList.Contains(chapterNumberBox.Text.Trim()) || string.IsNullOrEmpty(chapterNumberBox.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError(chapterNumberBox, "This Folder Already Exist");
            }

            if (string.IsNullOrEmpty(chapterNumberBox.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError(chapterNumberBox, "Should Not Be Empty.");
            }

            else 
            {
                e.Cancel = false;

                errorProvider1.SetError(chapterNumberBox, "");
            }
        }

        private void pictureBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (pictureBox1.Image == null || pictureBox1.Image == Resources.add_icon)
            {
                e.Cancel = true;

                errorProvider1.SetError(pictureBox1, "You Should Choose Image File To Manga Cover!");
            }

            else 
            {
                e.Cancel = false;
                errorProvider1.SetError(pictureBox1, "");
            }
        }
    }
}
