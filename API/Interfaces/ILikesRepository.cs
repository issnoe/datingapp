using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);
        Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
        Task<AppUser> GetUserLikes(int userId);
    }
}