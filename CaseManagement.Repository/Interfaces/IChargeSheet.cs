using CaseManagement.Models;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Repository.Interfaces
{
    public interface IChargeSheet
    {
        ChargeSheetDTOResponse List(int survivorCode, string userName);
        ChargeSheetDTOResponse DeletedList(int survivorCode, string userName);
        ChargeSheetChangeLogDTOResponse ChangeLog_GetById(int chargesheetCode, string userName);
        ChargeSheetHeaderDTOResponse Chargesheet_Header_GetByCode(int investigationCode, string userName);
        ChargeSheetAccusedDetailResponse Chargesheet_Accused_List(int chargesheetCode, int investigationCode, string userName);
        ChargesheetSectionDetailResponse Chargesheet_Section_List(int chargesheetCode, int investigationCode, string userName);
        ChargeSheetDTOAddEditResult Add(ChargeSheetDTOAddDB ChargeSheetDTOAddDB);
        ChargeSheetDTOAddEditResult Edit(ChargeSheetDTOEditDB ChargeSheetDTOEditDB);
        ChargeSheetDTODetailResponse Detail(int chargeSheetCode, string userName);
        DataUpdateResponseDTO Delete(int chargeSheetCode, string deletedBy, string deletedByIpAddress);

    }
}
