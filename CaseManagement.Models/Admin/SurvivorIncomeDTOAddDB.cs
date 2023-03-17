using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorIncomeDTOAddDB
    {
        public int SurvivorCode { get; set; }
        public int ModeOfEarningCode { get; set; }
        public int Amount { get; set; }
        public int NatureOfWorkCode { get; set; }
        public bool IsAvailable { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
