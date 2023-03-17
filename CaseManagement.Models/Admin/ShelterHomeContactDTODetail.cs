﻿using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeContactDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public ShelterHomeContactDTODetail ShelterHomeContactDTODetail { get; set; }

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
            status += $"ShelterHomeContactDTODetail :{this.ShelterHomeContactDTODetail}";
            return status;
        }
    }

    public class ShelterHomeContactDTODetail
    {
        public int ShelterHomeContactCode { get; set; }
        public int ShelterHomeCode { get; set; }
        public string ShelterHomeName { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}