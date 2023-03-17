using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CaseManagement.Repository.Repositories
{
    public class SectionRepository : ISection
    {
        private readonly AppConnectionString appConnectionString;

        public SectionRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public SectionDTOResponse List(string userName)
        {
            SectionDTOResponse actSectionDTOResponse = new SectionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ActSection_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actSectionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actSectionDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actSectionDTOResponse.ActSectionDTOList = result.Read<SectionDTOList>().ToList();
                    }
                }
            }
            return actSectionDTOResponse;
        }

        public SectionDTOAddEditResult Add(SectionDTOAddDB sectionDTOAddDB)
        {
            SectionDTOAddEditResult sectionDTOAddEditResult = new SectionDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ActSection_Insert_Admin", sectionDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    sectionDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (sectionDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        sectionDTOAddEditResult.SectionDTODetail = result.Read<SectionDTODetail>().FirstOrDefault();
                    }
                }
            }
            return sectionDTOAddEditResult;
        }

        public SectionDTOAddEditResult Edit(SectionDTOEditDB sectionDTOEditDB)
        {
            SectionDTOAddEditResult sectionDTOAddEditResult = new SectionDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ActSection_Update_Admin", sectionDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    sectionDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (sectionDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        sectionDTOAddEditResult.SectionDTODetail = result.Read<SectionDTODetail>().FirstOrDefault();
                    }
                }
            }
            return sectionDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int actSectionCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("ActSection_Delete_Admin", new { ActSectionCode = actSectionCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public SectionDTODetailResponse Detail(int actSectionCode, string userName)
        {
            SectionDTODetailResponse actSectionDTODetailResponse = new SectionDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ActSection_GetByCode_Admin", new { ActSectionCode = actSectionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actSectionDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actSectionDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actSectionDTODetailResponse.ActSectionDTODetail = result.Read<SectionDTODetail>().FirstOrDefault();
                    }
                }
            }
            return actSectionDTODetailResponse;
        }

        public SectionLogDTOResponse ChangeLog_GetById(int actSectionCode, string userName)
        {
            SectionLogDTOResponse actSectionLogDTOResponse = new SectionLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ActSectionLog_GetByCode_Admin", new { ActSectionCode = actSectionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actSectionLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actSectionLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actSectionLogDTOResponse.ActSectionLogDTOList = result.Read<SectionLogDTOList>().ToList();
                    }
                }
            }
            return actSectionLogDTOResponse;
        }

        public SectionDTOResponse DeletedList(string userName)
        {
            SectionDTOResponse actSectionDTOResponse = new SectionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ActSection_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actSectionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actSectionDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actSectionDTOResponse.ActSectionDTOList = result.Read<SectionDTOList>().ToList();
                    }
                }
            }
            return actSectionDTOResponse;
        }
    }
}