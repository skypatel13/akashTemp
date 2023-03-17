using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class MemberSurvivorDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public MemberSurvivorDTOLHeader MemberSurvivorDTOLHeader { get; set; }
        public List<MemberSurvivorDTOList> MemberSurvivorDTOList { get; set; }
        public List<MemberOrganizationDTOList> MemberOrganizationDTOList { get; set; }

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
            status += $"MemberSurvivorDTOLHeader:{MemberSurvivorDTOLHeader}";
            status += $"MemberSurvivorDTOList Count:{MemberSurvivorDTOList.Count}";
            return status;
        }
    }

    public class MemberSurvivorDTOLHeader
    {
        public int MemberCode { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public int DataAccessRuleCode { get; set; }
        public int MemberDataAccessCode { get; set; }
        public string AccessRule { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class MemberSurvivorDTOList
    {
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class MemberOrganizationDTOList
    {
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string PartnerName { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public bool IsSelected { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}