namespace Gmanga
{
    partial class MangaPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.summeryTextBox = new System.Windows.Forms.RichTextBox();
            this.MangaCoverPBox = new System.Windows.Forms.PictureBox();
            this.chapterListTable = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.scrollPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MangaCoverPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBarBox
            // 
            this.searchBarBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBarBox_KeyDown);
            // 
            // scrollPanel
            // 
            this.scrollPanel.Controls.Add(this.mainPageButton);
            this.scrollPanel.Controls.Add(this.label1);
            this.scrollPanel.Controls.Add(this.chapterListTable);
            this.scrollPanel.Controls.Add(this.MangaCoverPBox);
            this.scrollPanel.Controls.Add(this.summeryTextBox);
            this.scrollPanel.Controls.SetChildIndex(this.addFiles, 0);
            this.scrollPanel.Controls.SetChildIndex(this.summeryTextBox, 0);
            this.scrollPanel.Controls.SetChildIndex(this.pictureBox1, 0);
            this.scrollPanel.Controls.SetChildIndex(this.searchBarBox, 0);
            this.scrollPanel.Controls.SetChildIndex(this.MangaCoverPBox, 0);
            this.scrollPanel.Controls.SetChildIndex(this.chapterListTable, 0);
            this.scrollPanel.Controls.SetChildIndex(this.label1, 0);
            this.scrollPanel.Controls.SetChildIndex(this.mainPageButton, 0);
            // 
            // addFiles
            // 
            this.addFiles.Text = "Add Chapter";
            this.addFiles.Click += new System.EventHandler(this.addFiles_Click);
            // 
            // summeryTextBox
            // 
            this.summeryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summeryTextBox.Location = new System.Drawing.Point(1229, 304);
            this.summeryTextBox.Name = "summeryTextBox";
            this.summeryTextBox.ReadOnly = true;
            this.summeryTextBox.Size = new System.Drawing.Size(558, 471);
            this.summeryTextBox.TabIndex = 2;
            this.summeryTextBox.Text = "";
            // 
            // MangaCoverPBox
            // 
            this.MangaCoverPBox.Location = new System.Drawing.Point(103, 253);
            this.MangaCoverPBox.Name = "MangaCoverPBox";
            this.MangaCoverPBox.Size = new System.Drawing.Size(721, 434);
            this.MangaCoverPBox.TabIndex = 3;
            this.MangaCoverPBox.TabStop = false;
            // 
            // chapterListTable
            // 
            this.chapterListTable.AutoScroll = true;
            this.chapterListTable.ColumnCount = 1;
            this.chapterListTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chapterListTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chapterListTable.Location = new System.Drawing.Point(103, 809);
            this.chapterListTable.Name = "chapterListTable";
            this.chapterListTable.RowCount = 2;
            this.chapterListTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chapterListTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chapterListTable.Size = new System.Drawing.Size(628, 120);
            this.chapterListTable.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(100, 759);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chapters :";
            // 
            // mainPageButton
            // 
            this.mainPageButton.Location = new System.Drawing.Point(734, 79);
            this.mainPageButton.Name = "mainPageButton";
            this.mainPageButton.Size = new System.Drawing.Size(167, 37);
            this.mainPageButton.TabIndex = 6;
            this.mainPageButton.Text = "Main Page";
            this.mainPageButton.UseVisualStyleBackColor = true;
            this.mainPageButton.Click += new System.EventHandler(this.mainPageButton_Click);
            // 
            // MangaPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Name = "MangaPage";
            this.Text = "MangaPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MangaPage_FormClosing);
            this.Load += new System.EventHandler(this.MangaPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MangaCoverPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox MangaCoverPBox;
        private System.Windows.Forms.RichTextBox summeryTextBox;
        private System.Windows.Forms.TableLayoutPanel chapterListTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mainPageButton;
    }
}