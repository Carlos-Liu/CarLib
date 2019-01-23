using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.Security.Application;

namespace Carlib.Web.Validation
{
  public class AntiXssAttribute : ValidationAttribute
  {
    private const string MessageUserInputInvalid = "The field is mandatory.";

    public bool IsRequired { get; set; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      //return when not string
      if (!(value is string)) return ValidationResult.Success;

      value = Sanitizer.GetSafeHtmlFragment(value.ToString()).Trim();
      if (IsRequired && string.IsNullOrEmpty(value.ToString()))
      {
        return new ValidationResult(MessageUserInputInvalid);
      }

      //get property value
      var propertyValue = validationContext.ObjectType.GetProperty(validationContext.MemberName, BindingFlags.Public | BindingFlags.Instance);

      //set property value
      if (propertyValue != null)
      {
        propertyValue.SetValue(validationContext.ObjectInstance, value);
      }

      return ValidationResult.Success;
    }
  }
}