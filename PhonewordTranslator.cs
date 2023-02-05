using System.Text;
namespace Application
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
                    var result = TranslaterToNumber(letra);
                    if (result != null)
                        newNumer.Append(result);
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
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
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

