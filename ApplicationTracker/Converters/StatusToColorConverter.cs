using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTracker.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        // This method converts the data (int) to the UI value (Color)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int status = (int)value;

            switch (status)
            {
                case 0: // Applied
                    return Colors.WhiteSmoke;
                case 1: // Interviewing
                    return Colors.Khaki;
                case 2: // Offer
                    return Colors.PaleGreen;
                case 3: // Rejected
                    return Colors.IndianRed;
                case 4: // Withdrawn
                    return Colors.Gainsboro;
                default:
                    return Colors.Transparent; // Default/fallback color
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
