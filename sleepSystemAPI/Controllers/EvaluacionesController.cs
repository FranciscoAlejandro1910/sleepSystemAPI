using Microsoft.AspNetCore.Mvc;
using sleepSystemAPI.Models.Dtos;
using sleepSystemAPI.Services;

namespace sleepSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacionesController : Controller
    {
        private readonly IEvaluacionService _evaluacionService;

        public EvaluacionesController(IEvaluacionService evaluacionService)
        {
            _evaluacionService = evaluacionService;
        }

        // POST: api/evaluaciones
        [HttpPost]
        public ActionResult<EvaluacionResponse> ProcesarEvaluacion([FromBody] EvaluacionRequest request)
        {
            if(request == null || request.Respuestas == null || request.Respuestas.Count == 0)
            {
                return BadRequest("La solicitud de evaluación es inválida.");

            }

            var resultado = _evaluacionService.procesarEvaluacion(request);
            return Ok(resultado);
        }

    }
}
