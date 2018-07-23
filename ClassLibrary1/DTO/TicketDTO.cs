namespace DTO
{
    public class TicketDTO : IEntityDTO
    {
        public  int Id { get; set; }
        public decimal Price { get; set; }
        public string FlightNumber { get; set; }

        
    }
}
