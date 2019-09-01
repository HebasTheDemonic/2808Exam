using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _280819Exam_Q2
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public DelegateCommand CorrectButtonPressDelegate { get; set; }
        public DelegateCommand IncorrectButtonPressDelegate { get; set; }
        public TimerValues TimerValues { get; set; }
        public Brush _timerTextColor;
        public Brush TimerTextColor
        {
            get
            {
                return _timerTextColor;
            }
            set
            {
                this._timerTextColor = value;
                OnPropertyChanged("TimerTextColor");
            }
        }
        public bool buttonPressFlag;
        private Brush _gridBackground;

        public Brush GridBackground
        {
            get
            {
                return _gridBackground;
            }
            set
            {
                this._gridBackground = value;
                OnPropertyChanged("GridBackground");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            TimerTextColor = Brushes.Black;
            GridBackground = Brushes.White;
            TimerValues = new TimerValues();
            TimerValues.TimerValue = 30;
            CorrectButtonPressDelegate = new DelegateCommand(ExecuteCommandCBP, canExecuteCommand);
            IncorrectButtonPressDelegate = new DelegateCommand(ExecuteCommandIBP, canExecuteCommand);
            buttonPressFlag = false;
            Task.Run(() =>
            {
                while (TimerValues.TimerValue != 15)
                {
                    canExecuteCommand();
                    Thread.Sleep(500);
                }
                while(TimerValues.TimerValue != 0)
                {
                    canExecuteCommand();
                    Thread.Sleep(500);
                    TimerTextColor = Brushes.Red;
                }
                TimerTextColor = Brushes.Black;
                GridBackground = Brushes.Red;
            });
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void ExecuteCommandIBP()
        {
            buttonPressFlag = true;
            TimerTextColor = Brushes.Black;
            GridBackground = Brushes.Red;
        }
       
        private void ExecuteCommandCBP()
        {
            buttonPressFlag = true;
            GridBackground = Brushes.Green;
        }

        private bool canExecuteCommand()
        {
            if (TimerValues.TimerValue == 0 || buttonPressFlag)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
