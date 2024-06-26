﻿using Common.Domain;
using Domain.Validations;
using FluentValidation.Results;

namespace Domain.Models
{
    public class Rental : Aggregate
    {
        protected Rental() { }

        public Rental(
            Guid deliveryDriverId,
            Guid motorcycleId,
            Guid rentalPlanId,
            short days,
            double pricePerDay,            
            Guid id = default
            )
        {
            Id = id;
            DeliveryDriverId = deliveryDriverId;
            MotorcycleId = motorcycleId;
            RentalPlanId = rentalPlanId;
            StartDate = DateTime.Today.AddDays(1);
            EndDate = null;
            ForecastEndDate = StartDate.AddDays(days);
            Days = days;
            PricePerDay = pricePerDay;            

            CheckInvariants(this, new CreateRentalInvariants(), new List<ValidationResult>());
        }

        public virtual Guid DeliveryDriverId { get; protected set; }
        public virtual Guid MotorcycleId { get; protected set; }
        public virtual Guid RentalPlanId { get; protected set; }
        public virtual DateTime StartDate { get; protected set; }
        public virtual DateTime? EndDate { get; protected set; }
        public virtual DateTime ForecastEndDate { get; protected set; }
        public virtual short Days { get; protected set; }
        public virtual double RentalValue { get; protected set; }
        public virtual double PricePerDay { get; protected set; }
        public virtual double FineValue { get; protected set; }
        public virtual double ExtraDailyValue { get; protected set; }
        public virtual double TotalValue { get; protected set; }


        public virtual void CloseRental(double fineValueToEarlyReturn, double extraDailyFee, DateTime returnedDate)
        {
            returnedDate = returnedDate.Date;

            if (returnedDate < ForecastEndDate)
                FineValue = CalculateFineValue(returnedDate, fineValueToEarlyReturn);

            if (returnedDate > ForecastEndDate)
                ExtraDailyValue = CalculateExtraDailyValue(returnedDate, extraDailyFee);

            EndDate = returnedDate;   

            var daysUsed = (returnedDate - StartDate).TotalDays;

            RentalValue = returnedDate > ForecastEndDate ? Days * PricePerDay : daysUsed * PricePerDay;

            TotalValue = RentalValue + FineValue + ExtraDailyValue;

            CheckInvariants(this, new CloseRentalMotorcycleInvariants(), new List<ValidationResult>());
        }   

        private double CalculateFineValue(DateTime returnedDate, double fineValueToEarlyReturn)
        {
            var daysDiff = (ForecastEndDate - returnedDate.Date).TotalDays;
            var dailyDiffValue = daysDiff * PricePerDay;

            return fineValueToEarlyReturn/100 * dailyDiffValue;
        }

        private double CalculateExtraDailyValue(DateTime returnedDate, double fineValueToEarlyReturn)
        {
            var daysDiff = (returnedDate - ForecastEndDate.Date).TotalDays;

            return fineValueToEarlyReturn * daysDiff;
        }
    }
}
