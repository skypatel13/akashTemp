using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using System.Text;

namespace CaseManagement.Repository.Interfaces
{
    public interface IRescue
    {
        RescueDTOResponse List(string userName,int? survivorCode = 0);

        RescueDTOAddEditResult Add(RescueDTOAddDB rescueDTOAddDB);

        DataUpdateResponseDTO Delete(int rescueCode, string deletedBy, string deletedByIpAddress);

        RescueDTOAddEditResult Edit(RescueDTOEditDB rescueDTOEditDB);

        RescueDTODetailResponse Detail(int rescueCode, string userName);

        RescueChangeLogDTOResponse ChangeLog_GetById(int rescueCode, string userName);

        RescueDTOResponse DeletedList(string userName);
    }
}
