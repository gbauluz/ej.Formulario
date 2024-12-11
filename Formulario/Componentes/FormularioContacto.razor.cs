using Formulario.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace Formulario.Componentes
{
    public partial class FormularioContacto
    {

        private ContactoForm _contact = new();
        private EditContext? editContext;
        private ValidationMessageStore? validationMessageStore;

        [Parameter]
        public EventCallback<ContactoForm> EnviarCallBack { get; set; }

        protected override void OnInitialized()
        {
            editContext = new EditContext(_contact);

            validationMessageStore = new ValidationMessageStore(editContext);
            base.OnInitialized();
        }


        public void Enviar()
        {
            bool isValid = editContext.Validate();

            if (_contact.Password != _contact.RepetirPassword)
            {
                validationMessageStore.Add(editContext.Field("RepetirPassword"), "Las contraseñas no coinciden");
                isValid = false;
            }


            if (isValid)
            {
                EnviarCallBack.InvokeAsync(_contact);
            }

            editContext.NotifyValidationStateChanged();
        }

    }
}
