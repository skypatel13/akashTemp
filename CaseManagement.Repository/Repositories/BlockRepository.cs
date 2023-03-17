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
    public class BlockRepository : IBlock
    {
        private readonly AppConnectionString appConnectionString;

        public BlockRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public BlockDTOListResponse List(string userName)
        {
            BlockDTOListResponse blockDTOListResponse = new BlockDTOListResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Block_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    blockDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (blockDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        blockDTOListResponse.BlockDTOList = result.Read<BlockDTOList>().ToList();
                    }
                }
            }
            return blockDTOListResponse;
        }
        public DataUpdateResponseDTO Add(BlockDTOAddDB blockDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Block_Insert_Admin", blockDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO Edit(BlockDTOEditDB blockDTOEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Block_Update_Admin", blockDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public BlockDetailResponse Detail(int blockCode, string userName)
        {
            BlockDetailResponse blockDetailResponse = new BlockDetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Block_GetByCode_Admin", new { BlockCode = blockCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    blockDetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (blockDetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        blockDetailResponse.BlockDetail = result.Read<BlockDetail>().FirstOrDefault();
                    }
                }
            }
            return blockDetailResponse;
        }
        public DataUpdateResponseDTO Delete(int blockCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Block_Delete_Admin", new { BlockCode = blockCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public BlockDTOListResponse DeletedList(string userName)
        {
            BlockDTOListResponse blockDTOListResponse = new BlockDTOListResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Block_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    blockDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (blockDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        blockDTOListResponse.BlockDTOList = result.Read<BlockDTOList>().ToList();
                    }
                }
            }
            return blockDTOListResponse;
        }
        //public BlockDTOListGetByDistrictResponse GetByDistrictId(int districtCode, string userName)
        //{
        //    BlockDTOListGetByDistrictResponse blockDTOListGetByDistrictResponse = new BlockDTOListGetByDistrictResponse();
        //    using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
        //    {
        //        var result = cnn.QueryMultiple("Block_GetByDistrictId_Admin", new { DistrictCode = districtCode, UserName = userName }, null, null, CommandType.StoredProcedure);
        //        if (!result.IsConsumed)
        //        {
        //            blockDTOListGetByDistrictResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
        //        }
        //        if (blockDTOListGetByDistrictResponse.DataUpdateResponse.Status == true)
        //        {
        //            if (!result.IsConsumed)
        //            {
        //                blockDTOListGetByDistrictResponse.BlockDTOListGetByDistrict = result.Read<BlockDTOListGetByDistrict>().ToList();
        //            }
        //        }
        //    }
        //    return blockDTOListGetByDistrictResponse;
        //}
        public BlockChangeLogDTOResponse ChangeLog_GetById(int blockCode, string userName)
        {
            BlockChangeLogDTOResponse blockChangeLogDTOListResponse = new BlockChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("BlockLog_GetByCode_Admin", new { BlockCode = blockCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    blockChangeLogDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (blockChangeLogDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        blockChangeLogDTOListResponse.BlockChangeLogDTOList = result.Read<BlockChangeLogDTOList>().ToList();
                    }
                }
            }
            return blockChangeLogDTOListResponse;
        }


    }
}
