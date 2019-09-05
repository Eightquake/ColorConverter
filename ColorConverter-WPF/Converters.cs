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

    public class ColorToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;
            string type = parameter.ToString().ToUpper();
            if (type == "HEX")
            {
                string red = color.R.ToString("X2"),
                green = color.G.ToString("X2"),
                blue = color.B.ToString("X2"),
                alpha = color.A.ToString("X2");

                return string.Format("#RRGGBB\t#{0}{1}{2}{4}#RRGGBBAA\t#{0}{1}{2}{3}{4}#AARRGGBB\t#{3}{0}{1}{2}", red, green, blue, alpha, Environment.NewLine);
            }
            else if (type == "RGB")
            {
                byte red = color.R,
                    green = color.G,
                    blue = color.B,
                    alpha = color.A;

                byte redPercent = (byte)(red / 255.0M * 100.0M);
                byte greenPercent = (byte)(green / 255.0M * 100.0M);
                byte bluePercent = (byte)(blue / 255.0M * 100.0M);

                decimal alphaDec = alpha / 255.0M;

                string text = string.Format("RGB({0}, {1}, {2})", red, green, blue) +
                string.Format("{0}", Environment.NewLine) +
                string.Format("RGB({0}%, {1}%, {2}%)", redPercent, greenPercent, bluePercent) +
                string.Format("{0}{0}", Environment.NewLine) +
                string.Format("RGBA({0}, {1}, {2}, {3}){5}RGBA({0}, {1}, {2}, {4})", red, green, blue, alpha, alphaDec, Environment.NewLine) +
                string.Format("{0}{0}", Environment.NewLine) +
                string.Format("RGBA({0}%, {1}%, {2}%, {4}){5}RGBA({0}%, {1}%, {2}%, {3})", redPercent, greenPercent, bluePercent, alpha, alphaDec, Environment.NewLine) +
                string.Format("{0}{0}", Environment.NewLine) +
                string.Format("ARGB({3}, {0}, {1}, {2}){5}ARGB({4}, {0}, {1}, {2})", red, green, blue, alpha, alphaDec, Environment.NewLine) +
                string.Format("{0}{0}", Environment.NewLine) +
                string.Format("ARGB({3}, {0}%, {1}%, {2}%){5}ARGB({4}, {0}%, {1}%, {2})", redPercent, greenPercent, bluePercent, alpha, alphaDec, Environment.NewLine);
                return text;
            }
            else if(type == "HSL")
            {
                ColorConverter.GetHSLFromColor(color.R, color.G, color.B, out double hue, out double saturation, out double lightness);

                hue = Math.Round(hue, 0);
                saturation = Math.Round(saturation * 100, 0);
                lightness = Math.Round(lightness * 100, 0);

                decimal alphaDec = color.A / 255.0M;

                string text = string.Format("HSL({0}, {1}, {2})", hue, saturation, lightness) +
                string.Format("{0}", Environment.NewLine) +
                string.Format("HSL({0}, {1}%, {2}%)", hue, saturation, lightness) +
                string.Format("{0}", Environment.NewLine) +
                string.Format("HSL({0}°, {1}%, {2}%)", hue, saturation, lightness) +
                string.Format("{0}{0}", Environment.NewLine) +
                string.Format("HSLA({0}, {1}, {2}, {3})", hue, saturation, lightness, alphaDec) +
                string.Format("{0}", Environment.NewLine) +
                string.Format("HSLA({0}, {1}%, {2}%, {3})", hue, saturation, lightness, alphaDec) +
                string.Format("{0}", Environment.NewLine) +
                string.Format("HSLA({0}°, {1}%, {2}%, {3})", hue, saturation, lightness, alphaDec);

                return text;
            }

            return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}