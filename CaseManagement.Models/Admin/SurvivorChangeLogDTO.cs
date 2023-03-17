using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorChangeLogDTOList> SurvivorChangeLogDTOList { get; set; }
        public List<SurvivorSHGChangeLogDTOList> SurvivorSHGChangeLogDTOList { get; set; }
        public List<SurvivorCollectiveChangeLogDTOList> SurvivorCollectiveChangeLogDTOList { get; set; }
        public List<TafteeshStatusChangeLogDTOList> TafteeshStatusChangeLogDTOList { get; set; }

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
            status += $"SurvivorChangeLogDTOList Count:{this.SurvivorChangeLogDTOList.Count};";
            status += $"SurvivorCollectiveChangeLogDTOList Count:{this.SurvivorCollectiveChangeLogDTOList.Count};";
            status += $"SurvivorSHGChangeLogDTOList Count:{this.SurvivorSHGChangeLogDTOList.Count};";
            status += $"TafteeshStatusChangeLogDTOList Count:{this.TafteeshStatusChangeLogDTOList.Count};";
            return status;
        }
    }

    public class SurvivorChangeLogDTOList
    {
        public int SurvivorCode { get; set; }
        public string Name { get; set; }
        public string AliasNames { get; set; }
        public int GenderCode { get; set; }
        public string Gender { get; set; }
        public int MaritalStatusCode { get; set; }
        public string MaritalStatus { get; set; }
        public int Children { get; set; }
        public string Address1 { get; set; }
        public string State { get; set; }
        public int StateCode { get; set; }
        public string District { get; set; }
        public int DistrictCode { get; set; }
        public string Block { get; set; }
        public int BlockCode { get; set; }
        public int VillageCode { get; set; }
        public string Village { get; set; }
        public int PanchayatCode { get; set; }
        public string Panchayat { get; set; }
        public string Pincode { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime TraffickingDate { get; set; }
        public int AgeWhenTrafficked { get; set; }
        public int PoliceStationCode { get; set; }
        public string PoliceStationName { get; set; }
        public int TafteeshStatusCode { get; set; }
        public string TafteeshStatus { get; set; }
        //public string TafteeshStatusNotes { get; set; }
        public int SurvivorTypeCode { get; set; }
        public string SurvivorType { get; set; }
        //public DateTime? SubmittedForApprovalOn { get; set; }
        //public DateTime? ProfileApprovalOn { get; set; }
        //public string ProfileApprovalBy { get; set; }
        //public string ProfileApprovalByIpAddress { get; set; }
        //public string ProfileApprovalNotes { get; set; }
        public int TafteeshStatusLogCode { get; set; }
        public string TafteeshStatusLog { get; set; }
        public string Photo { get; set; }
        public string PhotoStoredAsFileName { get; set; }
        public string ConsentForm { get; set; }
        public string ConsentFormStoredAsFileName { get; set; }
        public string Notes { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public int FamilyMembers { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
       
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class TafteeshStatusChangeLogDTOList
    {
        public int SurvivorStatusLogCode { get; set; }
        public int SurvivorCode { get; set; }
        public int TafteeshStatusLogCode { get; set; }
        public string TafteeshStatusLog { get; set; }
        public string TafteeshStatusNotes { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string RecordMode { get; set; }
    }
}