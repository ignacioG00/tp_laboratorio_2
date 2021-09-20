using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el char recibido sea un operador matematico
        /// </summary>
        /// <param name="operador">a validar</param>
        /// <returns>retorna operador validado, caso contrario "+"</returns>
        private static char ValidarOperador(char operador)
        {
            char retorno;
            retorno = '+';
            if (operador == '+' || operador == '-' ||
                operador == '/' || operador == '*')
            {
                return operador;
            }
            return retorno;
        }
        /// <summary>
        /// Realiza una operacion matematica
        /// </summary>
        /// <param name="num1">tipo operando</param>
        /// <param name="num2">tipo operando</param>
        /// <param name="operador"> operador matematico</param>
        /// <returns>Retorna resultado de operacion matematica en double</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
            {
            double result = 0;
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
            }
            return result;
            }
    }
}
