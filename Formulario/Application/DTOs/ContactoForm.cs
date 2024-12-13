namespace Formulario.Application.DTOs
{
    public class ContactoForm
    {
        public string Nombre { get; set; } = default!;

        public string Apellidos { get; set; } = default!;

        public string Correo { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string RepetirPassword { get; set; } = default!;

        public string Nickname { get; set; } = default!;
    }
}
