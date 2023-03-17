using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class EmailDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public EmailDTODetail EmailDTODetail { get; set; }

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
            status += $"EmailDTODetail Count:{EmailDTODetail}";
            return status;
        }
    }

    public class EmailDTODetail
    {
        public int EmailCode { get; set; }
        public int SenderMemberCode { get; set; }
        public string SenderName { get; set; }
        public int RecipientMemberCode { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public string Subject { get; set; }
        public int EmailTypeCode { get; set; }
        public string EmailType { get; set; }
        public bool HasAttachmentsValue { get; set; }
        public string HasAttachmentsText { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public bool IsSentValue { get; set; }
        public string IsSentText { get; set; }
        public DateTime? SentOn { get; set; }
        public string ExceptionDetails { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}