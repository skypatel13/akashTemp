using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorIncomeDTOEdit
    {
        public int IncomeCode { get; set; }
        public int ModeOfEarningCode { get; set; }
        public int Amount { get; set; }
        public int NatureOfWorkCode { get; set; }
        public bool IsAvailable { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
