using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApplication2
{

	public class TrimmedTextBlockVisibilityConverter : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null) return Visibility.Collapsed;
			var textBlock = value as TextBlock;
			if (textBlock == null) return Visibility.Collapsed;
			if (textBlock.TextTrimming == TextTrimming.WordEllipsis) return Visibility.Visible;
			double width = textBlock.ActualWidth;
			var totalWidth = textBlock.MaxWidth;
			var res = width > totalWidth ;
			if (res)
				textBlock.TextTrimming = TextTrimming.WordEllipsis;
			return res? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
