namespace FribergCarRentalsHemuppgift.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public int Milage { get; set; }
        public int Horsepower { get; set; }
        public int PricePerDay  { get; set; }
        public string? ImgUrl { get; set; }  

    }
}
