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


    }
}
