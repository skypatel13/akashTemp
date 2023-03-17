using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CaseManagement.Repository.Repositories
{
    public class SurvivorRepository : ISurvivor
    {
        private readonly AppConnectionString appConnectionString;

        public SurvivorRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public SurvivorDTOResponse List(string userName)
        {
            SurvivorDTOResponse survivorDTOListResponse = new SurvivorDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorDTOListResponse.SurvivorDTOList = result.Read<SurvivorDTOList>().ToList();
                    }

                }
            }
            return survivorDTOListResponse;
        }

        public SurvivorDTOAddEditResult Add(SurvivorDTOAddDB survivorDTOAddDB)
        {
            SurvivorDTOAddEditResult survivorDTOAddEditResult = new SurvivorDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_InsertDetails_Admin", survivorDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorDTOAddEditResult.SurvivorDTODetail = result.Read<SurvivorDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int survivorCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Survivor_Delete_Admin", new { SurvivorCode = survivorCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public SurvivorDTOAddEditResult Edit(SurvivorDTOEditDB survivorDTOEditDB)
        {
            SurvivorDTOAddEditResult survivorDTOAddEditResult = new SurvivorDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_UpdateDetails_Admin", survivorDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorDTOAddEditResult.SurvivorDTODetail = result.Read<SurvivorDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorDTOAddEditResult;
        }

        public SurvivorDTODetailResponse Detail(int survivorCode, string userName)
        {
            SurvivorDTODetailResponse survivorDetailResponse = new SurvivorDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_GetByCode_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorDetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorDetailResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorDetailResponse.SurvivorDTODetail = result.Read<SurvivorDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorDetailResponse.SurvivorDTODetail.SurvivorSHGDTOList = result.Read<SurvivorSHGDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorDetailResponse.SurvivorDTODetail.SurvivorCollectiveDTOList = result.Read<SurvivorCollectiveDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorDetailResponse.SurvivorDTODetail.TafteeshStatusLogDTO = result.Read<TafteeshStatusLogDTO>().ToList();
                    }
                }
            }
            return survivorDetailResponse;
        }

        public SurvivorDTOResponse DeletedList(string userName)
        {
            SurvivorDTOResponse survivorDTOListResponse = new SurvivorDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorDTOListResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorDTOListResponse.SurvivorDTOList = result.Read<SurvivorDTOList>().ToList();
                    }
                }
            }
            return survivorDTOListResponse;
        }
        public SurvivorChangeLogDTOResponse ChangeLog_GetById(int survivorCode, string userName)
        {
            SurvivorChangeLogDTOResponse survivorChangeLogDTOResponse = new SurvivorChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SurvivorLog_GetByCode_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorChangeLogDTOResponse.SurvivorChangeLogDTOList = result.Read<SurvivorChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorChangeLogDTOResponse.SurvivorSHGChangeLogDTOList = result.Read<SurvivorSHGChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorChangeLogDTOResponse.SurvivorCollectiveChangeLogDTOList = result.Read<SurvivorCollectiveChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorChangeLogDTOResponse.TafteeshStatusChangeLogDTOList = result.Read<TafteeshStatusChangeLogDTOList>().ToList();
                    }
                }
            }
            return survivorChangeLogDTOResponse;
        }
        public DataUpdateResponseDTO ProfileStatusUpdate(SurvivorProfileApproveRequestDTODB survivorProfileApproveRequestDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Survivor_UpdateProfileApprovalStatus_Admin", survivorProfileApproveRequestDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO TafteeshStatusUpdate(SurvivorTafteeshStatusRequestDTODB survivorTafteeshStatusRequestDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Survivor_UpdateTafteeshStatus_Admin", survivorTafteeshStatusRequestDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO SurvivorStatus_Insert_Admin(TafteeshStatusRequestDTODB TafteeshStatusRequestDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("SurvivorStatus_Insert_Admin", TafteeshStatusRequestDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO SurvivorStatus_Update_Admin(TafteeshStatusResponseDTODB TafteeshStatusResponseDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("SurvivorStatus_Update_Admin", TafteeshStatusResponseDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public TafteeshStatusLogDTOResponse SurvivorStatus_ListByCode(int survivorCode, string userName)
        {
            TafteeshStatusLogDTOResponse tafteeshStatusLogDTOResponse = new TafteeshStatusLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SurvivorStatus_List_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    tafteeshStatusLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (tafteeshStatusLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        tafteeshStatusLogDTOResponse.TafteeshStatusLogDTO = result.Read<TafteeshStatusLogDTO>().ToList();
                    }
                }
            }
            return tafteeshStatusLogDTOResponse;
        }
        public SurvivorProfileReportDTOResponse SurvivorProfileDetailsByCode(int survivorCode, string userName)
        {
            SurvivorProfileReportDTOResponse survivorProfileReportDTOResponse = new SurvivorProfileReportDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SurvivorProfile_GetByCode_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorProfileReportDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorProfileReportDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.SurvivorBasicDetailsDTO = result.Read<SurvivorBasicDetailsDTO>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.RescueDetailsDTO = result.Read<RescueDetailsDTO>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.ShgDetailsDTO = result.Read<SHGDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.CollectiveDetailsDTO = result.Read<CollectiveDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.ShelterHomeDetailsDTO = result.Read<ShelterHomeDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.LawyerDetailsDTO = result.Read<LawyerDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.FirDetailsDTO = result.Read<FIRDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.InvestigationDetailsDTO = result.Read<InvestigationDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.VcDetailsDTO = result.Read<VCDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.PcDetailsDTO = result.Read<PCDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.CitReviewDetailsDTO = result.Read<CITReviewDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.CitDimensionDetailsDTO = result.Read<CITDimensionDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.CitObjectiveDTO = result.Read<CITObjectiveDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.CitActivitiesDTO = result.Read<CITActivitiesDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.LoanTotalRemainingDTO = result.Read<LoanTotalRemainingDTO>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.LoanDetailsDTO = result.Read<LoanDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.TotalIncomeDTO = result.Read<TotalIncomeDTO>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.IncomeDetailsDTO = result.Read<IncomeDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.SurvivorDocDetailsDTO = result.Read<SurvivorDocDetailsDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorProfileReportDTOResponse.ChargeSheetDetailsDTO = result.Read<ChargeSheetDetailsDTO>().ToList();
                    }
                }
            }
            return survivorProfileReportDTOResponse;
        }
    }
}