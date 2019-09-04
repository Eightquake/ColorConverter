using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

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
            DataContext = Model;
        }
        private void InputCheckCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Color enteredColor = InputChecker.TestRegex(InputTextBox.Text);

            Model.InputColor = new SolidColorBrush(enteredColor);
            Color websafeColor = ColorCalculator.CalculateWebsafeFromColor(enteredColor);
            Model.WebsafeColor = new SolidColorBrush(websafeColor);
            Model.WebsafeText = websafeColor.ToString();
            Color complementColor = ColorCalculator.CalculateComplementFromColor(enteredColor);
            Model.ComplementColor = new SolidColorBrush(complementColor);
            Model.ComplementText = complementColor.ToString();
        }
    }
    public class MyColorBrushes : INotifyPropertyChanged
    {
        SolidColorBrush _inputColor = new SolidColorBrush();
        SolidColorBrush _websafeColor = new SolidColorBrush();
        string _websafeText = "";
        SolidColorBrush _complementColor = new SolidColorBrush();
        string _complementText = "";
        SolidColorBrush[] _harmonyColors = new SolidColorBrush[] { new SolidColorBrush(), new SolidColorBrush(), new SolidColorBrush(), new SolidColorBrush() };
        static MyColorBrushes _brushes;

        public SolidColorBrush InputColor
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
        public SolidColorBrush WebsafeColor
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
        public string WebsafeText
        {
            get { return this._websafeText; }
            set
            {
                if (_websafeText != value)
                {
                    _websafeText = value;
                    NotifyPropertyChanged("WebsafeText");
                }
            }
        }
        public SolidColorBrush ComplementColor
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
        public string ComplementText
        {
            get { return this._complementText; }
            set
            {
                if (_complementText != value)
                {
                    _complementText = value;
                    NotifyPropertyChanged("ComplementText");
                }
            }
        }
        public SolidColorBrush[] HarmonyColors
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
