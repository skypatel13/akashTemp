using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTOCalendar
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? EndDate { get; set; }
        public int MemberCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
