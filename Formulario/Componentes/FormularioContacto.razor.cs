using Formulario.Data;
using Microsoft.AspNetCore.Components;

namespace Formulario.Componentes
{
    public partial class FormularioContacto
    {

        private ContactoForm _contact = new();

        [Parameter]
        public EventCallback<ContactoForm> EnviarCallBack { get; set; }


        public void Enviar()
        {
            EnviarCallBack.InvokeAsync(_contact);
        }

        //public async Task Enviar()
        //{
        //    await EnviarCallBack.InvokeAsync(_contact);
        //}
    }
}
