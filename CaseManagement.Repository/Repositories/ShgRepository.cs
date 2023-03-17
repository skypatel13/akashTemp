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
    public class ShgRepository : IShg
    {
        private readonly AppConnectionString appConnectionString;

        public ShgRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public ShgDTOResponse List(string userName)
        {
            ShgDTOResponse shgDTOResponse = new ShgDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SHG_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shgDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shgDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        shgDTOResponse.SHGDTOList = result.Read<SHGDTOList>().ToList();
                    }
                }
            }
            return shgDTOResponse;
        }

        public DataUpdateResponseDTO Add(ShgDTOAddDB shgDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("SHG_Insert_Admin", shgDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Edit(ShgDTOEditDB shgDTOEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("SHG_Update_Admin", shgDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public SHGDTODetailResponse Detail(int shgCode, string userName)
        {
            SHGDTODetailResponse sHGDTODetailResponse = new SHGDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SHG_GetById_Admin", new { SHGCode = shgCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    sHGDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (sHGDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        sHGDTODetailResponse.SHGDTODetail = result.Read<SHGDTODetail>().FirstOrDefault();
                    }
                }
            }
            return sHGDTODetailResponse;
        }

        public DataUpdateResponseDTO Delete(int shgCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("SHG_Delete_Admin", new { SHGCode = shgCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public ShgDTOResponse DeletedList(string userName)
        {
            ShgDTOResponse shgDTOResponse = new ShgDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SHG_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shgDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shgDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        shgDTOResponse.SHGDTOList = result.Read<SHGDTOList>().ToList();
                    }
                }
            }
            return shgDTOResponse;
        }

        public ShgChangeLogDTOResponse ChangeLog_GetById(int shgCode, string userName)
        {
            ShgChangeLogDTOResponse shgChangeLogDTOResponse = new ShgChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("SHGLog_GetByCode_Admin", new { SHGCode = shgCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shgChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shgChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        shgChangeLogDTOResponse.ShgChangeLogDTOList = result.Read<ShgChangeLogDTOList>().ToList();
                    }
                }
            }
            return shgChangeLogDTOResponse;
        }
    }
}