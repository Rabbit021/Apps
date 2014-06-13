using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WpfMVVMSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.MainWindow = new WpfMVVMSample.Views.Default.MainWindow();
            this.MainWindow.Show();
        }
    }
}
