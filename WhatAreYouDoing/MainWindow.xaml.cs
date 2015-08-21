using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        private int _count = 0;
        private static readonly string CurrentDir = Environment.CurrentDirectory;

        public MainWindow()
        {
            InitializeComponent();
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

        }
    /*
            
            var makeVideo = new VideoMaker();

            if (!timer.IsEnabled)
            {
                timer.Start();
                start_capture.Content = "Stop capture";
            }
            else
            {
                if (File.Exists(Environment.CurrentDirectory + "00000001.jpg"))
                {
                    timer.Stop();
                    start_capture.Content = "Start capture";
                    count = 0;
                    label_render.Content = "Rendering video&#xD;&#xA;Please wait";
                    makeVideo.MakeVideo();
                    Environment.Exit(0);
                }
                else
                    Environment.Exit(0);
            }
            */

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            _count++;
            Screenshoter.TakeAndSave(_count);
        }

        private void startCapStopCap_Checked(object sender, RoutedEventArgs e)
        {
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 1, 0);
            _timer.Start();
        }

        private void startCapStopCap_Unchecked(object sender, RoutedEventArgs e)
        {
            VideoMaker makeVideo = new VideoMaker();
            FileDeleter delete = new FileDeleter();
            if (_count != 0)
            {
                _timer.Stop();
                _count = 0;
                label_render.Content = "Rendering video&#xD;&#xA;Please wait";
                makeVideo.MakeVideo();
                delete.DeleteFiles();
                Environment.Exit(0);

            }
            else
            {
                delete.DeleteFiles();
                Environment.Exit(0);
            }
        }
    }

    class FileDeleter
    {
        public void DeleteFiles()
        {
            new List<string>(Directory.GetFiles(Environment.CurrentDirectory)).ForEach(file => {
                Regex re = new Regex(@"(\d{8}).jpg", RegexOptions.IgnoreCase);
                if(re.IsMatch(file))
                    File.Delete(file);
            });
        }
    }
}
