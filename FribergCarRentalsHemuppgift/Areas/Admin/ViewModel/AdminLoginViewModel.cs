using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsHemuppgift.Areas.Admin.ViewModel
{
    public class AdminLoginViewModel
    {
        [Required]
        [Display(Name = "Admin Användarnamn")]
        public string AdminUsername { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string AdminPassword { get; set; }
    }
}
