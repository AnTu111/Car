namespace CarsProject.Models
{
    public class CarsViewModel
    {
        public Guid? Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string MotorPower { get; set; }
        public string Fuel { get; set; }
        public string Price { get; set; }
    }
}
