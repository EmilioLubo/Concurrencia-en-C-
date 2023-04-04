using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("tarjetas")]
    public class TarjetasController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> ProcesarTarjeta([FromBody] string tarjeta)
        {
            var num = RandomGen.NextDouble();

            var ok = num > 0.1;

            await Task.Delay(1000);
            Console.WriteLine($"Tarjeta {tarjeta} procesada.");
            return Ok(new {Tarjeta = tarjeta, Aprobada = ok});
        }
    }
}
