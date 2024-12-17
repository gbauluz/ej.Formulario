using System.Diagnostics.Contracts;
using Formulario.Application.DTOs;
using Formulario.Domain.Interfaces;
using Formulario.Domain.Models;

namespace Formulario.Infraestructure.Repositories
{
    public class ContactRepo : IContactRepo
    {
        private Contacto _contacto = default!;
        public ContactRepo()
        {
                
        }

        public void SaveContact(Contacto contacto) => _contacto = contacto;


        public Contacto GetContact() => _contacto;

    }
}
