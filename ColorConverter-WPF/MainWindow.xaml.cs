using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

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

            /* The grid for input texts and all of the colors should have the Model as datacontext */
            InputTextAndBoxGrid.DataContext = Model;
        }

        private void InputCheckCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Color enteredColor = InputChecker.TestRegex(Model.InputBoxText);
            Model.InputColor = enteredColor;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = (Rectangle)sender;

            string newInput = "#" + rectangle.Fill.ToString().Substring(3, 6);

            Model.InputColor = InputChecker.TestRegex(newInput);
            Model.InputBoxText = newInput;
        }
    }
}