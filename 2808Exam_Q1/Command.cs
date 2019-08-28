using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2808Exam_Q1
{
    class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Double BtnWidth { get; set; }
        public Double BtnHeight { get; set; }
        public string BtnText { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ButtonParameterWindow window = new ButtonParameterWindow(BtnHeight,BtnWidth,BtnText);
            window.Show();
        }
    }
}
