using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BasicMvvmSample.Converters
{
    public class StringSplitConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string str && parameter is string delimiter)
            {
                return str.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}