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
    public class LookupRepository : ILookup
    {
        private readonly AppConnectionString appConnectionString;

        public LookupRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public LookupDTOListResponse List(string tagName, string userName)
        {
            LookupDTOListResponse lookupDTOListResponse = new LookupDTOListResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LookupValues_GetByTagName_Admin", new { TagName = tagName, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        lookupDTOListResponse.LookupDTOList = result.Read<LookupDTOList>().ToList();
                    }
                }
            }
            return lookupDTOListResponse;
        }

        public LookupStateDistrictDTOListResponse GetStateListByDistrict(string userName)
        {
            LookupStateDistrictDTOListResponse lookupStateDistrictDTOListResponse = new LookupStateDistrictDTOListResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Lookup_StateDistrict_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupStateDistrictDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupStateDistrictDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        lookupStateDistrictDTOListResponse.LookupStateDistrictDTOList = result.Read<LookupStateDistrictDTOList>().ToList();
                    }
                }
            }
            return lookupStateDistrictDTOListResponse;
        }

        public LookupLocationDTOResponse lookupLocationDTOResponse(string userName)
        {
            LookupLocationDTOResponse lookupLocationDTOResponse = new LookupLocationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Lookup_Location_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupLocationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupLocationDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        lookupLocationDTOResponse.lookupStateDTOLists = result.Read<LookupStateDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupLocationDTOResponse.lookupStatesDistricts = result.Read<LookupStateDistrictDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupLocationDTOResponse.lookupBlockDTOLists = result.Read<LookupBlockDTOList>().ToList();
                    }
                }
            }
            return lookupLocationDTOResponse;
        }

        public LookupRescueLocationResponseDTO lookupRescueLocationResponseDTO(string userName)
        {
            LookupRescueLocationResponseDTO lookupRescueLocationResponseDTO = new LookupRescueLocationResponseDTO();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Lookup_StateDistrictCity_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupRescueLocationResponseDTO.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupRescueLocationResponseDTO.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        lookupRescueLocationResponseDTO.LookupStateDTOList = result.Read<LookupStateDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupRescueLocationResponseDTO.LookupStateDistrictDTOList = result.Read<LookupStateDistrictDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupRescueLocationResponseDTO.LookupCityDTOList = result.Read<LookupCityDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupRescueLocationResponseDTO.lookupPoliceStationDTOLists = result.Read<LookupPoliceStationDTOList>().ToList();
                    }
                }
            }
            return lookupRescueLocationResponseDTO;
        }

        public LookupPoliceStationWithLocationDTOResponse LookupPoliceStationWithLocation(string userName)
        {
            LookupPoliceStationWithLocationDTOResponse lookupPoliceStationWithLocationDTOResponse = new LookupPoliceStationWithLocationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Lookup_PoliceStationWithLocation_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupPoliceStationWithLocationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupPoliceStationWithLocationDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        lookupPoliceStationWithLocationDTOResponse.LookupStateDTOList = result.Read<LookupStateDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupPoliceStationWithLocationDTOResponse.LookupStateDistrictDTOList = result.Read<LookupStateDistrictDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupPoliceStationWithLocationDTOResponse.LookupBlockDTOList = result.Read<LookupBlockDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupPoliceStationWithLocationDTOResponse.LookupPoliceStationDTOList = result.Read<LookupPoliceStationDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupPoliceStationWithLocationDTOResponse.LookupVillageDTOList = result.Read<LookupVillageDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupPoliceStationWithLocationDTOResponse.LookupPanchayatDTOList = result.Read<LookupPanchayatDTOList>().ToList();
                    }
                }
            }
            return lookupPoliceStationWithLocationDTOResponse;
        }

        public LookupActSectionDTOResponse SurvivorActSectionList(string userName)
        {
            LookupActSectionDTOResponse lookupActSectionDTOResponse = new LookupActSectionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Lookup_ActSectionForSurvivor_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupActSectionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupActSectionDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        lookupActSectionDTOResponse.LookupActSectionDTOList = result.Read<LookupActSectionDTOList>().ToList();
                    }
                }
            }
            return lookupActSectionDTOResponse;
        }
        public LookupLegalServiceProviderDTOResponse LegalServiceProviderList(string userName, string tagName, int survivorCode)
        {
            LookupLegalServiceProviderDTOResponse lookupLegalServiceProviderDTOResponse = new LookupLegalServiceProviderDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Lookup_LegalServiceProvider_Admin", new { UserName = userName, TagName = tagName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupLegalServiceProviderDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupLegalServiceProviderDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        lookupLegalServiceProviderDTOResponse.LookupLegalServiceTypeDTOList = result.Read<LookupLegalServiceTypeDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupLegalServiceProviderDTOResponse.LookupLegalServiceProviderDTOList = result.Read<LookupLegalServiceProviderDTOList>().ToList();
                    }
                }
            }
            return lookupLegalServiceProviderDTOResponse;
        }
        public LookupLegalServiceProviderDTOResponse LegalServiceProviderList_PC(string userName, int survivorCode, int? pcCode)
        {
            LookupLegalServiceProviderDTOResponse lookupLegalServiceProviderDTOResponse = new LookupLegalServiceProviderDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Lookup_LegalServiceProvider_PC_Admin", new { UserName = userName, PcCode = pcCode, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupLegalServiceProviderDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupLegalServiceProviderDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        lookupLegalServiceProviderDTOResponse.LookupLegalServiceTypeDTOList = result.Read<LookupLegalServiceTypeDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupLegalServiceProviderDTOResponse.LookupLegalServiceProviderDTOList = result.Read<LookupLegalServiceProviderDTOList>().ToList();
                    }
                }
            }
            return lookupLegalServiceProviderDTOResponse;
        }
        public SurvivorLawyerLookupGetByTypeDTOResponse SurvivorLawyerGetByTypeList(string userName, int survivorCode, string typeName)
        {
            SurvivorLawyerLookupGetByTypeDTOResponse survivorLawyerLookupGetByTypeDTOResponse = new SurvivorLawyerLookupGetByTypeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SurvivorLawyer_Lookup_GetByType_Admin", new { UserName = userName, SurvivorCode = survivorCode, TypeName = typeName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorLawyerLookupGetByTypeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorLawyerLookupGetByTypeDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorLawyerLookupGetByTypeDTOResponse.SurvivorLawyerLookupGetByTypeDTOList = result.Read<SurvivorLawyerLookupGetByTypeDTOList>().ToList();
                    }
                }
            }
            return survivorLawyerLookupGetByTypeDTOResponse;
        }
        public SurvivorDTOHeaderResponse SurvivorDetail(string userName, int survivorCode)
        {
            SurvivorDTOHeaderResponse survivorDTOHeaderResponse = new SurvivorDTOHeaderResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_BasicDetailsGetByCode_Admin", new { UserName = userName, SurvivorCode = survivorCode, }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorDTOHeaderResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorDTOHeaderResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    survivorDTOHeaderResponse.SurvivorDTOHeader = result.Read<SurvivorDTOHeader>().FirstOrDefault();
                }
            }
            return survivorDTOHeaderResponse;
        }
        public LookupWhyPCDTOResponse WhyPcList(string userName)
        {
            LookupWhyPCDTOResponse lookupWhyPCDTOResponse = new LookupWhyPCDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Lookup_WhyPC_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupWhyPCDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupWhyPCDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        lookupWhyPCDTOResponse.ReferenceListDTO = result.Read<ReferenceListDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        lookupWhyPCDTOResponse.WhyPcDTOList = result.Read<WhyPCDTOList>().ToList();
                    }
                }
            }
            return lookupWhyPCDTOResponse;
        }

        public LookupLegalServiceTypeDTOResponse lookupLegalServiceType(string userName)
        {
            LookupLegalServiceTypeDTOResponse lookupLegalServiceTypeDTOResponse = new LookupLegalServiceTypeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Lookup_LegalServiceType_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lookupLegalServiceTypeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lookupLegalServiceTypeDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        lookupLegalServiceTypeDTOResponse.lookupLegalServiceTypes = result.Read<LookupLegalServiceType>().ToList();
                    }
                }
            }
            return lookupLegalServiceTypeDTOResponse;
        }

        public GetDepartmentDutyBearerResponse getDepartmentDutyBearer(string userName)
        {
            GetDepartmentDutyBearerResponse getDepartmentDutyBearer = new GetDepartmentDutyBearerResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("[CIT].[Department_List_Admin]", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed) 
                {
                    getDepartmentDutyBearer.dataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (getDepartmentDutyBearer.dataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        getDepartmentDutyBearer.getDepartmentByDimensions = result.Read<GetDepartmentByDimensionDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        getDepartmentDutyBearer.getDutyBearerByDepartments = result.Read<GetDutyBearerByDepartmentDTO>().ToList();
                    }
                }
            }
            return getDepartmentDutyBearer;
        }
    }
}