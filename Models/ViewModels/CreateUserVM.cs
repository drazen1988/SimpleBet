
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class CreateUserVM
    {
        public CreateUserVM()
        {
            UserRoleDropDownList = new List<UserRoleDropDown>();
            ClanDropDownList = new List<ClanDropDown>();
        }

        public List<UserRoleDropDown> UserRoleDropDownList { get; set; }
        public List<ClanDropDown> ClanDropDownList { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string UserRole { get; set; }

        [Required]
        public int ClanId { get; set; }
    }

    public class UserRoleDropDown
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ClanDropDown
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
    }
}
