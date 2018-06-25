namespace WindowsFormsAppAudio
{
    partial class Form1
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
            this.AudioLabel = new System.Windows.Forms.Label();
            this.AudioFileLocationTextBox = new System.Windows.Forms.TextBox();
            this.Browse1Button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.TimestampNameRichTextBox = new System.Windows.Forms.RichTextBox();
            this.BrowseJPGButton = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.ComputeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AudioLabel
            // 
            this.AudioLabel.AutoSize = true;
            this.AudioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioLabel.Location = new System.Drawing.Point(12, 26);
            this.AudioLabel.Name = "AudioLabel";
            this.AudioLabel.Size = new System.Drawing.Size(144, 20);
            this.AudioLabel.TabIndex = 0;
            this.AudioLabel.Text = "Audio File Location";
            // 
            // AudioFileLocationTextBox
            // 
            this.AudioFileLocationTextBox.Location = new System.Drawing.Point(183, 26);
            this.AudioFileLocationTextBox.Name = "AudioFileLocationTextBox";
            this.AudioFileLocationTextBox.Size = new System.Drawing.Size(433, 20);
            this.AudioFileLocationTextBox.TabIndex = 1;
            // 
            // Browse1Button
            // 
            this.Browse1Button.Location = new System.Drawing.Point(652, 17);
            this.Browse1Button.Name = "Browse1Button";
            this.Browse1Button.Size = new System.Drawing.Size(90, 40);
            this.Browse1Button.TabIndex = 2;
            this.Browse1Button.Text = "Browse";
            this.Browse1Button.UseVisualStyleBackColor = true;
            this.Browse1Button.Click += new System.EventHandler(this.Browse1Button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Timestamps and names";
            // 
            // TimestampNameRichTextBox
            // 
            this.TimestampNameRichTextBox.Location = new System.Drawing.Point(197, 72);
            this.TimestampNameRichTextBox.Name = "TimestampNameRichTextBox";
            this.TimestampNameRichTextBox.Size = new System.Drawing.Size(545, 239);
            this.TimestampNameRichTextBox.TabIndex = 4;
            this.TimestampNameRichTextBox.Text = "";
            // 
            // BrowseJPGButton
            // 
            this.BrowseJPGButton.Location = new System.Drawing.Point(764, 72);
            this.BrowseJPGButton.Name = "BrowseJPGButton";
            this.BrowseJPGButton.Size = new System.Drawing.Size(140, 115);
            this.BrowseJPGButton.TabIndex = 5;
            this.BrowseJPGButton.Text = "Compute Timestamps";
            this.BrowseJPGButton.UseVisualStyleBackColor = true;
            this.BrowseJPGButton.Click += new System.EventHandler(this.BrowseJPGButton_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(199, 345);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(90, 186);
            this.listBox1.TabIndex = 6;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(309, 345);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(433, 186);
            this.listBox2.TabIndex = 7;
            // 
            // ComputeButton
            // 
            this.ComputeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComputeButton.Location = new System.Drawing.Point(408, 583);
            this.ComputeButton.Name = "ComputeButton";
            this.ComputeButton.Size = new System.Drawing.Size(419, 108);
            this.ComputeButton.TabIndex = 8;
            this.ComputeButton.Text = "Compute";
            this.ComputeButton.UseVisualStyleBackColor = true;
            this.ComputeButton.Click += new System.EventHandler(this.ComputeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 752);
            this.Controls.Add(this.ComputeButton);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.BrowseJPGButton);
            this.Controls.Add(this.TimestampNameRichTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Browse1Button);
            this.Controls.Add(this.AudioFileLocationTextBox);
            this.Controls.Add(this.AudioLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AudioLabel;
        private System.Windows.Forms.TextBox AudioFileLocationTextBox;
        private System.Windows.Forms.Button Browse1Button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TimestampNameRichTextBox;
        private System.Windows.Forms.Button BrowseJPGButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button ComputeButton;
    }
}

