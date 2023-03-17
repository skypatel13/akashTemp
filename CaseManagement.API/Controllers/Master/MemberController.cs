using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Reports;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace CaseManagement.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IMember member;
        private readonly IAlert alert;
        private readonly ILogger<MemberController> logger;
        private readonly IMapper mapper;

        public MemberController(IMember member, ILogger<MemberController> logger, IMapper mapper, IAlert alert)
        {
            this.member = member;
            this.logger = logger;
            this.mapper = mapper;
            this.alert = alert;
        }

        [HttpGet]
        [Route("{memberCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int memberCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},MemberCode:{memberCode}");
            var result = member.Detail(memberCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = member.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{memberCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int memberCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},MemberCode:{memberCode}");
            var result = member.ChangeLog_GetById(memberCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{memberCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int memberCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},MemberCode:{memberCode},");
            var result = member.Delete(memberCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(MemberDTOAdd memberDTOAdd)
        {
            string userName = User.Identity.Name;
            MemberDTOAddDB memberDTOAddDB = mapper.Map<MemberDTOAddDB>(memberDTOAdd);
            string dataXmlUserRole = Utility.GetXMLString(memberDTOAdd.MemberRoleLists);
            string dataXmlLawyer = Utility.GetXMLString(memberDTOAdd.MemberLawyerTypeDTOLists);
            memberDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            memberDTOAddDB.CreatedBy = userName;
            memberDTOAddDB.UserRole = dataXmlUserRole;
            memberDTOAddDB.LawyerType = memberDTOAdd.IsLawyer ? dataXmlLawyer : null;
            logger.LogInformation($"|Request Argument:{memberDTOAddDB}");
            var result = member.Add(memberDTOAddDB);
            //if (result.DataUpdateResponse.Status == true)
            //{
            //    Utility.SendEmail("skypatel13@gmail.com", "Test", "Testing akash");
            //}
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(MemberDTOEdit memberDTOEdit)
        {
            string userName = User.Identity.Name;
            MemberDTOEditDB memberDTOEditDB = mapper.Map<MemberDTOEditDB>(memberDTOEdit);
            string dataXmlUserRole = Utility.GetXMLString(memberDTOEdit.MemberRoleLists);
            string dataXmlLawyer = Utility.GetXMLString(memberDTOEdit.MemberLawyerTypeDTOLists);
            memberDTOEditDB.UserRole = dataXmlUserRole;
            memberDTOEditDB.LawyerType = memberDTOEdit.IsLawyer ? dataXmlLawyer : null;
            memberDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            memberDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{memberDTOEditDB}");
            var result = member.Edit(memberDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = member.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult MemberLawyerList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = member.MemberLawyerList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{memberId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult MemberSurvivorList(string memberId)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},MemberId:{memberId}");
            var result = member.MemberSurvivorList(userName, memberId);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult MemberSurviviorAdd(MemberSurvivorDTOAdd memberSurvivorDTOAdd)
        {
            string userName = User.Identity.Name;
            MemberSurvivorDTOAddDB memberSurvivorDTOAddDB = mapper.Map<MemberSurvivorDTOAddDB>(memberSurvivorDTOAdd);
            string dataXmlSurvivor = Utility.GetXMLString(memberSurvivorDTOAdd.MemberSurvivorMappingDTOList);
            string dataXmlOrganization = Utility.GetXMLString(memberSurvivorDTOAdd.memberSurvivorMappingOrganizationDTOList);
            memberSurvivorDTOAddDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            memberSurvivorDTOAddDB.ModifiedBy = userName;
            // 1 For Selected Survivor Data
            memberSurvivorDTOAddDB.SurvivorData = memberSurvivorDTOAdd.DataAccessRuleCode == 1 ? dataXmlSurvivor : null;
            memberSurvivorDTOAddDB.OrganizationData = memberSurvivorDTOAdd.DataAccessRuleCode == 4 ? dataXmlOrganization : null;
            logger.LogInformation($"|Request Argument:{memberSurvivorDTOAddDB}");
            var result = member.MemberSurviviorAdd(memberSurvivorDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{memberDataAccessCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult MemberSurvivorChangeLogGetById(int memberDataAccessCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},MemberDataAccessCode:{memberDataAccessCode}");
            var result = member.MemberSurvivorChangeLog_GetById(userName, memberDataAccessCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{memberCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SendMemberCredMail(int memberCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},Member Code:{memberCode}");
            StringBuilder strSubject = new StringBuilder();
            strSubject.Append("Details to access Tafteesh MIS user credential");
            EmailDTOAdd emailDTOAdd = new EmailDTOAdd
            {
                RecipientMemberCode = memberCode,
                EmailTypeCode = Convert.ToInt16(EnumType.EmailType.SEND_CREDENTIAL),
                Subject = strSubject.ToString(),
                Body = null,
                SenderIpAddress = iPAddress,
                SenderUserName = userName
            };
            var emailAddResult = alert.EmailAdd(emailDTOAdd);
            logger.LogInformation($"|Email Add Response: {emailAddResult}");

            if (!emailAddResult.DataUpdateResponse.Status)
            {
                return Ok(emailAddResult.DataUpdateResponse);
            }
            var memberCredentialResult = member.MemberCredential_GetByCode_ForEmail(memberCode, userName);
            if(!memberCredentialResult.DataUpdateResponse.Status)
            {
                return Ok(memberCredentialResult.DataUpdateResponse);
            }
           
            string str = "Hello,\n\n Here is a credential to access Tafteesh MIS.\n\nUsername:" + memberCredentialResult.MemberCredentialDTODetail.Email + " \nPassword:" + memberCredentialResult.MemberCredentialDTODetail.PasswordHash + " \n\n\nThanks,\nTafteesh MIS";
            var result = Utility.SendEmail(memberCredentialResult.MemberCredentialDTODetail.Email, Convert.ToString(strSubject), str);
            logger.LogInformation($"|Send Mail Result: {result}");
            EmailUpdateResponseDTO emailUpdateResponseDTO = new EmailUpdateResponseDTO
            {
                EmailCode = emailAddResult.EmailDTODetail.EmailCode,
                IsSent = result.Status,
                ExceptionDetails = result.Status ? null : result.Description,
                UserName = userName
            };
            var isEmailSent = alert.EmailUpdateIsReceived(emailUpdateResponseDTO);
            logger.LogInformation($"|IsEmailSent: {isEmailSent}");
            return Ok(result);
        }
    }
}