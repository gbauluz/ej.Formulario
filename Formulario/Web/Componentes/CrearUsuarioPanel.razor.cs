using Formulario.Application.DTOs;

namespace Formulario.Componentes
{
    public partial class CrearUsuarioPanel
    {
        private ContactoForm? contactoProcesado;

        private void ProcesarContacto(ContactoForm contactoHijo)
        {
            contactoProcesado = contactoHijo;
        }

    }
}
