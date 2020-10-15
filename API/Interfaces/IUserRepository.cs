using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

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
        // Task<IEnumerable<MemberDto>> GetMembersAsync();
        // Task<MemberDto> GetMemberAsync(string username);
    }
}