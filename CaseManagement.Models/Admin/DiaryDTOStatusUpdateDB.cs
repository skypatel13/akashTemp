using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTOStatusUpdateDB
    {
        public int DailyDiaryId { get; set; }
        public int StatusCode { get; set; }
        public string Result { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
