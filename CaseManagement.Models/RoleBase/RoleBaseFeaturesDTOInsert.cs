using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.RoleBase
{
    public class RoleBaseFeaturesDTOInsert
    {
        public string RoleId { get; set; }
        public List<RoleBaseFeatureAdminDTO> FeaturesData { get; set; }
        public List<RoleBaseActionAdminDTO> FeaturesActionData { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
