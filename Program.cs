using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;


namespace tutorial_no1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fotoName = "d:\\sfkara.jpg";
            Image<Bgr, byte>  img = new Image<Bgr, byte>(fotoName);
            CvInvoke.Imshow("Image", img);

            CvInvoke.WaitKey(0);
        }
    }
}
