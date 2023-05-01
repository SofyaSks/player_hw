using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace player_hw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click_PS(object sender, RoutedEventArgs e)
        {
            if(buttonPS.Content.ToString() == "Play")
            {
                video.Play();
                buttonPS.Content = "Pause";
            }
            else
                if (buttonPS.Content.ToString() == "Pause")
            {
                video.Pause();
                buttonPS.Content = "Play";
            }

        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            video.Stop();
            video_slider.Value = 0;
            video.Play();
            buttonPS.Content = "Pause";
        }

        private void volume_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            video.Volume = volume_slider.Value;
        }

        private void Button_Click_File(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = filepath.Text;
                video.Source = new Uri(str);
                video.Play();
                filepath.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void video_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Ошибка загрузки. Проверьте путь");
        }

        private void video_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            video_slider.Maximum = video.NaturalDuration.TimeSpan.TotalMilliseconds;
            video.Position = new TimeSpan(0, 0, 0, 0, (int)video_slider.Value);
        }


        private void video_MediaOpened(object sender, RoutedEventArgs e)
        {
            /*Timer timerVideoTime = new Timer();
             timerVideoTime.Interval = TimeSpan.FromSeconds(1);
             timerVideoTime.Tick += new EventHandler(timer_Tick);
             timerVideoTime.Start();*/
            
        }

        private void video_MediaEnded(object sender, RoutedEventArgs e)
        {
            video.Stop();
            video_slider.Value = 0;
            buttonPS.Content = "Play";
        }
    }
}
