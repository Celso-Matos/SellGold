using System;
using System.Collections.Generic;
using System.Text;

namespace SellGold.Utils
{
    public class Action
    {
        public static string FormatCep(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            var digits = value.Replace("-", "");

            if (digits.Length <= 5)
                return digits;

            return $"{digits[..5]}-{digits[5..Math.Min(8, digits.Length)]}";
        }
        public static bool IsCepCompleto(string cep)
        {
            return !string.IsNullOrWhiteSpace(cep)
                   && cep.Length == 9
                   && cep[5] == '-';
        }

    }
}
