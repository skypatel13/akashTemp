using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class FirActSectionRequestDTO
    {
        public int FIRCode { get; set; }
        public bool IsAddedLater { get; set; }
        public DateTime AddedOn { get; set; }
        public List<FirActSectionMappingDTOList> FirActSectionMappingDTOList { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}