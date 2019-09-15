using System.Windows.Input;

namespace ColorConverter_WPF
{
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