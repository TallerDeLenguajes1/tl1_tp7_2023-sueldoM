﻿// See https://aka.ms/new-console-template for more information
using System;
using EspacioCalculadora;

namespace TuEspacioDeNombre
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
                    char operacion = input[0];
                    double valor = double.Parse(input.Substring(1));

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
