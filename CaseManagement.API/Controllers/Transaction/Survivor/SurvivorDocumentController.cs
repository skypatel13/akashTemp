using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SurvivorDocumentController : ControllerBase
    {
        private readonly ISurvivorDocument survivorDocument;
        private readonly ILogger<SurvivorDocumentController> logger;
        private readonly MyAppSettingsOptions myAppSettingsOptions;
        private readonly IMapper mapper;

        public SurvivorDocumentController(ISurvivorDocument survivorDocument, ILogger<SurvivorDocumentController> logger, IOptions<MyAppSettingsOptions> myAppSettingsOptions, IMapper mapper)
        {
            this.survivorDocument = survivorDocument;
            this.logger = logger;
            this.myAppSettingsOptions = myAppSettingsOptions.Value;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = survivorDocument.List(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DownloadFile(SurvivorDocumentDownload survivorDocumentDownload)
        {
            logger.LogInformation($"" +
                $"SurvivorCode {survivorDocumentDownload.SurvivorCode} " +
                $"DocumentCode {survivorDocumentDownload.DocumentCode} " +
                $"FileName {survivorDocumentDownload.FileName} " +
                $"Store FleName{survivorDocumentDownload.StoredAsFileName}");

            var BasePath = myAppSettingsOptions.BasePath;
            var survivorFolder = myAppSettingsOptions.Survivor;
            var PCFolder = myAppSettingsOptions.PC;
            var VCFolder = myAppSettingsOptions.VC;
            var contentType = "APPLICATION/octet-stream";

            if (survivorDocumentDownload.IsSurvivorSpecificValue == true)
            {
                var specificDocFolder = myAppSettingsOptions.SpecificDoc;
                var consentFilePath = Path.Combine(BasePath, survivorFolder, survivorDocumentDownload.SurvivorCode.ToString(), specificDocFolder, survivorDocumentDownload.StoredAsFileName);
                if (System.IO.File.Exists(consentFilePath))
                {
                    var filepdf = System.IO.File.ReadAllBytes(consentFilePath);
                    return File(filepdf, contentType, survivorDocumentDownload.StoredAsFileName);
                }
                return Ok();
            }

            switch (survivorDocumentDownload.DocumentCode)
            {
                case (int)DocumentTypes.Consentform:
                    var consentFormFolder = myAppSettingsOptions.ConsentForm;
                    var consentFilePath = Path.Combine(BasePath, survivorFolder, survivorDocumentDownload.SurvivorCode.ToString(), consentFormFolder, survivorDocumentDownload.StoredAsFileName);
                    if (System.IO.File.Exists(consentFilePath))
                    {
                        var filepdf = System.IO.File.ReadAllBytes(consentFilePath);
                        return File(filepdf, contentType, survivorDocumentDownload.StoredAsFileName);
                    }
                    break;
                case (int)DocumentTypes.GDCopy:
                    var GDFolder = myAppSettingsOptions.GD;
                    var GDFilePath = Path.Combine(BasePath, survivorFolder, survivorDocumentDownload.SurvivorCode.ToString(), GDFolder, survivorDocumentDownload.StoredAsFileName);
                    if (System.IO.File.Exists(GDFilePath))
                    {
                        var filepdf = System.IO.File.ReadAllBytes(GDFilePath);
                        return File(filepdf, contentType, survivorDocumentDownload.StoredAsFileName);
                    }
                    break;
                case (int)DocumentTypes.FIRCopy:
                    var FIRFolder = myAppSettingsOptions.FIR;
                    var FIRFilePath = Path.Combine(BasePath, survivorFolder, survivorDocumentDownload.SurvivorCode.ToString(), FIRFolder, survivorDocumentDownload.StoredAsFileName);
                    if (System.IO.File.Exists(FIRFilePath))
                    {
                        var filepdf = System.IO.File.ReadAllBytes(FIRFilePath);
                        return File(filepdf, contentType, survivorDocumentDownload.StoredAsFileName);
                    }
                    break;
                case (int)DocumentTypes.VCApplication:
                    var VCApplication = myAppSettingsOptions.VCApplication;
                    var VCAppFilePath = Path.Combine(BasePath, survivorFolder, survivorDocumentDownload.SurvivorCode.ToString(), VCFolder, VCApplication, survivorDocumentDownload.StoredAsFileName);
                    if (System.IO.File.Exists(VCAppFilePath))
                    {
                        var filepdf = System.IO.File.ReadAllBytes(VCAppFilePath);
                        return File(filepdf, contentType, survivorDocumentDownload.StoredAsFileName);
                    }
                    break;
                case (int)DocumentTypes.VCOrder:
                    var VCOrder = myAppSettingsOptions.VCOrder;
                    var VCOrderFilePath = Path.Combine(BasePath, survivorFolder, survivorDocumentDownload.SurvivorCode.ToString(), VCFolder, VCOrder, survivorDocumentDownload.StoredAsFileName);
                    if (System.IO.File.Exists(VCOrderFilePath))
                    {
                        var filepdf = System.IO.File.ReadAllBytes(VCOrderFilePath);
                        return File(filepdf, contentType, survivorDocumentDownload.StoredAsFileName);
                    }
                    break;
                case (int)DocumentTypes.PCApplication:
                    var PCApplication = myAppSettingsOptions.PCApplication;
                    var PCAppFilePath = Path.Combine(BasePath, survivorFolder, survivorDocumentDownload.SurvivorCode.ToString(), PCFolder, PCApplication, survivorDocumentDownload.StoredAsFileName);
                    if (System.IO.File.Exists(PCAppFilePath))
                    {
                        var filepdf = System.IO.File.ReadAllBytes(PCAppFilePath);
                        return File(filepdf, contentType, survivorDocumentDownload.StoredAsFileName);
                    }
                    break;
                case (int)DocumentTypes.PCOrder:
                    var PCOrder = myAppSettingsOptions.PCOrder;
                    var PCOrderFilePath = Path.Combine(BasePath, survivorFolder, survivorDocumentDownload.SurvivorCode.ToString(), PCFolder, PCOrder, survivorDocumentDownload.StoredAsFileName);
                    if (System.IO.File.Exists(PCOrderFilePath))
                    {
                        var filepdf = System.IO.File.ReadAllBytes(PCOrderFilePath);
                        return File(filepdf, contentType, survivorDocumentDownload.StoredAsFileName);
                    }
                    break;
                case (int)DocumentTypes.ChargeSheet:
                    var ChargeSheet = myAppSettingsOptions.ChargeSheet;
                    var ChargeSheetFilePath = Path.Combine(BasePath, survivorFolder, survivorDocumentDownload.SurvivorCode.ToString(), ChargeSheet, survivorDocumentDownload.StoredAsFileName);
                    if (System.IO.File.Exists(ChargeSheetFilePath))
                    {
                        var filepdf = System.IO.File.ReadAllBytes(ChargeSheetFilePath);
                        return File(filepdf, contentType, survivorDocumentDownload.StoredAsFileName);
                    }
                    break;
            }
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UploadFile([FromForm] SurvivorDocumentUpload survivorDocumentUpload)
        {
            string userName = User.Identity.Name;
            SurvivorDocumentUploadDB survivorDocumentUploadDB = mapper.Map<SurvivorDocumentUploadDB>(survivorDocumentUpload);
            survivorDocumentUploadDB.CreatedByIpAddress = GetIPAddress(Request);
            survivorDocumentUploadDB.CreatedBy = userName;
            survivorDocumentUploadDB.FileName = survivorDocumentUpload.FileName?.FileName;
            logger.LogInformation($"|Request Argument:{survivorDocumentUploadDB}");
            var result = survivorDocument.DocumentUpload(survivorDocumentUploadDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (survivorDocumentUpload.FileName != null)
                {
                    var specificDocFolder = myAppSettingsOptions.SpecificDoc;
                    var directoryPath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.SurvivorDocumentDTODetail.SurvivorCode.ToString(), specificDocFolder);
                    bool isDirectoryExists = System.IO.Directory.Exists(directoryPath);
                    if (!isDirectoryExists)
                        System.IO.Directory.CreateDirectory(directoryPath);

                    var uploadFilePath = Path.Combine(directoryPath, result.SurvivorDocumentDTODetail.StoredAsFileName);
                    using (FileStream stream = System.IO.File.Create(uploadFilePath))
                    {
                        survivorDocumentUpload.FileName.CopyTo(stream);
                    }
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
