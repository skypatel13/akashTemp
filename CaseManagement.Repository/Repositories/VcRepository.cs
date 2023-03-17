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
    public class VcRepository : IVc
    {
        private readonly AppConnectionString appConnectionString;
        public VcRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public VcDTOResponse List(string userName, int survivorCode)
        {
            VcDTOResponse vcDTOResponse = new VcDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Vc_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcDTOResponse.vcDTOAmount = result.Read<VcDTOAmount>().FirstOrDefault();
                }
                if (vcDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcDTOResponse.VcDTOList = result.Read<VcDTOList>().ToList();
                }
            }
            return vcDTOResponse;
        }
        public VcDTOAddEditResult VCApplicationAdd(VcApplicationDTOAddDB lawyerDTOAddDB)
        {
            VcDTOAddEditResult vcDTOAddEditResult = new VcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("VC_Insert_Admin", lawyerDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcDTOAddEditResult.VcDTODetail = result.Read<VcDTODetail>().FirstOrDefault();
                }
            }
            return vcDTOAddEditResult;
        }
        public VcDTOAddEditResult VCApplicationEdit(VcApplicationDTOEditDB vcDTOBasicEditDB)
        {
            VcDTOAddEditResult vcDTOAddEditResult = new VcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("VC_Update_Basic_Admin", vcDTOBasicEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcDTOAddEditResult.VcDTODetail = result.Read<VcDTODetail>().FirstOrDefault();
                }
            }
            return vcDTOAddEditResult;
        }
        public VcDTOAddEditResult OrderUpdate(VcDTOOrderEditDB vcDTOStatusEditDB)
        {
            VcDTOAddEditResult vcDTOAddEditResult = new VcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("VC_Update_Status_Admin", vcDTOStatusEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcDTOAddEditResult.VcDTODetail = result.Read<VcDTODetail>().FirstOrDefault();
                }
            }
            return vcDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int vcCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("Vc_Delete_Admin", new { VcCode = vcCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public VcDTODetailResponse Detail(int vcCode, string userName)
        {
            VcDTODetailResponse lawyerDTODetailResponse = new VcDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Vc_GetByCode_Admin", new { VcCode = vcCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTODetailResponse.VcDTODetail = result.Read<VcDTODetail>().FirstOrDefault();
                }
            }
            return lawyerDTODetailResponse;
        }
        public VcChangeLogDTOResponse ChangeLog_GetById(int VCCode, string userName)
        {
            VcChangeLogDTOResponse vcChangeLogDTOResponse = new VcChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("VCLog_GetByCode_Admin", new { VCCode = VCCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcChangeLogDTOResponse.VcChangeLogDTOList = result.Read<VcChangeLogDTOList>().ToList();
                }
            }
            return vcChangeLogDTOResponse;
        }
        public VcDTOResponse DeletedList(string userName, int survivorCode)
        {
            VcDTOResponse lawyerDTOResponse = new VcDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Vc_Deleted_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    lawyerDTOResponse.VcDTOList = result.Read<VcDTOList>().ToList();
                }
            }
            return lawyerDTOResponse;
        }
        public VcEscalationDTOResponse EscalationList(string userName, int? vcCode)
        {
            VcEscalationDTOResponse vcEscalationDTOResponse = new VcEscalationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("VC_Escalation_List_Admin", new { UserName = userName, VCCode = vcCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcEscalationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcEscalationDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcEscalationDTOResponse.VCEscalationDTOList = result.Read<VcEscalationDTOList>().ToList();
                }
            }
            return vcEscalationDTOResponse;
        }
        public VcDTOAddEditResult EscalationAdd(VcEscalationDTOAddDB vcEscalationDTOAddDB)
        {
            VcDTOAddEditResult vcDTOAddEditResult = new VcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("VC_Escalation_Insert_Admin", vcEscalationDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcDTOAddEditResult.VcDTODetail = result.Read<VcDTODetail>().FirstOrDefault();
                }
            }
            return vcDTOAddEditResult;
        }
        public VcDTOAddEditResult concludedAdd(VCConcludeDTOAddDB vCConcludeDTOAddDB)
        {
            VcDTOAddEditResult vcDTOAddEditResult = new VcDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("VC_Update_Conclude_Admin", vCConcludeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcDTOAddEditResult.VcDTODetail = result.Read<VcDTODetail>().FirstOrDefault();
                }
            }
            return vcDTOAddEditResult;
        }
        public VcDTODetailResponse BankDetailUpdate(VcBankDetailDTOAddDB vcBankDetailDTOAddDB)
        {
            VcDTODetailResponse vcDTODetailResponse = new VcDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("VC_Update_BankDetails_Admin", vcBankDetailDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    vcDTODetailResponse.VcDTODetail = result.Read<VcDTODetail>().FirstOrDefault();
                }
            }
            return vcDTODetailResponse;
        }
    }
}
