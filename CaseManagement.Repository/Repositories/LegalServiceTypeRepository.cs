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
    public class LegalServiceTypeRepository : ILegalServiceType
    {
        private readonly AppConnectionString appConnectionString;

        public LegalServiceTypeRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public LegalServiceTypeDTOResponse List(string userName)
        {
            LegalServiceTypeDTOResponse legalServiceTypeDTOResponse = new LegalServiceTypeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceType_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceTypeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceTypeDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceTypeDTOResponse.LegalServiceTypeDTOList = result.Read<LegalServiceTypeDTOList>().ToList();
                    }
                }
            }
            return legalServiceTypeDTOResponse;
        }

        public LegalServiceTypeDTOAddEditResult Add(LegalServiceTypeDTOAddDB legalServiceTypeDTOAddDB)
        {
            LegalServiceTypeDTOAddEditResult legalServiceTypeDTOAddEditResult = new LegalServiceTypeDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceType_Insert_Admin", legalServiceTypeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceTypeDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceTypeDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceTypeDTOAddEditResult.LegalServiceTypeDTODetail = result.Read<LegalServiceTypeDTODetail>().FirstOrDefault();
                    }
                }
            }
            return legalServiceTypeDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int actCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("LegalServiceType_Delete_Admin", new { LegalServiceTypeCode = actCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public LegalServiceTypeDTOAddEditResult Edit(LegalServiceTypeDTOEditDB legalServiceTypeDTOEditDB)
        {
            LegalServiceTypeDTOAddEditResult legalServiceTypeDTOAddEditResult = new LegalServiceTypeDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceType_Update_Admin", legalServiceTypeDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceTypeDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceTypeDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceTypeDTOAddEditResult.LegalServiceTypeDTODetail = result.Read<LegalServiceTypeDTODetail>().FirstOrDefault();
                    }
                }
            }
            return legalServiceTypeDTOAddEditResult;
        }

        public LegalServiceTypeDTODetailResponse Detail(int actCode, string userName)
        {
            LegalServiceTypeDTODetailResponse legalServiceTypeDTODetailResponse = new LegalServiceTypeDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceType_GetByCode_Admin", new { LegalServiceTypeCode = actCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceTypeDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceTypeDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceTypeDTODetailResponse.LegalServiceTypeDTODetail = result.Read<LegalServiceTypeDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        legalServiceTypeDTODetailResponse.LegalServiceTypeDTODetail.ProgramAxis = result.Read<LegalServiceTypeAssignedProgramAxis>().ToList();
                    }
                }
            }
            return legalServiceTypeDTODetailResponse;
        }

        public LegalServiceTypeChangeLogDTOResponse ChangeLog_GetById(int actCode, string userName)
        {
            LegalServiceTypeChangeLogDTOResponse legalServiceTypeChangeLogDTOResponse = new LegalServiceTypeChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceTypeLog_GetByCode_Admin", new { LegalServiceTypeCode = actCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceTypeChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceTypeChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceTypeChangeLogDTOResponse.LegalServiceTypeChangeLogDTOList = result.Read<LegalServiceTypeChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        legalServiceTypeChangeLogDTOResponse.legalServiceTypeChangeLogProgramAxes = result.Read<LegalServiceTypeChangeLogProgramAxis>().ToList();
                    }
                }
            }
            return legalServiceTypeChangeLogDTOResponse;
        }

        public LegalServiceTypeDTOResponse DeletedList(string userName)
        {
            LegalServiceTypeDTOResponse legalServiceTypeDTOResponse = new LegalServiceTypeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceType_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceTypeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceTypeDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceTypeDTOResponse.LegalServiceTypeDTOList = result.Read<LegalServiceTypeDTOList>().ToList();
                    }
                }
            }
            return legalServiceTypeDTOResponse;
        }
    }
}