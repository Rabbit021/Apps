using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication2
{
	public class TextBlockUtils
	{
//		#region AutoTooltip
//		public static bool GetAutoTooltip(DependencyObject obj)
//		{
//			return (bool)obj.GetValue(AutoTooltipProperty);
//		}

//		public static void SetAutoTooltip(DependencyObject obj, bool value)
//		{
//			obj.SetValue(AutoTooltipProperty, value);
//		}

//		// Using a DependencyProperty as the backing store for AutoTooltip.  This enables animation, styling, binding, etc...
//		public static readonly DependencyProperty AutoTooltipProperty =
//			DependencyProperty.RegisterAttached("AutoTooltip", typeof(bool), typeof(TextBlockUtils), new PropertyMetadata(false, OnAutoTooltipPropertyChanged));
//		#endregion

//		private static void OnAutoTooltipPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//		{
//			var textblock = d as TextBlock;
//			if (textblock == null) return;
//			if (e.NewValue.Equals(true))
//			{
//				textblock.TextTrimming = TextTrimming.WordEllipsis;
//				ComputeAutoTooltip(textblock);
//				textblock.SizeChanged += Textblock_SizeChanged;
//			}
//			else
//				textblock.SizeChanged -= Textblock_SizeChanged;
//		}

//		private static void Textblock_SizeChanged(object sender, SizeChangedEventArgs e)
//		{
//			var textblock = sender as TextBlock;
//			ComputeAutoTooltip(textblock);
//		}

//		private static void ComputeAutoTooltip(TextBlock textblock)
//		{
//#if WPF
//			textblock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
//			var width = textblock.DesiredSize.Width;
//			if (textblock.ActualWidth < width)
//				ToolTipService.SetToolTip(textblock, textblock.Text);
//			else
//				ToolTipService.SetToolTip(textblock, null);
//#else
//			var parentElement = VisualTreeHelper.GetParent(textblock) as FrameworkElement;
//			if (parentElement != null)
//			{
//				if (textblock.ActualWidth > parentElement.ActualWidth)
//					ToolTipService.SetToolTip(textblock , textblock.Text);
//				else
//					ToolTipService.SetToolTip(textblock, null);
//			}
//#endif

//		}
	}
}
