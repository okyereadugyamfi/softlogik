using System;
using System.Collections.Generic;
using System.Text;

namespace SoftLogik.Miscellaneous
{
    public static class ParameterUtils
    {
        public static void ValidateStringNotNullOrEmpty(string value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);

            if (value.Length == 0)
                throw new ArgumentException(string.Format("{0} parameter must not be empty", parameterName), parameterName);
        }
    }
}
