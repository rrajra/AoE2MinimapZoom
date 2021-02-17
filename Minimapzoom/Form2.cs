using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minimapzoom
{
    public partial class Form2 : Form
    {

        //public Form1 form = new Form1();

        public Form2()
        {
            InitializeComponent();
            //form.GetMapScreenshot();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        public Image PictureBox
        {
            get
            {
                return this.pictureBox1.Image;
            }
            set
            {
                this.pictureBox1.Image = value;
            }
        }
    }
}
