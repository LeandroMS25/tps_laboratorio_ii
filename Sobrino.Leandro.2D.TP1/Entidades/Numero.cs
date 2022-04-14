using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Constructor por defecto que inicializa el atributo numero en 0;
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que recibe un numero double y lo guarda en el atributo;
        /// </summary>
        public Numero(double numero) : this()
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que recibe un numero como string y lo guarda en el atributo;
        /// </summary>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Retorna un numero.
        /// </summary>
        /// <returns>Atributo numero del objeto</returns>
        public double GetNumero()
        {
            return this.numero;
        }
        /// <summary>
        /// Guarda el numero luego de validarlo.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// Verifica si la cadena de caracteres recibida como parametro es un numero.
        /// </summary>
        /// <param name="strNumero">string</param>
        /// <returns>El numero convertido en double o 0 en caso de no tratarse de un numero</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero = 0;
            strNumero = strNumero.Replace('.', ',');
            double.TryParse(strNumero, out numero);
            return numero;
        }
        /// <summary>
        /// Verifica si la cadena de caracteres recibida como parametro es un numero binario.
        /// </summary>
        /// <param name="binario">string</param>
        /// <returns>True en caso de que sea binario y false en caso que tenga caracteres diferentes de 0 y 1</returns>
        private bool EsBinario(string binario)
        {
            foreach (char caracter in binario)
            {
                if (!(caracter == '0' || caracter == '1'))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Convierte la cadena recibida a numero decimal, en caso de validar que sea un numero binario.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>El numero decimal en caso de recibir uno binario, sino retorna "Valor inválido"</returns>
        public string BinarioDecimal(string binario)
        {
            double total = 0;
            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[i] == '1')
                    {
                        total = total + Math.Pow(2, binario.Length - i - 1);
                    }
                }
                return total.ToString();
            }
            return "Valor inválido";
        }
        /// <summary>
        /// Convierte un numero decimal a binario.
        /// </summary>
        /// <param name="numero">Un numero como string</param>
        /// <returns>Retorno un numero binario en forma de string o "Valor invalido" en caso de no ser posible convertir</returns>
        public string DecimalBinario(string numero)
        {
            double num;
            if (double.TryParse(numero, out num))
            {
                long binarioNum = (long)Math.Abs(num);
                string binario = String.Empty;
                do
                {
                    binario = Convert.ToString(binarioNum % 2) + binario;
                    binarioNum = binarioNum / 2;
                } while (binarioNum >= 1);
                return binario;
            }
            return "Valor inválido";
        }
        /// <summary>
        /// Convierte un numero decimal a binario.
        /// </summary>
        /// <param name="numero">Un numero como double</param>
        /// <returns>Retorno un numero binario en forma de string</returns>
        public string DecimalBinario(double numero)
        {
            long num = (long)Math.Abs(numero);
            string binario = String.Empty;
            do
            {
                binario = Convert.ToString(num % 2) + binario;
                num = num / 2;
            } while (num >= 1);
            return binario;
        }
        /// <summary>
        /// Permite usar el operador + para sumar entre Objeto Numero.
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>El resultado de la suma entre el atributo numero de ambos objetos</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Permite usar el operador - para dividir entre Objeto Numero.
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>El resultado de la resta entre el atributo numero de ambos objetos</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Permite usar el operador * para multiplicar entre Objeto Numero.
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>El resultado de la multiplicación entre el atributo numero de ambos objetos</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Permite usar el operador / para dividir entre Objeto Numero. Valida división por 0.
        /// </summary>
        /// <param name="n1">Objeto Numero</param>
        /// <param name="n2">Objeto Numero</param>
        /// <returns>El resultado de la disivión entre el atributo numero de ambos objetos</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = double.MinValue;
            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }
    }
}
