using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SurvivorCitController : ControllerBase
    {
        private readonly ISurvivorCit survivorCit;
        private readonly ILogger<SurvivorCitController> logger;
        private readonly IMapper mapper;
        public SurvivorCitController(ISurvivorCit survivorCit, ILogger<SurvivorCitController> logger, IMapper mapper)
        {
            this.survivorCit = survivorCit;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List(int survivorCode)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} SurvivorCode:{survivorCode}");
            var result = survivorCit.List(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(SurvivorCitAssessmentDTOAdd survivorCitAssessmentDTOAdd)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument  User:{userName} Survivor CIT Assessment Add:{survivorCitAssessmentDTOAdd}");
            SurvivorCitAssessmentDTOAddDB survivorCitAssessmentDTOAddDB = mapper.Map<SurvivorCitAssessmentDTOAddDB>(survivorCitAssessmentDTOAdd);
            survivorCitAssessmentDTOAddDB.CreatedBy = userName;
            survivorCitAssessmentDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            survivorCitAssessmentDTOAddDB.citDate = survivorCitAssessmentDTOAdd.citDate.ToLocalTime();
            var result = survivorCit.Add(survivorCitAssessmentDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AddAnswer(SurvivorCitAnswerAdd survivorCitAnswerAdd)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} Survivor CIT Answer Add:{survivorCitAnswerAdd}");
            SurvivorCitAnswerAddDB survivorCitAnswerAddDB = mapper.Map<SurvivorCitAnswerAddDB>(survivorCitAnswerAdd);
            survivorCitAnswerAddDB.CreatedBy = userName;
            survivorCitAnswerAddDB.CreatedByIpAddress = GetIPAddress(Request);
            var result = survivorCit.AddAnswer(survivorCitAnswerAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Assessment_Submit(SurvivorCitAssessmentSubmitDTO survivorCitAssessmentSubmitDTO)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} Survivor CIT Assessment Submit :{survivorCitAssessmentSubmitDTO}");
            SurvivorCitAssessmentSubmitDTODB survivorCitAssessmentSubmitDTODB = mapper.Map<SurvivorCitAssessmentSubmitDTODB>(survivorCitAssessmentSubmitDTO);
            survivorCitAssessmentSubmitDTODB.CreatedBy = userName;
            survivorCitAssessmentSubmitDTODB.CreatedByIpAddress = GetIPAddress(Request);
            var result = survivorCit.AssessmentSubmit(survivorCitAssessmentSubmitDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{surAsmtCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ActionList(int surAsmtCode)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} SurAsmtCode:{surAsmtCode}");
            var result = survivorCit.CitActionList(surAsmtCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AddAction(SurvivorCitAssessmentActionDTOAdd survivorCitAssessmentActionDTOAdd)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} Survivor CIT Assessment Action Add :{survivorCitAssessmentActionDTOAdd}");
            SurvivorCitAssessmentActionDTOAddDB survivorCitAssessmentActionDTOAddDB = mapper.Map<SurvivorCitAssessmentActionDTOAddDB>(survivorCitAssessmentActionDTOAdd);
            survivorCitAssessmentActionDTOAddDB.CreatedBy = userName;
            survivorCitAssessmentActionDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            survivorCitAssessmentActionDTOAddDB.TargetedDate = survivorCitAssessmentActionDTOAdd.TargetedDate.ToLocalTime();
            var result = survivorCit.AddAction(survivorCitAssessmentActionDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult EditAction(SurvivorCitAssessmentActionDTOEdit survivorCitAssessmentActionDTOEdit)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} Survivor CIT Assessment Action Edit :{survivorCitAssessmentActionDTOEdit}");
            SurvivorCitAssessmentActionDTOEditDB survivorCitAssessmentActionDTOEditDB = mapper.Map<SurvivorCitAssessmentActionDTOEditDB>(survivorCitAssessmentActionDTOEdit);
            survivorCitAssessmentActionDTOEditDB.ModifiedBy = userName;
            survivorCitAssessmentActionDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            survivorCitAssessmentActionDTOEditDB.TargetedDate = survivorCitAssessmentActionDTOEdit.TargetedDate.ToLocalTime();
            var result = survivorCit.EditAction(survivorCitAssessmentActionDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{surAsmtActCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DetailAction(int surAsmtActCode)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument SurAsmtActCode :{surAsmtActCode} User:{userName}");
            var result = survivorCit.DetailAction(surAsmtActCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{surAsmtActCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteAction(int surAsmtActCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = survivorCit.DeleteAction(surAsmtActCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateDimensionScore(SurvivorCitDimensionScoreEdit survivorCitDimensionScoreEdit)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument  User:{userName} Survivor CIT Dimension Score Edit:{survivorCitDimensionScoreEdit}");
            SurvivorCitDimensionScoreEditDB survivorCitDimensionScoreEditDB = mapper.Map<SurvivorCitDimensionScoreEditDB>(survivorCitDimensionScoreEdit);
            survivorCitDimensionScoreEditDB.CreatedBy = userName;
            survivorCitDimensionScoreEditDB.CreatedByIpAddress = GetIPAddress(Request);
            var result = survivorCit.UpdateDimensionScore(survivorCitDimensionScoreEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{surAsmtCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int surAsmtCode)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument SurAsmtCode :{surAsmtCode} User:{userName}");
            var result = survivorCit.Detail(surAsmtCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{surAsmtCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int surAsmtCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = survivorCit.Delete(surAsmtCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SubActivityAdd(SurvivorCitSubActionDTOAdd survivorCitSubActionDTOAdd)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument  User:{userName} Survivor CIT SubAction :{survivorCitSubActionDTOAdd}");
            SurvivorCitSubActionAddDTODB survivorCitSubActionAddDTODB = mapper.Map<SurvivorCitSubActionAddDTODB>(survivorCitSubActionDTOAdd);
            survivorCitSubActionAddDTODB.CreatedBy = userName;
            survivorCitSubActionAddDTODB.CreatedByIpAddress = GetIPAddress(Request);
            var result = survivorCit.SubActionAdd(survivorCitSubActionAddDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{surAsmtSubActCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SubActivityDelete(int surAsmtSubActCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = survivorCit.SubActionDelete(surAsmtSubActCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CITStatus_Insert(CitStatusRequestDTO citStatusRequestDTO)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            CitStatusRequestDTODB citStatusRequestDTODB = mapper.Map<CitStatusRequestDTODB>(citStatusRequestDTO);
            citStatusRequestDTODB.CreatedBy = userName;
            citStatusRequestDTODB.CreatedByIpAddress = iPAddress;
            logger.LogInformation($"|Request Argument:{citStatusRequestDTODB}");
            var result = survivorCit.SurvivorCITStatus_Insert_Admin(citStatusRequestDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CITStatus_Update(CitStatusResponseDTO citStatusResponseDTO)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            CitStatusResponseDTODB citStatusResponseDTODB = mapper.Map<CitStatusResponseDTODB>(citStatusResponseDTO);
            citStatusResponseDTODB.CreatedBy = userName;
            citStatusResponseDTODB.CreatedByIpAddress = iPAddress;
            logger.LogInformation($"|Request Argument:{citStatusResponseDTODB}");
            var result = survivorCit.SurvivorCITStatus_Update_Admin(citStatusResponseDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{surAsmtCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CITStatus_List(int surAsmtCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{surAsmtCode}");
            var result = survivorCit.SurvivorCITStatus_ListByCode(surAsmtCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Section11_Submit(SurvivorCitSection11SubmitDTO survivorCitSection11SubmitDTO)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName},Data: {survivorCitSection11SubmitDTO}");
            SurvivorCitSection11SubmitDTODB survivorCitSection11SubmitDTODB = mapper.Map<SurvivorCitSection11SubmitDTODB>(survivorCitSection11SubmitDTO);
            survivorCitSection11SubmitDTODB.ModifiedBy = userName;
            survivorCitSection11SubmitDTODB.ModifiedByIpAddress = GetIPAddress(Request);
            var result = survivorCit.Section11Submit(survivorCitSection11SubmitDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeptDutyBearerAdd(CitDeptDutyBearerAddDTO citDeptDutyBearerAddDTO)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName},Data: {citDeptDutyBearerAddDTO}");
            CitDeptDutyBearerAddDTODB citDeptDutyBearerAddDTODB = mapper.Map<CitDeptDutyBearerAddDTODB>(citDeptDutyBearerAddDTO);
            citDeptDutyBearerAddDTODB.CitDeptDutyBearerMappingData = GetXMLString(citDeptDutyBearerAddDTO.CitDeptDutyBearerMappingData);
            citDeptDutyBearerAddDTODB.CreatedBy = userName;
            citDeptDutyBearerAddDTODB.CreatedByIpAddress = GetIPAddress(Request);
            var result = survivorCit.DeptDutyBearerAdd(citDeptDutyBearerAddDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{surAsmtActCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SubActionList(int surAsmtActCode)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} SurAsmtCode:{surAsmtActCode}");
            var result = survivorCit.CitSubActionList(surAsmtActCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{surAsmtCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PlanDimensionList(int surAsmtCode)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} SurAsmtCode:{surAsmtCode}");
            var result = survivorCit.CitPlanDimensionList(surAsmtCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PlannedDimensionAdd(CitPlannedDimensionAddDTO citPlannedDimensionAddDTO)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName},Data: {citPlannedDimensionAddDTO}");
            CitPlannedDimensionAddDTODB citPlannedDimensionAddDTODB = mapper.Map<CitPlannedDimensionAddDTODB>(citPlannedDimensionAddDTO);
            citPlannedDimensionAddDTODB.SurvivorCitPlannedDimDTOAdd = GetXMLString(citPlannedDimensionAddDTO.SurvivorCitPlannedDimDTOAdd);
            citPlannedDimensionAddDTODB.CreatedBy = userName;
            citPlannedDimensionAddDTODB.CreatedByIpAddress = GetIPAddress(Request);
            var result = survivorCit.CitPlannedDimensionAdd(citPlannedDimensionAddDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CITObservation_Update(CitObservationUpdateDTO citObservationUpdateDTO)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            CitObservationUpdateDTODB citObservationUpdateDTODB = mapper.Map<CitObservationUpdateDTODB>(citObservationUpdateDTO);
            citObservationUpdateDTODB.ModifiedBy = userName;
            citObservationUpdateDTODB.ModifiedByIpAddress = iPAddress;
            logger.LogInformation($"|Request Argument:{citObservationUpdateDTODB}");
            var result = survivorCit.SurvivorCITObservation_Update_Admin(citObservationUpdateDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult StarReport_GetByCode(int survivorCode)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} SurvivorCode:{survivorCode}");
            var result = survivorCit.Star_Report_GetByCode(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList(int survivorCode)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} SurvivorCode:{survivorCode}");
            var result = survivorCit.DeletedList(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{SurAsmtCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int surAsmtCode)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request Argument User:{userName} SurAsmtCode:{surAsmtCode}");
            var result = survivorCit.ChangeLog_GetById(surAsmtCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
