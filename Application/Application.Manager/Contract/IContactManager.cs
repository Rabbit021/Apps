using Application.DTO.ProfileModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Manager.Contract
{
	public interface IContactManager
	{
		List<ProfileDTO> FindAllProfiles();

		ProfileDTO FindProfileById(int id);

		void DeleteProfile(int profileId);

		void SaveProfileInformation(ProfileDTO profile);

		void UppdateProfileInformation(int id, ProfileDTO profileDTO);

		ContactForm InitializePageData();
	}
}
