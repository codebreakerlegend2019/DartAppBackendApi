using DartAppSingapore.Models;
using System.Collections.Generic;

namespace DartAppSingapore.Helpers
{
    public static class ErrorHelper
    {
        public static List<Error> PutError(params string [] errors)
        {
            var result = new List<Error>();
            foreach (var error in errors)
                result.Add(new Error(error));
            return result;
        }
    }
}
