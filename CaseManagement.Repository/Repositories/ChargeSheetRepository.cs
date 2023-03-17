using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using CaseManagement.Models;

namespace CaseManagement.Repository.Repositories
{
    public class ChargeSheetRepository : IChargeSheet
    {
        private readonly AppConnectionString appConnectionString;

        public ChargeSheetRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public ChargeSheetDTOResponse List(int survivorCode, string userName)
        {
            ChargeSheetDTOResponse chargeSheetDTOResponse = new ChargeSheetDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Chargesheet_ListBySurvivorCode_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    chargeSheetDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (chargeSheetDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTOResponse.ChargeSheetDTOList = result.Read<ChargeSheetDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTOResponse.ChargeSheetSectionDTOList = result.Read<ChargeSheetSectionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTOResponse.ChargeSheetAccuseDTOList = result.Read<ChargeSheetAccuseDTOList>().ToList();
                    }

                }
            }
            return chargeSheetDTOResponse;
        }
        public ChargeSheetDTOResponse DeletedList(int survivorCode, string userName)
        {
            ChargeSheetDTOResponse chargeSheetDTOResponse = new ChargeSheetDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Chargesheet_Deleted_ListBySurvivorCode_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    chargeSheetDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (chargeSheetDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTOResponse.ChargeSheetDTOList = result.Read<ChargeSheetDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTOResponse.ChargeSheetSectionDTOList = result.Read<ChargeSheetSectionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTOResponse.ChargeSheetAccuseDTOList = result.Read<ChargeSheetAccuseDTOList>().ToList();
                    }
                }
            }
            return chargeSheetDTOResponse;
        }
        public ChargeSheetChangeLogDTOResponse ChangeLog_GetById(int chargesheetCode, string userName)
        {
            ChargeSheetChangeLogDTOResponse ChargeSheetChangeLogDTOResponse = new ChargeSheetChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ChargesheetLog_GetByCode_Admin", new { ChargesheetCode = chargesheetCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    ChargeSheetChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (!result.IsConsumed)
                {
                    ChargeSheetChangeLogDTOResponse.ChargeSheetChangeLogDTOList = result.Read<ChargeSheetChangeLogDTOList>().ToList();
                }   
                if (!result.IsConsumed)
                {
                    ChargeSheetChangeLogDTOResponse.ChargeSheetActSectionChangeLogDTOList = result.Read<ChargeSheetActSectionChangeLogDTOList>().ToList();
                }
                if (!result.IsConsumed)
                {
                    ChargeSheetChangeLogDTOResponse.ChargeSheetAccusedChangeLogDTOList = result.Read<ChargeSheetAccusedChangeLogDTOList>().ToList();
                }
            }
            return ChargeSheetChangeLogDTOResponse;
        }

        public ChargeSheetHeaderDTOResponse Chargesheet_Header_GetByCode(int investigationCode, string userName)
        {
            ChargeSheetHeaderDTOResponse chargeSheetHeaderDTOResponse = new ChargeSheetHeaderDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Chargesheet_Header_GetByCode_Admin", new { InvestigationCode = investigationCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    chargeSheetHeaderDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (chargeSheetHeaderDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        chargeSheetHeaderDTOResponse.ChargeSheetHeaderDTO = result.Read<ChargeSheetHeaderDTO>().FirstOrDefault();
                    }
                }
            }
            return chargeSheetHeaderDTOResponse;
        }
        public ChargeSheetAccusedDetailResponse Chargesheet_Accused_List(int chargesheetCode,int investigationCode, string userName)
        {
            ChargeSheetAccusedDetailResponse chargesheetAccusedDetailResponse = new ChargeSheetAccusedDetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Chargesheet_Accused_List_Admin", new { ChargesheetCode= chargesheetCode, InvestigationCode = investigationCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    chargesheetAccusedDetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (chargesheetAccusedDetailResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        chargesheetAccusedDetailResponse.ChargeSheetAccusedDTOList = result.Read<ChargeSheetAccusedDTOList>().ToList();
                    }
                }
            }
            return chargesheetAccusedDetailResponse;
        }
        public ChargesheetSectionDetailResponse Chargesheet_Section_List(int chargesheetCode, int investigationCode, string userName)
        {
            ChargesheetSectionDetailResponse chargesheetSectionDetailResponse = new ChargesheetSectionDetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Chargesheet_ActSection_List_Admin", new { ChargesheetCode = chargesheetCode, InvestigationCode = investigationCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    chargesheetSectionDetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (chargesheetSectionDetailResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        chargesheetSectionDetailResponse.ChargesheetActSectionDTOList = result.Read<ChargesheetActSectionDTOList>().ToList();
                    }
                }
            }
            return chargesheetSectionDetailResponse;
        }
        public ChargeSheetDTOAddEditResult Add(ChargeSheetDTOAddDB chargeSheetDTOAddDB)
        {
            ChargeSheetDTOAddEditResult chargeSheetDTOAddEditResult = new ChargeSheetDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ChargeSheet_Insert_Admin", chargeSheetDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    chargeSheetDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (chargeSheetDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTOAddEditResult.ChargeSheetDTODetail = result.Read<ChargeSheetDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTOAddEditResult.ChargeSheetDTODetail.ChargeSheetSectionDTOList = result.Read<ChargeSheetSectionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTOAddEditResult.ChargeSheetDTODetail.ChargeSheetAccuseDTOList = result.Read<ChargeSheetAccuseDTOList>().ToList();
                    }
                }
            }
            return chargeSheetDTOAddEditResult;
        }
        public ChargeSheetDTOAddEditResult Edit(ChargeSheetDTOEditDB chargeSheetDTOEditDB)
        {
            ChargeSheetDTOAddEditResult chargeSheetDTOAddEditResult = new ChargeSheetDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ChargeSheet_Update_Admin", chargeSheetDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    chargeSheetDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (chargeSheetDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    chargeSheetDTOAddEditResult.ChargeSheetDTODetail = result.Read<ChargeSheetDTODetail>().FirstOrDefault();
                }
            }
            return chargeSheetDTOAddEditResult;
        }
        public ChargeSheetDTODetailResponse Detail(int chargeSheetCode, string userName)
        {
            ChargeSheetDTODetailResponse chargeSheetDTODetailResponse = new ChargeSheetDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ChargeSheet_GetByCode_Admin", new { ChargeSheetCode = chargeSheetCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    chargeSheetDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (chargeSheetDTODetailResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTODetailResponse.ChargeSheetDTODetail = result.Read<ChargeSheetDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTODetailResponse.ChargeSheetDTODetail.ChargeSheetSectionDTOList = result.Read<ChargeSheetSectionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        chargeSheetDTODetailResponse.ChargeSheetDTODetail.ChargeSheetAccuseDTOList = result.Read<ChargeSheetAccuseDTOList>().ToList();
                    }
                }
            }
            return chargeSheetDTODetailResponse;
        }
        public DataUpdateResponseDTO Delete(int chargeSheetCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("Chargesheet_Delete_Admin", new { ChargeSheetCode = chargeSheetCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
