using Formulario.Domain.Models;
using Formulario.Application.Services;
using Microsoft.AspNetCore.Components;

namespace Formulario.Web.Componentes
{
    public partial class ResultadosFormulario : ComponentBase
    {

        private Contacto? _contactShown;

        [Inject] public ContactService Service { get; set; } = default!;


        //Inicializa y nos suscribimos al evento OnStateChanged para que al hacer click en el botón del componente hermano,
        //desde aquí se reciba un cambio de estado que lo hace volver a renderizarse ***Actualizado: Gestionado desde el HandleRender que invoca el StateHasChanged***
        protected override void OnInitialized() 
        {
            _contactShown = Service.ObtenerContacto();
            
            Service.OnStateChanged += HandleRender;

            base.OnInitialized();
        }


        public void HandleRender()
        {
            _contactShown = Service.ObtenerContacto();
            
            InvokeAsync(StateHasChanged);
        }

        public void Dispose() => Service.OnStateChanged -= HandleRender; //Nos desuscribimos

       
    }
}
