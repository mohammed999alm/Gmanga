using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Gmanga
{
    public partial class ChapterPage : Form
    {

     
        public ChapterPage()
        {
            InitializeComponent();
        }

        private void ChapterPage_Load(object sender, EventArgs e)
        {
            
        }



        Button prevBtn;

        Button nextBtn;

        Button homeBtn;

        Button mangaBtn;

        FlowLayoutPanel buttons;

        FlowLayoutPanel dropDownLists;

        ComboBox chapterDropDownList;

        PictureBox picture;

        Image image;

        short chapterIndex = 0;

        string currentPageNumber = "1";

        sbyte pageNumber;

        List<string> pagesList = new List<string>();

        string mangaPath;

        string chaptersPaths;

        string chapterPath;

        string currentChapter;

        string path;

        string title;

        

        List <string> chapters = new List<string>();   
        public void showChapterPage(string path, string title, string chapterNumber) 
        {

            this.path = path;

            this.title = title;

            this.chapterPath = Path.Combine(path, title, chapterNumber);

            this.currentChapter = chapterNumber;

            this.mangaPath = Path.Combine(path, title);

            this.chaptersPaths = Path.Combine(mangaPath, "chapters.txt");

            loadChaptersList();

            chapterDropDownList.SelectedIndexChanged += chapterDropDownList_SelectedIndexChanged;

            pageMode.SelectedIndex = 0;

            loadChapter();
        }


        private bool getChapterIndex(short index)
        {
            if (index < chapters.Count() && index >= 0) 
            {
                chapterDropDownList.SelectedIndex = index;

                return true;
            }

            return false;
        }
        

        private void loadChaptersList() 
        {
            try 
            {
                chapterDropDownList = new ComboBox();

                chapters.Clear();

                StreamReader reader = new StreamReader(chaptersPaths);

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    chapterDropDownList.Items.Add(line);

                    chapters.Add(line);
                }

                setChapterNumber();
                reader.Close();

            }
            catch (FileNotFoundException ex) 
            {
            
            }
        }

        private void setChapterNumber() 
        {
            for (short i = 0; i < chapterDropDownList.Items.Count; i++) 
            {
                if (currentChapter == chapterDropDownList.Items[i].ToString()) 
                {
                    chapterDropDownList.SelectedIndex = i;

                    return;
                }
            }
        }


        private void copyChapterDorpDownListItems(ComboBox chaptersList)
        {
            chaptersList.Items.Clear();

            
           for (short i = 0; i < chapters.Count; i++)
           {
                chaptersList.Items.Add(chapters[i]);
           }
        }

        private short getChapterIndex(string chapterNumber) 
        {
            short counter = 0;

            foreach (string chapter in chapters) 
            {
                if (chapter == chapterNumber) 
                {
                    return counter;
                }

                counter++;
            }

            return -1;
        }


        private void setButtonLayout(Button button) 
        {

            button.BackColor = Color.Black;

            button.ForeColor = Color.White;

            button.Font = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);

            button.AutoSize = true;

        }

        private void HomeButton_Click(object sender, EventArgs e) 
        {
            this.Close();

            MangaPage.closeTheMangaPage();

            MainPageScreen.goBackToMainPage();
        }

        private void mangaButton_Click(object sender, EventArgs e)
        {
            this.Close();

            MangaPage.goBackToCMangaPage();
        }
        private FlowLayoutPanel buttonsInitialize() 
        {


            homeBtn = new Button();

            homeBtn.Text = "Home";

            setButtonLayout(homeBtn);

            homeBtn.Click += HomeButton_Click;

            mangaBtn = new Button();

            mangaBtn.Text = title;

            setButtonLayout(mangaBtn);

            mangaBtn.Click += mangaButton_Click;


            prevBtn = new Button();

            prevBtn.Text = "Prev";

            setButtonLayout(prevBtn);

            prevBtn.Click += prevButton_Clicked;

            nextBtn = new Button();

            nextBtn.Text = "Next";

            setButtonLayout(nextBtn);

            nextBtn.Click += nextButton_Clicked;

            buttons = new FlowLayoutPanel();

            buttons.FlowDirection = FlowDirection.LeftToRight;

            buttons.Padding = new Padding(10, 10, 10, 10);


            buttons.Controls.Add(homeBtn);
            buttons.Controls.Add(mangaBtn);
            buttons.Controls.Add(prevBtn);
            buttons.Controls.Add(nextBtn);

            return buttons;
        }

        private FlowLayoutPanel dropListInitializer() 
        {
            
            ComboBox pageList = new ComboBox();

            pageList.Items.Add("one page");
            pageList.Items.Add("all pages");

            pageList.SelectedIndex = pageMode.SelectedIndex;

            pageList.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            ComboBox chapters = new ComboBox();

            copyChapterDorpDownListItems(chapters);

            chapters.SelectedIndex = chapterDropDownList.SelectedIndex;

            chapters.SelectedIndexChanged += chapterDropDownList_SelectedIndexChanged;

            dropDownLists = new FlowLayoutPanel();
            
            dropDownLists.FlowDirection = FlowDirection.LeftToRight;

            dropDownLists.Padding = new Padding(10, 0, 10, 10);

            dropDownLists.Controls.Add(pageList);
            dropDownLists.Controls.Add(chapters);

            return dropDownLists;
        }
        private void initializeComponents() 
        {

            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.AutoScroll = false;

            setTablePanelStyle();

            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;


            buttons = buttonsInitialize();

            dropDownLists = dropListInitializer();

            tableLayoutPanel1.Controls.Add(buttons, 0, 0);

            tableLayoutPanel1.Controls.Add(dropDownLists, 0, 1);

            tableLayoutPanel1.AutoScroll = true;
        }


        private void setTablePanelStyle() 
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        }


        private void loadChapter() 
        {
            loadChapterPages();
            if (pageMode.SelectedItem.ToString() == "one page")
            {
                initializeComponents();
                tableLayoutPanel1.RowCount = 3;
                tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

                tableLayoutPanel1.AutoSize = true;

                loadOnePage();
            }

            else 
            {

                initializeComponents();

                if (chapterIndex == chapters.Count - 1)
                {
                    nextBtn.Hide();
                }

                if (chapterIndex == 0)
                {
                    prevBtn.Hide();
                }

                tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
       
                loadAllPages();

            }
        }


        private void checkPrevButtonVisibilityControl() 
        {
            if (chapterIndex == 0 && pageNumber == 1)
            {
                prevBtn.Hide();
            }

            else 
            {
                prevBtn.Show();
            }
        }

        private void checkNextButtonVisibilityControl()
        {
            if (chapterIndex == chapters.Count - 1 && pageNumber == pagesList.Count)
            {
                nextBtn.Hide();
            }

            else
            {
                nextBtn.Show();
            }
        }


        private void setImageLayout(int index) 
        {
            picture = new PictureBox();

            using (image = Image.FromFile(Path.Combine(chapterPath, pagesList[index]))) 
            {
                picture.Image = new Bitmap(image);
            } 

            picture.SizeMode = PictureBoxSizeMode.StretchImage;

            picture.Size = new Size(1200, 2300);

            picture.Padding = new Padding(200, 10, 200, 10);

            
        }



        private int imagesLoadedPerPage = 5;

        private int lastVisibleIndex = 0;


        private void loadAllPages()
        {


            try
            {

                for (int i = 0; i < pagesList.Count; i++)
                {
                    setImageLayout(i);

                    tableLayoutPanel1.Controls.Add(picture);


                    if (i >= imagesLoadedPerPage)
                    {
                        picture.Visible = false;
                    }
                }


                int rowsCount = tableLayoutPanel1.Controls.Count;



                buttons = buttonsInitialize();
                dropDownLists = dropListInitializer();

                tableLayoutPanel1.Controls.Add(buttons);
                tableLayoutPanel1.Controls.Add(dropDownLists);

                //buttons.Visible = false;

                tableLayoutPanel1.Scroll += (sender, e) =>
                {

                    int firstVisibleIndex = tableLayoutPanel1.VerticalScroll.Value / 2300;

                    int loadedImageCount = firstVisibleIndex + imagesLoadedPerPage;

                    for (int i = lastVisibleIndex; i < loadedImageCount && i < tableLayoutPanel1.Controls.Count; i++)
                    {
                        tableLayoutPanel1.Controls[i].Visible = true;
                    }

                    tableLayoutPanel1.Controls[0].Visible = true;

                    lastVisibleIndex = loadedImageCount;
                };
            }
            catch (FileNotFoundException)
            {

            }
        }


        private bool nextOrPrevChapter(short number) 
        {

            return getChapterIndex(chapterIndex);
        }
        private void loadOnePage() 
        {
            pageNumber = sbyte.Parse(currentPageNumber);
       
            try
            {
                checkPrevButtonVisibilityControl();

                checkNextButtonVisibilityControl();


                picture = new PictureBox();

                Size imageSize;

                using (image = Image.FromFile(Path.Combine(chapterPath, currentPageNumber + ".jpg"))) 
                {
                      picture.Image = new Bitmap(image);

                    imageSize = image.Size;
                }

               


                picture.SizeMode = PictureBoxSizeMode.StretchImage;


                picture.Size = imageSize;

                //picture.Image = Image.FromFile(Path.Combine(path, currentPageNumber + ".jpg"));


                picture.Padding = new Padding(200, 10, 200, 10);

    
                tableLayoutPanel1.AutoScroll = true;

                tableLayoutPanel1.Controls.Add(picture, 0, 2);

            }
            catch (FileNotFoundException ex) 
            {
                
            }
        }
        
        private void loadChapterPages() 
        {
            try 
            {
                pagesList.Clear();
                StreamReader reader = new StreamReader(this.chapterPath + "\\pages.txt");

                string page;

                while ((page = reader.ReadLine() )!= null) 
                {
                    pagesList.Add(page);
                }

                reader.Close();
            } 
            catch (FileNotFoundException ex)
            {
            
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox list = (ComboBox)sender;


            pageMode.SelectedIndex = list.SelectedIndex;

            loadChapter();
        }

        private void nextButton_Clicked(object sender, EventArgs e) 
        {
            switch (pageMode.SelectedItem.ToString())
            {
                case "one page":


                    pageNumber++;

                    checkPrevButtonVisibilityControl();

                    checkNextButtonVisibilityControl();

                    if (pageNumber <= pagesList.Count)
                    {
                        currentPageNumber = pageNumber.ToString();

                        using (Image image = Image.FromFile(Path.Combine(chapterPath, currentPageNumber + ".jpg"))) 
                        {
                            picture.Image = new Bitmap(image);
                        } 
                    }

                    else
                    {

                        if (chapterIndex < chapters.Count - 1)
                        {
                            chapterIndex++;

                            getChapterIndex(chapterIndex);
                        }
                    }

                    break;


                case "all pages":

                    if (chapterIndex < chapters.Count - 1)
                    {               
                        chapterIndex++;

                        getChapterIndex(chapterIndex);
                    }

                    break;
            }

        }

        private void prevButton_Clicked(object sender, EventArgs e)
        {

            Button button = (Button)sender;

            
            
               switch (pageMode.SelectedItem.ToString())
               {
                   case "one page":

                       pageNumber--;

                       checkPrevButtonVisibilityControl();

                       checkNextButtonVisibilityControl();

                       if (pageNumber <= 0)
                       {
                           if (chapterIndex > 0)
                           {
                               chapterIndex--;

                               getChapterIndex(chapterIndex);
                           }
                  
                           return;
                       }



                       if (pageNumber <= pagesList.Count)
                       {
                           currentPageNumber = pageNumber.ToString();

                        using (Image image = Image.FromFile(Path.Combine(chapterPath, currentPageNumber + ".jpg")))
                        {
                            picture.Image = new Bitmap(image);
                        }
                    }

                       break;


                   case "all pages":


                       if (chapterIndex > 0)
                       {
                           chapterIndex--;

                           getChapterIndex(chapterIndex);
                       }

                       break;
               }

            

        }
        private void chapterDropDownList_SelectedIndexChanged(object sender, EventArgs e) 
        {
            ComboBox list = (ComboBox)sender;

            this.currentChapter = Convert.ToUInt16(list.SelectedItem).ToString();
            this.currentPageNumber = "1";

            chapterDropDownList.SelectedIndex = list.SelectedIndex;


            chapterIndex = Convert.ToInt16(list.SelectedIndex);

            showChapterPage(path, title, currentChapter); 
        }

        private void ChapterPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            MangaPage.goBackToCMangaPage();
        }
    }
}
