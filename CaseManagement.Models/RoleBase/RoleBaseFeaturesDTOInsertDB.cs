using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.RoleBase
{
    public class RoleBaseFeaturesDTOInsertDB
    {
        public string RoleId { get; set; }
        public string FeaturesData { get; set; }
        public string FeaturesActionData { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
