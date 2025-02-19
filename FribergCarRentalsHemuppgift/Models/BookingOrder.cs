using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsHemuppgift.Models
{
    public class BookingOrder : IValidatableObject
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int CarId { get; set; }
        public virtual Car? Car { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int? BookingPrice { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate >= EndDate) 
            { 
                yield return new ValidationResult("Välj ett senare slutdatum", new[] {nameof(EndDate)});
            }
            if (StartDate < DateOnly.FromDateTime(DateTime.Today)) 
            {
                yield return new ValidationResult("Välj ett senare startdatum", new[] { nameof(StartDate)});
            }

        }
    }
}
