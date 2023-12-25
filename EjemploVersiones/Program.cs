using System;
using System.Collections.Generic;

class Tarea
{
    public string Descripcion { get; set; }
    public bool Completada { get; set; }
}

class Program
{
    static List<Tarea> tareas = new List<Tarea>();

    static void Main()
    {
        MostrarMenu();
    }

    static void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine("===== Gestor de Tareas =====");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Mostrar Tareas");
            Console.WriteLine("3. Marcar Tarea como Completada");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    MostrarTareas();
                    break;
                case "3":
                    MarcarComoCompletada();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void AgregarTarea()
    {
        Console.Write("Ingrese la descripción de la tarea: ");
        string descripcion = Console.ReadLine();
        Tarea nuevaTarea = new Tarea { Descripcion = descripcion, Completada = false };
        tareas.Add(nuevaTarea);
        Console.WriteLine("Tarea agregada con éxito.");
    }

    static void MostrarTareas()
    {
        Console.WriteLine("===== Lista de Tareas =====");
        for (int i = 0; i < tareas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. [{(tareas[i].Completada ? "X" : " ")}] {tareas[i].Descripcion}");
        }
    }

    static void MarcarComoCompletada()
    {
        MostrarTareas();
        Console.Write("Ingrese el número de la tarea completada: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tareas.Count)
        {
            tareas[indice - 1].Completada = true;
            Console.WriteLine("Tarea marcada como completada.");
        }
        else
        {
            Console.WriteLine("Número de tarea no válido.");
        }
    }
}
