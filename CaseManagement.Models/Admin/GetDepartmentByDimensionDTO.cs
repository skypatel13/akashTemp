using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{

    public class GetDepartmentDutyBearerResponse
    {
        public DataUpdateResponseDTO dataUpdateResponse { get; set; }
        public List<GetDepartmentByDimensionDTO> getDepartmentByDimensions { get; set; }
        public List<GetDutyBearerByDepartmentDTO> getDutyBearerByDepartments { get; set; }
        public override string ToString()
        {
            if (this.dataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = dataUpdateResponse.ToString();
            if (this.dataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Get Department By Dimensions:{this.getDepartmentByDimensions.Count}";
            status += $"Get Duty Bearer By Dimensions:{this.getDutyBearerByDepartments.Count}";
            return status;
        }
    }
    public class GetDepartmentByDimensionDTO
    {
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DimensionCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class GetDutyBearerByDepartmentDTO
    {
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int DutyBearerCode { get; set; }
        public string DutyBearer { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
