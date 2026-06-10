using ApiSegundaPractica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSegundaPractica.Data
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options)
            : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
