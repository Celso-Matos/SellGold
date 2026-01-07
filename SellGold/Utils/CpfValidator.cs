using System;
using System.Collections.Generic;
using System.Text;

namespace SellGold.Utils
{
    public static class CpfValidator
    {
        public static bool Validar(string cpf)
        {
            string numeros = ExtrairNumeros(cpf);
            return numeros.Length == 11 &&
                   !EhSequenciaRepetida(numeros) &&
                   ValidarDigitos(numeros);
        }

        private static string ExtrairNumeros(string cpf)
            => new string(cpf?.Where(char.IsDigit).ToArray() ?? Array.Empty<char>());

        private static bool EhSequenciaRepetida(string cpf)
            => cpf.All(c => c == cpf[0]);

        private static bool ValidarDigitos(string cpf)
        {
            int[] pesos1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesos2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string baseCpf = cpf.Substring(0, 9);

            int digito1 = CalcularDigito(baseCpf, pesos1);
            if (digito1 != int.Parse(cpf[9].ToString()))
                return false;

            int digito2 = CalcularDigito(baseCpf + digito1, pesos2);
            return digito2 == int.Parse(cpf[10].ToString());
        }

        private static int CalcularDigito(string numeros, int[] pesos)
        {
            int soma = numeros
                .Select((c, i) => (c - '0') * pesos[i])
                .Sum();

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        public static string Formatar(string cpf)
        {
            string numeros = ExtrairNumeros(cpf);
            return numeros.Length == 11
                ? $"{numeros.Substring(0, 3)}.{numeros.Substring(3, 3)}.{numeros.Substring(6, 3)}-{numeros.Substring(9, 2)}"
                : numeros;
        }
    }
}
