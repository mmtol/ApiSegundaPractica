using ApiSegundaPractica.Data;
using ApiSegundaPractica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSegundaPractica.Repositories
{
    public class RepositoryEventos
    {
        private EventosContext context;

        public RepositoryEventos(EventosContext context)
        {
            this.context = context;
        }

        // Mostrar categorías
        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            return await this.context.Categorias
                .ToListAsync();
        }

        // Mostrar eventos de una categoría
        public async Task<List<Evento>> GetEventosCategoriaAsync(int idCategoria)
        {
            return await this.context.Eventos
                .Where(x => x.IdCategoria == idCategoria)
                .ToListAsync();
        }
    }
}
