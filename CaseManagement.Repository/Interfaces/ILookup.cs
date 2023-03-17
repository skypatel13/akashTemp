using CaseManagement.Models.Admin;

namespace CaseManagement.Repository.Interfaces
{
    public interface ILookup
    {
        LookupDTOListResponse List(string tagName, string userName);
        LookupStateDistrictDTOListResponse GetStateListByDistrict(string userName);
        LookupLocationDTOResponse lookupLocationDTOResponse(string userName);
        LookupRescueLocationResponseDTO lookupRescueLocationResponseDTO(string userName);
        LookupPoliceStationWithLocationDTOResponse LookupPoliceStationWithLocation(string userName);
        LookupActSectionDTOResponse SurvivorActSectionList(string userName);
        LookupLegalServiceProviderDTOResponse LegalServiceProviderList(string userName, string tagName, int survivorCode);

        LookupLegalServiceProviderDTOResponse LegalServiceProviderList_PC(string userName,  int survivorCode, int? pcCode);

        SurvivorLawyerLookupGetByTypeDTOResponse SurvivorLawyerGetByTypeList(string userName, int survivorCode, string typeName);
        SurvivorDTOHeaderResponse SurvivorDetail(string userName, int survivorCode);
        LookupWhyPCDTOResponse WhyPcList(string userName);

        LookupLegalServiceTypeDTOResponse lookupLegalServiceType(string userName);
        GetDepartmentDutyBearerResponse getDepartmentDutyBearer(string userName);
    }
}