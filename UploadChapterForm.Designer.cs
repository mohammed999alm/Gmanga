namespace Gmanga
{
    partial class UploadChapterForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.chapterNumberBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chapter Number";
            // 
            // chapterNumberBox
            // 
            this.chapterNumberBox.Location = new System.Drawing.Point(283, 91);
            this.chapterNumberBox.Name = "chapterNumberBox";
            this.chapterNumberBox.Size = new System.Drawing.Size(193, 22);
            this.chapterNumberBox.TabIndex = 1;
            this.chapterNumberBox.Validating += new System.ComponentModel.CancelEventHandler(this.chapterNumberBox_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gmanga.Properties.Resources.add_icon;
            this.pictureBox1.Location = new System.Drawing.Point(325, 222);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Add Chapter Pages";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(325, 420);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 36);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(44, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 36);
            this.button1.TabIndex = 16;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UploadChapterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 576);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chapterNumberBox);
            this.Controls.Add(this.label1);
            this.Name = "UploadChapterForm";
            this.Text = "UploadChapterForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       protected System.Windows.Forms.Label label1;
       protected System.Windows.Forms.TextBox chapterNumberBox;
       protected System.Windows.Forms.PictureBox pictureBox1;
       protected System.Windows.Forms.Label label2;
       protected System.Windows.Forms.Button button2;
       protected System.Windows.Forms.Button button1;
       protected  System.Windows.Forms.ErrorProvider errorProvider1;
    }
}