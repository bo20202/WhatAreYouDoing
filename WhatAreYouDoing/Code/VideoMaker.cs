using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AForge.Video.FFMPEG;

namespace WhatAreYouDoing.Code
{
    class VideoMaker
    {
        private VideoFileWriter _writer = new VideoFileWriter();
        private int _height = Screen.PrimaryScreen.Bounds.Height;
        private int _width = Screen.PrimaryScreen.Bounds.Width;

        public void InitializeThread()
        {
            //Thread thread = new Thread(InitializeWriter);
            // thread.Start();
        }

        public void InitializeWriter()
        {
            _writer.Open(DateTime.Today.ToString()+".mp4", _width, _height, 10, VideoCodec.MPEG4);
        }

        public void WriteFrame(Bitmap img)
        {
            _writer.WriteVideoFrame(img);
        }

        public void StopWriter()
        {
            _writer.Close();
            Dispose();
        }

        private void Dispose()
        {
            _writer.Dispose();
        }
    }
}
