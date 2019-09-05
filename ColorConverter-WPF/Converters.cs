using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    public class ColorToSolidBrushOrStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;
            if (targetType == typeof(Brush))
            {
                return new SolidColorBrush(color);
            }
            else if (targetType == typeof(string))
            {
                return "#" + color.ToString().Substring(3, 6);
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorToWebsafeColorOrStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color websafeColor = ColorCalculator.CalculateWebsafeFromColor((Color)value);

            if (targetType == typeof(Brush))
            {
                return new SolidColorBrush(websafeColor);
            }
            else if (targetType == typeof(string))
            {
                return "#" + websafeColor.ToString().Substring(3, 6);
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorToComplementColorOrStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color complementColor = ColorCalculator.CalculateComplementFromColor((Color)value);

            if (targetType == typeof(Brush))
            {
                return new SolidColorBrush(complementColor);
            }
            else if (targetType == typeof(string))
            {
                return "#" + complementColor.ToString().Substring(3, 6);
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorToHarmoyColorOrStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color harmonyColor = ColorCalculator.CalculateHarmonyColorFromColor((Color)value, int.Parse(parameter.ToString()));

            if (targetType == typeof(Brush))
            {
                return new SolidColorBrush(harmonyColor);
            }
            else if (targetType == typeof(string))
            {
                return "#" + harmonyColor.ToString().Substring(3, 6);
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}