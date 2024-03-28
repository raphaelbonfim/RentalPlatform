using Common.Domain;
using Domain.Validations;

namespace Domain.Models
{
    public class CNH : ValueObject<CNH>
    {
        protected CNH() { }

        public CNH(int number, string imageUrl, ECnhType cnhType)
        {
            Number = number;
            ImageUrl = imageUrl;
            CnhType = cnhType;

            CheckInvariants(this, new CreateCNHInvariants()); //Verificar se está correto
        }

        public virtual int Number { get; protected set; }
        public virtual string ImageUrl { get; protected set; }
        public virtual ECnhType CnhType { get; protected set; }

        protected override IEnumerable<object> AttributesToEqualityCheck()
        {
            return new object[] { Number, ImageUrl, CnhType };
        }
    }
}
