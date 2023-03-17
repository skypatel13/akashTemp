using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using static CaseManagement.UtilityLibrary.EnumType;
using static CaseManagement.UtilityLibrary.Utility;
namespace CaseManagement.API.Controllers.DailyDiary
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class DailyDiaryController : ControllerBase
    {
        private readonly IDiary diary;
        private readonly ILogger<DailyDiaryController> logger;
        private readonly IMapper mapper;
        public DailyDiaryController(IDiary diary, ILogger<DailyDiaryController> logger, IMapper mapper)
        {
            this.diary = diary;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = diary.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult FullCalendarList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = diary.CalendarList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{dailyDiaryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult RelatedSurvivorList(int? dailyDiaryId)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = diary.RelatedSurvivorList(userName, dailyDiaryId);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(DiaryDTOAdd diaryDTOAdd)
        {
            string userName = User.Identity.Name;
            DiaryDTOAddDB diaryDTOAddDB = mapper.Map<DiaryDTOAddDB>(diaryDTOAdd);
            diaryDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            diaryDTOAddDB.CreatedBy = userName;
            diaryDTOAddDB.PlanToCloseOn = diaryDTOAdd.PlanToCloseOn.ToLocalTime();
            diaryDTOAddDB.SurvivorData = Convert.ToInt32(RelatedTo.SURVIVOR) == diaryDTOAdd.RelatedToCode ? GetXMLString(diaryDTOAdd.DiarySurvivorMappingDTOAdd) : null;
            diaryDTOAddDB.StakeholderData = Convert.ToInt32(RelatedTo.OTHER) == diaryDTOAdd.RelatedToCode ? GetXMLString(diaryDTOAdd.DiaryStackeHoldeMappingDTOAdd) : null; ;
            diaryDTOAddDB.PlanToCloseOn = diaryDTOAddDB.PlanToCloseOn.ToLocalTime();
            logger.LogInformation($"|Request Argument:{diaryDTOAddDB}");
            var result = diary.Add(diaryDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(DiaryDTOEdit diaryDTOEdit)
        {
            string userName = User.Identity.Name;
            DiaryDTOEditDB diaryDTOEditDB = mapper.Map<DiaryDTOEditDB>(diaryDTOEdit);
            diaryDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            diaryDTOEditDB.ModifiedBy = userName;
            diaryDTOEditDB.PlanToCloseOn = diaryDTOEdit.PlanToCloseOn.ToLocalTime();
            diaryDTOEditDB.SurvivorData = Convert.ToInt32(RelatedTo.SURVIVOR) == diaryDTOEdit.RelatedToCode ? GetXMLString(diaryDTOEdit.DiarySurvivorMappingDTOAdd) : null;
            diaryDTOEditDB.StakeholderData = Convert.ToInt32(RelatedTo.OTHER) == diaryDTOEdit.RelatedToCode ? GetXMLString(diaryDTOEdit.DiaryStackeHoldeMappingDTOAdd) : null;
            diaryDTOEditDB.PlanToCloseOn = diaryDTOEditDB.PlanToCloseOn.ToLocalTime();
            logger.LogInformation($"|Request Argument:{diaryDTOEditDB}");
            var result = diary.Edit(diaryDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult StatusUpdate(DiaryDTOStatusUpdate diaryDTOStatusUpdate)
        {
            string userName = User.Identity.Name;
            DiaryDTOStatusUpdateDB diaryDTOStatusUpdateDB = mapper.Map<DiaryDTOStatusUpdateDB>(diaryDTOStatusUpdate);
            diaryDTOStatusUpdateDB.ModifiedByIpAddress = GetIPAddress(Request);
            diaryDTOStatusUpdateDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{diaryDTOStatusUpdateDB}");
            var result = diary.StatusUpdate(diaryDTOStatusUpdateDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ActionAdd(DiaryDTOActionAdd diaryDTOActionAdd)
        {
            string userName = User.Identity.Name;
            DiaryDTOActionAddDB diaryDTOActionAddDB = mapper.Map<DiaryDTOActionAddDB>(diaryDTOActionAdd);
            diaryDTOActionAddDB.CreatedByIpAddress = GetIPAddress(Request);
            diaryDTOActionAddDB.CreatedBy = userName;
            diaryDTOActionAddDB.ActionDate = diaryDTOActionAddDB.ActionDate.ToLocalTime();
            logger.LogInformation($"|Request Argument:{diaryDTOActionAddDB}");
            var result = diary.ActionAdd(diaryDTOActionAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{dailyDiaryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int dailyDiaryId)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},DailyDiaryId:{dailyDiaryId}");
            var result = diary.Detail(userName, dailyDiaryId);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{dailyDiaryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int dailyDiaryId)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"Request Daily Diary Delete User: {userName},IP:{iPAddress}, Argument:DailyDiaryId:{dailyDiaryId}");
            var result = diary.Delete(dailyDiaryId, userName, iPAddress);
            logger.LogInformation($"Request Daily Diary Delete Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{dailyDiaryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Actions(int dailyDiaryId)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = diary.Actions(userName, dailyDiaryId);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{dailyDiaryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int dailyDiaryId)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = diary.ChangeLog_GetById(userName, dailyDiaryId);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = diary.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Close(DiaryCloseDTOAdd diaryCloseDTOAdd)
        {
            string userName = User.Identity.Name;
            DiaryCloseDTOAddDB diaryCloseDTOAddDB = mapper.Map<DiaryCloseDTOAddDB>(diaryCloseDTOAdd);
            diaryCloseDTOAddDB.ClosedByIpAddress = GetIPAddress(Request);
            diaryCloseDTOAddDB.ClosedBy = userName;
            diaryCloseDTOAddDB.ClosedOn = diaryCloseDTOAddDB.ClosedOn.ToLocalTime();
            logger.LogInformation($"|Request Argument:{diaryCloseDTOAddDB}");
            var result = diary.Close(diaryCloseDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{dailyDiaryActionsId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ActionDelete(int dailyDiaryActionsId)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"Request Daily Diary Action Delete User: {userName},IP:{iPAddress}, Argument:DailyDiaryActionsId:{dailyDiaryActionsId}");
            var result = diary.ActionDelete(dailyDiaryActionsId, userName, iPAddress);
            logger.LogInformation($"Request Daily Diary Action Delete Result: {result}");
            return Ok(result);
        }
    }
}
