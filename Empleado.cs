using System;

public enum Cargos
{
    Auxiliar,
    Administrativo,
    Ingeniero,
    Especialista,
    Investigador
}

public class Empleado
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public char EstadoCivil { get; set; }
    public char Genero { get; set; }
    public DateTime FechaIngreso { get; set; }
    public double SueldoBasico { get; set; }
    public Cargos Cargo { get; set; }

    public int CalcularAntiguedad()
    {
        DateTime fechaActual = DateTime.Now;
        TimeSpan antiguedad = fechaActual - FechaIngreso;
        return antiguedad.Days / 365; // Devuelve la antigüedad en años
    }

    public int CalcularEdad()
    {
        DateTime fechaActual = DateTime.Now;
        TimeSpan edad = fechaActual - FechaNacimiento;
        return edad.Days / 365; // Devuelve la edad en años
    }

    public int CalcularAniosParaJubilacion()
    {
        int aniosFaltantes = 0;
        if (Genero == 'M')
        {
            int edadActual = CalcularEdad();
            aniosFaltantes = 65 - edadActual;
        }
        else if (Genero == 'F')
        {
            int edadActual = CalcularEdad();
            aniosFaltantes = 60 - edadActual;
        }
        return aniosFaltantes;
    }

    public double CalcularSalario()
    {
        double adicional = 0;
        int antiguedad = CalcularAntiguedad();

        // Calcular el adicional por antigüedad
        if (antiguedad <= 20)
            adicional = SueldoBasico * (antiguedad * 0.01);
        else
            adicional = SueldoBasico * 0.25;

        // Incrementar el adicional si el cargo es Ingeniero o Especialista
        if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
            adicional += adicional * 0.5;

        // Incrementar el adicional si es casado
        if (EstadoCivil == 'C')
            adicional += 15000;

        return SueldoBasico + adicional;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la cantidad de empleados:");
        int cantidadEmpleados = int.Parse(Console.ReadLine());

        Empleado[] empleados = new Empleado[cantidadEmpleados];

        for (int i = 0; i < cantidadEmpleados; i++)
        {
            Console.WriteLine("\nEmpleado #" + (i + 1));

            Console.Write("Ingrese el nombre: ");
            string? nombre = Console.ReadLine();

            Console.Write("Ingrese el apellido: ");
            string? apellido = Console.ReadLine();

            Console.Write("Ingrese la fecha de nacimiento (dd/mm/aaaa): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el estado civil (S - Soltero, C - Casado): ");
            char estadoCivil = Console.ReadLine().ToUpper()[0];

            Console.Write("Ingrese el género (M - Masculino, F - Femenino): ");
            char genero = Console.ReadLine().ToUpper()[0];

            Console.Write("Ingrese la fecha de ingreso en la empresa (dd/mm/aaaa): ");
            DateTime fechaIngreso = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el sueldo básico: ");
            double sueldoBasico = double.Parse(Console.ReadLine());

            Console.Write("Ingrese el cargo (0 - Auxiliar, 1 - Administrativo, 2 - Ingeniero, 3 - Especialista, 4 - Investigador): ");
            Cargos cargo = (Cargos)int.Parse(Console.ReadLine());

            empleados[i] = new Empleado
            {
                Nombre = nombre,
                Apellido = apellido,
                FechaNacimiento = fechaNacimiento,
                EstadoCivil = estadoCivil,
                Genero = genero,
                FechaIngreso = fechaIngreso,
                SueldoBasico = sueldoBasico,
                Cargo = cargo
            };
        }

        double montoTotalSalarios = 0;
        Empleado? empleadoMasProximoJubilarse = null;
        int aniosMasProximoJubilarse = int.MaxValue;

        foreach (Empleado empleado in empleados)
        {
            double salario = empleado.CalcularSalario();
            montoTotalSalarios += salario;

            int aniosParaJubilacion = empleado.CalcularAniosParaJubilacion();
            if (aniosParaJubilacion >= 0 && aniosParaJubilacion < aniosMasProximoJubilarse)
            {
                empleadoMasProximoJubilarse = empleado;
                aniosMasProximoJubilarse = aniosParaJubilacion;
            }
        }

        Console.WriteLine("\nMonto total de salarios: $" + montoTotalSalarios);
        Console.WriteLine("\nEmpleado más próximo a jubilarse:");
        Console.WriteLine("Nombre: " + empleadoMasProximoJubilarse.Nombre);
        Console.WriteLine("Apellido: " + empleadoMasProximoJubilarse.Apellido);
        Console.WriteLine("Antigüedad: " + empleadoMasProximoJubilarse.CalcularAntiguedad() + " años");
        Console.WriteLine("Edad: " + empleadoMasProximoJubilarse.CalcularEdad() + " años");
        Console.WriteLine("Años para jubilación: " + aniosMasProximoJubilarse + " años");
        Console.WriteLine("Salario: $" + empleadoMasProximoJubilarse.CalcularSalario());

        Console.ReadLine();
    }
}