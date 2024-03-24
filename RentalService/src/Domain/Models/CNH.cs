using Common.Domain;

namespace Domain.Models
{
    public class CNH : ValueObject<CNH>
    {
        public CNH() { }

        public CNH(int number, string imageUrl, ECnhType cnhType)
        {
            Number = number;
            ImageUrl = imageUrl;
            CnhType = cnhType;
        }

        public virtual int Number { get; private set; }
        public virtual string ImageUrl { get; private set; }
        public virtual ECnhType CnhType { get; private set; }

        protected override IEnumerable<object> AttributesToEqualityCheck()
        {
            throw new NotImplementedException();
        }
    }
}
