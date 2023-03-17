using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class EmailDTOAdd
    {
        public int RecipientMemberCode { get; set; }
        public int EmailTypeCode { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderUserName { get; set; }
        public string SenderIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}