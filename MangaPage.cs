using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Gmanga
{
    public partial class MangaPage : Screen
    {
        public MangaPage()
        {
            InitializeComponent();
            mangaPage = this;
        }

        private void MangaPage_Load(object sender, EventArgs e)
        {

        }

        string path;
        string title;

        string mangaPath;

        List<string> chaptersList = new List<string>();

        static MangaPage mangaPage;
        public void showMangaPage(string path, string title)
        {
            try
            {

                this.path = path;

                this.title = title;

                mangaPath = Path.Combine(path, title);

                chaptersList.Clear();

                string imageFile = Path.Combine(path, title, title + ".jpg");

                using (Image image = Image.FromFile(imageFile)) 
                {
                    MangaCoverPBox.Image = new Bitmap(image);
                }


                MangaCoverPBox.SizeMode = PictureBoxSizeMode.StretchImage;

                StreamReader reader = new StreamReader(Path.Combine(path, title, "summery story.txt"));

                string summery = reader.ReadToEnd();

                reader.Close();

                summeryTextBox.Text = summery;



                reader = new StreamReader(Path.Combine(path, title, "chapters.txt"));

                string chapter;

                while ((chapter = reader.ReadLine()) != null)
                {
                    chaptersList.Add(chapter);
                }

                reader.Close();

                setChaptersList();
            }

            catch (FileNotFoundException ex)
            {

            }



        }


        public static void  closeTheMangaPage() 
        {
            mangaPage.Close();

            mangaPage.Dispose();
        }
        private void setTableLayout()
        {
            chapterListTable.Visible = false;

            chapterListTable.Controls.Clear();

            chapterListTable.Visible = true;

            chapterListTable.Padding = new Padding(0);

            chapterListTable.RowStyles.Clear();

            chapterListTable.ColumnStyles.Clear();


            chapterListTable.RowCount = chaptersList.Count;

            for (int i = 0; i < chaptersList.Count; i++)
            {
                chapterListTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }


            chapterListTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));

        }
        private void setChaptersList()
        {
            setTableLayout();

            foreach (string chapter in chaptersList)
            {
                Button chapterNumber = new Button();

                chapterNumber.Text = chapter;

                chapterNumber.Size = new Size(100, 50);

                chapterNumber.BackColor = Color.Black;

                chapterNumber.ForeColor = Color.White;

                chapterNumber.Font = new Font(FontFamily.GenericSerif, 18, FontStyle.Bold);

                chapterNumber.MouseDown += mouse_RightClicked;

                chapterNumber.Click += (sender, e) =>
                {
                    ChapterPage page = new ChapterPage();

                    page.showChapterPage(path, title, chapter);

                    if (!page.IsAccessible)
                    {
                        this.Hide();
                    }

                    page.Show();
                };

                chapterListTable.Controls.Add(chapterNumber);
            }
        }


        private void mouse_RightClicked(object sender, EventArgs e) 
        {
            Button button = (Button)sender;

            string chapterNumber = button.Text;

            ContextMenu menu = new ContextMenu();

            button.ContextMenu = menu;

            menu.MenuItems.Add("Update").Click += (obj, ee) => updateChapter(chapterNumber);
            menu.MenuItems.Add("Delete").Click += (obj, ee) => deleteChapter(chapterNumber);


        }

        private void updateChapter(string chapter) 
        {
            //MessageBox.Show($"you wanna update this chapter {chapter} ? ");

            UpdateChapterScreen updateScreen = new UpdateChapterScreen();

            updateScreen.showUpdateChapterScreen(mangaPath, title, chapter);

            updateScreen.ShowDialog();

            showMangaPage(path, title);
        }

        private void deleteChapter(string chapter)
        {
            //MessageBox.Show($"you wanna Delete this chapter {chapter} ? ");

            string folderPath = Path.Combine(mangaPath, chapter);

            if (Directory.Exists(folderPath))
            {
                if (MessageBox.Show($"Delete  chapter {chapter} ? ", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Directory.Delete(folderPath, true);

                    try
                    {
                        using (StreamWriter write = new StreamWriter(Path.Combine(mangaPath, "chapters.txt")))
                        {
                            foreach (string path in chaptersList)
                            {
                                if (chapter != path)
                                {
                                    write.WriteLine(path);
                                }
                            }
                        }

                        MessageBox.Show("Deleted Successfully.");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                else
                {
                    MessageBox.Show("Deletion Cancelled");
                }
            }

            else
            {
                MessageBox.Show("Error 404 Not Found Dirctory.");
            }

            showMangaPage(path, title);
        }
        private void summeryTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void searchBarBox_KeyDown(object sender, KeyEventArgs e)
        {
            MainPageScreen page = new MainPageScreen();

            page.setSearchBarText(searchBarBox.Text);

            page.searchBarBox_KeyDown(sender, e);

            if (page.getPageFound() == true)
            {
                //page.Close();
                this.Close();
            }

            page.Close();
        }


        private void addManga() 
        {
            //FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            //mangaPagePath = Path.Combine(this.path, this.title);

            //folderDialog.Description = mangaPagePath;

            //if (folderDialog.ShowDialog() == DialogResult.OK)
            //{

            //    string selectedDirecotry = folderDialog.SelectedPath;

            //    string folderName = Path.GetFileName(selectedDirecotry);

            //    OpenFileDialog fileDialog = new OpenFileDialog();

            //    fileDialog.Multiselect = true;



            //    fileDialog.Filter = "Image files (*.jpg, *.png, *txt) | *.jpg;*.png;*.txt";

            //    string folderPath = Path.Combine(selectedDirecotry);

            //    StreamWriter write = new StreamWriter(Path.Combine(mangaPagePath, "chapters.txt"));

            //    int folderCounters = 0;

            //    folderCounters = Directory.GetDirectories(mangaPagePath).Length;

            //    string[] folderNames = Directory.GetDirectories(mangaPagePath);

            //    List<short> folderIndexes = new List<short>();

            //    for (int i = 0; i < folderCounters; i++)
            //    {
            //        folderNames[i] = Path.GetFileName(folderNames[i]);

            //        if (short.TryParse(folderNames[i], out short folderIndex))
            //        {
            //             folderIndexes.Add(folderIndex);
            //        }
            //    }


            //    folderIndexes.Sort();

            //    foreach (short folderIndex in folderIndexes) 
            //    {
            //        write.WriteLine(folderIndex);
            //    }

            //    write.Close();

            //    write = new StreamWriter(Path.Combine(folderPath, "pages.txt"));

            //    if (fileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        int fileIndex = 1;

            //        foreach (string path in fileDialog.FileNames)
            //        {
            //            string fileName = Path.GetFileName(path);
            //            string extentionFile = Path.GetExtension(path);

            //            string newFileName = $"{fileIndex}{extentionFile}";

            //            string destinationPath = Path.Combine(folderPath, newFileName);

            //            write.WriteLine(newFileName);

            //            File.Copy(path, destinationPath, true);

            //            fileIndex++;
            //        }

            //        write.Close();
            //    } showMangaPage(this.path, this.title);}


        }
        private void addFiles_Click(object sender, EventArgs e)
        {
   

            AddChapterScreen addingScreen = new AddChapterScreen();

            addingScreen.showAddChapterScreen(mangaPath, title);
            addingScreen.ShowDialog();

            showMangaPage(this.path, this.title);
            
        }

        private void mainPageButton_Click(object sender, EventArgs e)
        {
            this.Close();

            MainPageScreen.goBackToMainPage();

            //this.Close();
        }

        public static void goBackToCMangaPage() 
        {
            mangaPage.Show();
        }

        private void MangaPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();

            MainPageScreen.goBackToMainPage();
        }
    }
}

