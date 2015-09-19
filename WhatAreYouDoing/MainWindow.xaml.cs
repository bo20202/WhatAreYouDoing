using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using AForge.Video.FFMPEG;
using WhatAreYouDoing.Code;

namespace WhatAreYouDoing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 

    public partial class MainWindow : Window
    {
        public DispatcherTimer Timer { get; set; }
        public VideoMaker Video { get; set; }
        public Screenshoter Screenshoter { get; set; }
        public VideoFileWriter Writer { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            Screenshoter = new Screenshoter();
            Video = new VideoMaker();
            Timer = new DispatcherTimer();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Video.AddFrame(Screenshoter.TakeScreenshot(Screen.PrimaryScreen));
        }

        private void startCapStopCap_Checked(object sender, RoutedEventArgs e)
        {
            Timer.Tick += dispatcherTimer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1, 0);
            Video.OpenVideo();
            Timer.Start();
        }

        private void startCapStopCap_Unchecked(object sender, RoutedEventArgs e)
        {
           Video.Stop();
        }
    }
}
