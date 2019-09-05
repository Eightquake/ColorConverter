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
        private readonly Model Model;

        public MainWindow()
        {
            InitializeComponent();
            Model = Model.GetBrushes();

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
        }
    }
}