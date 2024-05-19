﻿using System.Globalization;

namespace AIS_Airport
{
	/// <summary>
	/// A converter that takes in a boolean and returns a thickness of 2 if true, useful for applying
	/// border radius on a true value
	/// </summary>
	public class BooleanToBorderThicknessConverter : BaseValueConverter<BooleanToBorderThicknessConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (parameter is null)
			{
				return (bool)value ? 2 : 0;
			}

			return (bool)value ? 0 : 2;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}