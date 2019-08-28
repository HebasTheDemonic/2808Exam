using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _2808Exam_Q1
{
    class MainWindowViewModel
    {
        public ICommand command { get; set; }
        public Double BtnWidth { get; set; }
        public Double BtnHeight { get; set; }
        public string BtnText { get; set; }
        public MainWindowViewModel()
        {
            command = new Command();
        }
    }


}
