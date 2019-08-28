using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _2808Exam_Q1
{
    public class HeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToInt32(value) < 30)
            {
                return "SMALL";
            }
            if (System.Convert.ToInt32(value) < 40)
            {
                return "MEDIUM";
            }
            if (System.Convert.ToInt32(value) < 50)
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
