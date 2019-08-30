using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _2808Exam_Q1
{
    public class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToInt32(value) < 150)
            {
                return "SMALL";
            }
            if (System.Convert.ToInt32(value) < 200)
            {
                return "MEDIUM";
            }
            if (System.Convert.ToInt32(value) < 250)
            {
                return "LARGE";
            }
            else
            {
                return "EXTRA LARGE";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}