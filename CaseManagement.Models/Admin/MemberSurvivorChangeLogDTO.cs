using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class MemberSurvivorChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<MemberSurvivorChangeLogDTOList> MemberSurvivorChangeLogDTOList { get; set; }
        public List<MemberDataAccessChangeLogDTOList> MemberDataAccessChangeLogDTOList { get; set; }

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
            status += $"MemberSurvivorChangeLogDTOList Count:{MemberSurvivorChangeLogDTOList.Count}";
            
                status += $"MemberDataAccessChangeLogDTOList Count:{MemberDataAccessChangeLogDTOList.Count}";
       
            return status;
        }
    }

    public class MemberSurvivorChangeLogDTOList
    {
        public int MemberDataAccessCode { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string Category { get; set; }
        public string IsTMCMember { get; set; }
        public int DataAccessRuleCode { get; set; }
        public string AccessRule { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class MemberDataAccessChangeLogDTOList
    {
        public int MemberSurvivorCode { get; set; }
        public int MemberDataAccessCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string Gender { get; set; }
        public bool IsOwner { get; set; }
        public string RecordMode { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}