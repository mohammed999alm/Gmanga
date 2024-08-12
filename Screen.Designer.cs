namespace Gmanga
{
    partial class Screen
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchBarBox = new System.Windows.Forms.TextBox();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.addFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.scrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gmanga.Properties.Resources.search_icon;
            this.pictureBox1.Location = new System.Drawing.Point(257, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // searchBarBox
            // 
            this.searchBarBox.Location = new System.Drawing.Point(328, 79);
            this.searchBarBox.Name = "searchBarBox";
            this.searchBarBox.Size = new System.Drawing.Size(235, 22);
            this.searchBarBox.TabIndex = 1;
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.AutoSize = true;
            this.scrollPanel.Controls.Add(this.addFiles);
            this.scrollPanel.Controls.Add(this.searchBarBox);
            this.scrollPanel.Controls.Add(this.pictureBox1);
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(1902, 1033);
            this.scrollPanel.TabIndex = 2;
            // 
            // addFiles
            // 
            this.addFiles.Location = new System.Drawing.Point(1415, 65);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(140, 36);
            this.addFiles.TabIndex = 2;
            this.addFiles.Text = "Add Manga";
            this.addFiles.UseVisualStyleBackColor = true;
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.scrollPanel);
            this.Name = "Screen";
            this.Text = "Screen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.TextBox searchBarBox;
        protected System.Windows.Forms.Panel scrollPanel;
        protected System.Windows.Forms.Button addFiles;
    }
}

