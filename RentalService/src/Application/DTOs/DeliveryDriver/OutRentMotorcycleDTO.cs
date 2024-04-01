namespace Application.DTOs.DeliveryDriver
{
    public class OutRentMotorcycleDTO
    {
        public Guid RentalId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ChosenPlanDescription { get; set; }
    }
}
