namespace DTO
{
    public class PlaneTypeDTO : IEntityDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Seats { get; set; }
        public double Payload { get; set; }
    }
}
