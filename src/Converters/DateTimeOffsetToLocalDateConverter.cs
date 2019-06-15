using System;
using System.Globalization;
using System.Windows.Data;

namespace Imago.Converters
{
	public class DateTimeOffsetToLocalDateConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is DateTimeOffset dateTimeOffset))
				throw new InvalidOperationException($"Expected DateTimeOffset, got {value.GetType().Name}");

			return $"{dateTimeOffset:d} {dateTimeOffset:T}";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
