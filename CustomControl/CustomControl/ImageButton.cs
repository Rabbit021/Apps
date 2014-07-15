using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Net;

namespace CustomControl
{
	[TemplatePart(Name = "PART_Image", Type = typeof(Image))]
	public class ImageButton : Button
	{
		#region Source
		public ImageSource Source
		{
			get { return (ImageSource)GetValue(SourceProperty); }
			set { SetValue(SourceProperty, value); }
		}

		public static readonly DependencyProperty SourceProperty =
			DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata((sender, e) =>
			{
				var vm = sender as ImageButton;
				if (vm == null) return;
			}));

		#endregion
		static ImageButton()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			var image = GetTemplateChild("PART_Image") as Image;
			if (image != null)
				image.Visibility = Visibility.Collapsed;

		}
	}
}
