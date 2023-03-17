﻿using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvirorIncomeResponseChangeLog
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorIncomeChangeLogDTO> survivorIncomeChangeLogList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"Survivor Income Change Logs List Count:{this.survivorIncomeChangeLogList.Count}";
            return status;
        }
    }
    public class SurvivorIncomeChangeLogDTO
    {
        public int IncomeCode { get; set; }
        public int SurvivorCode { get; set; }
        public int ModeOfEarningCode { get; set; }
        public string ModeOfEarning { get; set; }
        public int Amount { get; set; }
        public int NatureOfWorkCode { get; set; }
        public string NatureOfWork { get; set; }
        public string IsAvailable { get; set; }
        public string IsDeleted { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
