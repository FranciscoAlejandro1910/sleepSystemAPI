using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sleepSystemAPI.Models;
using sleepSystemAPI.Models.Dtos;
using sleepSystemAPI.Services;

namespace sleepSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacionesController : Controller
    {
        private readonly IEvaluacionService _evaluacionService;
        private readonly SleepSystemContext _context;

        public EvaluacionesController(IEvaluacionService evaluacionService, SleepSystemContext context)
        {
            _evaluacionService = evaluacionService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluacione>>> GetEvaluacion()
        {
            return await _context.Evaluaciones.ToListAsync();
        }

        // POST: api/evaluaciones
        [HttpPost]
        public async Task<ActionResult<EvaluacionResponse>> ProcesarEvaluacion([FromBody] EvaluacionRequest request)
        {
            if (request == null || request.Respuestas == null || request.Respuestas.Count == 0)
            {
                return BadRequest("La solicitud de evaluación es inválida.");
            }

            var resultado = _evaluacionService.procesarEvaluacion(request);

            // Crear el objeto Evaluacione y asignar los valores
            var evaluacion = new Evaluacione
            {
                UsuarioId = request.usuarioId,
                Componente1 = resultado.componente1,
                Componente2 = resultado.componente2,
                Componente3 = resultado.componente3,
                Componente4 = resultado.componente4,
                Componente5 = resultado.componente5,
                Componente6 = resultado.componente6,
                Componente7 = resultado.componente7,
                PuntajeTotal = resultado.puntajeTotal
            };

            // Guardar en la base de datos
            _context.Evaluaciones.Add(evaluacion);
            await _context.SaveChangesAsync();

            return Ok(resultado);
        }
    }
}
