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
    public class SurvivorShelterRepository : ISurvivorShelter
    {
        private readonly AppConnectionString appConnectionString;

        public SurvivorShelterRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public SurvivorShelterDTOResponse List(string userName, int survivorCode)
        {
            SurvivorShelterDTOResponse survivorShelterDTOResponse = new SurvivorShelterDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_ShelterHome_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorShelterDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorShelterDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorShelterDTOResponse.survivorShelterDTOLists = result.Read<SurvivorShelterDTOList>().ToList();
                    }
                }
            }
            return survivorShelterDTOResponse;
        }
        public SurvivorShelterDTOAddEditResult Add(SurvivorShelterDTOAddDB survivorShelterDTOAddDB)
        {
            SurvivorShelterDTOAddEditResult survivorShelterDTOAddEditResult = new SurvivorShelterDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_ShelterHome_Insert_Admin", survivorShelterDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorShelterDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorShelterDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorShelterDTOAddEditResult.SurvivorShelterDTODetail = result.Read<SurvivorShelterDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorShelterDTOAddEditResult;
        }

        public SurvivorShelterDTOAddEditResult Edit(SurvivorShelterDTOEditDB survivorShelterDTOEditDB)
        {
            SurvivorShelterDTOAddEditResult survivorShelterDTOAddEditResult = new SurvivorShelterDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_ShelterHome_Update_Admin", survivorShelterDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorShelterDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorShelterDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorShelterDTOAddEditResult.SurvivorShelterDTODetail = result.Read<SurvivorShelterDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorShelterDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int survivorShelterHomeCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Survivor_ShelterHome_Delete_Admin", new { SurvivorShelterHomeCode = survivorShelterHomeCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SurvivorShelterDTODetailResponse Detail(int survivorShelterHomeCode, string userName)
        {
            SurvivorShelterDTODetailResponse survivorShelterDTODetailResponse = new SurvivorShelterDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_ShelterHome_GetByCode_Admin", new { SurvivorShelterHomeCode = survivorShelterHomeCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorShelterDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorShelterDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorShelterDTODetailResponse.survivorShelterDTODetail = result.Read<SurvivorShelterDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorShelterDTODetailResponse;
        }
        public SurvivorShelterChangeLogDTOResponse ChangeLog_GetById(int survivorShelterHomeCode, string userName)
        {
            SurvivorShelterChangeLogDTOResponse survivorShelterChangeLogDTOResponse = new SurvivorShelterChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_ShelterHomeLog_GetByCode_Admin", new { SurvivorShelterHomeCode = survivorShelterHomeCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorShelterChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorShelterChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorShelterChangeLogDTOResponse.survivorShelterChangeLogDTOLists = result.Read<SurvivorShelterChangeLogDTOList>().ToList();
                    }
                }
            }
            return survivorShelterChangeLogDTOResponse;
        }
        public SurvivorShelterDTOResponse DeletedList(string userName, int survivorCode)
        {
            SurvivorShelterDTOResponse survivorShelterDTOResponse = new SurvivorShelterDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_ShelterHome_Deleted_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorShelterDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorShelterDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorShelterDTOResponse.survivorShelterDTOLists = result.Read<SurvivorShelterDTOList>().ToList();
                    }
                }
            }
            return survivorShelterDTOResponse;
        }

    }
}
