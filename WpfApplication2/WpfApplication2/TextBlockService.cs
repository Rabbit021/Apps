using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication2
{
	public class TextBlockService
	{
		static TextBlockService()
		{
			// Register for the SizeChanged event on all TextBlocks, even if the event was handled.
			EventManager.RegisterClassHandler(typeof(TextBlock), FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnTextBlockSizeChanged), true);
		}

		public static readonly DependencyPropertyKey IsTextTrimmedKey = DependencyProperty.RegisterAttachedReadOnly("IsTextTrimmed", typeof(bool), typeof(TextBlockService), new PropertyMetadata(false));
		public static readonly DependencyProperty IsTextTrimmedProperty = IsTextTrimmedKey.DependencyProperty;

		[AttachedPropertyBrowsableForType(typeof(TextBlock))]
		public static Boolean GetIsTextTrimmed(TextBlock target)
		{
			return (Boolean)target.GetValue(IsTextTrimmedProperty);
		}

		public static void OnTextBlockSizeChanged(object sender, SizeChangedEventArgs e)
		{
			TextBlock textBlock = sender as TextBlock;
			if (null == textBlock)
				return;
			var res = calculateIsTextTrimmed(textBlock);
			textBlock.SetValue(IsTextTrimmedKey, res);
		}

		private static bool calculateIsTextTrimmed(TextBlock textBlock)
		{
			double width = textBlock.ActualWidth;
			if (textBlock.TextTrimming != TextTrimming.None)
				return true;
			textBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			double totalWidth = textBlock.DesiredSize.Width;
			var res = width >= totalWidth;
			return res;
		}
	}

}
