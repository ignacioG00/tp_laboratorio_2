using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        #region Atributos
        private double numero;//ATRIBUTO
        #endregion
        #region Propiedades
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor inicializado en 0 por defecto
        /// </summary>
        public Operando() //CONSTRUCTOR X DEFECTO
        {
            this.numero = 0;
        }
        /// <summary>
        /// Sobrecarga de constructor con double
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Sobrecarga de constructor con string
        /// </summary>
        /// <param name="numero"></param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        #endregion
        #region Validaciones
        /// <summary>
        /// Valida si el operando recibido es un operando valido
        /// </summary>
        /// <param name="binario"> String a verificar </param>
        /// <returns> Retorna true en caso valido o false </returns>
        public static double ValidarOperando(string strNumero) //METODO
        {
            double auxNum = 0;
            if (strNumero.All(char.IsDigit))
            {
                auxNum = double.Parse(strNumero);
            }
            return auxNum;
        }
        /// <summary>
        /// Valida si el numero es binario
        /// </summary>
        /// <param name="binario"> String a verificar </param>
        /// <returns> Retorna true en caso valido o false </returns>
        private static bool EsBinario(string binario)
        {
            bool auxRet = true;

            foreach (char caracter in binario)
            {
                if (caracter != '1' && caracter != '0')
                {
                    auxRet = false;
                }
            }
            return auxRet;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Convierte binario a decimal
        /// </summary>
        /// <param name="numero"> Atributo a convertir </param>
        /// <returns> Retorna el decimal en string, msj error caso contrario </returns>
        public string BinarioDecimal(string binario)
        {
            int resultado = 0;
            int cantidadCaracteres = binario.Length;

            if (EsBinario(binario))
            {
                foreach (char caracter in binario)
                {
                    cantidadCaracteres--;
                    if (caracter == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }
                return resultado.ToString();
            }
            else
            {
                return "Valor Invalido";
            }
        }
        /// <summary>
        /// Convierte decimal a binario
        /// </summary>
        /// <param name="numero"> Atributo a convertir </param>
        /// <returns> Retorna el valor binario en string </returns>
        public string DecimalBinario(double numero)
        {
            string auxBin = string.Empty;
            int numAbsoluto = (int)Math.Abs(numero);
            if (numAbsoluto == 0)
            {
                auxBin = "0";
            }
            while (numAbsoluto > 0)
            {
                auxBin = (int)numAbsoluto % 2 + auxBin;
                numAbsoluto = (int)numAbsoluto / 2;
            }
            return auxBin;
        }
        /// <summary>
        /// Convierte decimal a binario
        /// </summary>
        /// <param name="numero"> Atributo a convertir </param>
        /// <returns> Retorna el valor binario en string, caso contrario devuelve un msj de error </returns>
        public string DecimalBinario(string numero)
        {
            if (Double.TryParse(numero, out double numDecimal))
            {
                return DecimalBinario(numDecimal);
            }
            return "Valor Invalido, vuelva a intentar";
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Sobrecarga de operador -
        /// </summary>
        /// <param name="n1">tipo Operando</param>
        /// <param name="n2">tipo Operando</param>
        /// <returns>valor de operacion en double</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return (n1.numero - n2.numero);
        }
        /// <summary>
        /// Sobrecarga de operador -
        /// </summary>
        /// <param name="n1">tipo Operando</param>
        /// <param name="n2">tipo Operando</param>
        /// <returns>valor de operacion en double</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return (n1.numero * n2.numero);
        }
        /// <summary>
        /// Sobrecarga de operador -
        /// </summary>
        /// <param name="n1">tipo Operando</param>
        /// <param name="n2">tipo Operando</param>
        /// <returns>valor de operacion en double, error en caso de que sea 0</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return Double.MinValue;
            }
            return (n1.numero / n2.numero);
        }
        /// <summary>
        /// Sobrecarga de operador -
        /// </summary>
        /// <param name="n1">tipo Operando</param>
        /// <param name="n2">tipo Operando</param>
        /// <returns>valor de operacion en double</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        #endregion
    }
}
