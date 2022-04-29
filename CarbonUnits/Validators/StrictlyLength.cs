using System.ComponentModel.DataAnnotations;
namespace CarbonUnits.Validators
{
    public class StrictlyLength: ValidationAttribute
    {
        int strLen { get; set; }
        public StrictlyLength(int len)
        {
            strLen = len;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            if (value == null)
                return new ValidationResult("Поле не может быть пустым");
            string result=(string)value;
            return (result.Length == strLen)
                ? ValidationResult.Success
                : new ValidationResult("Для данного поля установлено ограничение на длину - ровно " + strLen + " символов");
        }

    }
}
