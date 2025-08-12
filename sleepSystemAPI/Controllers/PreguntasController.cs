using Microsoft.AspNetCore.Mvc;
using sleepSystemAPI.Models;

namespace sleepSystemAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PreguntasController : Controller
    {
        private readonly SleepSystemContext _context;

        public PreguntasController(SleepSystemContext context)
        {
            _context = context;
        }

        //GET: api/preguntas

        [HttpGet]
        public ActionResult<IEnumerable<Pregunta>> GetPreguntas()
        {
            return _context.Preguntas.ToList();
        }

        //Get: api/preguntas/{id}

        [HttpGet("{id}")]

        public ActionResult<Pregunta> GetPregunta(int id)
        {
            var pregunta = _context.Preguntas.Find(id);
            if (pregunta == null)
            {
                return NotFound();
            }
            return pregunta;
        }

    }
}
