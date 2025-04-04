using L02P02_2023_MM_658_2022_RL_652.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2023_MM_658_2022_RL_652.Controllers
{
    public class LibrosController : Controller
    {
        private readonly libreriaDbContext _context;

        public LibrosController(libreriaDbContext context)
        {
            _context = context;
        }
        [Route("Libros/Index/{idAutor}")]
        public IActionResult Index(int idAutor)
        {
            var autor = _context.autores.FirstOrDefault(a => a.id == idAutor);
            var libros = _context.libros.Where(l => l.id_autor == idAutor).ToList();

            if (autor == null) return NotFound();

            var viewModel = new AutorLibrosViewModel
            {
                Autor = autor,
                Libros = libros
            };

            return View(viewModel);
        }
    }
}
