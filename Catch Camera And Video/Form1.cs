using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading;

namespace Catch_Camera_and_Video
{
    public partial class Form1 : Form
    {
        VideoCapture capture;
        public Form1()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                capture = new Emgu.CV.VideoCapture(0);
            }
            capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start();

        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat x = new Mat();
                capture.Retrieve(x);
                pictureBox1.Image = x.ToImage<Bgr, byte>().Bitmap;
            }
            catch (Exception)
            {
                throw;
                
            }
            
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture = null;
            }
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture.Pause(); 
            }
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (capture==null)
            {
                OpenFileDialog dialog = new OpenFileDialog;
                dialog.Filter = " Video Files |*.mp4";
                if (dialog.ShowDialog() == DialogResult.OK;
                {
                    capture = new Emgu.CV.VideoCapture(dialog.FileName);

                }
            }
            capture.ImageGrabbed += Capture_ImageGrabbed1;
            capture.Start();
        }

        private void Capture_ImageGrabbed1(object sender, EventArgs e)
        {
            try
            {
                Mat x = new Mat();
                capture.Retrieve(x);
                pictureBox1.Image = x.ToImage<Bgr, byte>().Bitmap;
                Thread.Sleep((int) capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void stopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (capture!=null)
            {
                capture.Stop();
            }
        }

        private void pauseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (capture!= null)

            {

                capture.Pause();
            }

        }
    }
}
