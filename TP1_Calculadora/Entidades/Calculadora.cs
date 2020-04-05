using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Calculadora
    {
        #region Métodos
        
        #region Validador
        private static string ValidarOperador(string operador)
        {
            string returnOperador = operador;

            if ((operador != "+") && (operador != "-") && (operador != "*") && (operador != "/"))
            {
                returnOperador = "+";
            }
            return returnOperador;
        }
        #endregion

        #region Operador
        public double Operar(Numero num1, Numero num2, string operador)
        {
            string operadorValidado = Calculadora.ValidarOperador(operador);
            double resultado = 0;

            switch (operadorValidado)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

        #endregion

        #endregion
    }

}
