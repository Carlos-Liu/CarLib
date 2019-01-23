using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Carlib.Web.Validation
{
  public class TrimAttribute : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      //return when not string
      if (!(value is string)) return ValidationResult.Success;

      value = value.ToString().Trim();

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