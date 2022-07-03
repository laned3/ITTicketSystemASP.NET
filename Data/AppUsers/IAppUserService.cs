using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITTicketSystem.Data.AppUsers
{
    public interface IAppUserService
    {
        Task<bool> AppUserInsert(AppUser appUsers);
        Task<IEnumerable<AppUser>> AppUserList();
        Task<IEnumerable<AppUser>> AppUser_Count();
        Task<bool> AppUserUpdate(AppUser appUsers);
        Task<AppUser> AppUser_GetOne(int id);
    }
}