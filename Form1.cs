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
using System.IO.Compression;

namespace Patcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;

        }

        public static class Global
        {
            public static bool directoryCheck = false;
            public static bool patchCheck = false;
        }


        private void updateButton()
        {
            button3.Enabled = (Global.directoryCheck == true && Global.patchCheck == true);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show(fbd.SelectedPath + " Has been selected.", "Message");
                    label2.Text = fbd.SelectedPath;
                    label2.ForeColor = Color.Green;
                    Global.directoryCheck = true;
                    updateButton();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Zip File|*.zip;*.rar";
            openDlg.Title = "Open";


            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openDlg.FileName;
                label3.ForeColor = Color.Purple;
                Global.patchCheck = true;
                updateButton();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var directoryPath = label2.Text;
            var patchPath = label3.Text;
            System.IO.Compression.ZipFile.ExtractToDirectory(patchPath, directoryPath);
            System.Windows.Forms.MessageBox.Show("Extraction Successful! ");
        }
    }
}

