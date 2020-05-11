using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoRandomizerv3
{
    public partial class ImageRandomizer : Form
    {
        public ImageRandomizer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Dir Of the Path
            string dirname = Application.StartupPath + @"\Images";

            //Creation of the Directory Images
            Directory.CreateDirectory(dirname);

            // Make an array holding the PictureBoxes
            PictureBox[] pics =
                { pictureBox1, pictureBox2, pictureBox3 };

            //Get all the Images of the Directory
            DirectoryInfo d = new DirectoryInfo(dirname);
            List<string> files = d.GetFiles().Where(f => f.Name.ToLower().EndsWith("jpg") || f.Name.ToLower().EndsWith("png") || f.Name.ToLower().EndsWith("jpeg")).Select(s => s.FullName).ToList();

            if (files.Count >= 3)
            {
                //Get only 3 Images of the Directory
                Random random = new Random();
                List<string> randomFiles = new List<string>();
                for (int i = 0; i < 3; i++)
                    randomFiles.Add(files[random.Next(0, files.Count())]);

                // Load the 3 pictures
                for (int i = 0; i < pics.Length; i++)
                    pics[i].Image = Bitmap.FromFile(randomFiles[i]);
            }
        }
    }
}
