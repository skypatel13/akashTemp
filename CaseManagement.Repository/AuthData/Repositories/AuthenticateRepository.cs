using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.AuthData;
using CaseManagement.Models.Common;
using CaseManagement.Repository.AuthData.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Repository.AuthData.Repositories
{
    public class AuthenticateRepository : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly TokenGenerator tokenGenerator;
        private readonly IAppUser appUser;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AppConnectionString appConnectionString;

        public AuthenticateRepository(UserManager<ApplicationUser> userManager, TokenGenerator tokenGenerator, IAppUser appUser, SignInManager<ApplicationUser> signInManager, AppConnectionString appConnectionString)
        {
            this.userManager = userManager;
            this.userManager.PasswordHasher = new CustomPasswordHasher();
            this.tokenGenerator = tokenGenerator;
            this.appUser = appUser;
            this.signInManager = signInManager;
            this.appConnectionString = appConnectionString;
        }

        public async Task<TokenModel> AuthenticateUser(LoginModel login, string userAgent, string iPAddress)
        {
            var user = await userManager.FindByNameAsync(login.UserName);

            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                //Get roles for the user
                var roles = await userManager.GetRolesAsync(user);
                if (roles.Count > 0)
                {
                    var userLoginHistoryDetail = appUser.UserHistoryInsert(login.UserName, userAgent, iPAddress, false);
                    var result = tokenGenerator.GenerateToken(user.UserName, roles[0], userLoginHistoryDetail.LoginHistoryId.ToString(), userLoginHistoryDetail.LoginOn, user.Email, userLoginHistoryDetail.IsConsentRequired);
                    return result;
                }
                return null;
            }
            return null;
        }

        public DataUpdateResponseDTO SignOut(string userName, Guid loginHistoryId)
        {
            var user = userManager.FindByNameAsync(userName);
            var userLogoutHistoryDetail = new DataUpdateResponseDTO();
            if (user != null)
            {
                userLogoutHistoryDetail = appUser.UserLogOutHistory_Update(loginHistoryId);
                signInManager.SignOutAsync();
                return userLogoutHistoryDetail;
            }
            return userLogoutHistoryDetail;
        }

        public MemberConsentDetailDTO memberConsent(string UserName)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<MemberConsentDetailDTO>("SDForm_Details_GetByUserName", new { UserName = UserName }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO UpdateConsent(string requestedBy)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Member_UpdateConsent_Admin", new { RequestedBy = requestedBy }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}