using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IDocumentType
    {
        DocumentTypeDTOResponse List(string userName);
        DataUpdateResponseDTO Add(DocumentTypeDTOAddDB documentTypeDTOAddDB);
        DataUpdateResponseDTO Edit(DocumentTypeDTOEditDB documentTypeDTOAddDB);
        DocumentTypeDTODetailResponse Detail(int documentCode, string userName);
        DataUpdateResponseDTO Delete(int documentCode, string deletedBy, string deletedByIpAddress);
        DocumentTypeChangeLogDTOResponse ChangeLog_GetById(int DocumentCode, string userName);
        DocumentTypeDTOResponse DeletedList(string userName);

    }
} 