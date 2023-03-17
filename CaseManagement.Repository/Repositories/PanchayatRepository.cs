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
    public class PanchayatRepository : IPanchayat
    {
        private readonly AppConnectionString appConnectionString;
        public PanchayatRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public PanchayatDTOResponse List(string userName)
        {
            PanchayatDTOResponse panchayatDTOListResponse = new PanchayatDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Panchayat_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    panchayatDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (panchayatDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        panchayatDTOListResponse.PanchayatDTOList = result.Read<PanchayatDTOList>().ToList();
                    }
                }
            }
            return panchayatDTOListResponse;
        }

        public PanchayatDTOAddEditResult Add(PanchayatDTOAddDB panchayatDTOAddDB)
        {
            PanchayatDTOAddEditResult panchayatDTOAddEditResult = new PanchayatDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Panchayat_Insert_Admin", panchayatDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    panchayatDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (panchayatDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        panchayatDTOAddEditResult.PanchayatDTODetail = result.Read<PanchayatDTODetail>().FirstOrDefault();
                    }
                }
            }
            return panchayatDTOAddEditResult;
        }
        public PanchayatDTOAddEditResult Edit(PanchayatDTOEditDB panchayatDTOEditDB)
        {
            PanchayatDTOAddEditResult panchayatDTOAddEditResult = new PanchayatDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Panchayat_Update_Admin", panchayatDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    panchayatDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (panchayatDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    panchayatDTOAddEditResult.PanchayatDTODetail = result.Read<PanchayatDTODetail>().FirstOrDefault();
                }
            }
            return panchayatDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int panchayatCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("Panchayat_Delete_Admin", new { PanchayatCode = panchayatCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public PanchayatDTODetailResponse Detail(int panchayatCode, string userName)
        {
            PanchayatDTODetailResponse panchayatDTODetailResponse = new PanchayatDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Panchayat_GetByCode_Admin", new { PanchayatCode = panchayatCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    panchayatDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (panchayatDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    panchayatDTODetailResponse.PanchayatDTODetail = result.Read<PanchayatDTODetail>().FirstOrDefault();
                }
            }
            return panchayatDTODetailResponse;
        }
        public PanchayatDTOResponse DeletedList(string userName)
        {
            PanchayatDTOResponse panchayatDTOResponse = new PanchayatDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Panchayat_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    panchayatDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (panchayatDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    panchayatDTOResponse.PanchayatDTOList = result.Read<PanchayatDTOList>().ToList();
                }
            }
            return panchayatDTOResponse;
        }

        public PanchayatChangeLogDTOResponse ChangeLog_GetById(int panchayatCode, string userName)
        {
            PanchayatChangeLogDTOResponse panchayatChangeLogDTOResponse = new PanchayatChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PanchayatLog_GetByCode_Admin", new { PanchayatCode = panchayatCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    panchayatChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (panchayatChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        panchayatChangeLogDTOResponse.PanchayatChangeLogDTOList = result.Read<PanchayatChangeLogDTOList>().ToList();
                    }
                }
            }
            return panchayatChangeLogDTOResponse;
        }
    }
}
