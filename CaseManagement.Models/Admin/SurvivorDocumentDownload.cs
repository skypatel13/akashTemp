using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public enum DocumentTypes
    {
        Passport = 1,
        PANCard = 2,
        RationCard = 3,
        VoterID = 4,
        DrivingLicense = 5,
        Aadhaar = 6,
        BirthCertificate = 7,
        SchoolLeavingCertificate = 8,
        Consentform = 9,
        GDCopy = 11,
        FIRCopy = 12,
        VCApplication = 13,
        VCOrder = 14,
        PCApplication = 15,
        PCOrder = 16,
        Statement161 = 17,
        Statement164 = 18,
        HSRReport = 19,
        MedicalReport = 20,
        Photo = 21,
        ChargeSheet= 30
    }
    public class SurvivorDocumentDownload
    {
        public int SurvivorCode { get; set; }
        public int DocumentCode { get; set; }
        public bool IsSurvivorSpecificValue { get; set; }
        public string FileName { get; set; }
        public string StoredAsFileName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
