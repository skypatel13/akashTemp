using CaseManagement.DAL;
using CaseManagement.Models.AuthData;
using CaseManagement.Models.Common;
using CaseManagement.Models.SuperAdmin;
using CaseManagement.Repository.AuthData.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Repository.AuthData.Repositories
{
    public class AppUserRepository : IAppUser
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppConnectionString appConnectionString;
        private readonly ApplicationDbContext dbContext;

        public AppUserRepository(UserManager<ApplicationUser> userManager, AppConnectionString appConnectionString, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.userManager.PasswordHasher = new CustomPasswordHasher();
            this.appConnectionString = appConnectionString;
            this.dbContext = dbContext;
        }

        public async Task<DataUpdateResponseDTO> CreateUserAsync(AppUser appUser)
        {
            //To store password as a plain text
            userManager.PasswordHasher = new CustomPasswordHasher();
            ApplicationUser user = new ApplicationUser()
            {
                Email = appUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = appUser.UserName
            };
            var result = await userManager.CreateAsync(user, appUser.UserPassword);
            if (result.Succeeded)
            {
                return new DataUpdateResponseDTO() { Status = true, Description = $"User Created {appUser.UserName}", RecordCount = 1 };
            }

            return new DataUpdateResponseDTO() { Status = false, Description = $"Fail to create user {appUser.UserName}", RecordCount = 0 };
        }

        public List<AppUserDTOList> GetList()
        {
            var result = (from t in userManager.Users select new AppUserDTOList() { UserName = t.UserName, Email = t.Email }).ToList();
            return result;
        }

        public UserLoginHistoryDetail UserHistoryInsert(string UName, string UserAgent, string IPAddress, bool IsRefreshed)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.Query<UserLoginHistoryDetail>("UserLogInHistory_Insert", new { UName, UserAgent, IPAddress, IsRefreshed }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
                return result;
            }
        }

        public DataUpdateResponseDTO UserLogOutHistory_Update(Guid loginHistoryId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.Query<DataUpdateResponseDTO>("UserLogOutHistory_Update", new { loginHistoryId }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
                return result;
            }
        }

        public async Task<DataUpdateResponseDTO> UpdatePassword(UpdatePasswordDTODB updatePasswordDTODB)
        {
            DataUpdateResponseDTO dataUpdateResponseDTO = new DataUpdateResponseDTO() { Status = false, Description = "Change Password", RecordCount = 0 };
            userManager.PasswordHasher = new CustomPasswordHasher();
            var user = await userManager.FindByNameAsync(updatePasswordDTODB.UserName);
            if (user != null)
            {
                var result = await userManager.ChangePasswordAsync(user, updatePasswordDTODB.CurrentPassword, updatePasswordDTODB.NewPassword);
                if (result.Succeeded)
                {
                    dataUpdateResponseDTO.Description = "Password Changed";
                    dataUpdateResponseDTO.Status = true;
                    dataUpdateResponseDTO.RecordCount = 1;
                }
                else
                {
                    dataUpdateResponseDTO.Description = result.ToString();
                }
            }
            return dataUpdateResponseDTO;
        }
        public UserProfileResponseDTO UserProfileDetail(string userName)
        {
            UserProfileResponseDTO userProfileResponseDTO = new UserProfileResponseDTO();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("UserDetails_GetByUser_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    userProfileResponseDTO.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (userProfileResponseDTO.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        userProfileResponseDTO.UserProfileDetail = result.Read<UserProfileDetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        userProfileResponseDTO.UserProfileRoles = result.Read<UserProfileRoles>().ToList();
                    }
                }
            }
            return userProfileResponseDTO;
        }
        public UserProfileResponseDTO UserDetails_Update(string mobile, string userName)
        {
            UserProfileResponseDTO userProfileResponseDTO = new UserProfileResponseDTO();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("UserDetails_Update_Admin", new { Mobile = mobile, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    userProfileResponseDTO.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (userProfileResponseDTO.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        userProfileResponseDTO.UserProfileDetail = result.Read<UserProfileDetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        userProfileResponseDTO.UserProfileRoles = result.Read<UserProfileRoles>().ToList();
                    }
                }
            }
            return userProfileResponseDTO;
        }
    }
}