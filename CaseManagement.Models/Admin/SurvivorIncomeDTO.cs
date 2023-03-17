using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvirorIncomeResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorTotalIncome survivorTotalIncome { get; set; }
        public List<SurvivorIncomeDTO> survivorIncomeList { get; set; }

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
            status += $"Survivor Total Income:{this.survivorTotalIncome}";
            status += $"Survivor Income List Count:{this.survivorIncomeList.Count}";
            return status;
        }
    }
    public class SurvivorTotalIncome
    {
        public int? TotalIncome { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorIncomeDTO
    {
        public int IncomeCode { get; set; }
        public int SurvivorCode { get; set; }
        public int ModeOfEarningCode { get; set; }
        public string ModeOfEarning { get; set; }
        public int? Amount { get; set; }
        public int NatureOfWorkCode { get; set; }
        public string NatureOfWork { get; set; }
        public string IsAvailable { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
