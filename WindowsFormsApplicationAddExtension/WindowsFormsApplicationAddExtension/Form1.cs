using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApplicationAddExtension.Core.Extensions;

namespace WindowsFormsApplicationAddExtension
{
    public partial class Form1 : Form
    {
        FormProgressBar m_Fp;
        int m_Filenum;
    
        public Form1(String[] args)
        {
            int res = 0;

            InitializeComponent();

            m_Fp = new FormProgressBar(0, 100);

            m_Filenum = 0;

            if (args.Length > 0)
            {       
                DialogResult MesgBoxResult;

                MesgBoxResult = MessageBox.Show("请选择？(是：添加后缀，否：移除后缀)", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (MesgBoxResult == DialogResult.Yes)
                {
                    textBox1.Text = args[0];

                    res = DirOrFileAddExtends(args[0], textBox2.Text);

                    if (res == -1)
                    {
                        MessageBox.Show("error!");
                    }
                    else
                    {
                        MessageBox.Show(g_SucFileNum + " 个文件成功！ , " + g_FailFlieNum + " 个文件失败！");
                    }
                    /*
                    if (res == 0)
                    {
                        MessageBox.Show("Success!");
                    }
                    else if (res == -1)
                    {
                        MessageBox.Show("error!");
                    }
                    else
                    {     
                        MessageBox.Show(res.ToString() + " File Fail!");
                    }
                     * */


                   
                    this.Close();
                    System.Environment.Exit(0);//彻底干净的退出所有
                }
                else if (MesgBoxResult == DialogResult.No)
                {
                    textBox1.Text = args[0];

                    res = DirOrFileRemoveExtends(args[0], textBox2.Text);
                    if (res == -1)
                    {
                        MessageBox.Show("error!");
                    }
                    else
                    {
                        MessageBox.Show(g_SucFileNum + " 个文件成功！ , " + g_FailFlieNum + " 个文件失败！");
                    }
                    /*
                    if (res == 0)
                    {
                        MessageBox.Show("Success!");
                    }
                    else if (res == -1)
                    {
                        MessageBox.Show("error!");
                    }
                    else
                    {
                        MessageBox.Show(res.ToString() + " File Fail!");
                    }
                    */
                    this.Close();
                    System.Environment.Exit(0);//彻底干净的退出所有
                    
             
                }
                else if (MesgBoxResult == DialogResult.Cancel)
                {
                    System.Environment.Exit(0);//彻底干净的退出所有
                    return;
                }
            
            }

        }

        //按钮点击事件，给文件添加后缀 
        private void button_open_dir_Click(object sender, EventArgs e)
        {
            String mesg;
            int res;
            
            if (textBox2.Text.Length == 0 )
            {
                richTextBox1.Clear();
                mesg = "请输入要添加的后缀名！";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                return;
            }
 
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "All File|*.*";

            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file.FileName;

                richTextBox1.Clear();

                res = FileAddExtends(file.FileName,textBox2.Text);
                switch (res)
                {
                    case 0:
                        break;
                    case -1:
                        {
                            mesg = "Fail: " + file.FileName + textBox2.Text + "文件名已存在或出现异常！\r\n";
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                        }
                        break;
                    case 1:
                        {
                            mesg = "Success: " + file.FileName + "  to  " + file.FileName + textBox2.Text + "\r\n";
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Green, false);
                        
                        }
                        break;
                    default:
                        break;
                }
            }
               
            return;
        }

