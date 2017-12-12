using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using DataTemplateExample.Components;

namespace DataTemplateExample
{
    public class ColorComponentToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var component = value as ColorComponent;
            if (component == null)
            {
                throw new NotImplementedException();
            }

            return ToBrush(component);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static Brush ToBrush(ColorComponent component)
        {

            return new SolidColorBrush(Color.FromRgb(component.Red, component.Green, component.Blue));
        }
    }

    public class StringEqualityToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var reference = parameter as string;
            var source = value as ComboBoxItem;

            if (source == null)
                return Visibility.Collapsed;

            return source.Content.Equals(reference) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Command : ICommand
    {
        private readonly Action _onExecute;

        public event EventHandler CanExecuteChanged;

        public Command(Action onExecute)
        {
            _onExecute = onExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _onExecute();
        }
    }
}