namespace Application.DTOs.DeliveryDriver
{
    public class InRentMotorcycleDTO
    {
        public Guid DeliveryDriverId { get; set; }
        public Guid RentalPlanId { get; set; }
        public Guid MotorcycleId { get; set; }
    }
}
