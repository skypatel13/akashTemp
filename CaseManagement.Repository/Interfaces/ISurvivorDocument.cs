using CaseManagement.Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISurvivorDocument
    {
        SurvivorDocumentResponse List(int survivorCode,string userName);
        SurvivorDocumentDTOAddEditResult DocumentUpload(SurvivorDocumentUploadDB survivorDocumentUploadDB);
    }
}
