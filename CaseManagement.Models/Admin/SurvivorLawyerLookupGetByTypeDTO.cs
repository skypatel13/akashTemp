using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLawyerLookupGetByTypeDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorLawyerLookupGetByTypeDTOList> SurvivorLawyerLookupGetByTypeDTOList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"SurvivorLawyerLookupGetByTypeDTOList Count:{SurvivorLawyerLookupGetByTypeDTOList.Count}";
            return status;
        }
    }

    public class SurvivorLawyerLookupGetByTypeDTOList
    {
        public int SurvivorLawyerCode { get; set; }
        public int MemberCode { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public int MemberLawyerTypeCode { get; set; }
        public string SourceDestination { get; set; }
        public int SourceDestinationCode { get; set; }
        public string LeadingFor { get; set; }
        public string IsLeading { get; set; }
        public DateTime? LeadingFrom { get; set; }
        public DateTime? LeadingTo { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}