using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador recibido como parametro.
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>El operador, en caso de ser +, -, / o *, sino retorna un signo + por defecto</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }
            return '+';
        }
        /// <summary>
        /// Recibe los 2 objetos de tipo Numero y realiza la operacion correspondiente al operador recibido.
        /// </summary>
        /// <param name="num1">Objeto Numero</param>
        /// <param name="num2">Objeto Numero</param>
        /// <param name="operador">El operador de tipo string</param>
        /// <returns>El resultado de la operacion o 0 en caso de que el operador sea incorrecto</returns>
        public static double Operar(Numero num1, Numero num2, char operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}
