using Microsoft.AspNetCore.Identity;

namespace WebStore.Models
{
    public class User : IdentityUser
    {
        public string Image { get; set; }
        public Transaction Transaction { get; set; }
    }
}
