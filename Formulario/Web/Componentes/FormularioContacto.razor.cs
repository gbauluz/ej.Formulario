using System.Text.RegularExpressions;
using Formulario.Application.DTOs;
using Formulario.Application.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;



namespace Formulario.Web.Componentes
{
    public partial class FormularioContacto : ComponentBase
    {

        private readonly ContactoForm _contact = new();

        private EditContext _editContext=default!;
        private ValidationMessageStore _validationMessageStore=default!;

        [Inject] public ContactService Service { get; set; } = default!;



        protected override void OnInitialized()
        {
            _editContext = new EditContext(_contact);

            _validationMessageStore = new ValidationMessageStore(_editContext);
            base.OnInitialized();
        }


        public void Enviar()
        {
            ContactoFormValidation();
            bool isValid = _editContext.Validate();

            if (isValid)
            {
                Service.GuardarContacto(_contact);
                Service.NotifyStateChanged(); 
                //Notificamos al servicio que el estado del hermano cambiará!!!
                //Este método invoca el evento al que está suscrito el StateHasChanged del hermano
            }
        }

        private void ContactoFormValidation()
        {
            _validationMessageStore.Clear();

            if (string.IsNullOrWhiteSpace(_contact.Nombre))
            {
                _validationMessageStore.Add(_editContext.Field(nameof(ContactoForm.Nombre)), $"El campo es obligatorio");
            }


            if (string.IsNullOrWhiteSpace(_contact.Apellidos))
            {
                _validationMessageStore.Add(_editContext.Field(nameof(ContactoForm.Apellidos)), $"El campo es obligatorio");
            }


            if (string.IsNullOrWhiteSpace(_contact.Correo))
            {
                _validationMessageStore.Add(_editContext.Field(nameof(ContactoForm.Correo)), $"El campo es obligatorio");
            }
            else
            {
                ContactoFormEmailValidation();
            }


            if (string.IsNullOrWhiteSpace(_contact.Password))
            {
                _validationMessageStore.Add(_editContext.Field(nameof(ContactoForm.Password)), $"El campo es obligatorio");
            }
            else
            {
                if (ContactoFormPasswordValidation())
                {
                    if (string.IsNullOrWhiteSpace(_contact.RepetirPassword))
                    {
                        _validationMessageStore.Add(_editContext.Field(nameof(ContactoForm.RepetirPassword)), $"El campo es obligatorio");
                    }
                    else
                    {
                        ContactoFormMatchedPasswordsValidation();
                    }
                }
            }


            if (string.IsNullOrWhiteSpace(_contact.Nickname))
            {
                _validationMessageStore.Add(_editContext.Field(nameof(ContactoForm.Nickname)), $"El campo es obligatorio");
            }

            _editContext.NotifyValidationStateChanged();
        }



        private void ContactoFormEmailValidation()
        {
            var emailRegex = new Regex("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$");
            if (!emailRegex.IsMatch(_contact.Correo))
            {
                _validationMessageStore.Add(_editContext.Field(nameof(ContactoForm.Correo)), "El correo no tiene un formato válido");
            }
        }


        private bool ContactoFormPasswordValidation()
        {
            bool isValid = true;
            var psswdRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{4,}$");
            if (!psswdRegex.IsMatch(_contact.Password))
            {
                _validationMessageStore.Add(_editContext.Field(nameof(ContactoForm.Password)), "La contraseña debe contener al menos 4 caracteres, incluyendo una letra mayúscula, una letra minúscula, un número y un carácter especial");
                isValid = false;
            }
            return isValid;
        }


        private void ContactoFormMatchedPasswordsValidation()
        {

            if (_contact.RepetirPassword != _contact.Password)
            {
                _validationMessageStore.Add(_editContext.Field(nameof(ContactoForm.RepetirPassword)), "Las contraseñas deben coincidir");
            }
        }

    }
}
