namespace clientes_ms.Domain.Common
{
    public static class DigitoVerificadorHelper
    {
        /// <summary>
        /// Calcula el dígito verificador módulo 10 (algoritmo GTIN/SSCC).
        /// </summary>
        public static char CalcularModulo10(string baseCode)
        {
            int suma = 0;
            bool multiplicarPorTres = true;

            for (int i = baseCode.Length - 1; i >= 0; i--)
            {
                int digito = baseCode[i] - '0';
                suma += multiplicarPorTres ? digito * 3 : digito;
                multiplicarPorTres = !multiplicarPorTres;
            }

            int modulo = suma % 10;
            int resultado = modulo == 0 ? 0 : 10 - modulo;

            return resultado.ToString()[0];
        }

        /// <summary>
        /// Calcula el dígito verificador para GTIN-13 usando módulo 10.
        /// </summary>
        public static int CalcularGTIN13(string codigoSinDV)
        {
            int suma = 0;
            for (int i = 0; i < codigoSinDV.Length; i++)
            {
                int digito = int.Parse(codigoSinDV[i].ToString());
                suma += (i % 2 == 0) ? digito : digito * 3;
            }

            int modulo = suma % 10;
            return (modulo == 0) ? 0 : 10 - modulo;
        }
    }
}
