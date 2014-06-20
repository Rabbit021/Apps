using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Manager.Contract;
using Application.DTO.ProfileModule;
using System.Diagnostics;

namespace Application.Manager.Implementation
{
	public class ContactManager : IContactManager
	{
		#region Instance
		//private static ContactManager instance = new ContactManager();
		//public static ContactManager Instance { get { return instance; } }
		#endregion

		public ContactManager() { }

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
}
