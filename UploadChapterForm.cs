using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmanga
{
    public partial class UploadChapterForm : Form
    {
        public UploadChapterForm()
        {
            InitializeComponent();
        }

        private void chapterNumberBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(chapterNumberBox.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError(chapterNumberBox, "Should not be empty!");
            }

            else 
            {
                e.Cancel = false;

                errorProvider1.SetError(chapterNumberBox, "");
            }
        }
    }
}
