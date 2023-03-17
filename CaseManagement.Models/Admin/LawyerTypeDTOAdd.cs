using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace CaseManagement.Models.Admin
{
    public class LawyerTypeDTOAdd
    {
        public string LawyerType { get; set; }
        public string Notes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
