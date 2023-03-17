using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class TraffickerStatusDTOAdd
    {
        public int TraffickerCode { get; set; }
        public int StatusCode { get; set; }
        public DateTime? StatusDate { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
