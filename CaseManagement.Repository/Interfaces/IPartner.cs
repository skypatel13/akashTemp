using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IPartner
    {
        PartnerDTOResponse List(string userName);

        DataUpdateResponseDTO Add(PartnerDTOAddDB partnerDTOAddDB);

        DataUpdateResponseDTO Edit(PartnerDTOEditDB partnerDTOEditDB);

        PartnerDTODetailResponse Detail(string userName, int partnerCode);

        DataUpdateResponseDTO Delete(int partnerCode, string deletedBy, string deletedByIpAddress);

        PartnerDTOResponse Deleted_List(string userName);

        PartnerChangeLogDTOResponse ChangeLog_GetById(string userName, int partnerCode);
    }
}