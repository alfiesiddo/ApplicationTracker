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
                    return Colors.Gray;
                case 1: // Assessments
                    return Colors.SandyBrown;
                case 2: // Interviewing
                    return Colors.Khaki;
                case 3: // Job Offer
                    return Colors.ForestGreen;
                case 4: // Rejected
                    return Colors.IndianRed;
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
