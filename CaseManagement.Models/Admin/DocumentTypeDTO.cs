using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DocumentTypeDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DocumentTypeDTOList> DocumentTypDTOList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"DocumentTypDTO List:{this.DocumentTypDTOList.Count}";
            return status;
        }
    }

    public class DocumentTypeDTOList
    {
        public int DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public string IsRequiredForSurvivor { get; set; }
        public string IsSurvivorSpecific { get; set; }
        public string DocumentReference { get; set; }
        public string IsDeleted { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}