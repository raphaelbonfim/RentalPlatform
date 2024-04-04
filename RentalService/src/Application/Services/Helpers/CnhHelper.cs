using Common.Application;
using Domain.Models;

namespace Application.Services.Utils
{
    public static class CnhHelper
    {

        private static readonly string _filePath = @"C:\CnhsSalvas";

        public static ECnhType GetCnhType(string inCnhType)
        {
            try
            {
                return Enum.Parse<ECnhType>(inCnhType);

            }
            catch
            {
                throw new BusinessException("Tipo CNH informado Inválido");
            }
        }

        public static string GetImageUrl(Guid deliveryDriverId, string base64)
        {
            var fileExtention = GetFileExtention(base64);
            if (fileExtention is null)
                throw new BusinessException("Imagem CNH inválida. Tipos aceitos: PNG ou BMP");

            if (!Directory.Exists(_filePath))
                Directory.CreateDirectory(_filePath);

            var fileName = $"{deliveryDriverId.ToString()}.{fileExtention}";

            return Path.Combine(_filePath, fileName);
        }

        public static void SaveCnhImage(string base64Image, string imageUrl)
        {
            try
            {
                // Decodifica a string base64 para um array de bytes
                byte[] imageBytes = Convert.FromBase64String(base64Image);

                // Verifica se a pasta de destino existe, caso contrário, cria
                // Salva a imagem
                using FileStream fs = new FileStream(imageUrl, FileMode.Create);
                fs.Write(imageBytes, 0, imageBytes.Length);

            }
            catch (Exception ex)
            {
                throw new BusinessException($"Erro ao salvar a imagem: {ex.Message}");
            }
        }

        private static string? GetFileExtention(string base64)
        {
            var pngType = "iVB"; 
            var bmpType = "Qk2";

            var validType = base64.StartsWith(pngType) || base64.StartsWith(bmpType);
            if (!validType)
                return null;

            if (base64.StartsWith(bmpType))
                return "bmp";
            else
                return "png";
        }
    }
}
