using DataBridge.Data;
using DataBridge.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBridge.Services
{
    public class ClienteService
    {
        private readonly SqlServerContext _context;

        public ClienteService(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteAntigo>> ListarAsync(string? filtro = null)
        {
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
                query = query.Where(c => c.NomeCompleto.Contains(filtro));

            return await query.OrderBy(c => c.NomeCompleto).ToListAsync();
        }

        public async Task<ClienteAntigo?> BuscarPorIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task CriarAsync(ClienteAntigo cliente)
        {
            cliente.DataCadastro = DateTime.Now;
            cliente.Ativo = true;
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(ClienteAntigo cliente)
        {
           _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
