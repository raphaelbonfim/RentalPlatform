namespace Application.DTOs.DeliveryDriver
{
    public class InOpenRentMotorcycleDTO
    {
        public Guid DeliveryDriverId { get; set; }
        public Guid RentalPlanId { get; set; }
        public Guid MotorcycleId { get; set; }
    }
}
