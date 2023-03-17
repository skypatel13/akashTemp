using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class DiaryActionsDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DiaryActionsDTOList> DiaryActionsDTOList { get; set; }
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
            status += $"DiaryActionsDTOList Count:{DiaryActionsDTOList.Count}";
            return status;
        }
    }
    public class DiaryActionsDTOList
    {
        public int DailyDiaryActionsId { get; set; }
        public int DailyDiaryId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
