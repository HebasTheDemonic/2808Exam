using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace _280819Exam_Q3
{
    public class MainWindowViewModel
    {
        public DelegateCommand DelegateCommand { get; set; }
        public Results Results { get; set; }
        public string URLString { get; set; }

        private bool IsProcessOver;

        public MainWindowViewModel()
        {
            DelegateCommand = new DelegateCommand(ExecuteCommand, canExecuteCommand);
            IsProcessOver = true;
            Results = new Results();
            Task.Run(() =>
            {
                while (true)
                {
                    DelegateCommand.RaiseCanExecuteChanged();
                    Thread.Sleep(500);
                }
            });
        }

        private async void ExecuteCommand()
        {
            IsProcessOver = false;
            string pageText = "";
            await Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    pageText = client.DownloadString(URLString);
                }
            });
            int pageSize = ASCIIEncoding.ASCII.GetByteCount(pageText);
            Results.Result = $"{pageSize} bytes";
        }

        private bool canExecuteCommand()
        {
            if(URLString == null)
            {
                return false;
            }
            if (URLString != null)
            {
                string urlPadded = URLString.PadRight(4);
                string textCheck = urlPadded.Substring(0, 4);
                if (textCheck != "http")
                {
                    return false;
                }
            }
            return IsProcessOver;
        }
    }
}
