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
    internal class PcRepository : IPc
    {
        private readonly AppConnectionString appConnectionString;

        public PcRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public PcDTOResponse List(int survivorCode, string userName)
        {
            PcDTOResponse vcDTOResponse = new PcDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PC_List_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcDTOResponse.PcDTOList = result.Read<PcDTOList>().ToList();
                }
            }
            return vcDTOResponse;
        }

        public PcDTOAddEditResult PCApplicationAdd(PcApplicationDTOAddDB pcApplicationDTOAddDB)
        {
            PcDTOAddEditResult pcDTOAddEditResult = new PcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PC_Insert_Admin", pcApplicationDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    pcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (pcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    pcDTOAddEditResult.PcDTODetail = result.Read<PcDTODetail>().FirstOrDefault();
                }
            }
            return pcDTOAddEditResult;
        }

        public PcDTOAddEditResult PCApplicationEdit(PcApplicationDTOEditDB pcDTOBasicEditDB)
        {
            PcDTOAddEditResult pcDTOAddEditResult = new PcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PC_Update_Basic_Admin", pcDTOBasicEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    pcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (pcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    pcDTOAddEditResult.PcDTODetail = result.Read<PcDTODetail>().FirstOrDefault();
                }
            }
            return pcDTOAddEditResult;
        }

        public PcDTOAddEditResult OrderUpdate(PcDTOOrderEditDB pcDTOStatusEditDB)
        {
            PcDTOAddEditResult pcDTOAddEditResult = new PcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PC_Update_Status_Admin", pcDTOStatusEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    pcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (pcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    pcDTOAddEditResult.PcDTODetail = result.Read<PcDTODetail>().FirstOrDefault();
                }
            }
            return pcDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int pcCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("Pc_Delete_Admin", new { PcCode = pcCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public PcDTODetailResponse Detail(int pcCode, string userName)
        {
            PcDTODetailResponse lawyerDTODetailResponse = new PcDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Pc_GetByCode_Admin", new { PcCode = pcCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTODetailResponse.PcDTODetail = result.Read<PcDTODetail>().FirstOrDefault();
                }
                if (lawyerDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTODetailResponse.PcDTODetail.PCWhyDataListDTO = result.Read<PCWhyDataListDTO>().ToList();
                }
            }
            return lawyerDTODetailResponse;
        }

        public PcChangeLogDTOResponse ChangeLog_GetById(int pcCode, string userName)
        {
            PcChangeLogDTOResponse pcChangeLogDTOResponse = new PcChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PCLog_GetByCode_Admin", new { PCCode = pcCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    pcChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (pcChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    pcChangeLogDTOResponse.PcChangeLogDTOList = result.Read<PcChangeLogDTOList>().ToList();
                }
            }
            return pcChangeLogDTOResponse;
        }

        public PcDTOResponse DeletedList(string userName, int survivorCode)
        {
            PcDTOResponse lawyerDTOResponse = new PcDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Pc_Deleted_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTOResponse.PcDTOList = result.Read<PcDTOList>().ToList();
                }
            }
            return lawyerDTOResponse;
        }

        public PcEscalationDTOResponse EscalationList(string userName, int? pcCode)
        {
            PcEscalationDTOResponse pcEscalationDTOResponse = new PcEscalationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PC_Escalation_List_Admin", new { UserName = userName, PCCode = pcCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    pcEscalationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (pcEscalationDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    pcEscalationDTOResponse.PcEscalationDTOList = result.Read<PcEscalationDTOList>().ToList();
                }
            }
            return pcEscalationDTOResponse;
        }

        public PcDTOAddEditResult EscalationAdd(PcEscalationDTOAddDB pcEscalationDTOAddDB)
        {
            PcDTOAddEditResult pcDTOAddEditResult = new PcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PC_Escalation_Insert_Admin", pcEscalationDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    pcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (pcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    pcDTOAddEditResult.PcDTODetail = result.Read<PcDTODetail>().FirstOrDefault();
                }
            }
            return pcDTOAddEditResult;
        }
        public PcDTOAddEditResult concludedAdd(PcConcludeDTOAddDB pcConcludeDTOAddDB)
        {
            PcDTOAddEditResult pcDTOAddEditResult = new PcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PC_Update_Conclude_Admin", pcConcludeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    pcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (pcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    pcDTOAddEditResult.PcDTODetail = result.Read<PcDTODetail>().FirstOrDefault();
                }
            }
            return pcDTOAddEditResult;
        }
    }
}