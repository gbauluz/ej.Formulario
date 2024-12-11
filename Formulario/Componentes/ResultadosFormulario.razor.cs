using Formulario.Data;
using Microsoft.AspNetCore.Components;

namespace Formulario.Componentes
{
    public partial class ResultadosFormulario
    {
        [Parameter]
        public ContactoForm ContactShown { get; set; }
    }
}
