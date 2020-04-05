using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        private string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }
        #endregion

        #region Métodos

        #region Constructores
        public Numero() : this(0)
        {

        }

        public Numero(double numero) : this(numero.ToString())
        {
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Validador
        private double ValidarNumero(string strNumero)
        {
            if (!double.TryParse(strNumero, out double returnNumero))
            {
                returnNumero = 0;
            }
            return returnNumero;
        }
        #endregion

        #region Conversores
        public string BinarioDecimal(string binario)
        {
            double numeroDecimal = 0;
            double auxDecimal, absoluto;
            string absolutobin;

            auxDecimal = Double.Parse(binario);
            absoluto = Math.Abs(auxDecimal);
            absolutobin = Convert.ToString(absoluto);

            for (int i = 0; i <= absolutobin.Length - 1; i++)
            {
                double.TryParse(absolutobin[i].ToString(), out double binarioParsed);
                if (binarioParsed == 1 || binarioParsed == 0)
                {
                    numeroDecimal += binarioParsed * Math.Pow(2, absolutobin.Length - i - 1);
                }
                else
                {
                    return "Valor invalido";
                }
            }
            return numeroDecimal.ToString();
        }

        public string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            double absoluto;
            absoluto = Math.Abs(numero);
            long cociente = (long)absoluto;
            long resto = (long)absoluto;

            while (cociente >= 1)
            {
                resto = cociente % 2;
                cociente = cociente / 2;

                if (resto != 0)
                {
                    numeroBinario = "1" + numeroBinario;
                }
                else
                {
                    numeroBinario = "0" + numeroBinario;
                }
            }
            return numeroBinario;
        }

        public string DecimalBinario(string numero)
        {
            string returnAux = "Valor invalido";

            if (double.TryParse(numero, out double cociente) && cociente > 0)
            {
                returnAux = this.DecimalBinario(cociente);
            }
            return returnAux;
        }

        #endregion

        #region Operadores
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }

        }

        #endregion

        #endregion
    }
}
