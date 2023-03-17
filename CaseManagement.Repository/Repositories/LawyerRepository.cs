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
    public class LawyerRepository : ILawyer
    {
        private readonly AppConnectionString appConnectionString;
        public LawyerRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public LawyerDTOResponse List(string userName, int? survivorCode = 0)
        {
            LawyerDTOResponse lawyerDTOResponse = new LawyerDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_Lawyer_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTOResponse.LawyerDTOList = result.Read<LawyerDTOList>().ToList();
                }
            }
            return lawyerDTOResponse;
        }
        public LawyerDTOAddEditResult Add(LawyerDTOAddDB lawyerDTOAddDB)
        {
            LawyerDTOAddEditResult lawyerDTOAddEditResult = new LawyerDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_Lawyer_Insert_Admin", lawyerDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTOAddEditResult.LawyerDTODetail = result.Read<LawyerDTODetail>().FirstOrDefault();
                }
            }
            return lawyerDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int survivorLawyerCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("Survivor_Lawyer_Delete_Admin", new { SurvivorLawyerCode = survivorLawyerCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public LawyerDTOAddEditResult Edit(LawyerDTOEditDB lawyerDTOEditDB)
        {
            LawyerDTOAddEditResult lawyerDTOAddEditResult = new LawyerDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_Lawyer_Update_Admin", lawyerDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTOAddEditResult.LawyerDTODetail = result.Read<LawyerDTODetail>().FirstOrDefault();
                }
            }
            return lawyerDTOAddEditResult;
        }
        public LawyerDTODetailResponse Detail(int survivorLawyerCode, string userName)
        {
            LawyerDTODetailResponse lawyerDTODetailResponse = new LawyerDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_Lawyer_GetByCode_Admin", new { SurvivorLawyerCode = survivorLawyerCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTODetailResponse.LawyerDTODetail = result.Read<LawyerDTODetail>().FirstOrDefault();
                }
            }
            return lawyerDTODetailResponse;
        }
        public LawyerChangeLogDTOResponse ChangeLog_GetById(int survivorLawyerCode, string userName)
        {
            LawyerChangeLogDTOResponse lawyerChangeLogDTOResponse = new LawyerChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_LawyerLog_GetByCode_Admin", new { SurvivorLawyerCode = survivorLawyerCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerChangeLogDTOResponse.LawyerChangeLogDTOList = result.Read<LawyerChangeLogDTOList>().ToList();
                }
            }
            return lawyerChangeLogDTOResponse;
        }
        public LawyerDTOResponse DeletedList(string userName)
        {
            LawyerDTOResponse lawyerDTOResponse = new LawyerDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_Lawyer_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTOResponse.LawyerDTOList = result.Read<LawyerDTOList>().ToList();
                }
            }
            return lawyerDTOResponse;
        }
        public LawyerDTOListBySurvivorResponse LawyerListBySurvivorGetByCode(string userName, int survivorCode)
        {
            LawyerDTOListBySurvivorResponse lawyerDTOListBySurvivorResponse = new LawyerDTOListBySurvivorResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_Lawyer_ListBySurvivor_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTOListBySurvivorResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTOListBySurvivorResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTOListBySurvivorResponse.LawyerDTOListBySurvivor = result.Read<LawyerDTOListBySurvivor>().ToList();
                }
            }
            return lawyerDTOListBySurvivorResponse;
        }
    }
}
