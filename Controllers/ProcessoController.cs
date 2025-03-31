using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseBackend.Data;
using CaseBackend.Models;

namespace CaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProcessoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/processos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Processo>>> GetProcessos()
        {
            // Obtendo todos os processos sem parent
            var processos = await _context.Processos
                .Where(p => p.ProcessoParentId == null)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Tools,
                    p.Responsables,
                    p.Documentation,
                    p.AreaId,
                    AreaName = p.Area.Name,
                    p.ProcessoParentId,
                    HasSubprocessos = _context.Processos.Any(sub => sub.ProcessoParentId == p.Id)  // Verificando se tem subprocessos
                })
                .ToListAsync();

            return Ok(processos);
        }

        // GET: api/processos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Processo>> GetProcesso(Guid id)
        {
            var processo = await _context.Processos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (processo == null)
            {
                return NotFound();
            }

            // Obtendo subprocessos do processo atual
            var subprocessos = await _context.Processos
                .Where(p => p.ProcessoParentId == id)
                .ToListAsync();

            var result = new
            {
                processo,
                Subprocessos = subprocessos
            };

            return Ok(result);
        }

        // POST: api/processos
        [HttpPost]
        public async Task<ActionResult<Processo>> CreateProcesso(Processo processo)
        {
            Console.WriteLine($"Recebido: {System.Text.Json.JsonSerializer.Serialize(processo)}");
            _context.Processos.Add(processo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProcesso), new { id = processo.Id }, processo);
        }

        // PUT: api/processos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProcesso(Guid id, Processo processo)
        {
            // Verifica se o processo existe no banco de dados com o ID fornecido na URL
            var existingProcesso = await _context.Processos.FindAsync(id);
            if (existingProcesso == null)
            {
                return NotFound();  // Caso o processo não seja encontrado
            }

            // Atualiza os campos do processo existente com os dados fornecidos no corpo da requisição
            existingProcesso.Name = processo.Name;
            existingProcesso.Description = processo.Description;
            existingProcesso.Tools = processo.Tools;
            existingProcesso.Responsables = processo.Responsables;
            existingProcesso.Documentation = processo.Documentation;
            existingProcesso.ProcessoParentId = processo.ProcessoParentId;
            existingProcesso.AreaId = processo.AreaId;

            try
            {
                // Salva as alterações no banco de dados
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Trata qualquer erro de concorrência
                if (!ProcessoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();  // Retorna sucesso sem corpo
        }

        // DELETE: api/processos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcesso(Guid id)
        {
            var processo = await _context.Processos.FindAsync(id);
            if (processo == null)
            {
                return NotFound();
            }

            // Verificar se o processo tem subprocessos
            var subprocessos = await _context.Processos
                .Where(p => p.ProcessoParentId == id)
                .ToListAsync();

            if (subprocessos.Any())  // Se o processo tiver filhos (subprocessos), não permitir exclusão
            {
                return BadRequest("Não é permitido excluir um processo que tem subprocessos.");
            }

            _context.Processos.Remove(processo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcessoExists(Guid id)
        {
            return _context.Processos.Any(e => e.Id == id);
        }
    }
}
