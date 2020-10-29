using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);

        // All the Task methods are going to manage async methods from context
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);

        // Enchange in SQL queries
        Task<IEnumerable<MemberDto>> GetMembersAsyncOld();
        Task<MemberDto> GetMemberAsync(string username);
        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
    }
}