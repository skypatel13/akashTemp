using CaseManagement.Models.Common;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LookupWhyPCDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ReferenceListDTO> ReferenceListDTO { get; set; }
        public List<WhyPCDTOList> WhyPcDTOList { get; set; }
    }

    public class ReferenceListDTO
    {
        public int PCReferenceCode { get; set; }
        public string PCReference { get; set; }
    }

    public class WhyPCDTOList
    {
        public int WhyPCCode { get; set; }
        public string WhyPC { get; set; }
        public string Action { get; set; }
        public int PCReferenceCode { get; set; }
        public string PCReference { get; set; }
    }
}