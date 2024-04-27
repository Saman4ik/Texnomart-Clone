using FluentValidation.Results;
using System.Text;
using Texnomart.Aplication.Common.Exceptions;

namespace Texnomart.Aplication.Common.Validators;

public static class Extension
{
    public static string GetErrorMessages(this ValidationResult result)
    {
        var resultMessage = new StringBuilder();
        foreach (var error in result.Errors)
        {
            resultMessage.Append(error.ErrorMessage);
        }
        return resultMessage.ToString();
    }
}
