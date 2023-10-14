using Microsoft.Extensions.Options;
using NetCoreWebAPI.Models;

namespace NetCoreWebAPI
{
    public class SmtpConfigurationValidation : IValidateOptions<SmtpOptions>
    {
        public ValidateOptionsResult Validate(string? name, SmtpOptions options)
        {
            if (string.IsNullOrEmpty(options.Port))
            {
                return ValidateOptionsResult.Fail("Port is required field");
            }
            if(string.IsNullOrEmpty(options.Server))
            {
                return ValidateOptionsResult.Fail("Server is required field");
            }
            if (string.IsNullOrEmpty(options.FromAddress))
            {
                return ValidateOptionsResult.Fail("FromAddress is required field");
            }
            return ValidateOptionsResult.Success;
        }
    }
}
