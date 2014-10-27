using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace WpfApplication2
{
	public class CTB : TextBlock
	{
		#region IsTrimed
		public bool IsTrimed
		{
			get { return (bool)GetValue(IsTrimedProperty); }
			set { SetValue(IsTrimedProperty, value); }
		}

		public static readonly DependencyProperty IsTrimedProperty =
			DependencyProperty.Register("IsTrimed", typeof(bool), typeof(CTB), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsTrimedChanged)));


		private static void OnIsTrimedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

		}

		#endregion

		public CTB()
		{
			EventManager.RegisterClassHandler(typeof(CTB), FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnTextBlockSizeChanged), true);
		}

		private void OnTextBlockSizeChanged(object sender, SizeChangedEventArgs e)
		{
			TextBlock textBlock = sender as TextBlock;
			if (null == textBlock)
				return;
			var res = calculateIsTextTrimmed(textBlock);
			this.IsTrimed = res;
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
