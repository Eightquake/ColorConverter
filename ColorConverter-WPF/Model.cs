using System.ComponentModel;
using System.Windows.Media;

namespace ColorConverter_WPF
{
    public class Model : INotifyPropertyChanged
    {
        private string _inputBoxText = "";
        private Color _inputColor = new Color();

        /* Singleton design, keep a reference to the one instace here */
        private static Model _model;

        public string InputBoxText
        {
            get { return this._inputBoxText; }
            set
            {
                if (_inputBoxText != value)
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

        /* Singleton design, no one should use constructor and use this instead. It will give the same instance to all or create it if it doesn't exist */

        public static Model GetBrushes()
        {
            if (_model == null)
            {
                _model = new Model();
            }
            return _model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}