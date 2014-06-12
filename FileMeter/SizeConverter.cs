using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FileMeter
{
    public class SizeConverter : IValueConverter
    {
        private static string[] _suffixes = new string[] { "b", "Kb", "Mb", "Gb" };

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var size = (double)(long)value;
            var i = 0;
            while (size > 0 && i < 3)
            {
                var newSize = size / 1000.0;
                if (newSize >= 1)
                {
                    size = newSize;
                    i++;
                }
                else
                    break;
            }
            return string.Format("{0:f2} {1}", size, _suffixes[i]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
