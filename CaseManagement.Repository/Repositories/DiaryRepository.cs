using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CaseManagement.Repository.Repositories
{
    public class DiaryRepository : IDiary
    {
        private readonly AppConnectionString appConnectionString;

        public DiaryRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public DiaryDTOResponse List(string userName)
        {
            DiaryDTOResponse diaryDTOResponse = new DiaryDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.DailyDiary_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    diaryDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (diaryDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    diaryDTOResponse.DiaryDTOList = result.Read<DiaryDTOList>().ToList();
                }
            }
            return diaryDTOResponse;
        }
        public List<DiaryDTOCalendar> CalendarList(string userName)
        {
          
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DiaryDTOCalendar>("Alert.DailyDiary_List_ForCalendarView_Admin", new { UserName = userName }, null, false,null, CommandType.StoredProcedure).ToList();
          
            }
        }
        public DiaryDTODetailResponse Detail(string userName, int dailyDiaryId)
        {
            DiaryDTODetailResponse diaryDTODetailResponse = new DiaryDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.DailyDiary_GetByCode_Admin", new { UserName = userName, DailyDiaryId = dailyDiaryId }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    diaryDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (diaryDTODetailResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        diaryDTODetailResponse.DiaryDTODetail = result.Read<DiaryDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        diaryDTODetailResponse.DiaryDTODetail.DiarySurvivorDTOList = result.Read<DiarySurvivorDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        diaryDTODetailResponse.DiaryDTODetail.DiaryStakeholdersDTOList = result.Read<DiaryStakeholdersDTOList>().ToList();
                    }
                }
            }
            return diaryDTODetailResponse;
        }
        public DiaryDTOAddEditResult Add(DiaryDTOAddDB diaryDTOAddDB)
        {
            DiaryDTOAddEditResult diaryDTOAddEditResult = new DiaryDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.DailyDiary_Insert_Admin", diaryDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    diaryDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (diaryDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    diaryDTOAddEditResult.DiaryDTODetail = result.Read<DiaryDTODetail>().FirstOrDefault();
                }
            }
            return diaryDTOAddEditResult;
        }
        public DiaryDTOAddEditResult Edit(DiaryDTOEditDB diaryDTOEditDB)
        {
            DiaryDTOAddEditResult diaryDTOAddEditResult = new DiaryDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.DailyDiary_Update_Admin", diaryDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    diaryDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (diaryDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    diaryDTOAddEditResult.DiaryDTODetail = result.Read<DiaryDTODetail>().FirstOrDefault();
                }
            }
            return diaryDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int dailyDiaryId, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Alert.DailyDiary_Delete_Admin", new { DailyDiaryId = dailyDiaryId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DiaryChangeLogDTOResponse ChangeLog_GetById(string userName, int dailyDiaryId)
        {
            DiaryChangeLogDTOResponse diaryChangeLogDTOResponse = new DiaryChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.DailyDiaryLog_GetByCode_Admin", new { DailyDiaryId = dailyDiaryId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    diaryChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (diaryChangeLogDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        diaryChangeLogDTOResponse.DiaryChangeLogDTOList = result.Read<DiaryChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        diaryChangeLogDTOResponse.DiarySurvivorChangeLogDTOList = result.Read<DiarySurvivorChangeLogDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        diaryChangeLogDTOResponse.DiaryStackeHoldeChangeLogDTOList = result.Read<DiaryStackeHoldeChangeLogDTOList>().ToList();
                    }
                }
            }
            return diaryChangeLogDTOResponse;
        }
        public DiaryDTOResponse DeletedList(string userName)
        {
            DiaryDTOResponse DiaryDTOResponse = new DiaryDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.DailyDiary_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    DiaryDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (DiaryDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    DiaryDTOResponse.DiaryDTOList = result.Read<DiaryDTOList>().ToList();
                }
            }
            return DiaryDTOResponse;
        }
        public DiarySurvivorDTOResponse RelatedSurvivorList(string userName, int? dailyDiaryId)
        {
            DiarySurvivorDTOResponse diarySurvivorDTOResponse = new DiarySurvivorDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.DailyDiary_Lookup_Survivor_Admin", new { UserName = userName, DailyDiaryId = dailyDiaryId }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    diarySurvivorDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (diarySurvivorDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    diarySurvivorDTOResponse.DiarySurvivorDTOList = result.Read<DiarySurvivorDTOList>().ToList();
                }
            }
            return diarySurvivorDTOResponse;
        }
        public DiaryDTOAddEditResult StatusUpdate(DiaryDTOStatusUpdateDB diaryDTOStatusUpdateDB)
        {
            DiaryDTOAddEditResult diaryDTOAddEditResult = new DiaryDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.DailyDiary_Status_Update_Admin", diaryDTOStatusUpdateDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    diaryDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (diaryDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    diaryDTOAddEditResult.DiaryDTODetail = result.Read<DiaryDTODetail>().FirstOrDefault();
                }
            }
            return diaryDTOAddEditResult;
        }

        public DataUpdateResponseDTO ActionAdd(DiaryDTOActionAddDB diaryDTOActionAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Alert.DailyDiary_Action_Insert_Admin", diaryDTOActionAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DiaryActionsDTOResponse Actions(string userName, int dailyDiaryId)
        {
            DiaryActionsDTOResponse diaryActionsDTOResponse = new DiaryActionsDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.DailyDiary_Action_List_Admin", new { UserName = userName, DailyDiaryId = dailyDiaryId }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    diaryActionsDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (diaryActionsDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    diaryActionsDTOResponse.DiaryActionsDTOList = result.Read<DiaryActionsDTOList>().ToList();
                }
            }
            return diaryActionsDTOResponse;
        }
        public DataUpdateResponseDTO Close(DiaryCloseDTOAddDB diaryCloseDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Alert.DailyDiary_Close_Admin", diaryCloseDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO ActionDelete(int dailyDiaryActionsId, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Alert.DailyDiary_Action_Delete_Admin", new { DailyDiaryActionsId = dailyDiaryActionsId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

    }
}