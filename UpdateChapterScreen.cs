using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmanga
{
    public partial class UpdateChapterScreen : UploadChapterForm
    {
        public UpdateChapterScreen()
        {
            InitializeComponent();     
        }

        private void UpdateChapterScreen_Load(object sender, EventArgs e)
        {

        }
        static string mangaPagePath;

        const string dataFile = "chapters.txt";

        string fileStoragePath;

        string oldFileName;

        static List<string> chaptersList;

        List<short> chaptersSort;

        string mangaTitle;

        List<string> imagesPath;
 
        public void showUpdateChapterScreen(string path, string title, string chapterNumber)
        {
            mangaTitle = title;

            mangaPagePath = path;

            oldFileName = chapterNumber;

            chapterNumberBox.Text = chapterNumber;

            try
            {
                using (Image image = Image.FromFile(Path.Combine(mangaPagePath, $"{title}.jpg")))
                {
                    pictureBox1.Image = new Bitmap(image);
                }

            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

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


        private void button1_Click_1(object sender, EventArgs e)
        {
            string folderName = chapterNumberBox.Text;

            string folderPath = Path.Combine(mangaPagePath, oldFileName);

            string newFolderPath = Path.Combine(mangaPagePath, folderName);

            byte index = 0;

            if (MessageBox.Show("Are You Sure You Want To Add This Chapter ? ", "Add Manga Chapter", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (Directory.Exists(folderPath))
                {
                  
                    try
                    {

                        if (folderName != oldFileName)
                        {
                            Directory.Move(folderPath, newFolderPath);


                            chaptersSort.Add(short.Parse(folderName));

                            chaptersSort.Sort();

                            using (StreamWriter write = new StreamWriter(fileStoragePath))
                            {
                                foreach (short chapter in chaptersSort)
                                {
                                    if (chapter.ToString() != oldFileName)
                                    {
                                        write.WriteLine(chapter.ToString());
                                    }
                                }
                            }

                        }

                        if (imagesPath != null)
                        {

                            using (StreamWriter write = new StreamWriter(Path.Combine(newFolderPath, "pages.txt")))
                            {
                                foreach (string path in imagesPath)
                                {
                                    string fileName = Path.GetFileName(path);

                                    string extention = Path.GetExtension(fileName);


                                    string newFileName = $"{++index}{extention}";

                                    write.WriteLine(newFileName);

                                    string destinationPath = Path.Combine(newFolderPath, newFileName);

                                    File.Copy(path, destinationPath, true);
                                }
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
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
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
