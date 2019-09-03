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
        private InputChecker inputChecker;
        private MyInputBrush inputBrush;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            inputBrush = new MyInputBrush();

            Binding binding = new Binding("Color")
            {
                Source = inputBrush
            };
            InputColorBox.SetBinding(Rectangle.FillProperty, binding);
            inputChecker = new InputChecker();
        }
        private void InputCheckCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            inputBrush.Color = new SolidColorBrush(inputChecker.TestRegex(InputTextBox.Text));
        }
    }
    public class MyInputBrush : INotifyPropertyChanged
    {
        private SolidColorBrush inputColor;
        public SolidColorBrush Color
        {
            get { return this.inputColor;  }
            set
            {
                if(inputColor != value)
                {
                    inputColor = value;
                    NotifyPropertyChanged("Color");
                }
            }
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
