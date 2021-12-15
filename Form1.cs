using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace vector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripContainer1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            statusLabel1.Text = "VectorDraw 0.0.1 is ready";
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "All files (*.*)|*.*|Json files (*.json)|*.json";
            openDlg.Title = "Choose file";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openDlg.FileName);
                    //sr.ReadToEnd();
                    statusLabel1.Text = "File " + openDlg.FileName + " loaded successfully";
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "All files (*.*)|*.*|Json files (*.json)|*.json";
            saveDialog.Title = "Save file";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    statusLabel1.Text = "File " + saveDialog.FileName + " saved successfully";
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void createToolStripButton_Click(object sender, EventArgs e)
        {
            TabControl.TabPages.Add("New page");
            TabControl.SelectedIndex = TabControl.TabPages.Count - 1;
        }
    }
}
