using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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

namespace _280819Exam_Q3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mv = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mv;
        }
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StartBtn.IsEnabled = false;
            string URLString = URLTxtBx.Text;
            string pageText = "";

            await Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    pageText = client.DownloadString(URLString);
                }
            });

            int pageSize = ASCIIEncoding.ASCII.GetByteCount(pageText);

            Action uiWork = () =>
            {
                ResultTxtBlck.Text = $"{pageSize} bytes";
                StartBtn.IsEnabled = true;
            };

            SafeInvoke(uiWork);
        }

        private void SafeInvoke(Action work)
        {
            if (Dispatcher.CheckAccess())
            {
                work.Invoke();
                return;
            }
            this.Dispatcher.BeginInvoke(work);
        }

    }
}
