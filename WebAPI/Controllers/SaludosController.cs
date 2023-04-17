using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("saludos")]
    [ApiController]
    public class SaludosController : ControllerBase
    {
        [HttpGet("{nombre}")]
        public ActionResult<string> ObtenerSaludo(string nombre)
        {
            return $"Hola {nombre}!";
        }
        [HttpGet("delay/{nombre}")]
        public async Task<ActionResult<string>> SaludoConDelay(string nombre)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000).ConfigureAwait(continueOnCapturedContext: true);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            var esperar = RandomGen.NextDouble() * 10 +1;
            await Task.Delay((int)esperar * 1000);
            return $"Hola {nombre}";
        }
    }
}
