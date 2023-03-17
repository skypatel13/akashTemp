using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Cit
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IDimensionQuestion dimensionQuestion;
        private readonly ILogger<QuestionController> logger;
        private readonly IMapper mapper;
        public QuestionController(IDimensionQuestion question, ILogger<QuestionController> logger, IMapper mapper)
        {
            this.dimensionQuestion = question;
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
            var result = dimensionQuestion.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(DimensionQuestionDTOAdd questionDTOAdd)
        {
            string userName = User.Identity.Name;
            string dataXmlOptionData = string.Empty;
            if (questionDTOAdd.QuestionUIControlTypeCode == 1)
                dataXmlOptionData = Utility.GetXMLString(questionDTOAdd.OptionDataMappingListDTO);
            DimensionQuestionDTOAddDB questionDTOAddDB = mapper.Map<DimensionQuestionDTOAddDB>(questionDTOAdd);
            questionDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            questionDTOAddDB.CreatedBy = userName;
            questionDTOAddDB.OptionData = dataXmlOptionData;
            logger.LogInformation($"|Request Argument:{questionDTOAddDB}, Count: {questionDTOAdd.OptionDataMappingListDTO?.Count}");
            var result = dimensionQuestion.Add(questionDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(DimensionQuestionDTOEdit questionDTOEdit)
        {
            string userName = User.Identity.Name;
            string dataXmlOptionData = string.Empty;
            if (questionDTOEdit.QuestionUIControlTypeCode == 1)
                dataXmlOptionData = Utility.GetXMLString(questionDTOEdit.OptionDataMappingListDTO);
            DimensionQuestionDTOEditDB questionDTOEditDB = mapper.Map<DimensionQuestionDTOEditDB>(questionDTOEdit);
            questionDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            questionDTOEditDB.ModifiedBy = userName;
            questionDTOEditDB.OptionData = dataXmlOptionData;
            logger.LogInformation($"|Request Argument:{questionDTOEditDB}, Count: {questionDTOEdit.OptionDataMappingListDTO?.Count}");
            var result = dimensionQuestion.Edit(questionDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{dimensionQuestionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int dimensionQuestionCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName}, IP:{iPAddress}, DimensionQuestionCode:{dimensionQuestionCode}");
            var result = dimensionQuestion.Delete(dimensionQuestionCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{dimensionQuestionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int dimensionQuestionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},DimensionQuestionCode:{dimensionQuestionCode}");
            var result = dimensionQuestion.Detail(dimensionQuestionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{dimensionQuestionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int dimensionQuestionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},DimensionQuestionCode:{dimensionQuestionCode}");
            var result = dimensionQuestion.ChangeLog_GetById(dimensionQuestionCode, userName);
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
            var result = dimensionQuestion.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}