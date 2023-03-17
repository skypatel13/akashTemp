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
    public class CitTemplateRepository : ICitTemplate
    {
        private readonly AppConnectionString appConnectionString;
        public CitTemplateRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public CitTemplateDTOResponse List(string userName)
        {
            CitTemplateDTOResponse versionDTOResponse = new CitTemplateDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Version_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDTOResponse.CitTemplateDTOList = result.Read<CitTemplateDTOList>().ToList();
                }
            }
            return versionDTOResponse;
        }
        public CitTemplateDTOAddEditResult Add(CitTemplateDTOAddDB versionDTOAddDB)
        {
            CitTemplateDTOAddEditResult versionDTOAddEditResult = new CitTemplateDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Version_Insert_Admin", versionDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDTOAddEditResult.CitTemplateDTODetail = result.Read<CitTemplateDTODetail>().FirstOrDefault();
                }
            }
            return versionDTOAddEditResult;
        }
        public DataUpdateResponseDTO Obsolete(int versionCode, string obsoleteBy, string obsoleteByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("CIT.Version_Obsolete_Admin", new { VersionCode = versionCode, ObsoleteBy = obsoleteBy, ObsoleteByIpAddress = obsoleteByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public CitTemplateDTOAddEditResult Edit(CitTemplateDTOEditDB versionDTOEditDB)
        {
            CitTemplateDTOAddEditResult versionDTOAddEditResult = new CitTemplateDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Version_Update_Admin", versionDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDTOAddEditResult.CitTemplateDTODetail = result.Read<CitTemplateDTODetail>().FirstOrDefault();
                }
            }
            return versionDTOAddEditResult;
        }
        public CitDTODetailResponse Detail(int versionCode, string userName)
        {
            CitDTODetailResponse versionDTODetailResponse = new CitDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Version_GetByCode_Admin", new { VersionCode = versionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDTODetailResponse.CitTemplateDTODetail = result.Read<CitTemplateDTODetail>().FirstOrDefault();
                }
            }
            return versionDTODetailResponse;
        }
        public CitChangeLogDTOResponse ChangeLog_GetById(int versionCode, string userName)
        {
            CitChangeLogDTOResponse versionChangeLogDTOResponse = new CitChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.VersionLog_GetByCode_Admin", new { VersionCode = versionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionChangeLogDTOResponse.CitTemplateChangeLogDTOList = result.Read<CitTemplateChangeLogDTOList>().ToList();
                }
            }
            return versionChangeLogDTOResponse;
        }
        public CitTemplateDTOResponse ObsoleteList(string userName)
        {
            CitTemplateDTOResponse versionDTOResponse = new CitTemplateDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Version_Obsolete_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDTOResponse.CitTemplateDTOList = result.Read<CitTemplateDTOList>().ToList();
                }
            }
            return versionDTOResponse;
        }
    }
    
}

