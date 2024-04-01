namespace Domain.DAO.DTOs
{
    public class OutMotorcycleQueryDto
    {
        public Guid Id { get; set; }
        public short Year { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
