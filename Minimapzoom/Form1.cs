using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Minimapzoom
{
    public partial class Form1 : Form
    {

        public float refreshDelay;
        public bool updateMap;
        public Form2 mapForm = new Form2();


        public Form1()
        {
            InitializeComponent();
        }

        public async void GetMapScreenshot()
        {
            while (updateMap == true)
            {
                await Task.Delay(200);
                Rectangle rect = new Rectangle(1520, 880, 400, 200);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                bmp.Save("minimap", ImageFormat.Jpeg);
                // Display Screenshot
                mapForm.PictureBox = bmp;
            }
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            updateMap = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mapForm.Show();
            updateMap = true;
            GetMapScreenshot();
            if(updateMap == true)
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                updateMap = false;
            }
            else
            {
                updateMap = true;
                GetMapScreenshot();
            }
        }
    }
}
