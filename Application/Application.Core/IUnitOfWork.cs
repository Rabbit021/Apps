using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Core
{
	public interface IUnitOfWork
	{
		void Commit();
		void RoolBack();
	}
}
