using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace YaLibrary.Models
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public AppUser() {}

        public AppUser( string _firstName, string _lastName, string email)
        {
            Firstname = _firstName;
            Lastname = _lastName;
            Email = email;
            UserName = email;
        }
    }
}
