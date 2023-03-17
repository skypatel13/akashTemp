using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorProfileReportDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorBasicDetailsDTO SurvivorBasicDetailsDTO { get; set; }
        public RescueDetailsDTO RescueDetailsDTO { get; set; }
        public List<SHGDetailsDTO> ShgDetailsDTO { get; set; }
        public List<CollectiveDetailsDTO> CollectiveDetailsDTO { get; set; }
        public List<ShelterHomeDetailsDTO> ShelterHomeDetailsDTO { get; set; }
        public List<LawyerDetailsDTO> LawyerDetailsDTO { get; set; }
        public List<FIRDetailsDTO> FirDetailsDTO { get; set; }
        public List<InvestigationDetailsDTO> InvestigationDetailsDTO { get; set; }
        public List<VCDetailsDTO> VcDetailsDTO { get; set; }
        public List<PCDetailsDTO> PcDetailsDTO { get; set; }
        public List<CITReviewDetailsDTO> CitReviewDetailsDTO { get; set; }
        public List<CITDimensionDetailsDTO> CitDimensionDetailsDTO { get; set; }
        public List<CITObjectiveDTO> CitObjectiveDTO { get; set; }
        public List<CITActivitiesDTO> CitActivitiesDTO { get; set; }
        public LoanTotalRemainingDTO LoanTotalRemainingDTO { get; set; }
        public List<LoanDetailsDTO> LoanDetailsDTO { get; set; }
        public TotalIncomeDTO TotalIncomeDTO { get; set; }
        public List<IncomeDetailsDTO> IncomeDetailsDTO { get; set; }
        public List<SurvivorDocDetailsDTO> SurvivorDocDetailsDTO { get; set; }
        public List<ChargeSheetDetailsDTO> ChargeSheetDetailsDTO { get; set; }
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
            status += $"SurvivorBasicDetailsDTO List:{this.SurvivorBasicDetailsDTO}";
            status += $"RescueDetailsDTO List:{this.RescueDetailsDTO}";
            status += $"SHGDetailsDTO List:{this.ShgDetailsDTO.Count}";
            status += $"CollectiveDetailsDTO List:{this.CollectiveDetailsDTO.Count}";
            status += $"ShelterHomeDetailsDTO List:{this.ShelterHomeDetailsDTO.Count}";
            status += $"LawyerDetailsDTO List:{this.LawyerDetailsDTO.Count}";
            status += $"FIRDetailsDTO List:{this.FirDetailsDTO.Count}";
            status += $"InvestigationDetailsDTO List:{this.InvestigationDetailsDTO.Count}";
            status += $"VCDetailsDTO List:{this.VcDetailsDTO.Count}";
            status += $"PCDetailsDTO List:{this.PcDetailsDTO.Count}";
            status += $"CITReviewDetailsDTO List:{this.CitReviewDetailsDTO.Count}";
            status += $"CITDimensionDetailsDTO List:{this.CitDimensionDetailsDTO.Count}";
            status += $"CITObjectiveDTO List:{this.CitObjectiveDTO.Count}";
            status += $"CITActivitiesDTO List:{this.CitActivitiesDTO.Count}";
            status += $"LoanTotalRemainingDTO List:{this.LoanTotalRemainingDTO}";
            status += $"LoanDetailsDTO List:{this.LoanDetailsDTO.Count}";
            status += $"TotalIncomeDTO List:{this.TotalIncomeDTO}";
            status += $"IncomeDetailsDTO List:{this.IncomeDetailsDTO.Count}";
            status += $"SurvivorDocDetailsDTO List:{this.SurvivorDocDetailsDTO.Count}";
            status += $"ChargeSheetDetailsDTO List:{this.ChargeSheetDetailsDTO.Count}";
            return status;
        }
    }
    public class ChargeSheetDetailsDTO
    {
        public string SourceDestination { get; set; }
        public string FIRNumber { get; set; }
        public string InvestingAgencyType { get; set; }
        public string InvestingAgency { get; set; }
        public string InvestigatingOfficer { get; set; }
        public string OfficerRank { get; set; }
        public string ChargeSheetNumber { get; set; }
        public Nullable<DateTime> ChargeSheetDate { get; set; }
        public string TypeOfViolation { get; set; }
        public string Sections { get; set; }
        public string Traffickers { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorDocDetailsDTO
    {
        public string DocumentName { get; set; }
        public string FileName { get; set; }
        public string IsRequiredForSurvivor { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class IncomeDetailsDTO
    {
        public int IncomeCode { get; set; }
        public int SurvivorCode { get; set; }
        public string ModeOfEarning { get; set; }
        public int Amount { get; set; }
        public int NatureOfWorkCode { get; set; }
        public string NatureOfWork { get; set; }
        public string SurvivorName { get; set; }
        public string IsAvailable { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class TotalIncomeDTO
    {
        public string SurvivorName { get; set; }
        public int TotalIncome { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class LoanTotalRemainingDTO
    {
        public string SurvivorName { get; set; }
        public int TotalRemaining { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class LoanDetailsDTO
    {
        public string SurvivorName { get; set; }
        public string TakenFrom { get; set; }
        public string Purpose { get; set; }
        public int Amount { get; set; }
        public int AmountPaid { get; set; }
        public int RemainingAmount { get; set; }
        public decimal InterestRate { get; set; }
        public string ModeOfInterest { get; set; }
        public int RepaymentTenure { get; set; }
        public int RepaymentPerMonth { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> CompleteDate { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorBasicDetailsDTO
    {
        public Nullable<DateTime> BirthDate { get; set; }
        public Nullable<DateTime> TraffickingDate { get; set; }
        public int SurvivorCode { get; set; }
        public int Age { get; set; }
        public int AgeWhenTrafficked { get; set; }
        public int Children { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Panchayat { get; set; }
        public string Pincode { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string TafteeshStatus { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string PoliceStationName { get; set; }
        public int FamilyMembers { get; set; }
        public string PhotoStoredAsFileName { get; set; }
        public string ProfilePhoto { get; set; }
        public Nullable<DateTime> RescueDate { get; set; }
        public int AgeWhenRescue { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class RescueDetailsDTO
    {
        public Nullable<DateTime> RescueDate { get; set; }
        public int AgeWhenRescue { get; set; }
        public int DaysToRescue { get; set; }
        public string RescuedState { get; set; }
        public string RescuedDistrict { get; set; }
        public string RescuedCity { get; set; }
        public string RescuedBy { get; set; }
        public string TypeOfPlace { get; set; }
        public string RescuedPlace { get; set; }
        public string PoliceStationName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class SHGDetailsDTO
    {
        public string ShgName { get; set; }
        public string Organization { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class CollectiveDetailsDTO
    {
        public string CollectiveName { get; set; }
        public string Organization { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class ShelterHomeDetailsDTO
    {
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public int NumberOfDays { get; set; }
        public string SourceDestination { get; set; }
        public string ShelterHomeName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class LawyerDetailsDTO
    {
        public string LawyerType { get; set; }
        public string SourceDestination { get; set; }
        public string LeadingFor { get; set; }
        public string IsLeading { get; set; }
        public string MemberName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class FIRDetailsDTO
    {
        public Nullable<DateTime> FirDate { get; set; }
        public string SourceDestination { get; set; }
        public string FirNumber { get; set; }
        public string PoliceStationName { get; set; }
        public string DeFactoComplainer { get; set; }
        public string Sections { get; set; }
        public string Traffickers { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class InvestigationDetailsDTO
    {
        public string SourceDestination { get; set; }
        public string FirNumber { get; set; }
        public string InvestingAgencyType { get; set; }
        public string OfficerRank { get; set; }
        public string Result { get; set; }
        public string IsAccepted { get; set; }
        public string InvestingAgency { get; set; }
        public string InvestigatingOfficer { get; set; }
        public string AcceptanceReason { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class VCDetailsDTO
    {
        public Nullable<DateTime> ApplicationDate { get; set; }
        public Nullable<DateTime> OrderDate { get; set; }
        public Nullable<DateTime> AmountReceivedDate { get; set; }
        public int AmountClaimed { get; set; }
        public int AmountAwarded { get; set; }
        public int AmountDifference { get; set; }
        public string SourceDestination { get; set; }
        public string AmountReceivedBank { get; set; }
        public string Result { get; set; }
        public string IsEscalation { get; set; }
        public string AppliedAtFullName { get; set; }
        public int DaysAppDateToOrderDate { get; set; }
        public int DaysOrderDateToRecvDate { get; set; }
        public int DaysAppDateToRecvDate { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class PCDetailsDTO
    {
        public Nullable<DateTime> ApplicationDate { get; set; }
        public Nullable<DateTime> ResultDate { get; set; }
        public string SourceDestination { get; set; }
        public string ReferenceRecordType { get; set; }
        public string WhyPC { get; set; }
        public string Action { get; set; }
        public string Result { get; set; }
        public string IsEscalation { get; set; }
        public string AppliedAtFullName { get; set; }
        public int DaysAppDateToFiledDate { get; set; }
        public string FirNumber { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class CITReviewDetailsDTO
    {
        public Nullable<DateTime> CitDate { get; set; }
        public Nullable<DateTime> NextAssessmentDate { get; set; }
        public int Score { get; set; }
        public string IsApproved { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class CITDimensionDetailsDTO
    {
        public Nullable<DateTime> CitDate { get; set; }
        public int Score { get; set; }
        public string DimensionName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class CITObjectiveDTO
    {
        public Nullable<DateTime> CitDate { get; set; }
        public Nullable<DateTime> TargetedDate { get; set; }
        public string DimensionName { get; set; }
        public string Action { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class CITActivitiesDTO
    {
        public Nullable<DateTime> CitDate { get; set; }
        public Nullable<DateTime> TargetedDate { get; set; }
        public string DimensionName { get; set; }
        public string Activity { get; set; }
        public string Action { get; set; }
        public string DepartmentName { get; set; }
        public string DutyBearer { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
