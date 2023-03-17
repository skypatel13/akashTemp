using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class FirBasicDetailDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public FirBasicDetailDTO FirBasicDetailDTO { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"FirBasicDetailDTO :{this.FirBasicDetailDTO}";
            return status;
        }
    }
    public class FirBasicDetailDTO
    {
        public int FIRCode { get; set; }
        public int SurvivorCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public string PoliceStationName { get; set; }
        public int PoliceStationCode { get; set; }
        public string DeFactoComplainer { get; set; }
        public string Relation { get; set; }
        public string GDNumber { get; set; }
        public DateTime? GDDate { get; set; }
        public string GDIssue { get; set; }
        public string FIRNumber { get; set; }
        public DateTime FIRDate { get; set; }
        public string FIRIssue { get; set; }
        public string Notes { get; set; }
        public string Sections { get; set; }
        public string Traffickers { get; set; }
        public int StateCode { get; set; }
        public string State { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int RescuedStateCode { get; set; }
        public string RescuedState { get; set; }
        public int RescuedDistrictCode { get; set; }
        public string RescuedDistrict { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}