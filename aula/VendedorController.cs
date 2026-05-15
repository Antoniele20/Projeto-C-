using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendedorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> Get()
        {
            return await _context.Vendedores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);

            await _context.SaveChangesAsync();

            return Ok(vendedor);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult> Put(int codigo, Vendedor vendedor)
        {
            var vendedorDb = await _context.Vendedores.FindAsync(codigo);

            if (vendedorDb == null)
                return NotFound();

            vendedorDb.Nome = vendedor.Nome;
            vendedorDb.Email = vendedor.Email;
            vendedorDb.Telefone = vendedor.Telefone;
            vendedorDb.Salario = vendedor.Salario;

            await _context.SaveChangesAsync();

            return Ok(vendedorDb);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(int codigo)
        {
            var vendedor = await _context.Vendedores.FindAsync(codigo);

            if (vendedor == null)
                return NotFound();

            _context.Vendedores.Remove(vendedor);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("salario/{valor}")]
        public async Task<ActionResult<IEnumerable<Vendedor>>> BuscarSalario(decimal valor)
        {
            return await _context.Vendedores
                .Where(v => v.Salario > valor)
                .ToListAsync();
        }
    }
}