        //按钮点击事件，移除文件后缀
        private void File_Remove_a_Click(object sender, EventArgs e)
        {
            String mesg;
            int res;

            if (textBox2.Text.Length == 0)
            {
                richTextBox1.Clear();
                mesg = "请输入后缀名！";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                return;
            }

            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "All File|*.*";

            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file.FileName;

                richTextBox1.Clear();

                res = FileRemoveExtends(file.FileName,textBox2.Text);
                switch (res)
                {
                    case 0:
                         mesg = "Fail: " + file.FileName + "后缀名不是"+textBox2.Text+"!\r\n";
                         RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                        break;
                    case -1:
                        {
                            mesg = "Fail: " + file.FileName + textBox2.Text + "文件名已存在或出现异常！\r\n";
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                        }
                        break;
                    case 1:
                        {
                            mesg = "Success: " + file.FileName + "  to  " + file.FileName.Substring(0, file.FileName.Length-textBox2.Text.Length) + "\r\n";
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Green, false);

                        }
                        break;
                    default:
                        break;
                }
            }

            return;
        }
        //按钮点击事件，给文件夹内的文件添加后缀
        private void button_open_file_Click(object sender, EventArgs e)
        {
            String mesg;

            if (textBox2.Text.Length == 0)
            {
                richTextBox1.Clear();
                mesg = "请输入后缀名！";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                return;
            }

            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folder.SelectedPath;

                richTextBox1.Clear();

                g_SucFileNum = 0;
                g_FailFlieNum = 0;

                m_Fp.Show(this);
                m_Fp.SetProgressBarpos(1);
                m_Filenum = m_Fp.getFileNum(folder.SelectedPath);

                RecursivelyAddSubDirExtends(folder.SelectedPath, textBox2.Text);

                m_Fp.Hide();

                mesg = "\r\n\r\n\r\n" + g_SucFileNum + "个文件成功！ , " + g_FailFlieNum + " 个文件失败！\r\n";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);

            }

            return;
        }
        //按钮点击事件，给文件夹内的文件移除后缀
        private void Dir_Remove_a_Click(object sender, EventArgs e)
        {
            String mesg;

            if (textBox2.Text.Length == 0)
            {
                richTextBox1.Clear();
                mesg = "Fail: 请输入后缀名！";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                return;
            }

            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folder.SelectedPath;

                richTextBox1.Clear();

                g_SucFileNum = 0;
                g_FailFlieNum = 0;

                m_Fp.Show(this);
                m_Fp.SetProgressBarpos(1);

                m_Filenum = m_Fp.getFileNum(folder.SelectedPath);

                RecursivelyRemoveSubDirExtends(folder.SelectedPath, textBox2.Text);

                m_Fp.Hide();

                mesg = "\r\n\r\n\r\n" + g_SucFileNum + "个文件成功！ , " + g_FailFlieNum + " 个文件失败！\r\n";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);
            }
          
            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;

        }


        /******************************* 拖动事件 *******************************************/
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            String mesg;

            if (textBox2.Text.Length == 0)
            {
                richTextBox1.Clear();
                mesg = "请输入要添加的后缀名！";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                return;
            }

            string FileName = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            textBox1.Text = FileName;

            DialogResult MesgBoxResult;

            MesgBoxResult = MessageBox.Show("请选择？(是：添加后缀，否：移除后缀)", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (MesgBoxResult == DialogResult.Yes)
            {
                richTextBox1.Clear();
                DirOrFileAddExtends(FileName, textBox2.Text);

                mesg = "\r\n\r\n\r\n" + g_SucFileNum + "个文件成功！ , " + g_FailFlieNum + " 个文件失败！\r\n";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);
            }
            else if (MesgBoxResult == DialogResult.No)
            {
                richTextBox1.Clear();
                DirOrFileRemoveExtends(FileName, textBox2.Text);

                mesg = "\r\n\r\n\r\n" + g_SucFileNum + "个文件成功！ , " + g_FailFlieNum + " 个文件失败！\r\n";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);
            }
            else if (MesgBoxResult == DialogResult.Cancel)
            {
                //System.Environment.Exit(0);//彻底干净的退出所有
                return;
            }


        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                e.Effect = DragDropEffects.Link;

            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
            return;
        }

        //文件夹按钮拖动事件，添加后缀
        private void button_open_file_DragDrop(object sender, DragEventArgs e)
        {
            String mesg;     

            if (textBox2.Text.Length == 0)
            {
                richTextBox1.Clear();
                mesg = "请输入要添加的后缀名！";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                return;
            }

            string FileName = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            textBox1.Text = FileName;

            richTextBox1.Clear();

            DirOrFileAddExtends(FileName,textBox2.Text);//

            mesg = "\r\n\r\n\r\n" + g_SucFileNum + "个文件成功！ , " + g_FailFlieNum + " 个文件失败！\r\n";
            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);
            
            return;
        }

        private void button_open_file_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                e.Effect = DragDropEffects.Link;

            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
            return;
        }

        //文件夹按钮拖动事件，移除
        private void Dir_Remove_a_DragDrop(object sender, DragEventArgs e)
        {
            String mesg;

            if (textBox2.Text.Length == 0)
            {
                richTextBox1.Clear();
                mesg = "请输入要添加的后缀名！";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                return;
            }

            string FileName = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            textBox1.Text = FileName;

            richTextBox1.Clear();

            DirOrFileRemoveExtends(FileName,textBox2.Text);

            mesg = "\r\n\r\n\r\n" + g_SucFileNum + "个文件成功！ , " + g_FailFlieNum + " 个文件失败！\r\n";
            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);

            return;


        }

        private void Dir_Remove_a_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                e.Effect = DragDropEffects.Link;

            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
            return;
        }

        //文件按钮拖动事件，添加后缀
        private void button_File_Add_a_DragDrop(object sender, DragEventArgs e)
        {
            String mesg;

            if (textBox2.Text.Length == 0)
            {
                richTextBox1.Clear();
                mesg = "请输入要添加的后缀名！";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                return;
            }

            string FileName = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            textBox1.Text = FileName;

            richTextBox1.Clear();

            DirOrFileAddExtends(FileName, textBox2.Text);

            mesg = "\r\n\r\n\r\n" + g_SucFileNum + "个文件成功！ , " + g_FailFlieNum + " 个文件失败！\r\n";
            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);

            return;
        }

        private void button_File_Add_a_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                e.Effect = DragDropEffects.Link;

            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
            return;
        }

        //文件按钮拖动事件，移除后缀
        private void File_Remove_a_DragDrop(object sender, DragEventArgs e)
        {
            String mesg;

            if (textBox2.Text.Length == 0)
            {
                richTextBox1.Clear();
                mesg = "请输入要添加的后缀名！";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                return;
            }

            string FileName = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            textBox1.Text = FileName;

            richTextBox1.Clear();

            DirOrFileRemoveExtends(FileName, textBox2.Text);

            mesg = "\r\n\r\n\r\n" + g_SucFileNum + "个文件成功！ , " + g_FailFlieNum + " 个文件失败！\r\n";
            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);

            return;
        }

        private void File_Remove_a_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                e.Effect = DragDropEffects.Link;

            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
            return;
        }


        int g_SucFileNum = 0;
        int g_FailFlieNum = 0;

