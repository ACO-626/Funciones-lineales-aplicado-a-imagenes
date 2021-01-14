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
using Emgu.CV;
using Emgu.CV.Structure;

namespace TemasSelectosdeProgramacióneImagenes
{
    public partial class FormMain : Form
    {
        Image<Bgr, Byte> My_Image;
        int y = 0;
     

        public FormMain()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                My_Image = new Image<Bgr, byte>(Openfile.FileName);
                Image<Gray, Byte> My_gray = My_Image.Convert<Gray, byte>();
                pictureBox1.Image = My_gray.ToBitmap();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";

            }
            if(textBox2.Text == "")
            {
                textBox2.Text = "0";
            }

            try
            {
                if(My_Image!=null)
                {
                    Image<Gray, byte> My_gray2 = My_Image.Convert<Gray, byte>();
                    for (int i=0;i<My_Image.Height;i++)
                    {
                        for(int j=0;j<My_Image.Width; j++)
                        {
                            My_gray2[i, j] = new Gray(nuevogris(float.Parse(textBox2.Text),float.Parse(textBox1.Text),(int)My_gray2[i,j].Intensity));
                        }
                       
                    }
                    pictureBox2.Image = My_gray2.ToBitmap();

                }
                else
                {
                    MessageBox.Show("Debe cargar una imagen");
                }
                
            }catch(IOException)
            {
                MessageBox.Show("Error al cargar");
            }

        }
        private int nuevogris(float m, float b, int i)
        {            
            y = (int)(m * i + b);
            
            if(y>=255)
            {
                y = 255;
            }
            if(y<=0)
            {
                y = 0;
            }
            return y;
        }
    }
}
