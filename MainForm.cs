using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public interface MainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            butOpenFile.Click += new EventHandler(ButOpenFile_Click);
            butSaveFile.Click += ButSaveFile_Click;
            fldContent.TextChanged += fldContent_TextChanged;
            butSelectFile.Click += ButSelectFile_Click;
        }

        private void ButSelectFile_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButOpenFile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }
        private void ButSaveFile_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #region Проброс событий
        void butOpenFile.Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }

        private void ButOpenFile_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region IMainForm
        public string FilePath
        {
            get{return fldFilePath.Text;}
            set { fldContent.Text = value;}
        }
        public void SetSymbolCount(int count)
        {
            lblSymbolCount.Text = count.ToString();
        }
        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void numFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.Font=new Font("Calibri", (float)numFont.Value);
        }
    }
}
