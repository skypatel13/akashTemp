using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDTOHeaderResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorDTOHeader SurvivorDTOHeader { get; set; }

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
            status += $"SurvivorDTOHeader :{this.SurvivorDTOHeader}";
            return status;
        }
    }
    public class SurvivorDTOHeader
    {
        public int SurvivorCode { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TafteeshStatus { get; set; }
        public string Rescue { get; set; }
        public string Vc { get; set; }
        public string Pc { get; set; }
        public int MonthsSinceTrafficked { get; set; }
        public int MonthsSinceRescued { get; set; }
        public DateTime TraffickingDate { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}