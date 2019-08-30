using Prism.Commands;
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
        public DelegateCommand delegateCommand { get; set; }

        public Double BtnWidth { get; set; }
        public Double BtnHeight { get; set; }
        public string BtnText { get; set; }

        public MainWindowViewModel()
        {
            delegateCommand = new DelegateCommand(ExecuteMethod, canExecuteMethod);
        }

        private void ExecuteMethod()
        {
            ButtonParameterWindow buttonParameterWindow = new ButtonParameterWindow(BtnHeight, BtnWidth, BtnText);
            buttonParameterWindow.Show();
        }

        private bool canExecuteMethod()
        {
            return true;
        }
    }


}