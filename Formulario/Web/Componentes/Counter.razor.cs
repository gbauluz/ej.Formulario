
using Formulario.Application.Services.CounterServices;
using Microsoft.AspNetCore.Components;

namespace Formulario.Web.Componentes
{
    public partial class Counter : ComponentBase
    {
        private int _currentCount;

        [Parameter]
        public string ServiceType { get; set; } = default!;

        public CounterService VarCounterService { get; set; }

        [Inject]
        public TransientCounterService TransientService { get; set; }

        [Inject]
        public ScopedCounterService ScopedService { get; set; }

        [Inject]
        public SingletonCounterService SingletonService { get; set; }


        protected override void OnInitialized()
        {
            if (ServiceType == "Transient")
            {
                VarCounterService = TransientService;
                
            }
            else if (ServiceType == "Scoped")
            {
                VarCounterService = ScopedService;
            }
            else
            {
                VarCounterService = SingletonService;
            }
            _currentCount = VarCounterService.RegisteredCount;
        }
        

        private void IncrementCount()
        {
            //VarCounterService.IncrementRegisteredCount();
            //_currentCount = VarCounterService.RegisteredCount;
            VarCounterService.RegisteredCount++;
            _currentCount=VarCounterService.RegisteredCount;
        }

    }
}
