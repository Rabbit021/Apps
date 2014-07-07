using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Castle.Core;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;

namespace WPFInjected
{
	/// <summary>
	/// App.xaml 的交互逻辑
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			var container = new WindsorContainer();
			container.Install(FromAssembly.This());
		}
	}
	public class RepositoriesInstaller : IWindsorInstaller
	{

		public void Install(IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly());
		}
	}
}
