using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Manager.Contract;
using Application.DTO.ProfileModule;
using System.Diagnostics;

namespace Application.Manager.Implementation
{
	public class ContactManager : BaseManager, IContactManager
	{
		private bool _isDispose;
		public bool IsDispose
		{
			get { return _isDispose; }
			set { _isDispose = value; }
		}

		public ContactManager(IUnitOfWorkManager unit)
			: base(unit)
		{
		}

		public List<ProfileDTO> FindAllProfiles()
		{
			var lst = new List<ProfileDTO>();

			lst.Add(new ProfileDTO
			{
				ProfileId = 1,
				FirstName = "John",
				LastName = "Devil",
				Email = "buct_wh2010@163.om"
			});

			return lst;
		}

		public ProfileDTO FindProfileById(int id)
		{
			return new ProfileDTO
			{
				ProfileId = 1,
				FirstName = "John",
				LastName = "Devil",
				Email = "buct_wh2010@163.om"
			};
		}

		public void DeleteProfile(int profileId)
		{
			using (var unit = this.Manager.NewUnitOfWork())
			{

				unit.Commit();
			}
		}

		public void SaveProfileInformation(ProfileDTO profile)
		{
		}

		public void UppdateProfileInformation(int id, ProfileDTO profileDTO)
		{
		}

		public ContactForm InitializePageData()
		{
			var initData = new ContactForm();
			return initData;
		}
	}

	public class BaseManager
	{
		private readonly IUnitOfWorkManager manager;

		public IUnitOfWorkManager Manager
		{
			get { return manager; }
		}

		public BaseManager(IUnitOfWorkManager unit)
		{
			this.manager = unit;
		}
	}
}
