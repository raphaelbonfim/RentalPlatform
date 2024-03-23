using Common.Domain;
using Domain.Validations;
using FluentValidation.Results;

namespace Domain.Models
{
    public class Motorcycle : Aggregate
    {
        protected Motorcycle(){}
        public Motorcycle(short year, string model, string plate, Guid id = default)
        {
            Id = id;
            Year = year;
            Model = model;
            Plate = plate;

            CheckInvariants(this, new CreateMotorcycleInvariants(), new List<ValidationResult>());
        }

        public virtual short Year { get; protected set; }
        public virtual string Model { get; protected set; }
        public virtual string Plate { get; protected set; }

        public virtual void ChangePlate(string plate)
        {
            Plate = plate;

            CheckInvariants(this, new ChangePlateInvariants(), new List<ValidationResult>());
        }
    }

}
