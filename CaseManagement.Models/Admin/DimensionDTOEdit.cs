using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class DimensionDTOEdit
    {
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public string Notes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
