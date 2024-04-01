
namespace Domain.DAO.DTOs
{
    public class OutNotificatedDeliveryDriverQueryDto
    {
        public Guid DeliveryDriverId { get; set; }
        public string Name { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool DeliveryAvailableForAcceptance { get; set; }
        public string Status { get; set; }
    }
}
