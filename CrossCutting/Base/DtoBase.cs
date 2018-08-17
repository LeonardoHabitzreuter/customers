using FluentValidation.Results;

namespace CrossCutting.Base
{
    public abstract class DtoBase
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}