using L02P02_2023_MM_658_2022_RL_652.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace L02P02_2023_MM_658_2022_RL_652.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly libreriaDbContext _context;

        public ComentariosController(libreriaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int idLibro)
        {
            // Obtener el libro seleccionado
            var libro = _context.libros.FirstOrDefault(l => l.id == idLibro);
            if (libro == null)
            {
                return NotFound("Libro no encontrado.");
            }

            // Obtener el autor del libro
            var autor = _context.autores.FirstOrDefault(a => a.id == libro.id_autor);

            // Obtener los comentarios asociados al libro
            var comentarios = _context.comentarios_libros.Where(c => c.id_libro == idLibro).ToList();

            // Crear y pasar el ViewModel
            var viewModel = new ComentariosViewModel
            {
                Autor = autor,
                Libro = libro,
                Comentarios = comentarios
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult GuardarComentario(int idLibro, string comentario, string usuario)
        {
            if (string.IsNullOrEmpty(comentario) || string.IsNullOrEmpty(usuario))
            {
                return BadRequest("El comentario y el usuario son requeridos.");
            }

            var nuevoComentario = new comentarios_libros
            {
                id_libro = idLibro,
                comentarios = comentario,
                usuario = usuario,
                created_at = DateTime.Now
            };

            _context.comentarios_libros.Add(nuevoComentario);
            _context.SaveChanges();

            return RedirectToAction("ConfirmacionComentario", new { idComentario = nuevoComentario.id });
        }


        public IActionResult ConfirmacionComentario(int idComentario)
        {
            var comentario = _context.comentarios_libros.FirstOrDefault(c => c.id == idComentario);

            if (comentario == null)
            {
                return NotFound("Comentario no encontrado.");
            }

            return View(comentario);
        }

    }
}
