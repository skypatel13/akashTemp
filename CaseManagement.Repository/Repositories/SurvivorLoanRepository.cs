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
    public class SurvivorLoanRepository : ISurvivorLoan
    {
        private readonly AppConnectionString appConnectionString;

        public SurvivorLoanRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public SurvivorLoanResponse List(string userName, int? survivorCode)
        {
            SurvivorLoanResponse survirorLoanResponse = new SurvivorLoanResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FinancialInclusion_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survirorLoanResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survirorLoanResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survirorLoanResponse.survivorLoansList = result.Read<SurvivorLoanDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survirorLoanResponse.survivorLoanPaidList = result.Read<SurvivorLoanPaidDTO>().ToList();
                    }
                }
            }
            return survirorLoanResponse;
        }
        public SurvivorLoanDTOAddEditResult Add(SurvivorLoanDTOAddDB survivorLoanDTOAddDB)
        {
            SurvivorLoanDTOAddEditResult survivorLoanDTOAddEditResult = new SurvivorLoanDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FinancialInclusion_Insert_Admin", survivorLoanDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorLoanDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorLoanDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorLoanDTOAddEditResult.survivorLoanDTODetail = result.Read<SurvivorLoanDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorLoanDTOAddEditResult;
        }
        public SurvivorLoanDTOAddEditResult Edit(SurvivorLoanDTOEditDB survivorLoanDTOEditDB)
        {
            SurvivorLoanDTOAddEditResult survivorLoanDTOAddEditResult = new SurvivorLoanDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FinancialInclusion_Update_Admin", survivorLoanDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorLoanDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorLoanDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorLoanDTOAddEditResult.survivorLoanDTODetail = result.Read<SurvivorLoanDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorLoanDTOAddEditResult;
        }
        public SurvivorLoanDetailResponse Detail(int financialInclusionCode, string userName)
        {
            SurvivorLoanDetailResponse survivorLoanDetailResponse = new SurvivorLoanDetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FinancialInclusion_GetByCode_Admin", new { FinancialInclusionCode = financialInclusionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorLoanDetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorLoanDetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorLoanDetailResponse.survivorLoanDTODetail = result.Read<SurvivorLoanDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorLoanDetailResponse.survivorLoanDTODetail.survivorLoanMortgageAssignedDTOLists = result.Read<SurvivorLoanMortgageAssignedDTOList>().ToList();
                    }
                }
            }
            return survivorLoanDetailResponse;
        }
        public DataUpdateResponseDTO Delete(int financialInclusionCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("FinancialInclusion_Delete_Admin", new { FinancialInclusionCode = financialInclusionCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SurvivorLoanPaidResponse PaidList(int financialInclusionCode, string userName)
        {
            SurvivorLoanPaidResponse survivorLoanPaidLogResponse = new SurvivorLoanPaidResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FinancialInclusionPaidLog_List_Admin", new { FinancialInclusionCode = financialInclusionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorLoanPaidLogResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorLoanPaidLogResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorLoanPaidLogResponse.survivorLoanPaidList = result.Read<SurvivorLoanPaidDTO>().ToList();
                    }
                }
            }
            return survivorLoanPaidLogResponse;
        }
        public DataUpdateResponseDTO PaidInsert(SurvivorLoanDTOPaidAddDB survivorLoanDTOPaidAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("FinancialInclusionPaidLog_Insert_Admin", survivorLoanDTOPaidAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO PaidEdit(SurvivorLoanDTOPaidEditDB survivorLoanDTOPaidEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("FinancialInclusionPaidLog_Update_Admin", survivorLoanDTOPaidEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO PaidDelete(int financialInclusionPaidLogCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("FinancialInclusionPaidLog_Delete_Admin", new { FinancialInclusionPaidLogCode = financialInclusionPaidLogCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SurvivorLoanChangeLogResponse ChangeLog_GetById(int financialInclusionCode, string userName)
        {
            SurvivorLoanChangeLogResponse survivorLoanChangeLogResponse = new SurvivorLoanChangeLogResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FinancialInclusionLog_GetByCode_Admin", new { FinancialInclusionCode = financialInclusionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorLoanChangeLogResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorLoanChangeLogResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorLoanChangeLogResponse.survivorLoanChangeLogDTOs = result.Read<SurvivorLoanChangeLogDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorLoanChangeLogResponse.survivorPaidChangeLogDTOs = result.Read<SurvivorPaidChangeLogDTO>().ToList();
                    }
                }
            }
            return survivorLoanChangeLogResponse;
        }
        public SurvivorLoanDeletedResponseDTO DeletedList(string userName, int? survivorCode)
        {
            SurvivorLoanDeletedResponseDTO survivorLoanDeletedResponseDTO = new SurvivorLoanDeletedResponseDTO();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FinancialInclusion_Deleted_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorLoanDeletedResponseDTO.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorLoanDeletedResponseDTO.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorLoanDeletedResponseDTO.survivorLoansList = result.Read<SurvivorLoanDTO>().ToList();
                    }
                }
            }
            return survivorLoanDeletedResponseDTO;
        }
    }
}
