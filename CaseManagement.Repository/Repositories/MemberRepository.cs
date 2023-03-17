using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace CaseManagement.Repository.Repositories
{
    public class MemberRepository : IMember
    {
        private readonly AppConnectionString appConnectionString;
        public MemberRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public MemberDTODetailResponse Detail(int memberCode, string userName)
        {
            MemberDTODetailResponse memberDTODetailResponse = new MemberDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Member_GetByCode_Admin", new { MemberCode = memberCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        memberDTODetailResponse.MemberDTODetail = result.Read<MemberDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        memberDTODetailResponse.MemberDTODetail.MemberRoleAssignedDTOList = result.Read<MemberRoleAssignedDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        memberDTODetailResponse.MemberDTODetail.MemberLawyerTypeAssignedDTOList = result.Read<MemberLawyerTypeAssignedDTOList>().ToList();
                    }
                }
            }
            return memberDTODetailResponse;
        }
        public MemberDTOResponse List(string userName)
        {
            MemberDTOResponse memberDTOResponse = new MemberDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Member_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        memberDTOResponse.MemberDTOList = result.Read<MemberDTOList>().ToList();
                    }
                }
            }
            return memberDTOResponse;
        }
        public MemberChangeLogDTOResponse ChangeLog_GetById(int memberCode, string userName)
        {
            MemberChangeLogDTOResponse memberChangeLogDTOResponse = new MemberChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("MemberLog_GetByCode_Admin", new { MemberCode = memberCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        memberChangeLogDTOResponse.MemberChangeLogDTOList = result.Read<MemberChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        memberChangeLogDTOResponse.MemberRoleChangeLogDTOList = result.Read<MemberRoleChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        memberChangeLogDTOResponse.MemberLawyerTypeChangeLogDTOList = result.Read<MemberLawyerTypeChangeLogDTOList>().ToList();
                    }
                }
            }
            return memberChangeLogDTOResponse;
        }
        public DataUpdateResponseDTO Delete(int memberCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Member_Delete_Admin", new { MemberCode = memberCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public MemberDTOAddEditResult Add(MemberDTOAddDB memberDTOAddDB)
        {
            MemberDTOAddEditResult memberDTOAddEditResult = new MemberDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Member_Insert_Admin", memberDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        memberDTOAddEditResult.MemberDTODetail = result.Read<MemberDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        memberDTOAddEditResult.MemberDTODetail.MemberRoleAssignedDTOList = result.Read<MemberRoleAssignedDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        memberDTOAddEditResult.MemberDTODetail.MemberLawyerTypeAssignedDTOList = result.Read<MemberLawyerTypeAssignedDTOList>().ToList();
                    }
                }
            }
            return memberDTOAddEditResult;
        }
        public MemberDTOAddEditResult Edit(MemberDTOEditDB memberDTOEditDB)
        {
            MemberDTOAddEditResult memberDTOAddEditResult = new MemberDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Member_Update_Admin", memberDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        memberDTOAddEditResult.MemberDTODetail = result.Read<MemberDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        memberDTOAddEditResult.MemberDTODetail.MemberRoleAssignedDTOList = result.Read<MemberRoleAssignedDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        memberDTOAddEditResult.MemberDTODetail.MemberLawyerTypeAssignedDTOList = result.Read<MemberLawyerTypeAssignedDTOList>().ToList();
                    }
                }
            }
            return memberDTOAddEditResult;
        }
        public MemberDTOResponse DeletedList(string userName)
        {
            MemberDTOResponse memberDTOResponse = new MemberDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Member_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        memberDTOResponse.MemberDTOList = result.Read<MemberDTOList>().ToList();
                    }
                }
            }
            return memberDTOResponse;
        }
        public DataUpdateResponseDTO UpdateConsent(int memberCode, string requestedBy)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Member_UpdateConsent_Admin", new { MemberCode = memberCode, RequestedBy = requestedBy }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public MemberLawyerDTOResponse MemberLawyerList(string userName)
        {
            MemberLawyerDTOResponse memberLawyerDTOResponse = new MemberLawyerDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("MemberLawyer_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberLawyerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberLawyerDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        memberLawyerDTOResponse.MemberLawyerDTOList = result.Read<MemberLawyerDTOList>().ToList();
                    }
                }
            }
            return memberLawyerDTOResponse;
        }

        public MemberSurvivorDTOResponse MemberSurvivorList(string userName, string memberId)
        {
            MemberSurvivorDTOResponse memberSurvivorDTOResponse = new MemberSurvivorDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("MemberSurvivor_List_Admin", new { UserName = userName, MemberId = memberId }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberSurvivorDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberSurvivorDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        memberSurvivorDTOResponse.MemberSurvivorDTOLHeader = result.Read<MemberSurvivorDTOLHeader>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        memberSurvivorDTOResponse.MemberSurvivorDTOList = result.Read<MemberSurvivorDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        memberSurvivorDTOResponse.MemberOrganizationDTOList = result.Read<MemberOrganizationDTOList>().ToList();
                    }
                }
            }
            return memberSurvivorDTOResponse;
        }
        public DataUpdateResponseDTO MemberSurviviorAdd(MemberSurvivorDTOAddDB memberSurvivorDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("MemberSurvivor_Insert_Admin", memberSurvivorDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public MemberSurvivorChangeLogDTOResponse MemberSurvivorChangeLog_GetById(string userName, int memberDataAccessCode)
        {
            MemberSurvivorChangeLogDTOResponse memberSurvivorChangeLogDTOResponse = new MemberSurvivorChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("MemberDataAccessLog_GetByCode_Admin", new { UserName = userName, MemberDataAccessCode = memberDataAccessCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberSurvivorChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberSurvivorChangeLogDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        memberSurvivorChangeLogDTOResponse.MemberSurvivorChangeLogDTOList = result.Read<MemberSurvivorChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        memberSurvivorChangeLogDTOResponse.MemberDataAccessChangeLogDTOList = result.Read<MemberDataAccessChangeLogDTOList>().ToList();
                    }
                }
            }
            return memberSurvivorChangeLogDTOResponse;
        }
        public MemberCredentialDTOResponse MemberCredential_GetByCode_ForEmail(int memberCode, string userName)
        {
            MemberCredentialDTOResponse memberCredentialDTOResponse = new MemberCredentialDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.MemberCredential_GetByCode_ForEmail_Admin", new { UserName = userName, MemberCode = memberCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    memberCredentialDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (memberCredentialDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        memberCredentialDTOResponse.MemberCredentialDTODetail = result.Read<MemberCredentialDTODetail>().FirstOrDefault();
                    }
                }
            }
            return memberCredentialDTOResponse;
        }
    }

}
