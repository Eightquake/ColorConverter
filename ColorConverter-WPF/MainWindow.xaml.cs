using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyColorBrushes Model;

        public MainWindow()
        {
            InitializeComponent();
            Model = MyColorBrushes.GetBrushes();

            /* The grid for input texts and all of the colors should have the Model as datacontext, but overall the datacontext should be this class - so that custom commands and converters work */
            InputTextAndBoxGrid.DataContext = Model;
            this.DataContext = this;
        }

        private void InputCheckCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Color enteredColor = InputChecker.TestRegex(Model.InputBoxText);
            Model.InputColor = enteredColor;

            Model.WebsafeColor = ColorCalculator.CalculateWebsafeFromColor(enteredColor);
            Model.ComplementColor = ColorCalculator.CalculateComplementFromColor(enteredColor);
            Model.HarmonyColors = ColorCalculator.CalculateHarmonyFromColor(enteredColor);
        }
    }

    public class MyColorBrushes : INotifyPropertyChanged
    {
        private string _inputBoxText = "";
        private Color _inputColor = new Color();
        private Color _websafeColor = new Color();
        private Color _complementColor = new Color();
        private Color[] _harmonyColors = new Color[] { };

        /* Singleton design, keep a reference to the one instace here */
        private static MyColorBrushes _brushes;

        public string InputBoxText
        {
            get { return this._inputBoxText; }
            set
            {
                if(_inputBoxText != value)
                {
                    _inputBoxText = value;
                    NotifyPropertyChanged("InputBoxText");
                }
            }
        }

        public Color InputColor
        {
            get { return this._inputColor; }
            set
            {
                if (_inputColor != value)
                {
                    _inputColor = value;
                    NotifyPropertyChanged("InputColor");
                }
            }
        }

        public Color WebsafeColor
        {
            get { return this._websafeColor; }
            set
            {
                if (_websafeColor != value)
                {
                    _websafeColor = value;
                    NotifyPropertyChanged("WebsafeColor");
                }
            }
        }

        public Color ComplementColor
        {
            get { return this._complementColor; }
            set
            {
                if (_complementColor != value)
                {
                    _complementColor = value;
                    NotifyPropertyChanged("ComplementColor");
                }
            }
        }

        public Color[] HarmonyColors
        {
            get { return this._harmonyColors; }
            set
            {
                if (_harmonyColors != value)
                {
                    _harmonyColors = value;
                    NotifyPropertyChanged("HarmonyColors");
                }
            }
        }

        /* Singleton design, no one should use constructor and use this instead. It will give the same instance to all or create it if it doesn't exist */
        public static MyColorBrushes GetBrushes()
        {
            if (_brushes == null)
            {
                _brushes = new MyColorBrushes();
            }
            return _brushes;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class ColorToSolidBrushOrStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;
            if (targetType == typeof(Brush))
            {
                return new SolidColorBrush(color);
            }
            else if(targetType == typeof(string))
            {
                return "#" + color.ToString().Substring(3, 6);
            }
            else
            {
                return null;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Debug.WriteLine("ConvertBack called.");
            SolidColorBrush brush = (SolidColorBrush)value;
            return brush.Color;
        }
    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand CheckInput = new RoutedUICommand
            (
            "CheckInput",
            "CheckInput",
            typeof(CustomCommands)
            );
    }
}