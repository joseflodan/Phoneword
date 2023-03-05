using System.Text;

namespace Phoneword
{
    public static class PhonewordTranslator
    {
        public static string ToNumber(string raw)
        {
            // raw = "Hola soy Jose"
            if (string.IsNullOrWhiteSpace(raw))
                return null;

            raw = raw.ToUpperInvariant();
            // raw = "HOLA SOY JOSE"

            var newNumber = new StringBuilder();
            foreach (var letra in raw)
            {
                if (" -0123456789".Contains(letra))
                    newNumber.Append(letra);
                else
                {
                    var result = TranslateToNumber(letra);
                    if (result != null)
                        newNumber.Append(result);
                    else
                        return null;
                }
            }
            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        static readonly string[] digits = {
        "ABC", "DEF", "GHI", "JKL", "MNÑO", "PQRS", "TUV", "WXYZ"
        };

        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}

