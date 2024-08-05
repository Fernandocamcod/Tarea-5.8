using System;

class Program
{
    static void Main()
    {
        decimal saldo = 1000.00m; // Saldo inicial
        bool continuar = true;

        do
        {
            Console.WriteLine("Cajero Automático:");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Retirar dinero");
            Console.WriteLine("3. Depositar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ConsultarSaldo(saldo);
                    break;
                case "2":
                    saldo = RetirarDinero(saldo);
                    break;
                case "3":
                    saldo = DepositarDinero(saldo);
                    break;
                case "4":
                    continuar = false;
                    Console.WriteLine("Saliendo del cajero automático...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 4.");
                    break;
            }

            Console.WriteLine(); // Agrega una línea en blanco para la siguiente iteración

        } while (continuar);

        // Mantiene la consola abierta hasta que el usuario presione una tecla
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    static void ConsultarSaldo(decimal saldo)
    {
        Console.WriteLine($"Tu saldo actual es: {saldo:C}");
    }

    static decimal RetirarDinero(decimal saldo)
    {
        Console.Write("Introduce la cantidad a retirar: ");
        string input = Console.ReadLine();

        if (decimal.TryParse(input, out decimal cantidad) && cantidad > 0)
        {
            if (cantidad <= saldo)
            {
                saldo -= cantidad;
                Console.WriteLine($"Has retirado {cantidad:C}. Tu nuevo saldo es: {saldo:C}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor, introduce una cantidad positiva.");
        }

        return saldo;
    }

    static decimal DepositarDinero(decimal saldo)
    {
        Console.Write("Introduce la cantidad a depositar: ");
        string input = Console.ReadLine();

        if (decimal.TryParse(input, out decimal cantidad) && cantidad > 0)
        {
            saldo += cantidad;
            Console.WriteLine($"Has depositado {cantidad:C}. Tu nuevo saldo es: {saldo:C}");
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor, introduce una cantidad positiva.");
        }

        return saldo;
    }
}
