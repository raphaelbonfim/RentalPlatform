namespace Application.DTOs.DeliveryDriver
{
    public class InCreateRentalDTO
    {
        public Guid DeliveryDriverId { get; set; }
        public Guid MotorcycleId { get; set; }
        public Guid RentalPlanId { get; set; }   
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ForecastEndDate { get; set; }
        public string Days { get; set; }
        public string PricePerDay { get; set; }
    }
}
