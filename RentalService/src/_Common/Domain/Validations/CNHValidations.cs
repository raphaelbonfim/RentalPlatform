using System.Text.RegularExpressions;

namespace Common.Domain.Validations
{
    public static class CNHValidations
    {
        public static bool MustBeValidCNHNumber(string cnhNumber)
        {
            if(cnhNumber.Length != 11) return false;
            var pattern = new Regex(@"([0-9]{11})");

            return pattern.Match(cnhNumber).Success;         
        }
    }
}
