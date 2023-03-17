using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISurvivorShelter
    {
        SurvivorShelterDTOResponse List(string userName, int survivorCode);
        SurvivorShelterDTOAddEditResult Add(SurvivorShelterDTOAddDB survivorShelterDTOAddDB);
        SurvivorShelterDTOAddEditResult Edit(SurvivorShelterDTOEditDB survivorShelterDTOEditDB);
        SurvivorShelterDTODetailResponse Detail(int survivorShelterHomeCode, string userName);
        DataUpdateResponseDTO Delete(int survivorShelterHomeCode, string deletedBy, string deletedByIpAddress);
        SurvivorShelterChangeLogDTOResponse ChangeLog_GetById(int survivorShelterHomeCode, string userName);
        SurvivorShelterDTOResponse DeletedList(string userName, int survivorCode);
    }
}
