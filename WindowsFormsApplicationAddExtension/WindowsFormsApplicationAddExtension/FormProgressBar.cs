using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplicationAddExtension
{
    public partial class FormProgressBar : Form
    {
        public FormProgressBar(int _Minimum,int _Maximum)
        {
            InitializeComponent();

            progressBar1.Minimum = _Minimum;
            progressBar1.Maximum = _Maximum;
            progressBar1.Value = 0;
        }

        public void SetProgressBarpos(int value)
        {
            if (value >= progressBar1.Minimum && value <= progressBar1.Maximum)
            {
                progressBar1.Value = value;
                label1.Text = ((value * 100) / progressBar1.Maximum).ToString() + "%";
            }
            Application.DoEvents();
            return;
        }

        private void FormProgressBar_Load(object sender, EventArgs e)
        {
           // this.Owner.Enabled = false;
        }

        private void FormProgressBar_FormClosed(object sender, FormClosedEventArgs e)
        {
           // this.Owner.Enabled = true;
        }


        public int getFileNum(String path)
        {
            int filenum = 0;
            try
            {
                string [] filelist = System.IO.Directory.GetFileSystemEntries(path);
                foreach(string file in filelist)
                {
                    if(System.IO.Directory.Exists(file))
                    {
                        filenum += getFileNum(file);
                    }
                    else
                    {
                        filenum++;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return filenum;
        }
    }

}
