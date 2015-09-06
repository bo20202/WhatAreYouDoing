using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using WhatAreYouDoing.Code;

namespace WhatAreYouDoing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 

    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private static readonly string CurrentDir = Environment.CurrentDirectory;
        private VideoMaker videoMaker = new VideoMaker();

        public MainWindow()
        {
            InitializeComponent();
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            videoMaker.WriteFrame(Screenshoter.TakeScreenshot(Screen.PrimaryScreen));
        }

        private void startCapStopCap_Checked(object sender, RoutedEventArgs e)
        {
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 1, 0);
            videoMaker.InitializeWriter();
            _timer.Start();
        }

        private void startCapStopCap_Unchecked(object sender, RoutedEventArgs e)
        {
            videoMaker.StopWriter();
        }
    }
}
