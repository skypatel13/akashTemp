using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;

namespace CaseManagement.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ActController : ControllerBase
    {
        private readonly IAct act;
        private readonly ILogger<ActController> logger;
        private readonly IMapper mapper;
        private readonly MyAppSettingsOptions myAppSettingsOptions;

        public ActController(IAct act, ILogger<ActController> logger, IMapper mapper, IOptions<MyAppSettingsOptions> myAppSettingsOptions)
        {
            this.act = act;
            this.logger = logger;
            this.mapper = mapper;
            this.myAppSettingsOptions = myAppSettingsOptions.Value;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = act.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add([FromForm] ActDTOAdd actDTOAdd)
        {
            string userName = User.Identity.Name;
            ActDTOAddDB actDTOAddDB = mapper.Map<ActDTOAddDB>(actDTOAdd);
            actDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            actDTOAddDB.CreatedBy = userName;
            if (actDTOAdd.GazetteFile != null)
            {
                actDTOAddDB.GazetteFile = actDTOAdd.GazetteFile.FileName;
            }
            logger.LogInformation($"|Request Argument:{actDTOAddDB}");
            var result = act.Add(actDTOAddDB);
            if (result.DataUpdateResponse.Status && actDTOAdd.GazetteFile != null)
            {
                var actFolder = myAppSettingsOptions.Act;
                var examInstructionFilePath = Path.Combine(myAppSettingsOptions.BasePath, actFolder, result.ActDTODetail.StoredAsFileName);
                using (FileStream stream = System.IO.File.Create(examInstructionFilePath))
                {
                    actDTOAdd.GazetteFile.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{actCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int actCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},ActCode:{actCode}");
            var result = act.Delete(actCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit([FromForm] ActDTOEdit actDTOEdit)
        {
            string userName = User.Identity.Name;
            ActDTOEditDB actDTOEditDB = mapper.Map<ActDTOEditDB>(actDTOEdit);
            actDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            actDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{actDTOEditDB}");
            if (actDTOEdit.GazetteFile != null)
            {
                actDTOEditDB.GazetteFile = actDTOEdit.GazetteFile.FileName;
            }
            else
            {
                actDTOEditDB.GazetteFile = actDTOEdit.StoredAsFileName;
            }
            var result = act.Edit(actDTOEditDB);
            if (result.DataUpdateResponse.Status && actDTOEdit.GazetteFile != null)
            {
                var actFolder = myAppSettingsOptions.Act;
                var examInstructionFilePath = Path.Combine(myAppSettingsOptions.BasePath, actFolder, result.ActDTODetail.StoredAsFileName);
                using (FileStream stream = System.IO.File.Create(examInstructionFilePath))
                {
                    actDTOEdit.GazetteFile.CopyTo(stream);
                }
            }

            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{actCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int actCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ActCode:{actCode}");
            var result = act.Detail(actCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{actCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int actCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ActCode:{actCode}");
            var result = act.ChangeLog_GetById(actCode, userName);
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
            var result = act.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{GazetteFile}")]
        public IActionResult DownloadFile(string GazetteFile)
        {
            logger.LogInformation($"GazetteFile:{GazetteFile}");
            var actFolder = myAppSettingsOptions.Act;
            var filePath = Path.Combine(myAppSettingsOptions.BasePath, actFolder, GazetteFile);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            var filepdf = System.IO.File.ReadAllBytes(filePath);
            return File(filepdf, "application/pdf", GazetteFile);
        }
    }
}