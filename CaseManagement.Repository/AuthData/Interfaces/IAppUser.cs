using CaseManagement.Models.AuthData;
using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseManagement.Repository.AuthData.Interfaces
{
    public interface IAppUser
    {
        Task<DataUpdateResponseDTO> CreateUserAsync(AppUser appUser);

        List<AppUserDTOList> GetList();

        UserLoginHistoryDetail UserHistoryInsert(string UName, string UserAgent, string IPAddress, bool IsRefreshed);

        DataUpdateResponseDTO UserLogOutHistory_Update(Guid loginHistoryId);

        Task<DataUpdateResponseDTO> UpdatePassword(UpdatePasswordDTODB updatePasswordDTODB);
        UserProfileResponseDTO UserProfileDetail(string userName);
        UserProfileResponseDTO UserDetails_Update(string mobile,string userName);

    }
}