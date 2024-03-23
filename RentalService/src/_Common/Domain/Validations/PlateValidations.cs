using System.Text.RegularExpressions;

namespace Common.Domain.Validations
{
    public static class PlateValidations
    {
        public static bool MustBeValidPlate(string plate)
        {
            if (plate.Length != 7) return false;
            var pattern = new Regex(@"[A-Z]{3}[0-9][0-9A-Z][0-9]{2}");
            return pattern.Match(plate.ToUpper()).Success;
        }
    }
}
