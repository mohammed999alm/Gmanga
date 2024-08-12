using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace Gmanga
{
    public partial class MainPageScreen : Screen
    {
        public MainPageScreen()
        {
            InitializeComponent();

            this.Load += MainPageScreen_Load;


            page = new MangaPage();
        }


        static List<string> paths;

        int columnCount;
        int rowCount;

    
        bool pageFound;

        static MangaPage page;

        static ChapterPage chapter;

        static MainPageScreen mangaListPage;

        static string diretoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

        static string mainPagePath = Path.Combine(diretoryPath, "Gmanga", "Storage", "Main page");


        private void MainPageScreen_Load(object sender, EventArgs e)
        {
            mangaListPage = this;

            setMangaList();
        }


        private void setMangaList() 
        {
            LoadMangaList();

            if (paths.Count > 0)
            {
                tableLayoutPanel1.Hide();
                int imageWidth = 300;
                int imageHeight = 400;

                int spacing = 10;

                intializeComponents(imageWidth, imageHeight, spacing);

            }
        }
        private void LoadMangaList() 
        {

            try
            {
                StreamReader reader = new StreamReader(Path.Combine(mainPagePath, "manga list.txt"));

                string line;

                paths = new List<string>();

                while (!string.IsNullOrEmpty((line = reader.ReadLine())))
                {
                    paths.Add(line);
                }


                reader.Close();

            }
            catch (FileNotFoundException ex)
            {

            }
        }
        private void setLayoutForPanelsCompenents() 
        {
            setScrollPanelLayout();

            setTablePanelLayout();
        }

        private void setScrollPanelLayout() 
        {
            scrollPanel.Controls.Clear();
            scrollPanel.AutoScroll = true;
            scrollPanel.Dock = DockStyle.Fill;
        }

        private void setTablePanelLayout() 
        {
            tableLayoutPanel1.Show();
            tableLayoutPanel1.Controls.Clear();

            columnCount = 4;
            rowCount = (paths.Count + columnCount - 1) / columnCount;

            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;

            tableLayoutPanel1.Dock = DockStyle.None;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            setColumnsStyle();
            setRowsStyle();

            tableLayoutPanel1.Dock = DockStyle.None;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.Padding = new Padding(150);
        }

        private void setColumnsStyle() 
        {
            for (int i = 0; i < columnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
            }
        }


        private void setRowsStyle() 
        {
            for (int i = 0; i < rowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }
        }
        private void intializeComponents(int width, int height, int spacing)
        {

            setLayoutForPanelsCompenents();

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    int index = row * columnCount + col;
                    if (index < paths.Count)
                    {
                        string path = paths[index];

                        PictureBox image = new PictureBox();
                        image.Size = new Size(width, height);
                        image.SizeMode = PictureBoxSizeMode.StretchImage;
                        //image.Image = Image.FromFile(Path.Combine(mainPagePath, path, path + ".jpg"));

                        using (Image mangaImage = Image.FromFile(Path.Combine(mainPagePath, path, path + ".jpg")))
                        {
                            image.Image = new Bitmap(mangaImage);
                        }


                        image.Margin = new Padding(spacing);

                        Button mangaTitle = new Button();
                        mangaTitle.Text = path;
                        mangaTitle.Size = new Size(width, 40);
                        mangaTitle.Font = new Font(FontFamily.GenericSerif, 18, FontStyle.Bold);
                        mangaTitle.Margin = new Padding(0, spacing, 0, 200);
                        mangaTitle.BackColor = Color.Black;
                        mangaTitle.ForeColor = Color.White;
                        mangaTitle.TextAlign = ContentAlignment.MiddleCenter;


                        mangaTitle.MouseDown += mangaTitle_MouseRightButtonDown;




                       //mangaTitle.Click += (obj, e) =>
                       //{

                       //    if (mangaTitle.Text.ToLower() == "one piece")
                       //    {
                       //        OnePieceScreen mangaPage = new OnePieceScreen();

                       //        if (!mangaPage.IsAccessible) 
                       //        {
                       //            this.Hide();
                       //        }

                       //        mangaPage.Show();
                       //    }
                       //};

                        mangaTitle.Click += mangaTitle_MouseClick;

                        tableLayoutPanel1.Controls.Add(image, col, row + row);
                        tableLayoutPanel1.Controls.Add(mangaTitle, col, row + row + 1);
                    }
                }
            }

            scrollPanel.Controls.Add(pictureBox1);
            scrollPanel.Controls.Add(searchBarBox);
            scrollPanel.Controls.Add(addFiles);
            scrollPanel.Controls.Add(tableLayoutPanel1);
        }

        private void mangaTitle_MouseClick(object sender, EventArgs e) 
        {
            Button manga = (Button)sender; 
            
            findManga(manga.Text);
        }
        private void mangaTitle_MouseRightButtonDown(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string mangaTitle = button.Text;

            ContextMenu menu = new ContextMenu();

            button.ContextMenu = menu;
        
            
            

            menu.MenuItems.Add("Update").Click += (obj, ee) =>   updateManga(mangaTitle);

            menu.MenuItems.Add("Delete").Click += (obj, ee) => deleteManga(mangaTitle);

        }


        private void updateManga(string manga) 
        {

            //addMangaOrUpdate(false);
            //MessageBox.Show($"Update {manga}");

            UpdateMangaScreen updateScreen = new UpdateMangaScreen();

            updateScreen.showUpdateMangaScreen(mainPagePath, manga);

            updateScreen.ShowDialog();

            setMangaList();

        }

        private void deleteManga(string manga) 
        {
            string folderPath = Path.Combine(mainPagePath, manga);

            if (Directory.Exists(folderPath))
            {
                if (MessageBox.Show($"Delete {manga} ? ", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Directory.Delete(folderPath, true);

                    try
                    {
                        using (StreamWriter write = new StreamWriter(Path.Combine(mainPagePath, "manga list.txt")))
                        {
                            foreach (string path in paths)
                            {
                                if (manga != path)
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

            setMangaList();
            
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void searchBarBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void scrollPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public void  setSearchBarText(string query)
        {
            searchBarBox.Text = query;
        }

        private bool findManga(string query) 
        {
            //page = new MangaPage();
            if (page.IsDisposed) 
            {
                page = new MangaPage();
            }

            foreach (string path in paths)
            {

                if (query.ToLower() == path.ToLower())
                {


                    page.showMangaPage(mainPagePath, path);


                    if (!page.IsAccessible)
                    {
                        this.Hide();
                    }

                    page.Show();

                    return true;
                }

            }

            return false;
        }


        public bool getPageFound() 
        {
            return pageFound;
        }

        public  void searchBarBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.pageFound = findManga(searchBarBox.Text);
            }
        }


        private void addToFileAppend(StreamWriter write, string mangaName) 
        {
           write.WriteLine(mangaName);

           write.Close();
        }

        private void overwriteFileContents(StreamWriter write) 
        {
            int folderCounters = 0;

            folderCounters = Directory.GetDirectories(mainPagePath).Length;

            string[] foldersPaths = Directory.GetDirectories(mainPagePath);

            for (int i = 0; i < folderCounters; i++)
            {
                foldersPaths[i] = Path.GetFileName(foldersPaths[i]);

                write.WriteLine(foldersPaths[i]);
            }

            write.Close();
        }



        private void addFileCheck(string folderName) 
        {
            StreamWriter write;

            if (paths.Count < 0)
            {
                write = new StreamWriter(Path.Combine(mainPagePath, "manga list.txt"), true);

                addToFileAppend(write, folderName);
            }
            else
            {
                write = new StreamWriter(Path.Combine(mainPagePath, "manga list.txt"));

                overwriteFileContents(write);
            }
        }
        private void addMangaOrUpdate(bool append = false) 
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            folderDialog.Description = mainPagePath;

            folderDialog.SelectedPath = mainPagePath;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {

                string selectedDirecotry = folderDialog.SelectedPath;

                string folderName = Path.GetFileName(selectedDirecotry);

                OpenFileDialog fileDialog = new OpenFileDialog();

                fileDialog.Multiselect = true;



                fileDialog.Filter = "Image files (*.jpg, *.png, *txt) | *.jpg;*.png;*.txt";

                string folderPath = Path.Combine(selectedDirecotry);
                
                StreamWriter write;


                if (append)
                {
                    addFileCheck(folderName);
                }

                else 
                {
                    write = new StreamWriter(Path.Combine(mainPagePath, "manga list.txt"));
                    overwriteFileContents(write);  
                }
        
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    int fileIndex = 1;

                    foreach (string path in fileDialog.FileNames)
                    {
                        string fileName = Path.GetFileName(path);
                        string extentionFile = Path.GetExtension(path);

                        string newFileName = $"{folderName}{extentionFile}";

                        string destinationPath = Path.Combine(folderPath, newFileName);

                        //write.WriteLine(newFileName);

                        File.Copy(path, destinationPath, true);

                        fileIndex++;
                    }

                   
                }
            }

        }
        private void addFiles_Click(object sender, EventArgs e)
        {
            //addMangaOrUpdate(true);
            AddMangaScreen addScreen = new AddMangaScreen();
            addScreen.showAddMangaScreen(mainPagePath);

            addScreen.ShowDialog();

            setMangaList();
        }



    
        public static void goBackToMainPage() 
        {

            //if (mangaListPage.IsDisposed)
            //{
            //    mangaListPage = new MainPageScreen();
            //}

            if (page.IsDisposed)
            {
                mangaListPage.Show();
            }
        }
    }   
}



