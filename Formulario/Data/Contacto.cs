﻿using System.ComponentModel.DataAnnotations;

namespace Formulario.Data
{
    public class Contacto
    {
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Apellidos { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Debes indicar un email válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public string RepetirPassword { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        public string Nickname { get; set; }



        public ValidationAttribute SamePassword()
        {
            return new ValidationAttribute(
        }
    }
}