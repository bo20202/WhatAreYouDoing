using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AForge.Video.FFMPEG;

namespace WhatAreYouDoing.Code
{
    public class VideoMaker
    {
        public VideoFileWriter Writer { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        

        public VideoMaker()
        {
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            
        }

        public void OpenVideo()
        {
            Writer = new VideoFileWriter();
            Writer.Open(DateTime.Today.ToShortDateString() + ".avi", 1920, 1080, 1, VideoCodec.MPEG4);
        }

        public void AddFrame(Bitmap img)
        {
            using (img)
            {
                Writer.WriteVideoFrame(img);
            }
        }

        public void Stop()
        {
            Writer.Close();
            Writer.Dispose();
        }
    }
}
