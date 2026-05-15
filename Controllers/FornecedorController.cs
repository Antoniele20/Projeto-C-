using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FornecedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> Get()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);

            await _context.SaveChangesAsync();

            return Ok(fornecedor);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult> Put(int codigo, Fornecedor fornecedor)
        {
            var fornecedorDb = await _context.Fornecedores.FindAsync(codigo);

            if (fornecedorDb == null)
                return NotFound();

            fornecedorDb.Nome = fornecedor.Nome;
            fornecedorDb.Email = fornecedor.Email;
            fornecedorDb.Cnpj = fornecedor.Cnpj;
            fornecedorDb.Telefone = fornecedor.Telefone;

            await _context.SaveChangesAsync();

            return Ok(fornecedorDb);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(int codigo)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(codigo);

            if (fornecedor == null)
                return NotFound();

            _context.Fornecedores.Remove(fornecedor);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> BuscarNome(string nome)
        {
            return await _context.Fornecedores
                .Where(f => f.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}