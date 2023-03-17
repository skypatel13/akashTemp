using CaseManagement.Models.Admin;
using CaseManagement.Models.AuthData;
using CaseManagement.Models.Common;
using System;
using System.Threading.Tasks;

namespace CaseManagement.Repository.AuthData.Interfaces
{
    public interface IAuthenticate
    {
        Task<TokenModel> AuthenticateUser(LoginModel login, string userAgent, string iPAddress);

        DataUpdateResponseDTO SignOut(string userName, Guid loginHistoryId);
        DataUpdateResponseDTO UpdateConsent(string requestedBy);
        MemberConsentDetailDTO memberConsent(string UserName);
    }
}