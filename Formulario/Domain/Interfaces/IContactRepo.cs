using System.Diagnostics.Contracts;
using Formulario.Domain.Models;

namespace Formulario.Domain.Interfaces
{
    public interface IContactRepo
    {
        void SaveContact(Contacto contacto);
        //void SaveContact(Contacto contacto, string RepetirPassword);

        Contacto GetContact();
    }
}
