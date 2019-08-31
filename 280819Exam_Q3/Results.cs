using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _280819Exam_Q3
{
    public class Results : INotifyPropertyChanged
    {
        private string _result;

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                this._result = value;
                OnPropertyChanged("Result");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public override string ToString()
        {
            return $"{Result} bytes";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
