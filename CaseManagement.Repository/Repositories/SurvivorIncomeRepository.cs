using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using System;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Linq;

namespace CaseManagement.Repository.Repositories
{
    public class SurvivorIncomeRepository : ISurvivorIncome
    {
        private readonly AppConnectionString appConnectionString;

        public SurvivorIncomeRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public SurvirorIncomeResponse List(string userName, int? survivorCode)
        {
            SurvirorIncomeResponse survirorIncomeResponse = new SurvirorIncomeResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Income_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survirorIncomeResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survirorIncomeResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survirorIncomeResponse.survivorTotalIncome = result.Read<SurvivorTotalIncome>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        survirorIncomeResponse.survivorIncomeList = result.Read<SurvivorIncomeDTO>().ToList();
                    }
                }
            }
            return survirorIncomeResponse;
        }
        public SurvivorIncomeDTOAddEditResult Add(SurvivorIncomeDTOAddDB survivorIncomeDTOAddDB)
        {
            SurvivorIncomeDTOAddEditResult survivorIncomeDTOAddEditResult = new SurvivorIncomeDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Income_Insert_Admin", survivorIncomeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorIncomeDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorIncomeDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorIncomeDTOAddEditResult.survivorIncomeDTODetail = result.Read<SurvivorIncomeDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorIncomeDTOAddEditResult;
        }
        

        public SurvivorIncomeDTOAddEditResult Edit(SurvivorIncomeDTOEditDB survivorIncomeDTOEditDB)
        {
            SurvivorIncomeDTOAddEditResult survivorIncomeDTOAddEditResult=new SurvivorIncomeDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Income_Update_Admin", survivorIncomeDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorIncomeDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorIncomeDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorIncomeDTOAddEditResult.survivorIncomeDTODetail = result.Read<SurvivorIncomeDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorIncomeDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int incomeCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Income_Delete_Admin", new { IncomeCode = incomeCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public SurvivorIncomeDetailResponse Detail(int incomeCode, string userName)
        {
            SurvivorIncomeDetailResponse survivorIcomeDetailResponse = new SurvivorIncomeDetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Income_GetByCode_Admin", new { IncomeCode = incomeCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorIcomeDetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorIcomeDetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorIcomeDetailResponse.survivorIncomeDTODetail = result.Read<SurvivorIncomeDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorIcomeDetailResponse;
        }

        public SurvirorIncomeResponseChangeLog ChangeLog_GetById(int incomeCode, string userName)
        {
            SurvirorIncomeResponseChangeLog survirorIncomeResponseChangeLog = new SurvirorIncomeResponseChangeLog();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("IncomeLog_GetByCode_Admin", new { IncomeCode = incomeCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survirorIncomeResponseChangeLog.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survirorIncomeResponseChangeLog.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survirorIncomeResponseChangeLog.survivorIncomeChangeLogList = result.Read<SurvivorIncomeChangeLogDTO>().ToList();
                    }
                }
            }
            return survirorIncomeResponseChangeLog;
        }
        public SurvirorIncomeResponse DeletedList(string userName, int? survivorCode)
        {
            SurvirorIncomeResponse survirorIncomeResponse = new SurvirorIncomeResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Income_Deleted_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survirorIncomeResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survirorIncomeResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survirorIncomeResponse.survivorIncomeList = result.Read<SurvivorIncomeDTO>().ToList();
                    }
                }
            }
            return survirorIncomeResponse;
        }
    }
}
