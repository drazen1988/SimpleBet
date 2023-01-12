using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class UserListVM
    {
        public string UserId { get; set; }

        [Display(Name = "Igrač")]
        public string UserName { get; set; }
    }
}
