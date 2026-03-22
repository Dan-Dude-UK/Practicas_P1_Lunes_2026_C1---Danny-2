using System;
using System.Collections.Generic;
using System.Linq;

namespace Contactes
{
    public class ContactManager
    {
        private readonly List<Contact> _contacts = new List<Contact>();

        public void AddContact()
        {
            var id = _contacts.Count + 1;
            Console.WriteLine("Vamos a agregar ese contacte que te trae loco.");
            Console.Write("Digite el Nombre: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("Digite el Teléfono: ");
            var phone = Console.ReadLine() ?? string.Empty;
            Console.Write("Digite el Email: ");
            var email = Console.ReadLine() ?? string.Empty;
            Console.Write("Digite la dirección: ");
            var address = Console.ReadLine() ?? string.Empty;

            var contact = new Contact
            {
                Id = id,
                Name = name,
                Phone = phone,
                Email = email,
                Address = address
            };

            _contacts.Add(contact);
            Console.WriteLine();
        }

        public void ViewContacts()
        {
            Console.WriteLine("Id           Nombre          Telefono            Email           Dirección");
            Console.WriteLine("___________________________________________________________________________");

            foreach (var c in _contacts)
            {
                Console.WriteLine($"{c.Id}    {c.Name}      {c.Phone}      {c.Email}     {c.Address}");
            }
        }

        public void EditContact()
        {
            ViewContacts();
            Console.WriteLine("Digite un  Id de Contacto Para Editar");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Id inválido");
                return;
            }

            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                Console.WriteLine("Contacto no encontrado");
                return;
            }

            Console.Write($"El nombre es: {contact.Name}, Digite el Nuevo Nombre: ");
            var name = Console.ReadLine() ?? contact.Name;
            contact.Name = name;

            Console.Write($"El Teléfono es: {contact.Phone}, Digite el Nuevo Teléfono: ");
            var phone = Console.ReadLine() ?? contact.Phone;
            contact.Phone = phone;

            Console.Write($"El Email es: {contact.Email}, Digite el Nuevo Email: ");
            var email = Console.ReadLine() ?? contact.Email;
            contact.Email = email;

            Console.Write($"La dirección es: {contact.Address}, Digite la nueva dirección: ");
            var address = Console.ReadLine() ?? contact.Address;
            contact.Address = address;
        }

        public void DeleteContact()
        {
            ViewContacts();
            Console.WriteLine("Digite un Id de Contacto Para Eliminar");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Id inválido");
                return;
            }

            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                Console.WriteLine("Contacto no encontrado");
                return;
            }

            Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
            if (!int.TryParse(Console.ReadLine(), out var opcion) || opcion != 1)
            {
                Console.WriteLine("Operación cancelada");
                return;
            }

            _contacts.Remove(contact);
            // Reassign ids to keep them sequential
            for (int i = 0; i < _contacts.Count; i++)
            {
                _contacts[i].Id = i + 1;
            }
        }

        public void SearchContact()
        {
            ViewContacts();
            Console.WriteLine("Digite un Id de Contacto Para Mostrar");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Id inválido");
                return;
            }

            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                Console.WriteLine("Contacto no encontrado");
                return;
            }

            Console.WriteLine($"El nombre es: {contact.Name}");
            Console.WriteLine($"El Teléfono es: {contact.Phone}");
            Console.WriteLine($"El Email es: {contact.Email}");
            Console.WriteLine($"La dirección es: {contact.Address}");
        }
    }
}
