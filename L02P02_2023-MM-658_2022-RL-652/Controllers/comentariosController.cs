using L02P02_2023_MM_658_2022_RL_652.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2023_MM_658_2022_RL_652.Controllers
{
    public class comentariosController : Controller
    {
        private readonly libreriaDbContext _context;
        public comentariosController(libreriaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var comentarios = _context.comentarios_libros
                                      .Where(c => c.id_libro == id)
                                      .ToList();

            if (comentarios == null)
            {
                comentarios = new List<comentarios_libros>(); // Evita errores si no hay datos
            }

            ViewBag.LibroId = id;
            return View(comentarios);
        }
    }
}
