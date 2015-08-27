using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using NReco.VideoConverter;
using WhatAreYouDoing.Code;

namespace WhatAreYouDoing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 

    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private readonly Screenshoter _screenshoter = new Screenshoter();
        private VideoMaker _video = new VideoMaker(new ConvertSettings
        {
            VideoCodec = "libx264",
            VideoFrameRate = 1/5
        });

        
        

        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Bitmap screenshot = _screenshoter.TakeScreenshot();
            using (var stream = new MemoryStream())
            {
                _video.AddFrame(stream, screenshot);
            }

        }

        private void startCapStopCap_Checked(object sender, RoutedEventArgs e)
        {
            _timer.Tick += dispatcherTimer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 1, 0);
            _video.StartConverter();
            _timer.Start();
        }


        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _video.StopConverter();
        }
    }
}

   