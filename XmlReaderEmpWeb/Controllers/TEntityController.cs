using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace XmlReaderEmpWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TEntityController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public TEntityController(TRepository repository)
        {
            this._repository = repository;
        }
        // GET: api/[controller]
        [HttpGet]
        public ActionResult<IEnumerable<TEntity>> Get()
        {
            return _repository.Get().ToList() ;
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _repository.Update(entity);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await _repository.Add(entity);
            return entity;
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await _repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
    }
}
