using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Web.Mvc;
using Application.Manager.Contract;
using Application.Manager.Implementation;
using Castle.Facilities.Logging;
using Application.Core;
using Application.DAL;

namespace Application.Web.Dependency
{
	public class DependencyConventions : IWindsorInstaller
	{

		public void Install(IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
			log4net.Config.XmlConfigurator.Configure();
			container.Register(
				Component.For<IContactManager>().ImplementedBy<ContactManager>(),
				Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>()
				).AddFacility<LoggingFacility>(x => x.UseLog4Net());
		}
	}
}