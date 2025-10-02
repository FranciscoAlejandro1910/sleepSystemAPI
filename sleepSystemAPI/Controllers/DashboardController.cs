using Microsoft.AspNetCore.Mvc;
using sleepSystemAPI.Models;
using System.Linq;

namespace sleepSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly SleepSystemContext _context;

        public DashboardController(SleepSystemContext context)
        {
            _context = context;
        }

        // GET: api/dashboard/puntaje-hombres
        [HttpGet("puntaje-hombres")]
        public ActionResult GetPuntajeHombres()
        {
            var resultado = _context.Evaluaciones
                .Where(e => e.Usuario.Genero == "Masculino")
                .Select(e => new
                {
                    e.PuntajeTotal
                })
                .ToList();

            return Ok(resultado);
        }

        // GET: api/dashboard/puntaje-mujeres
        [HttpGet("puntaje-mujeres")]
        public ActionResult GetPuntajeMujeres()
        {
            var resultado = _context.Evaluaciones
                .Where(e => e.Usuario.Genero == "Femenino")
                .Select(e => new
                {
                    e.PuntajeTotal
                })
                .ToList();

            return Ok(resultado);
        }
    }
}