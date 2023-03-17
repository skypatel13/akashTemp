using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CaseManagement.API.Controllers.Transaction.Survivor.FinancialInclusion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ISurvivorLoan survivorLoan;
        private readonly ILogger<LoanController> logger;
        private readonly IMapper mapper;
        private readonly MyAppSettingsOptions myAppSettingsOptions;

        public LoanController(ISurvivorLoan survivorLoan, ILogger<LoanController> logger, IMapper mapper, IOptions<MyAppSettingsOptions> myAppSettingsOptions)
        {
            this.survivorLoan = survivorLoan;
            this.logger = logger;
            this.mapper = mapper;
            this.myAppSettingsOptions = myAppSettingsOptions.Value;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{survivorCode:int}")]
        public IActionResult List(int? survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:SurvivorCode:{survivorCode} User:{userName},IP:{iPAddress}");
            var result = survivorLoan.List(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add([FromForm] SurvivorLoanDTOAdd survivorLoanDTOAdd)
        {
            string userName = User.Identity.Name;
            SurvivorLoanDTOAddDB survivorLoanDTOAddDB = mapper.Map<SurvivorLoanDTOAddDB>(survivorLoanDTOAdd);
            if (survivorLoanDTOAdd.loanMortgageDTOLists != null)
            {
                List<SurvivorLoanMortgageDTOList> loanMortgageDTOLists = JsonConvert.DeserializeObject<List<SurvivorLoanMortgageDTOList>>(survivorLoanDTOAdd.loanMortgageDTOLists);
                string dataXmlMortgage = Utility.GetXMLString(loanMortgageDTOLists);
                survivorLoanDTOAddDB.MortgageData = dataXmlMortgage;
            }
            survivorLoanDTOAddDB.ReferenceDocument = (survivorLoanDTOAdd.ReferenceDocument?.FileName);
            survivorLoanDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            survivorLoanDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{survivorLoanDTOAddDB}");
            var result = survivorLoan.Add(survivorLoanDTOAddDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (survivorLoanDTOAdd.ReferenceDocument != null)
                {
                    var loanFolder = myAppSettingsOptions.Loan;
                    var loanFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.survivorLoanDTODetail.SurvivorCode.ToString(), loanFolder, result.survivorLoanDTODetail.ReferenceDocumentStoredAs);
                    using FileStream stream = System.IO.File.Create(loanFilePath);
                    survivorLoanDTOAdd.ReferenceDocument.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit([FromForm] SurvivorLoanDTOEdit survivorLoanDTOEdit)
        {
            string userName = User.Identity.Name;
            SurvivorLoanDTOEditDB survivorLoanDTOEditDB = mapper.Map<SurvivorLoanDTOEditDB>(survivorLoanDTOEdit);
            if (survivorLoanDTOEdit.loanMortgageDTOLists != null)
            {
                List<SurvivorLoanMortgageDTOList> loanMortgageDTOLists = JsonConvert.DeserializeObject<List<SurvivorLoanMortgageDTOList>>(survivorLoanDTOEdit.loanMortgageDTOLists);
                string dataXmlMortgage = Utility.GetXMLString(loanMortgageDTOLists);
                survivorLoanDTOEditDB.MortgageData = dataXmlMortgage;
            }
            survivorLoanDTOEditDB.ReferenceDocument = (survivorLoanDTOEdit.ReferenceDocument?.FileName);
            survivorLoanDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            survivorLoanDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{survivorLoanDTOEditDB}");
            var result = survivorLoan.Edit(survivorLoanDTOEditDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (survivorLoanDTOEdit.ReferenceDocument != null)
                {
                    var loanFolder = myAppSettingsOptions.Loan;
                    var loanFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.survivorLoanDTODetail.SurvivorCode.ToString(), loanFolder, result.survivorLoanDTODetail.ReferenceDocumentStoredAs);
                    using FileStream stream = System.IO.File.Create(loanFilePath);
                    survivorLoanDTOEdit.ReferenceDocument.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{financialInclusionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int financialInclusionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},FinancialInclusionCode:{financialInclusionCode}");
            var result = survivorLoan.Delete(financialInclusionCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{financialInclusionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int financialInclusionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},FinancialInclusionCode:{financialInclusionCode}");
            var result = survivorLoan.Detail(financialInclusionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{financialInclusionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PaidLoanList(int financialInclusionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},FinancialInclusionCode:{financialInclusionCode}");
            var result = survivorLoan.PaidList(financialInclusionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PaidLoanInsert(SurvivorLoanDTOPaidAdd survivorLoanDTOPaidAdd)
        {
            string userName = User.Identity.Name;
            SurvivorLoanDTOPaidAddDB survivorLoanDTOPaidAddDB = mapper.Map<SurvivorLoanDTOPaidAddDB>(survivorLoanDTOPaidAdd);
            survivorLoanDTOPaidAddDB.PaidDate = survivorLoanDTOPaidAdd.PaidDate.ToLocalTime();
            survivorLoanDTOPaidAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            survivorLoanDTOPaidAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{survivorLoanDTOPaidAddDB}");
            var result = survivorLoan.PaidInsert(survivorLoanDTOPaidAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PaidLoanEdit(SurvivorLoanDTOPaidEdit survivorLoanDTOPaidEdit)
        {
            string userName = User.Identity.Name;
            SurvivorLoanDTOPaidEditDB survivorLoanDTOPaidEditDB = mapper.Map<SurvivorLoanDTOPaidEditDB>(survivorLoanDTOPaidEdit);
            survivorLoanDTOPaidEditDB.PaidDate = survivorLoanDTOPaidEditDB.PaidDate.ToLocalTime();
            survivorLoanDTOPaidEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            survivorLoanDTOPaidEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{survivorLoanDTOPaidEditDB}");
            var result = survivorLoan.PaidEdit(survivorLoanDTOPaidEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{financialInclusionPaidLogCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PaidLoanDelete(int financialInclusionPaidLogCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},FinancialInclusionPaidLogCode:{financialInclusionPaidLogCode}");
            var result = survivorLoan.PaidDelete(financialInclusionPaidLogCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{survivorCode:int}")]
        public IActionResult DeletedList(int? survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode{survivorCode}");
            var result = survivorLoan.DeletedList(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{financialInclusionCode:int}")]
        public IActionResult ChangeLog_GetById(int financialInclusionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},FincialInclusionCode{financialInclusionCode}");
            var result = survivorLoan.ChangeLog_GetById(financialInclusionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{financialInclusionCode:int}/{survivorCode}/{loanCopy}")]
        public IActionResult DownloadFile(int financialInclusionCode, string survivorCode, string loanCopy)
        {
            logger.LogInformation($"FinancialInclusionCode : {financialInclusionCode}, survivorCode: {survivorCode}, Loan FileName : {loanCopy}");
            var survivorFolder = myAppSettingsOptions.Survivor;
            var contentType = "APPLICATION/octet-stream";
            if (loanCopy != "null")
            {
                var loanFolder = myAppSettingsOptions.Loan;
                var loanFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, survivorCode, loanFolder, loanCopy);
                if (System.IO.File.Exists(loanFilePath))
                {
                    var filepdf = System.IO.File.ReadAllBytes(loanFilePath);
                    return File(filepdf, contentType, loanCopy);
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }
    }
}
