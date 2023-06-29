using System;

namespace EspacioCalculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculadora calculadora = new Calculadora();

            bool salir = false;

            while (!salir)
            {
                string input = "";

                while (true)
                {
                    Console.WriteLine("Ingrese una operación (+, -, *, /) seguida del valor o 'exit' para salir:");
                    input = Console.ReadLine();

                    if (input == null)
                    {
                        Console.WriteLine("Entrada inválida. Inténtelo de nuevo.");
                        continue;
                    }

                    if (string.IsNullOrEmpty(input.Trim()))
                    {
                        Console.WriteLine("Entrada inválida. Inténtelo de nuevo.");
                        continue;
                    }
                    break;
                }
                if (input.ToLower() == "exit")
                {
                    salir = true;
                }
                else
                {
                    if (input.Length <= 1)
                    {
                        Console.WriteLine("Entrada inválida. Inténtelo de nuevo.");
                        continue;
                    }

                    char operacion = input[0]; // Obtener el primer carácter de la entrada

                    string numericInput = input.Substring(1);
                    if (!double.TryParse(numericInput, out double valor))
                    {
                        Console.WriteLine("Valor numérico inválido. Inténtelo de nuevo.");
                        continue;
                    }

                    switch (operacion)
                    {
                        case '+':
                            calculadora.Sumar(valor);
                            break;
                        case '-':
                            calculadora.Restar(valor);
                            break;
                        case '*':
                            calculadora.Multiplicar(valor);
                            break;
                        case '/':
                            calculadora.Dividir(valor);
                            break;
                        default:
                            Console.WriteLine("Operación no válida");
                            break;
                    }

                    Console.WriteLine("Resultado: " + calculadora.Resultado);
                }
            }
        }
    }
}
