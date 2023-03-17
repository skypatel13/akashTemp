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
    public class DocumentTypeRepository : IDocumentType
    {
        private readonly AppConnectionString appConnectionString;

        public DocumentTypeRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public DocumentTypeDTOResponse List(string userName)
        {
            DocumentTypeDTOResponse documentTypeDTOResponse = new DocumentTypeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Document_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    documentTypeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (documentTypeDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        documentTypeDTOResponse.DocumentTypDTOList = result.Read<DocumentTypeDTOList>().ToList();
                    }
                }
            }
            return documentTypeDTOResponse;
        }

        public DataUpdateResponseDTO Add(DocumentTypeDTOAddDB documentTypeDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Document_Insert_Admin", documentTypeDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Edit(DocumentTypeDTOEditDB documentTypeDTOEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Document_Update_Admin", documentTypeDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DocumentTypeDTODetailResponse Detail(int documentCode, string userName)
        {
            DocumentTypeDTODetailResponse documentTypeDTODetailResponse = new DocumentTypeDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Document_GetByCode_Admin", new { DocumentCode = documentCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    documentTypeDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (documentTypeDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        documentTypeDTODetailResponse.DocumentTypeDTODetail = result.Read<DocumentTypeDTODetail>().FirstOrDefault();
                    }
                }
            }
            return documentTypeDTODetailResponse;
        }

        public DataUpdateResponseDTO Delete(int documentCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Document_Delete_Admin", new { DocumentCode = documentCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DocumentTypeChangeLogDTOResponse ChangeLog_GetById(int documentCode, string userName)
        {
            DocumentTypeChangeLogDTOResponse documentTypeChangeLogDTOResponse = new DocumentTypeChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("DocumentLog_GetByCode_Admin", new { DocumentCode = documentCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    documentTypeChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (documentTypeChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        documentTypeChangeLogDTOResponse.DocumentTypeChangeLogDTOList = result.Read<DocumentTypeChangeLogDTOList>().ToList();
                    }
                }
            }
            return documentTypeChangeLogDTOResponse;
        }

        public DocumentTypeDTOResponse DeletedList(string userName)
        {
            DocumentTypeDTOResponse documentTypeDTOResponse = new DocumentTypeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Document_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    documentTypeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (documentTypeDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        documentTypeDTOResponse.DocumentTypDTOList = result.Read<DocumentTypeDTOList>().ToList();
                    }
                }
            }
            return documentTypeDTOResponse;
        }
    }
}