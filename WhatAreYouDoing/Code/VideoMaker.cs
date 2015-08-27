using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NReco.VideoConverter;

namespace WhatAreYouDoing.Code
{
    class VideoMaker
    {
        public Stream Stream { get; set; }
        public ConvertSettings Settings { get; set; }
        public ConvertLiveMediaTask Task { get; set; }


        public VideoMaker(ConvertSettings settings)
        {
            Settings = settings;
            Task = new FFMpegConverter().ConvertLiveMedia(Stream, "apng",
                Environment.CurrentDirectory + DateTime.Today + ".mp4", Format.mp4, Settings);
            /*var task = _converter.ConvertLiveMedia(_inputStream, "png",
                Environment.CurrentDirectory + DateTime.Today + ".mp4",
                Format.mp4, settings);*/
            
        }
        public void StartConverter()
        {
            Task.Start();
        }

        public void StopConverter()
        {
            Task.Stop();
        }

        public void AddFrame(Stream stream, Bitmap img)
        {
            Stream = stream;
            img.Save(Stream, ImageFormat.Png);

        }
    }
}/*var task = _converter.ConvertLiveMedia(_inputStream, "png",
                Environment.CurrentDirectory + DateTime.Today + ".mp4",
                Format.mp4, settings);*/
