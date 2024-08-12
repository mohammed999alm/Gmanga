using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gmanga
{
    public partial class AddChapterScreen : UploadChapterForm
    {
        public AddChapterScreen()
        {
            InitializeComponent();
        }

        static string mangaPagePath;

        const string dataFile = "chapters.txt";

        string fileStoragePath;

        static List<string> chaptersList;

        List<short> chaptersSort;

        string mangaTitle;

        List<string> imagesPath;
        private void AddChapterScreen_Load(object sender, EventArgs e)
        {
            //pictureBox1.Click += PictureBox1_Click;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void showAddChapterScreen(string path, string title) 
        {
            mangaTitle = title;

            mangaPagePath = path;

            loadChapterList();
        }

        private void loadChapterList()
        {
            fileStoragePath = Path.Combine(mangaPagePath, dataFile);



            chaptersList = new List<string>();

            chaptersSort = new List<short>();

            if (File.Exists(fileStoragePath))
            {
                try
                {


                    using (StreamReader read = new StreamReader(fileStoragePath))
                    {

                        string line;

                        while (!string.IsNullOrEmpty(line = read.ReadLine()))
                        {
                            chaptersSort.Add(short.Parse(line));
                            chaptersList.Add(line);
                        }
                    }

                }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string folderName = chapterNumberBox.Text;

            string folderPath = Path.Combine(mangaPagePath, folderName);
           
            byte index = 0;

            if (MessageBox.Show("Are You Sure You Want To Add This Chapter ? ", "Add Manga Chapter", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                try
                {
                        
                        chaptersSort.Add(short.Parse(folderName));

                        chaptersSort.Sort();

                        using (StreamWriter write = new StreamWriter(fileStoragePath))
                        {
                            foreach (short chapter in chaptersSort) 
                            {
                                write.WriteLine(chapter.ToString());
                            }
                        }


                        using (StreamWriter write = new StreamWriter(Path.Combine(folderPath, "pages.txt")))
                        {
                            foreach (string path in imagesPath)
                            {
                                string fileName = Path.GetFileName(path);

                                string extention = Path.GetExtension(fileName);


                                string newFileName = $"{++index}{extention}";

                                write.WriteLine(newFileName);

                                string destinationPath = Path.Combine(folderPath, newFileName);

                                File.Copy(path, destinationPath, true);
                            }
                        }


                        this.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileHandle = new OpenFileDialog();

            fileHandle.Multiselect = true;

            fileHandle.Filter = "Images file (*.jpg, *.png) | *jpg; *png;";


            if (fileHandle.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    imagesPath = new List<string>();

                    foreach (string path in fileHandle.FileNames)
                    {
                        imagesPath.Add(path);
                    }

                    using (Image image = Image.FromFile(Path.Combine(mangaPagePath, $"{mangaTitle}.jpg"))) 
                    {
                        pictureBox1.Image = new Bitmap(image);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}

