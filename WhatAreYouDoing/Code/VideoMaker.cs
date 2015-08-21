using System;
using NReco.VideoConverter;

namespace WhatAreYouDoing.Code
{
    internal class VideoMaker
    {
        public void MakeVideo()
        {
            var ffmpeg = new FFMpegConverter();
            ffmpeg.Invoke("-f image2 -r 1/5 -i %08d.jpg -vcodec libx264 out.mp4");

        }
    }
}
