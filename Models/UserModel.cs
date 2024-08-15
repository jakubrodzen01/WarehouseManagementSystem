using Microsoft.AspNetCore.Identity;

namespace WarehouseManagementSystem.Models
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
