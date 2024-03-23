using FluentValidation;
using FluentValidation.Results;

namespace Common.Domain;

public abstract class DomainValidationBase
{
    public virtual bool Valid { get; private set; }
    public virtual bool Invalid => !Valid;
    public virtual ValidationResult ValidationResult { get; private set; }

    protected InvariantResult CheckInvariants<T>(T domainObject, AbstractValidator<T> validator)
    {
        if (domainObject is Aggregate) 
            throw new ArgumentException("This method is only for no aggregates.");
            
        ValidationResult = validator.Validate(domainObject);
        Valid = ValidationResult.IsValid;
            
        return (Valid ? InvariantResult.Successful: InvariantResult.Failed);
    }

    protected InvariantResult CheckInvariants<T>(
        T aggregate, 
        AbstractValidator<T> validator, 
        IList<ValidationResult> domainModelObjectResults) 
        where T: Aggregate
    {
        if (domainModelObjectResults == null) 
            throw new ArgumentNullException(nameof(domainModelObjectResults));
            
        if (ValidationResult == null) 
            ValidationResult = new ValidationResult();

        foreach (var result in domainModelObjectResults)
        {
            for (int i = 0; i < result?.Errors.Count; i++)
            {
                ValidationResult.Errors.Add(result.Errors[i]);
            }
        }

        var rootValidationResult = validator.Validate(aggregate); 

        for (int i = 0; i < rootValidationResult.Errors.Count; i++)
        {
            ValidationResult.Errors.Add(rootValidationResult.Errors[i]);
        }

        Valid = ValidationResult.IsValid;
            
        return (Valid ? InvariantResult.Successful: InvariantResult.Failed);
    }
}