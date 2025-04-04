using Microsoft.EntityFrameworkCore;
namespace L02P02_2023_MM_658_2022_RL_652.Models
{
    public class libreriaDbContext:DbContext
    {
        public libreriaDbContext(DbContextOptions<libreriaDbContext> options) : base(options)
        {

        }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Autores> autores { get; set; }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Libros> libros { get; set; }
        public DbSet<pedido_encabezado> pedido_encabezado { get; set; }
        public DbSet<pedido_detalle> pedido_detalle { get; set; }
        public DbSet<comentarios_libros> comentarios_libros { get; set; }
    }
}
