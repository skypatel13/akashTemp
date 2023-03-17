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
    public class SurvivorDocumentRespository : ISurvivorDocument
    {
        private readonly AppConnectionString appConnectionString;
        public SurvivorDocumentRespository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public SurvivorDocumentResponse List(int survivorCode, string userName)
        {
            SurvivorDocumentResponse survivorDocumentResponse = new SurvivorDocumentResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SurvivorDocument_List_Admin", new { SurvivorCode = survivorCode, UserName = userName, }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorDocumentResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorDocumentResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    survivorDocumentResponse.survivorDocumentsList = result.Read<SurvivorDocumentDTO>().ToList();
                }
            }
            return survivorDocumentResponse;
        }
        public SurvivorDocumentDTOAddEditResult DocumentUpload(SurvivorDocumentUploadDB survivorDocumentUploadDB)
        {
            SurvivorDocumentDTOAddEditResult survivorDocumentDTOAddEditResult = new SurvivorDocumentDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SurvivorSpecificDocument_Insert_Admin", survivorDocumentUploadDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorDocumentDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorDocumentDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    survivorDocumentDTOAddEditResult.SurvivorDocumentDTODetail = result.Read<SurvivorDocumentDTODetail>().FirstOrDefault();
                }
            }
            return survivorDocumentDTOAddEditResult;
        }
    }
}
