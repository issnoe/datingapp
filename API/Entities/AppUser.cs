using System;
using System.Collections.Generic;
using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        // Calculate age
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }
        // One user have many photos

        // Enchange in SQL queries

        // The reason is : When this mathos IMapper provider create a Bad Query that in not good for the performance
        // For get the age We can update the IMapper Provicer on 

        // public int GetAge()
        // {
        //      return DateOfBirth.CalculateAge();
        // }

        // Relation many likes, from other users
        public ICollection<UserLike> LikedByUsers { get; set; }

        // Relation many likes, my likes
        public ICollection<UserLike> LikedUsers { get; set; }
    }
}