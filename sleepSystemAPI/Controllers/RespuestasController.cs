using Microsoft.AspNetCore.Mvc;
using sleepSystemAPI.Models;
using sleepSystemAPI.Models.Dtos;
using System.Globalization;

namespace sleepSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RespuestasController : Controller
    {
        private readonly SleepSystemContext _context;

        public RespuestasController(SleepSystemContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Respuesta>>> GetRespuestas()
        {
            return await Task.FromResult(_context.Respuestas.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<Respuesta>> PostRespuesta(Respuesta respuesta)
        {
            if (respuesta == null || string.IsNullOrWhiteSpace(respuesta.Respuesta1) || respuesta.PreguntaId <= 0 || respuesta.UsuarioId <= 0)
            {
                return BadRequest("La solicitud de respuesta es inválida.");
            }

            _context.Respuestas.Add(respuesta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostRespuesta), new { id = respuesta.IdRespuesta }, respuesta);
        }

        // Nuevo endpoint para guardar un lote de respuestas
        [HttpPost("lote")]
        public async Task<ActionResult> PostRespuestasLote([FromBody] RespuestaLoteDto lote)
        {
            if (lote == null || lote.respuestas == null || lote.respuestas.Count != 18)
            {
                return BadRequest("El lote debe contener exactamente 18 respuestas.");
            }

            var respuestas = lote.respuestas.Select(r => new Respuesta
            {
                UsuarioId = lote.usuarioId,
                PreguntaId = r.preguntaId,
                Respuesta1 = r.texto ?? r.valor.ToString()
            }).ToList();

            _context.Respuestas.AddRange(respuestas);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Respuestas guardadas correctamente", cantidad = respuestas.Count });
        }


        
    }
}
