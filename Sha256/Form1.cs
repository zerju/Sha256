using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sha256
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public string ArrayToString(List<byte> arr)
        {
            StringBuilder s = new StringBuilder(arr.Count * 2);
            for (int i = 0; i < arr.Count; ++i)
            {
                s.AppendFormat("{0:x}", arr[i]);
            }

            return s.ToString();
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    List<byte> hash = Sha256.Hash(File.OpenRead(openFileDialog1.FileName));
                    double length = new System.IO.FileInfo(openFileDialog1.FileName).Length;
                    outputHash.Text = ArrayToString(hash);
                    filePath.Text = openFileDialog1.FileName;
                    stopWatch.Stop();
                    // Console.WriteLine(length+"", stopWatch.ElapsedMilliseconds+"");
                    double elapsedSec = stopWatch.ElapsedMilliseconds / 1000;
                    double speed = Math.Round(length / 1000 / elapsedSec, 8);
                    if (elapsedSec == 0)
                    {
                        elapsedSec = 1;
                        speed = length / 1000;
                    }
                    hashSpeed.Text = "Hash Speed: " + speed +" KB/s";
                }
            }

        }

        private void hashBtn_Click(object sender, EventArgs e)
        {
            if (checksumInput.Text.Equals(outputHash.Text))
            {
                checksumOK.Text = "Hashes identical";
            }
            else
            {
                checksumOK.Text = "Hashes not identical";
            }
        }

        private void saveHash_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"hashed.txt");
            
            File.WriteAllText(path, outputHash.Text);
        }
    }
}
