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
    public class DimensionRepository : IDimension
    {
        private readonly AppConnectionString appConnectionString;
        public DimensionRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public DimensionDTOResponse List(string userName)
        {
            DimensionDTOResponse dimensionDTOResponse = new DimensionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Dimension_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    dimensionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (dimensionDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    dimensionDTOResponse.DimensionDTOList = result.Read<DimensionDTOList>().ToList();
                }
            }
            return dimensionDTOResponse;
        }
        public DimensionDTOAddEditResult Add(DimensionDTOAddDB dimensionDTOAddDB)
        {
            DimensionDTOAddEditResult dimensionDTOAddEditResult = new DimensionDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Dimension_Insert_Admin", dimensionDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    dimensionDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (dimensionDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    dimensionDTOAddEditResult.DimensionDTODetail = result.Read<DimensionDTODetail>().FirstOrDefault();
                }
            }
            return dimensionDTOAddEditResult;
        }
        public DataUpdateResponseDTO Obsolete(int dimensionCode, string obsoleteBy, string obsoleteByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("CIT.Dimension_Obsolete_Admin", new { DimensionCode = dimensionCode, ObsoleteBy = obsoleteBy, ObsoleteByIpAddress = obsoleteByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public DimensionDTOAddEditResult Edit(DimensionDTOEditDB dimensionDTOEditDB)
        {
            DimensionDTOAddEditResult dimensionDTOAddEditResult = new DimensionDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Dimension_Update_Admin", dimensionDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    dimensionDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (dimensionDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    dimensionDTOAddEditResult.DimensionDTODetail = result.Read<DimensionDTODetail>().FirstOrDefault();
                }
            }
            return dimensionDTOAddEditResult;
        }
        public DimensionDTODetailResponse Detail(int dimensionCode, string userName)
        {
            DimensionDTODetailResponse dimensionDTODetailResponse = new DimensionDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Dimension_GetByCode_Admin", new { DimensionCode = dimensionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    dimensionDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (dimensionDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    dimensionDTODetailResponse.DimensionDTODetail = result.Read<DimensionDTODetail>().FirstOrDefault();
                }
            }
            return dimensionDTODetailResponse;
        }
        public DimensionChangeLogDTOResponse ChangeLog_GetById(int dimensionCode, string userName)
        {
            DimensionChangeLogDTOResponse dimensionChangeLogDTOResponse = new DimensionChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.DimensionLog_GetByCode_Admin", new { DimensionCode = dimensionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    dimensionChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (dimensionChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    dimensionChangeLogDTOResponse.DimensionChangeLogDTOList = result.Read<DimensionChangeLogDTOList>().ToList();
                }
            }
            return dimensionChangeLogDTOResponse;
        }
        public DimensionDTOResponse ObsoleteList(string userName)
        {
            DimensionDTOResponse dimensionDTOResponse = new DimensionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Dimension_Obsolete_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    dimensionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (dimensionDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    dimensionDTOResponse.DimensionDTOList = result.Read<DimensionDTOList>().ToList();
                }
            }
            return dimensionDTOResponse;
        }
    }
}
