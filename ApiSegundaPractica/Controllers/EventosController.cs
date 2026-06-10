using ApiSegundaPractica.Models;
using ApiSegundaPractica.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiSegundaPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private RepositoryEventos repo;

        public EventosController(RepositoryEventos repo)
        {
            this.repo = repo;
        }

        // GET: api/eventos
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetCategorias()
        {
            return await this.repo.GetCategoriasAsync();
        }

        // GET: api/eventos/7
        [HttpGet("{idCategoria}")]
        public async Task<ActionResult<List<Evento>>> GetEventosCategoria(int idCategoria)
        {
            return await this.repo.GetEventosCategoriaAsync(idCategoria);
        }
    }
}
