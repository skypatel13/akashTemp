using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class VcBankDetailDTOAddDB
    {
        public int VCCode { get; set; }
        public int? AmountReceivedBank { get; set; }
        public DateTime? AmountReceivedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
