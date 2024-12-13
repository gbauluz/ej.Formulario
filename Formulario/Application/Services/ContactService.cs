using Formulario.Application.DTOs;
using Formulario.Domain.Interfaces;
using Formulario.Domain.Models;

namespace Formulario.Application.Services
{
    public class ContactService
    {
        private readonly IContactRepo _contactRepo;
        public event Action? OnStateChanged;


        public ContactService(IContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public void GuardarContacto(ContactoForm contactoForm)
        {
            _contactRepo.SaveContact(MapContactoFormToContactoFormModel(contactoForm));
        }

        public Contacto ObtenerContacto()
        {
            return _contactRepo.GetContact();
        }

        //Cuando el método es llamado desde el onclick del formulario, lanza el evento OnStateChanged
        //Al hacerlo, lanza el StateHasChanged de los resultados del form, pues está suscrito a este evento.
        public void NotifyStateChanged() => OnStateChanged?.Invoke(); //Para servicio singleton, InvokeAsync()

        private Contacto MapContactoFormToContactoFormModel(ContactoForm contactoForm)
        {
            var contacto = new Contacto
            {
                Nombre = contactoForm.Nombre,
                Apellidos = contactoForm.Apellidos,
                Correo = contactoForm.Correo,
                Password = contactoForm.Password, 
                Nickname = contactoForm.Nickname
            };
            //Repetir Password sólo lo utilizamos para el formulario, por lo que Contacto no tiene esa propiedad.
            //Mapeamos manualmente
            return contacto;
        }
    }
}
