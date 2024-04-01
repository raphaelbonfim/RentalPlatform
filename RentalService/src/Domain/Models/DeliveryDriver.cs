using Common.Application;
using Common.Domain;
using Domain.Validations;
using FluentValidation.Results;

namespace Domain.Models
{
    public class DeliveryDriver : Aggregate
    {
        protected DeliveryDriver() { }

        public DeliveryDriver(
            string name,
            string cnpj,
            DateTime birthdate,
            string cnhNumber,
            string base64,
            string cnhType,
            Guid id = default
            )
        {
            Id = id;
            Name = name;
            CNPJ = cnpj;
            CNH = new CNH(cnhNumber, UpdateCNH(base64), ConvertCNHType(cnhType));
            Birthdate = birthdate;

            CheckInvariants(this, new CreateDeliveryDriverInvariants(base64), new List<ValidationResult>
            {
                CNH.ValidationResult
            });
        }

        protected ICollection<Delivery> Deliverieslist { get; set; }
        public virtual IReadOnlyCollection<Delivery> Deliveries => Deliverieslist.ToList();
        public virtual string Name { get; protected set; }
        public virtual string CNPJ { get; protected set; }
        public virtual CNH CNH { get; protected set; }
        public virtual DateTime Birthdate { get; protected set; }

        public virtual string UpdateCNH(string base64image)
        {
            return SaveCnhImage(base64image);
        }

        private string SaveCnhImage(string base64Image)
        {
            try
            {
                // Decodifica a string base64 para um array de bytes
                byte[] imageBytes = Convert.FromBase64String(base64Image);

                string destinationDirectory = @"C:\CnhsSalvas";

                //Pega o tipo da imagem
                var imageType = GetImageType(base64Image);

                //Cria o nome da imagem
                string imageName = Guid.NewGuid().ToString() + imageType;

                // Verifica se a pasta de destino existe, caso contrário, cria
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Define o caminho completo para salvar a imagem
                string caminhoCompleto = Path.Combine(destinationDirectory, imageName);

                // Salva a imagem
                using (FileStream fs = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    fs.Write(imageBytes, 0, imageBytes.Length);
                }

                // Retorna o caminho onde a imagem foi salva
                return caminhoCompleto;
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna uma mensagem de erro
                return $"Erro ao salvar a imagem: {ex.Message}";
            }
        }

        public virtual void AddDelivery() { }
        public virtual void AcceptDelivery() { }
        public virtual void RejectDelivery() { }
        public virtual void CloseDelivery() { }


        public virtual ECnhType ConvertCNHType(string inCnhType)
        {
            var cnhType = Enum.Parse<ECnhType>(inCnhType);

            if (cnhType == null)
                throw new BusinessException("Tipo CNH informado Inválido");

            return cnhType;
        }

        private string GetImageType(string base64image)
        {          
            var imageType = "";

            if (base64image.StartsWith("iVBORw0KGgo"))
            {
                return imageType = ".png";
            }

            if (base64image.StartsWith("Qk2Keww"))
            {
                return imageType = ".bpm";

            }
            return imageType;
        }

        public virtual ECnhType GetCNHType()
        {
            return CNH.CnhType;
        }
    }
}
