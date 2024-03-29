using Domain.Models;

namespace Application.DTOs.DeliveryDriver
{
    public class InCreateDeliveryDriverDTO
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime Birthdate { get; set; }
        public string CNHNumber { get; set; }
        public string CNHBase64 { get; set; }
        public string CNHType { get; set; }  
    }
}
