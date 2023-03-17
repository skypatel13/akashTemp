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
    public class FirRepository : IFir
    {
        private readonly AppConnectionString appConnectionString;

        public FirRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public FirDTOResponse List(string userName)
        {
            FirDTOResponse firDTOResponse = new FirDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Fir_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    firDTOResponse.FirDTOList = result.Read<FirDTOList>().ToList();
                }
            }
            return firDTOResponse;
        }

        public FirDTOAddEditResult Add(FirDTOAddDB firDTOAddDB)
        {
            FirDTOAddEditResult firDTOAddEditResult = new FirDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Fir_Insert_Admin", firDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        firDTOAddEditResult.FirDTODetail = result.Read<FirDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        firDTOAddEditResult.FirDTODetail.FirAssignedActSectionDTOList = result.Read<FirAssignedActSectionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        firDTOAddEditResult.FirDTODetail.FirAssignedAccusedDTOList = result.Read<FirAssignedAccusedDTOList>().ToList();
                    }
                }
            }
            return firDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int firCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("Fir_Delete_Admin", new { FirCode = firCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public FirDTOAddEditResult Edit(FirDTOEditDB firDTOEditDB)
        {
            FirDTOAddEditResult firDTOAddEditResult = new FirDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Fir_Update_Admin", firDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    firDTOAddEditResult.FirDTODetail = result.Read<FirDTODetail>().FirstOrDefault();
                }
            }
            return firDTOAddEditResult;
        }

        public FirDTODetailResponse Detail(int firCode, string userName)
        {
            FirDTODetailResponse firDTODetailResponse = new FirDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Fir_GetByCode_Admin", new { FirCode = firCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firDTODetailResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        firDTODetailResponse.FirDTODetail = result.Read<FirDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        firDTODetailResponse.FirDTODetail.FirAssignedActSectionDTOList = result.Read<FirAssignedActSectionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        firDTODetailResponse.FirDTODetail.FirAssignedAccusedDTOList = result.Read<FirAssignedAccusedDTOList>().ToList();
                    }
                }
            }
            return firDTODetailResponse;
        }
        public FirBasicDetailDTOResponse BasicDetail(int firCode, string userName)
        {
            FirBasicDetailDTOResponse firBasicDetailDTOResponse = new FirBasicDetailDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FIR_GetBasicDetailByCode_Admin", new { FirCode = firCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firBasicDetailDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firBasicDetailDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        firBasicDetailDTOResponse.FirBasicDetailDTO = result.Read<FirBasicDetailDTO>().FirstOrDefault();
                    }

                }
            }
            return firBasicDetailDTOResponse;
        }

        public FirChangeLogDTOResponse ChangeLog_GetById(int firCode, string userName)
        {
            FirChangeLogDTOResponse firChangeLogDTOResponse = new FirChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FirLog_GetByCode_Admin", new { FirCode = firCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firChangeLogDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        firChangeLogDTOResponse.FirChangeLogDTOList = result.Read<FirChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        firChangeLogDTOResponse.ActSectionChangeLogDTOList = result.Read<ActSectionChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        firChangeLogDTOResponse.AccusedChangeLogDTOList = result.Read<AccusedChangeLogDTOList>().ToList();
                    }
                }
            }
            return firChangeLogDTOResponse;
        }
        public FirAccusedDTOResponse GetFirAccusedList(int firCode, string userName)
        {
            FirAccusedDTOResponse firAccusedDTOResponse = new FirAccusedDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FIR_Accused_List_Admin", new { FirCode = firCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firAccusedDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firAccusedDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    firAccusedDTOResponse.assignedAccusedDTOLists = result.Read<FirAssignedAccusedDTOList>().ToList();
                }
            }
            return firAccusedDTOResponse;
        }
        public FirActSectionDTOResponse GetFirActSectionList(int firCode, string userName)
        {
            FirActSectionDTOResponse firActSectionDTOResponse = new FirActSectionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FIR_ActSection_List_Admin", new { FirCode = firCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firActSectionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firActSectionDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    firActSectionDTOResponse.firAssignedActSectionDTOLists = result.Read<FirAssignedActSectionDTOList>().ToList();
                }
            }
            return firActSectionDTOResponse;
        }

        public FirDTOResponse DeletedList(string userName)
        {
            FirDTOResponse firDTOResponse = new FirDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Fir_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    firDTOResponse.FirDTOList = result.Read<FirDTOList>().ToList();
                }
            }
            return firDTOResponse;
        }
        public FirDTOResponse ListBySurvivor(string userName, int survivorCode)
        {
            FirDTOResponse firDTOResponse = new FirDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FIR_ListBySurvivorCode_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        firDTOResponse.FirDTOList = result.Read<FirDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        firDTOResponse.FirAssignedActSectionDTOList = result.Read<FirAssignedActSectionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        firDTOResponse.FirAssignedAccusedDTOList = result.Read<FirAssignedAccusedDTOList>().ToList();
                    }
                }
            }
            return firDTOResponse;
        }
        public FirDTOResponse DeletedListBySurvivor(string userName, int survivorCode)
        {
            FirDTOResponse firDTOResponse = new FirDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FIR_Deleted_ListBySurvivorCode_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        firDTOResponse.FirDTOList = result.Read<FirDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        firDTOResponse.FirAssignedActSectionDTOList = result.Read<FirAssignedActSectionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        firDTOResponse.FirAssignedAccusedDTOList = result.Read<FirAssignedAccusedDTOList>().ToList();
                    }
                }
            }
            return firDTOResponse;
        }
        public DataUpdateResponseDTO ActSectionAdd(FirActSectionRequestDTODB firActSectionRequestDTODB)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("FIR_ActSection_Insert_Admin", firActSectionRequestDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public SurvivorPoliceStationSourceDestinationDTOResponse GetPoliceStationBySourceDestination(string userName, int survivorCode)
        {
            SurvivorPoliceStationSourceDestinationDTOResponse survivorPoliceStationSourceDestinationDTOResponse = new SurvivorPoliceStationSourceDestinationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_GetPoliceStationBySourceDestination", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorPoliceStationSourceDestinationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorPoliceStationSourceDestinationDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    survivorPoliceStationSourceDestinationDTOResponse.SurvivorPoliceStationSourceDestinationDTOList = result.Read<SurvivorPoliceStationSourceDestinationDTOList>().ToList();
                }
            }
            return survivorPoliceStationSourceDestinationDTOResponse;
        }
    }
}