/**************************************** 自定义函数 ******************************************/


        /**********************************************************************************
        * 函数名：int FileAddExtends(String fileFullName,String Extends)
        * 功能：添加文件后缀
        * 参数：
        *      fileFullName,文件的绝对路径
        *      Extends,要添加的文件后缀名
        * 返回值：
        *           -1：文件已存在或出现异常
        *            1：修改成功
        **********************************************************************************/
        public int FileAddExtends(String fileFullName, String Extends)
        {
            String filename;

            filename = fileFullName + Extends;

            if (File.Exists(@filename) == true)//如果文件已经存在
            {
                DialogResult MesgBoxResult;
                MesgBoxResult = MessageBox.Show("文件名已存在是否覆盖？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (MesgBoxResult == DialogResult.Yes)
                {
                    File.Delete(@filename);
                }
                else
                {
                    return -1;//文件名已存在
                }
                
            }
            try
            {
                System.IO.File.Move(@fileFullName, @filename);

            }
            catch
            {
                return -1;
            }

            return 1;
        }


        /**********************************************************************************
        * 函数名：public int FileRemoveExtends(String FileFullName,String Extends)
        * 功能：移除文件后缀
        * 参数：
        *      fileFullName,文件的绝对路径
        *      Extends,要移除的文件后缀名
        *返回值：
         *     -1：文件已存在或出现异常
         *     0：文件扩展名不匹配
         *     1：修改成功
        **********************************************************************************/
        public int FileRemoveExtends(String FileFullName, String Extends)
        {
            int FileNameLenth;
            String filename;

            FileNameLenth = FileFullName.Length;

            for (int i = 0; i < Extends.Length; i++)
            {
                if (FileFullName[FileNameLenth - Extends.Length + i] != Extends[i])
                {
                    return 0;//后缀名不正确
                }

            }

            filename = FileFullName.Substring(0, FileFullName.Length - Extends.Length);

            if (File.Exists(@filename) == true)
            {
                DialogResult MesgBoxResult;
                MesgBoxResult = MessageBox.Show("文件名已存在是否覆盖？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (MesgBoxResult == DialogResult.Yes)
                {
                    File.Delete(@filename);    
                }
                else     
                {
                    return -1;//文件名已存在
                }
               
            }
            try
            {
                System.IO.File.Move(@FileFullName, @filename);
            }
            catch
            {
                return -1;//异常
            }

            return 1; //成功
        }



        /*********************************************************************************
        * 函数名：public int FileRemoveExtends(String FileFullName,String Extends)
        * 功能：添加文件夹内所有后缀
        * 参数：
        *      fileFullName,文件的绝对路径
        *      Extends,添加的文件后缀名
        *返回值：
         *      无
        **********************************************************************************/
        public int DirAddExtends(String path, String Extends)
        {
            String mesg;
            int DealFileCount = 0;
            int res;

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);

            if (dir.Exists)
            {
                FileInfo[] fileInfo = dir.GetFiles();

                if (fileInfo.Length <= 0)
                {
                    mesg = "Fail: 空文件夹! \r\n";
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);

                    return -1;
                }

                for (int i = 0; i < fileInfo.Length; i++)
                {

                    res = FileAddExtends(fileInfo[i].FullName, textBox2.Text);
                    switch (res)
                    {
                        case 0:

                            break;
                        case -1:
                            {
                                mesg = "Fail: " + fileInfo[i].Name + "  to  " + fileInfo[i].Name + textBox2.Text + "文件名已存在！\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                            }
                            break;
                        case 1:
                            {
                                mesg = "Success: " + fileInfo[i].Name + "  to  " + fileInfo[i].Name + textBox2.Text + "\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Green, false);
                                DealFileCount++;
                            }
                            break;
                        default:
                            break;
                    }

                }

                mesg = "\r\n\r\n\r\n" + DealFileCount.ToString() + "个文件成功！ , " + (fileInfo.Length - DealFileCount).ToString() + " 个文件失败！\r\n";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, false);

                return (fileInfo.Length - DealFileCount);
            }

            return -1;
        }

        /*********************************************************************************
     * 函数名：public int FileRemoveExtends(String FileFullName,String Extends)
     * 功能：digui添加文件夹内所有后缀
     * 参数：
     *      fileFullName,文件的绝对路径
     *      Extends,添加的文件后缀名
     *返回值：
      *      无
     **********************************************************************************/
        public int RecursivelyAddSubDirExtends(String path, String Extends)
        {
            String mesg;
            int res;


            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);

            if (dir.Exists)
            {
                FileInfo[] fileInfo = dir.GetFiles();

                for (int i = 0; i < fileInfo.Length; i++)
                {

                    res = FileAddExtends(fileInfo[i].FullName, textBox2.Text);
                    switch (res)
                    {
                        case 0:

                            break;
                        case -1:
                            {
                                mesg = "Fail: " + fileInfo[i].Name + "  to  " + fileInfo[i].Name + textBox2.Text + "文件名已存在！\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                                g_FailFlieNum++;//gloable val, record deal success file num
                            }
                            break;
                        case 1:
                            {
                                mesg = "Success: " + fileInfo[i].Name + "  to  " + fileInfo[i].Name + textBox2.Text + "\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Green, false);
                                g_SucFileNum++;//gloable val, record deal fail file num
                            }
                            break;
                        default:
                            break;
                    }

                    decimal result = Math.Round((decimal)(g_FailFlieNum + g_SucFileNum) / m_Filenum*100, 2); 
                    m_Fp.SetProgressBarpos((int) result);

                }

                DirectoryInfo[] DirInfo = dir.GetDirectories();

                for (int j = 0; j < DirInfo.Length; j++)
                {
                    RecursivelyAddSubDirExtends(DirInfo[j].FullName, Extends);
                }

                /*
                mesg = "\r\n\r\n\r\n" + DealFileCount.ToString() + "个文件成功！ , " + (fileInfo.Length - DealFileCount).ToString() + " 个文件失败！\r\n";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, false);

                return (fileInfo.Length - DealFileCount);
                 * */

                return 0;
            }

            return -1;
        }
        /*********************************************************************************
        * 函数名：  public void DirRemoveExtends(String path,String Extends)
        * 功能：移除文件夹内所有后缀
        * 参数：
        *      fileFullName,文件的绝对路径
        *      Extends,要移除的文件后缀名
        *返回值：
         *      无
        **********************************************************************************/
        public int DirRemoveExtends(String path, String Extends)
        {
            String mesg;
            int res;

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);

            if (dir.Exists)
            {
                FileInfo[] fileInfo = dir.GetFiles();

                if (fileInfo.Length <= 0)
                {
                    mesg = "Fail: 空文件夹! \r\n";
                    RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);

                    return -1;
                }

                int DealFileCount = 0;

                for (int i = 0; i < fileInfo.Length; i++)//遍历文件夹所有文件
                {

                    res = FileRemoveExtends(fileInfo[i].FullName, Extends);
                    switch (res)
                    {
                        case 0:
                            {
                                mesg = "Fail: " + fileInfo[i].Name + "后缀名不是 " + Extends + "！\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                            }
                            break;
                        case -1:
                            {
                                mesg = "Fail: " + fileInfo[i].Name + "文件名已存在！\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                            }
                            break;
                        case 1:
                            {
                                mesg = "Success: " + fileInfo[i].Name + " to " + fileInfo[i].Name.Substring(0, fileInfo[i].Name.Length - Extends.Length) + "\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Green, false);
                                DealFileCount++;
                            }
                            break;
                        default:
                            break;
                    }

                }

                mesg = "\r\n\r\n\r\n" + DealFileCount.ToString() + "个文件成功！ , " + (fileInfo.Length - DealFileCount).ToString() + " 个文件失败！\r\n";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);

                return (fileInfo.Length - DealFileCount);
            }

            return -1;
        }

        /*********************************************************************************
        * 函数名：  public void DirRemoveExtends(String path,String Extends)
        * 功能：移除文件夹内所有后缀
        * 参数：
        *      fileFullName,文件的绝对路径
        *      Extends,要移除的文件后缀名
        *返回值：
         *      无
        **********************************************************************************/
        public int RecursivelyRemoveSubDirExtends(String path, String Extends)
        {
            String mesg;
            int res;

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);

            if (dir.Exists)
            {
                FileInfo[] fileInfo = dir.GetFiles();

                for (int i = 0; i < fileInfo.Length; i++)//遍历文件夹所有文件
                {

                    res = FileRemoveExtends(fileInfo[i].FullName, Extends);
                    switch (res)
                    {
                        case 0:
                            {
                                mesg = "Fail: " + fileInfo[i].Name + "后缀名不是 " + Extends + "！\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                                g_FailFlieNum++;
                            }
                            break;
                        case -1:
                            {
                                mesg = "Fail: " + fileInfo[i].Name + "文件名已存在！\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                                g_FailFlieNum++;
                            }
                            break;
                        case 1:
                            {
                                mesg = "Success: " + fileInfo[i].Name + " to " + fileInfo[i].Name.Substring(0, fileInfo[i].Name.Length - Extends.Length) + "\r\n";
                                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Green, false);
                                g_SucFileNum++;
                            }
                            break;
                        default:
                            break;
                    }

                    decimal result = Math.Round((decimal)(g_FailFlieNum + g_SucFileNum) / m_Filenum * 100, 2);
                    m_Fp.SetProgressBarpos((int)result);

                }

                DirectoryInfo[] DirInfo = dir.GetDirectories();

                for (int j = 0; j < DirInfo.Length; j++)
                {
                    RecursivelyRemoveSubDirExtends(DirInfo[j].FullName, Extends);
                }

                /*
                mesg = "\r\n\r\n\r\n" + DealFileCount.ToString() + "个文件成功！ , " + (fileInfo.Length - DealFileCount).ToString() + " 个文件失败！\r\n";
                RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Blue, true);

                return (fileInfo.Length - DealFileCount);
                 * */
                return 0;
            }

            return -1;
        }

      
        /*********************************************************************************
        * 函数名：  public void DirOrFileAddExtends(String PathOrFileName, String Extends)
        * 功能：添加文件内所有文件或单个文件的后缀
        * 参数：
        *      PathOrFileName,文件夹或文件的绝对路径名
        *      Extends,要添加的文件后缀名
        *返回值：
         *      -1,
        **********************************************************************************/

        public int DirOrFileAddExtends(String PathOrFileName, String Extends)
        {
            int res;
            String mesg;

            if (PathOrFileName.Length == 0 || Extends.Length == 0)
            {
                return -1;
            }
            g_FailFlieNum = 0;
            g_SucFileNum = 0;
            if (System.IO.Directory.Exists(@PathOrFileName))
            {
                m_Fp.Show(this);

                m_Fp.SetProgressBarpos(1);

                m_Filenum = m_Fp.getFileNum(@PathOrFileName);

                RecursivelyAddSubDirExtends(PathOrFileName, Extends);

                m_Fp.Hide();

                return 0;
               // DirAddExtends(PathOrFileName, Extends);
            }
            else if (File.Exists(@PathOrFileName))
            {
                res = FileAddExtends(PathOrFileName, Extends);
                switch (res)
                {
                    case 0:
                        break;
                    case -1:
                        {
                            mesg = "Fail: " + PathOrFileName + Extends + "文件名已存在！\r\n";
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                            g_FailFlieNum++;
                        }
                        return 1;   
                    case 1:
                        {
                            mesg = "Success: " + PathOrFileName + "  to  " + PathOrFileName + Extends + "\r\n";
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Green, false);
                            g_SucFileNum++;

                        }
                        return 0;
                    default:
                        break;
                }
            }


            return -1;
        }
        /*********************************************************************************
        * 函数名：  public void DirOrFileRemoveExtends(String PathOrFileName, String Extends)
        * 功能：移除文件内所有文件或单个文件的后缀
        * 参数：
        *      PathOrFileName,文件夹或文件的绝对路径名
        *      Extends,要移除的文件后缀名
        *返回值：
         *      无
        **********************************************************************************/
        public int DirOrFileRemoveExtends(String PathOrFileName, String Extends)
        {
            int res;
            String mesg;

            if (PathOrFileName.Length == 0 || Extends.Length == 0)
            {
                return -1;
            }

            g_FailFlieNum = 0;
            g_SucFileNum = 0;
            if (System.IO.Directory.Exists(@PathOrFileName))
            {
                m_Fp.Show(this);

                m_Fp.SetProgressBarpos(1);

                m_Filenum = m_Fp.getFileNum(@PathOrFileName);

                RecursivelyRemoveSubDirExtends(PathOrFileName, Extends);

                m_Fp.Hide();
             
            }
            else if (File.Exists(@PathOrFileName))
            {
                res = FileRemoveExtends(PathOrFileName, Extends);
                switch (res)
                {
                    case 0:
                        {
                            mesg = "Fail: " + PathOrFileName + "后缀名不是" + Extends + "!\r\n";
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                            g_FailFlieNum++;
                        }
                        break;
                    case -1:
                        {
                            mesg = "Fail: " + PathOrFileName + Extends + "文件名已存在！\r\n";
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Red, false);
                            g_FailFlieNum++;
                        }
                        break;
                    case 1:
                        {
                            mesg = "Success: " + PathOrFileName + "  to  " + PathOrFileName.Substring(0, PathOrFileName.Length - Extends.Length) + "\r\n";
                            RichTextBoxExtension.AppendTextColorful(richTextBox1, mesg, Color.Green, false);
                            g_SucFileNum++;
                            
                        }
                        break;
                    default:
                        break;
                }
            }

            return 0;
        }

 
    }
}
