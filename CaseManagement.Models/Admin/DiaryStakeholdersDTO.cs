using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DiaryStakeholdersDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DiaryStakeholdersDTOList> DiaryStakeholdersDTOList { get; set; }

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
            status += $"DiaryStakeholdersDTOList Count:{DiaryStakeholdersDTOList?.Count}";
            return status;
        }
    }

    public class DiaryStakeholdersDTOList
    {
        public int DailyDiaryStakeholdersId { get; set; }
        public int StakeholderTypeCode { get; set; }
        public int DailyDiaryId { get; set; }
        public string StakeholderType { get; set; }
        public string StakeholderName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}