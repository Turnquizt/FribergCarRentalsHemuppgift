using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsHemuppgift.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Epostadress")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lösenord måste matcha")]
        [Display(Name = "Upprepa Lösenord")]
        public string ConfirmPassword {  get; set; }
    }
}
