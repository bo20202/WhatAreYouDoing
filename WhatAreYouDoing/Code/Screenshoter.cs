using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WhatAreYouDoing.Code
{
    class Screenshoter
    {
        static Bitmap _bitmap;

        private static Bitmap TakeScreenshot(Screen currentScreen)
        {
            Graphics graph = null;
            var bmpScreenshot = new Bitmap(currentScreen.Bounds.Width, currentScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            graph = Graphics.FromImage(bmpScreenshot);
            graph.CopyFromScreen(currentScreen.Bounds.X, currentScreen.Bounds.Y, 0,0,currentScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return bmpScreenshot;
        }

        private static void SaveScreenshot(Image bmpScreenshot, int count)
        {
            string coun = $"{count:D8}";
            var x = Environment.CurrentDirectory;
            string filename = x + "\\" + coun + ".jpg";
            bmpScreenshot.Save(filename, ImageFormat.Jpeg);
        }

        public static void TakeAndSave(int count)
        {
            _bitmap = TakeScreenshot(Screen.PrimaryScreen);
            SaveScreenshot(_bitmap, count);
        }
    }
}
