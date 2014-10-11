using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using WindowsServiceHostsService;
using System.ServiceModel.Description;

namespace WCFHostedWindowsService
{
	public partial class Service1 : ServiceBase
	{
		public Service1()
		{
			InitializeComponent();
		}
		private ServiceHost host;
		protected override void OnStart(string[] args)
		{
			if (host != null)
				host.Close();
			Uri httpUri = new Uri("http://localhost:8090/MyService/SimpleCalculator");
			host = new ServiceHost(typeof(WindowsServiceHostsService.SimpleCalculator), httpUri);

			host.AddServiceEndpoint(typeof(WindowsServiceHostsService.ISimpleCalculator), new WSHttpBinding(),"");
			
			ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
			smb.HttpGetEnabled = true;
			host.Description.Behaviors.Add(smb);
			host.Open();

		}

		protected override void OnStop()
		{
			if (host != null)
			{
				host.Close();
			}
		}
	}
}
