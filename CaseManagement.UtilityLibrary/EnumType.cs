namespace CaseManagement.UtilityLibrary
{
    public static class EnumType
    {
        public enum DocumentType
        {
            PCAPPLICATION = 5, //For PCApplication,
            PCORDER = 6 // For PcOrder
        }
        public enum RelatedTo
        {
            SURVIVOR = 1,
            OTHER = 2
        }
        public enum MonthlyReportLabelType
        {
            TOTAL_SURVIVOR = 1,
            VC_APPLIED_OVERALL = 2,
            VCAPPLIEDCOUNT = 3,
            VCCONCLUDEDCOUNT = 4,
            VCAWARDEDCOUNT = 5,
            VCREJECTEDCOUNT = 6,
            VCESCLATIONCOUNT = 7,
            ESCALATIONCONCLUDEDCOUNT = 8,
            ESCALATIONAWARDEDCOUNT = 9,
            ESCALATIONREJECTEDCOUNT = 10,
            COMPENSATIONS_AWARDED_EQUAL = 11,
            COMPENSATIONS_AWARDED_LESS = 12
        }
        public enum EmailType
        {
            SEND_CREDENTIAL = 1,
            ALERT_MESSAGE = 2
        }
    }
}