namespace WindowsFormsApplicationAddExtension
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_File_Add_a = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_open_file = new System.Windows.Forms.Button();
            this.File_Remove_a = new System.Windows.Forms.Button();
            this.Dir_Remove_a = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(95, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(395, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件路径:";
            // 
            // button_File_Add_a
            // 
            this.button_File_Add_a.AllowDrop = true;
            this.button_File_Add_a.BackColor = System.Drawing.SystemColors.Control;
            this.button_File_Add_a.Location = new System.Drawing.Point(374, 81);
            this.button_File_Add_a.Name = "button_File_Add_a";
            this.button_File_Add_a.Size = new System.Drawing.Size(75, 23);
            this.button_File_Add_a.TabIndex = 2;
            this.button_File_Add_a.Text = "添加后缀名";
            this.button_File_Add_a.UseVisualStyleBackColor = false;
            this.button_File_Add_a.Click += new System.EventHandler(this.button_open_dir_Click);
            this.button_File_Add_a.DragDrop += new System.Windows.Forms.DragEventHandler(this.button_File_Add_a_DragDrop);
            this.button_File_Add_a.DragEnter += new System.Windows.Forms.DragEventHandler(this.button_File_Add_a_DragEnter);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_open_file
            // 
            this.button_open_file.AllowDrop = true;
            this.button_open_file.BackColor = System.Drawing.SystemColors.Control;
            this.button_open_file.Location = new System.Drawing.Point(95, 81);
            this.button_open_file.Name = "button_open_file";
            this.button_open_file.Size = new System.Drawing.Size(75, 23);
            this.button_open_file.TabIndex = 4;
            this.button_open_file.Text = "添加后缀名\r\n";
            this.button_open_file.UseVisualStyleBackColor = false;
            this.button_open_file.Click += new System.EventHandler(this.button_open_file_Click);
            this.button_open_file.DragDrop += new System.Windows.Forms.DragEventHandler(this.button_open_file_DragDrop);
            this.button_open_file.DragEnter += new System.Windows.Forms.DragEventHandler(this.button_open_file_DragEnter);
            // 
            // File_Remove_a
            // 
            this.File_Remove_a.AllowDrop = true;
            this.File_Remove_a.BackColor = System.Drawing.SystemColors.Control;
            this.File_Remove_a.Location = new System.Drawing.Point(468, 81);
            this.File_Remove_a.Name = "File_Remove_a";
            this.File_Remove_a.Size = new System.Drawing.Size(75, 23);
            this.File_Remove_a.TabIndex = 5;
            this.File_Remove_a.Text = "移除后缀名";
            this.File_Remove_a.UseVisualStyleBackColor = false;
            this.File_Remove_a.Click += new System.EventHandler(this.File_Remove_a_Click);
            this.File_Remove_a.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_Remove_a_DragDrop);
            this.File_Remove_a.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_Remove_a_DragEnter);
            // 
            // Dir_Remove_a
            // 
            this.Dir_Remove_a.AllowDrop = true;
            this.Dir_Remove_a.BackColor = System.Drawing.SystemColors.Control;
            this.Dir_Remove_a.Location = new System.Drawing.Point(185, 81);
            this.Dir_Remove_a.Name = "Dir_Remove_a";
            this.Dir_Remove_a.Size = new System.Drawing.Size(75, 23);
            this.Dir_Remove_a.TabIndex = 6;
            this.Dir_Remove_a.Text = "移除后缀名";
            this.Dir_Remove_a.UseVisualStyleBackColor = false;
            this.Dir_Remove_a.Click += new System.EventHandler(this.Dir_Remove_a_Click);
            this.Dir_Remove_a.DragDrop += new System.Windows.Forms.DragEventHandler(this.Dir_Remove_a_DragDrop);
            this.Dir_Remove_a.DragEnter += new System.Windows.Forms.DragEventHandler(this.Dir_Remove_a_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(422, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "选择文件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(133, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "选择文件夹";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox1.ForeColor = System.Drawing.Color.Red;
            this.richTextBox1.Location = new System.Drawing.Point(23, 122);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(597, 361);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.Location = new System.Drawing.Point(562, 26);
            this.textBox2.MaxLength = 100;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(58, 21);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = ".a";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "后缀名:";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(646, 511);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dir_Remove_a);
            this.Controls.Add(this.File_Remove_a);
            this.Controls.Add(this.button_open_file);
            this.Controls.Add(this.button_File_Add_a);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ATool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_File_Add_a;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_open_file;
        private System.Windows.Forms.Button File_Remove_a;
        private System.Windows.Forms.Button Dir_Remove_a;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}

