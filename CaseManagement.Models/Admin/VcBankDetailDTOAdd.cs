using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class VCBankDetailDTOAdd
    {
        public int VCCode { get; set; }
        public int? AmountReceivedBank { get; set; }
        public Nullable<DateTime> AmountReceivedDate { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
