﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace ParkInspectGroupC.Converter
{
    internal class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object param, CultureInfo culture)
        {
            return value.Equals(param);
        }

        public object ConvertBack(object value, Type targetType, object param, CultureInfo culture)
        {
            return (bool) value ? param : Binding.DoNothing;
        }
    }
}