using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ITTicketSystem.Data.AppUsers
{
    public class AppUserService : IAppUserService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public AppUserService(SqlConnectionConfiguration confirguation)
        {
            _configuration = confirguation;
        }

        //Insert New AppUser
        public async Task<bool> AppUserInsert(AppUser appUsers)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("FirstName", appUsers.FirstName, DbType.String);
                parameters.Add("LastName", appUsers.LastName, DbType.String);
                parameters.Add("Status", appUsers.Status, DbType.String);
                parameters.Add("EmailAddress", appUsers.EmailAddress, DbType.String);                

                await conn.ExecuteAsync("ITTicketSystem_InsertAppUsers", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        //Get a List of AppUsers
        public async Task<IEnumerable<AppUser>> AppUserList()
        {
            IEnumerable<AppUser> appUsers;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                appUsers = await conn.QueryAsync<AppUser>("ITTicketSystem_GetAppUsers", commandType: CommandType.StoredProcedure);
            }
            return appUsers;
        }

        //Get One AppUser by ID
        public async Task<AppUser> AppUser_GetOne(int id)
        {
            AppUser appUser = new AppUser();
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using (var conn = new SqlConnection(_configuration.Value))
            {
                appUser = await conn.QueryFirstOrDefaultAsync<AppUser>("ITTicketSystem_GetOneAppUsers", parameters, commandType: CommandType.StoredProcedure);
            }
            return appUser;
        }

        // Get Active AppUser Count
        async Task<IEnumerable<AppUser>> IAppUserService.AppUser_Count()
        {
            IEnumerable<AppUser> countAppUsers;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                countAppUsers = await conn.QueryAsync<AppUser>("ITTicketSystem_AppUserCount", commandType: CommandType.StoredProcedure);
            }
            return countAppUsers;
        }

        //Update AppUser
        public async Task<bool> AppUserUpdate(AppUser appUsers)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("AppUserID", appUsers.AppUserID, DbType.Int32);
                parameters.Add("FirstName", appUsers.FirstName, DbType.String);
                parameters.Add("LastName", appUsers.LastName, DbType.String);
                parameters.Add("EmailAddress", appUsers.EmailAddress, DbType.String);                
                parameters.Add("UpdatedDate", appUsers.UpdatedDate, DbType.Date);
                parameters.Add("Status", appUsers.Status, DbType.String);
                await conn.ExecuteAsync("ITTicketSystem_UpdateAppUsers", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }
    }
}
