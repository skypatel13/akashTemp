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
    public class CityRepository : ICity
    {
        private readonly AppConnectionString appConnectionString;
        public CityRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public CityDTOResponse List(string userName)
        {
            CityDTOResponse cityDTOResponse = new CityDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("City_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    cityDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (cityDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        cityDTOResponse.cityDTOLists = result.Read<CityDTOList>().ToList();
                    }
                }
            }
            return cityDTOResponse;

        }
        public CityDTOAddEditResult Add(CityDTOAddDB cityDTOAddDB)
        {
            CityDTOAddEditResult cityDTOAddEditResult = new CityDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("City_Insert_Admin", cityDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    cityDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (cityDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        cityDTOAddEditResult.CityDTODetail = result.Read<CityDTODetail>().FirstOrDefault();
                    }
                }
            }
            return cityDTOAddEditResult;
        }

        public CityDTOAddEditResult Edit(CityDTOEditDB cityDTOEditDB)
        {
            CityDTOAddEditResult cityDTOAddEditResult = new CityDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("City_Update_Admin", cityDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    cityDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (cityDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        cityDTOAddEditResult.CityDTODetail = result.Read<CityDTODetail>().FirstOrDefault();
                    }
                }
            }
            return cityDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int cityCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("City_Delete_Admin", new { CityCode = cityCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CityDTODetailResponse Detail(int cityCode, string userName)
        {
            CityDTODetailResponse cityDTODetailResponse = new CityDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("City_GetByCode_Admin", new { CityCode = cityCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    cityDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (cityDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        cityDTODetailResponse.cityDTODetail = result.Read<CityDTODetail>().FirstOrDefault();
                    }
                }
            }
            return cityDTODetailResponse;
        }

        public CityChangeLogDTOResponse ChangeLog_GetById(int CityCode, string userName)
        {
            CityChangeLogDTOResponse cityChangeLogDTOResponse = new CityChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CityLog_GetByCode_Admin", new { CityCode = CityCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    cityChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (cityChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        cityChangeLogDTOResponse.cityChangeLogDTOs = result.Read<CityChangeLogDTO>().ToList();
                    }
                }
            }
            return cityChangeLogDTOResponse;
        }

        public CityDTOResponse DeletedList(string userName)
        {
            CityDTOResponse cityDTOResponse = new CityDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("City_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    cityDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (cityDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        cityDTOResponse.cityDTOLists = result.Read<CityDTOList>().ToList();
                    }
                }
            }
            return cityDTOResponse;

        }
    }
}
