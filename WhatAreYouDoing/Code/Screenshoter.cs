using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace WhatAreYouDoing.Code
{
    
    class Screenshoter
    {
        public Bitmap TakeScreenshot()
        {
            Graphics graph = null;
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            graph = Graphics.FromImage(bmpScreenshot);
            graph.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0,0,Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return bmpScreenshot;
        }

        
    }
}
