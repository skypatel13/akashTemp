using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class PanchayatDTOAdd
    {
        public string Panchayat { get; set; }
        public int BlockCode { get; set; }
        public int DistrictCode { get; set; }
        public int StateCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
