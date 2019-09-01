using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _280819Exam_Q2
{
    class TimerValues : INotifyPropertyChanged
    {
        private int _timerValue;

        public int TimerValue
        {
            get
            {
                return _timerValue;
            }
            set
            {
                this._timerValue = value;
                OnPropertyChanged("TimerValue");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
