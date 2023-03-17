using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaseManagement.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentType documentType;
        private readonly ILogger<DocumentTypeController> logger;
        private readonly IMapper mapper;

        public DocumentTypeController(IDocumentType documentType, ILogger<DocumentTypeController> logger, IMapper mapper)
        {
            this.documentType = documentType;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Document Type List User: {userName},IP:{iPAddress}");
            var result = documentType.List(userName);
            logger.LogInformation($"Result  Document Type : {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(DocumentTypeDTOAdd documentTypeDTOAdd)
        {
            string userName = User.Identity.Name;
            DocumentTypeDTOAddDB documentTypeDTOAddDB = mapper.Map<DocumentTypeDTOAddDB>(documentTypeDTOAdd);
            documentTypeDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            documentTypeDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request Collective Add Argument:{documentTypeDTOAddDB}");
            var result = documentType.Add(documentTypeDTOAddDB);
            logger.LogInformation($"Result Collective Add {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(DocumentTypeDTOEdit documentTypeDTOEdit)
        {
            string userName = User.Identity.Name;
            DocumentTypeDTOEditDB documentTypeDTOEditDB = mapper.Map<DocumentTypeDTOEditDB>(documentTypeDTOEdit);
            documentTypeDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            documentTypeDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request Collective Edit Argument:{documentTypeDTOEditDB}");
            var result = documentType.Edit(documentTypeDTOEditDB);
            logger.LogInformation($"Result Collective Edit {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{documentCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int documentCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request DocumentType Detail User: {userName},IP:{iPAddress}, Argument:documentCode:{documentCode}");
            var result = documentType.Detail(documentCode, userName);
            logger.LogInformation($"Result DocumentType Detail: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{documentCode:int}")]
        public IActionResult Delete(int documentCode)
        {
            string userName = User.Identity.Name;
            string ip = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request DocumentType Delete User:{userName},documentCode:{documentCode},IP:{ip}");
            var result = documentType.Delete(documentCode, userName, Utility.GetIPAddress(Request));
            logger.LogInformation($"Result DocumentType Delete {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{documentCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int documentCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request:DocumentType ChangeLog_GetById User: {userName},IP:{iPAddress}, Argument:documentCode:{documentCode}");
            var result = documentType.ChangeLog_GetById(documentCode, userName);
            logger.LogInformation($"Result:DocumentType ChangeLog_GetById {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Document Type Deleted List User: {userName},IP:{iPAddress}");
            var result = documentType.DeletedList(userName);
            logger.LogInformation($"Result  Document Type Deleted List : {result}");
            return Ok(result);
        }
    }
}