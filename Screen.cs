using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmanga
{
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }


        protected void addFileToStorage(string receivedPath, string receivedFileName)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            folderDialog.Description = receivedPath;

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {

                string selectedDirecotry = folderDialog.SelectedPath;

                string folderName = Path.GetFileName(selectedDirecotry);

                OpenFileDialog fileDialog = new OpenFileDialog();

                fileDialog.Multiselect = true;



                fileDialog.Filter = "Image files (*.jpg, *.png, *txt) | *.jpg;*.png;*.txt";

                string folderPath = Path.Combine(selectedDirecotry);

                StreamWriter write = new StreamWriter(Path.Combine(receivedPath, receivedFileName));

                int folderCounters = 0;

                folderCounters = Directory.GetDirectories(folderPath).Length;

                string[] names = Directory.GetDirectories(receivedPath);

                

                for (int i = 0; i < names.Length; i++) 
                {
                    names[i] = Path.GetFileName(names[i]);
                }

                for (int i = 0; i < folderCounters; i++)
                {
                    write.WriteLine(names[i]);
                }

                write.Close();

                write = new StreamWriter(Path.Combine(folderPath, "pages.txt"));

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    int fileIndex = 1;

                    foreach (string path in fileDialog.FileNames)
                    {
                        string fileName = Path.GetFileName(path);
                        string extentionFile = Path.GetExtension(path);

                        string newFileName = $"{fileIndex}{extentionFile}";

                        string destinationPath = Path.Combine(folderPath, newFileName);

                        write.WriteLine(newFileName);

                        File.Copy(path, destinationPath, true);

                        fileIndex++;
                    }

                    write.Close();
                }

            }
        }
    }
}
