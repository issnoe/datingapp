using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipleExtencions
    {
        // This statis methos is for get the user info 
        // Obtener el nombre de usuario por medio del TOKEN :) 
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}