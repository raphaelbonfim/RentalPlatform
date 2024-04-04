namespace Application.DTOs.DeliveryDriver
{
    public class InUpdateDeliveryDriverDTO
    {
        public Guid Id { get; set; }
        public string CNHNumber { get; set; }
        public string CNHBase64 { get; set; }
        public string CNHType { get; set; }
    }
}
