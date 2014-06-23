using Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Manager.Contract
{
	public interface IUnitOfWorkManager
	{
		IUnitOfWork NewUnitOfWork();
	}
}
