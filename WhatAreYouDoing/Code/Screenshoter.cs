using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WhatAreYouDoing.Code
{
    public class Screenshoter
    {
        public Bitmap TakeScreenshot(Screen currentScreen)
        {
            Graphics graph = null;
            var bmpScreenshot = new Bitmap(currentScreen.Bounds.Width, currentScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            graph = Graphics.FromImage(bmpScreenshot);
            graph.CopyFromScreen(currentScreen.Bounds.X, currentScreen.Bounds.Y, 0,0,currentScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return bmpScreenshot;

        }
    }
}
