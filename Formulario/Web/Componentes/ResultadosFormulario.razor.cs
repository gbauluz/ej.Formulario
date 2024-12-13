using Formulario.Domain.Models;
using Formulario.Application.Services;
using Microsoft.AspNetCore.Components;

namespace Formulario.Web.Componentes
{
    public partial class ResultadosFormulario : ComponentBase
    {

        private Contacto? _contactShown;
        private bool _mostrar;

        [Inject] public ContactService Service { get; set; } = default!;


        //Inicializa y nos suscribimos al evento OnStateChanged para que al hacer click en el botón del componente hermano,
        //desde aquí se reciba un cambio de estado que lo hace volver a renderizarse
        protected override void OnInitialized() 
        {
            _contactShown = Service.ObtenerContacto();
            if (_contactShown != null)
            {
                _mostrar = true;
            }
            else
            {
                _mostrar = false;
            }
            Service.OnStateChanged += StateHasChanged;
            base.OnInitialized();
        }

        //protected override void OnAfterRender(bool firstRender) //Prueba para ver si así furulaba el "primer" ShouldRender
        //{
        //    if(firstRender)
        //    {
        //        StateHasChanged();
        //    }
        //}

        protected override bool ShouldRender()
        {
            _contactShown = Service.ObtenerContacto();
            if (_contactShown != null)
            {
                _mostrar = true;
            }
            return _contactShown != null;//!!!!!Renderiza de todos modos
        }

        public void Dispose() => Service.OnStateChanged -= StateHasChanged; //Nos desuscribimos
    }
}
