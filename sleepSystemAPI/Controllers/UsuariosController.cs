using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sleepSystemAPI.Data;
using sleepSystemAPI.Models;

namespace sleepSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly SleepSystemContext _context;

        public UsuariosController(SleepSystemContext context)
        {
            _context = context;
        }

        //GET: api/usuarios

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        //POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuarios), new { usuarioid = usuario.IdUser},usuario);
        }
    }
}
