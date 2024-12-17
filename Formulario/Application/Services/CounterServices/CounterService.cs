using System.Net;

namespace Formulario.Application.Services.CounterServices
{
    public class CounterService
    {
        public int RegisteredCount { get; set; }

        public CounterService()
        {
            RegisteredCount = 0;
            Console.WriteLine($"Tipo primitivo: {this.GetType()}");
        }

        //public void IncrementRegisteredCount()
        //{
        //    RegisteredCount++;
        //}
    }
}
