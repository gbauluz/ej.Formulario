using System.Text.RegularExpressions;
using Formulario.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace Formulario.Componentes
{
    public partial class FormularioContacto
    {

        private ContactoForm _contact = new();
        private EditContext? _editContext;
        private ValidationMessageStore? _validationMessageStore;

        [Parameter]
        public EventCallback<ContactoForm> EnviarCallBack { get; set; }

        protected override void OnInitialized()
        {
            _editContext = new EditContext(_contact);

            _validationMessageStore = new ValidationMessageStore(_editContext);
            base.OnInitialized();
        }


        public void Enviar()
        {
            ContactoFormValidation(_contact);
            bool isValid = _editContext.Validate();

            if (isValid)
            {
                EnviarCallBack.InvokeAsync(_contact);
            }


        }

        private void ContactoFormValidation(ContactoForm contacto)
        {
            _validationMessageStore.Clear();

            var properties = typeof(ContactoForm).GetProperties();


            foreach (var property in properties)
            {
                var value = property.GetValue(contacto) as string;
                if (string.IsNullOrWhiteSpace(value))
                {
                    _validationMessageStore.Add(_editContext.Field(property.Name), $"El campo {property.Name} es obligatorio");
                }
                else if (property.Name == "Correo")
                {
                    ContactoFormEmailValidation(contacto);
                }
                else if (property.Name == "Password")
                {
                    ContactoFormPasswordValidation(contacto);
                }
                else if (property.Name == "RepetirPassword")
                {
                    ContactoFormMatchedPasswordsValidation(contacto);
                }
            }
            _editContext.NotifyValidationStateChanged();

        }

        private void ContactoFormEmailValidation(ContactoForm contacto)
        {
            var emailRegex = new Regex("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$");
            if (!emailRegex.IsMatch(contacto.Correo))
            {
                _validationMessageStore.Add(_editContext.Field("Correo"), "El correo no tiene un formato válido");
            }
        }

        private void ContactoFormPasswordValidation(ContactoForm contacto)
        {
            var psswdRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{4,}$");
            if (!psswdRegex.IsMatch(contacto.Password))
            {
                _validationMessageStore.Add(_editContext.Field("Password"), "La contraseña debe contener al menos 4 caracteres, incluyendo una letra mayúscula, una letra minúscula, un número y un carácter especial");
            }
        }

        private void ContactoFormMatchedPasswordsValidation(ContactoForm contacto)
        {

            if (contacto.Password != contacto.RepetirPassword)
            {
                _validationMessageStore.Add(_editContext.Field("RepetirPassword"), "Las contraseñas deben coincidir");
            }
        }

    }
}
