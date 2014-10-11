using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace WCFHostedWindowsService
{
	[RunInstaller(true)]
	public partial class WinServiceInstaller : System.Configuration.Install.Installer
	{
		private ServiceProcessInstaller process;
		private ServiceInstaller service;
		public WinServiceInstaller()
		{
			InitializeComponent();

			process = new ServiceProcessInstaller();
			process.Account = ServiceAccount.NetworkService;

			service = new ServiceInstaller();
			service.ServiceName = "WCFHostedWS";
			service.DisplayName = "WCFHostedWS";
			service.Description = "WCF Hosted with WS";
			service.StartType = ServiceStartMode.Automatic;

			Installers.Add(process);
			Installers.Add(service);
		}
	}
}
