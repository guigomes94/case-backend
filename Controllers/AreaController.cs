using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseBackend.Data;
using CaseBackend.Models;

namespace CaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AreaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/areas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            return await _context.Areas.ToListAsync();
        }

        // GET: api/areas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(Guid id) 
        {
            var area = await _context.Areas.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        // POST: api/areas
        [HttpPost]
        public async Task<ActionResult<Area>> CreateArea(Area area)
        {
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArea), new { id = area.Id }, area);
        }

        // PUT: api/areas/{id}
       [HttpPut("{id}")]
public async Task<IActionResult> UpdateArea(Guid id, [FromBody] Area area)
{
    // Buscar a área no banco de dados usando o id fornecido
    var existingArea = await _context.Areas.FindAsync(id);
    
    // Se a área não for encontrada, retorna um erro NotFound
    if (existingArea == null)
    {
        return NotFound();
    }

    // Atualiza os dados da área existente com os novos dados do corpo da requisição
    existingArea.Name = area.Name;
    existingArea.Description = area.Description;

    // Marca a entidade como modificada
    _context.Entry(existingArea).State = EntityState.Modified;

    try
    {
        // Salva as mudanças no banco de dados
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        // Verifica se a área ainda existe no banco de dados
        if (!AreaExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    // Retorna uma resposta de sucesso sem conteúdo
    return Ok();
}


        // DELETE: api/areas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(Guid id) 
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaExists(Guid id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}
