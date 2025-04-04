using L02P02_2023_MM_658_2022_RL_652.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2023_MM_658_2022_RL_652.Controllers
{
    public class autoresController : Controller


    {
        private readonly libreriaDbContext _context;
        public autoresController(libreriaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var autores = await _context.autores.ToListAsync();
            return View(autores);
        }
    }
}


