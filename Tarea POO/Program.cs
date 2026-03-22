using System;
using Contactes;

var manager = new ContactManager();

Console.WriteLine("Mi Agenda Perrón");
Console.WriteLine("Bienvenido a tu lista de contactes");

bool running = true;
while (running)
{
    Console.Write("1. Agregar Contacto      ");
    Console.Write("2. Ver Contactos     ");
    Console.Write("3. Buscar Contactos      ");
    Console.Write("4. Modificar Contacto        ");
    Console.Write("5. Eliminar Contacto     ");
    Console.WriteLine("6. Salir");
    Console.Write("Elige una opción: ");

    if (!int.TryParse(Console.ReadLine(), out var choice))
    {
        Console.WriteLine("Opción no válida");
        continue;
    }

    switch (choice)
    {
        case 1:
            manager.AddContact();
            break;
        case 2:
            manager.ViewContacts();
            break;
        case 4:
            manager.EditContact();
            break;
        case 5:
            manager.DeleteContact();
            break;
        case 3:
            manager.SearchContact();
            break;
        case 6:
            running = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }
}
