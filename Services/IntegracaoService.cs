using DataBridge.Data;
using DataBridge.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBridge.Services
{
    public class IntegracaoService
    {
        private readonly SqlServerContext _sqlContext;
        private readonly MySqlContext _mySqlContext;

        public IntegracaoService(SqlServerContext sqlContext, MySqlContext mySqlContext)
        {
            _sqlContext = sqlContext;
            _mySqlContext = mySqlContext;
        }

        public async Task<ClienteAntigo?> BuscarOrigemPorIdAsync(int id)
        {
            return await _sqlContext.Clientes.FindAsync(id);
        }

        public async Task TransferirAsync(ClienteNovo cliente)
        {
            cliente.Id = 0;
            cliente.DataAlteracao = DateTime.Now;
            await _mySqlContext.Clientes.AddAsync(cliente);
            await _mySqlContext.SaveChangesAsync();
        }

        public async Task AtualizarDestinoAsync(ClienteNovo cliente)
        {
            _mySqlContext.Clientes.Update(cliente);
            await _mySqlContext.SaveChangesAsync();
        }

        public async Task<List<ClienteNovo>> ListarDestinoAsync(string? filtro = null)
        {
            var query = _mySqlContext.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
                query = query.Where(c => c.NomeCompleto.Contains(filtro));

            return await query.OrderBy(c => c.NomeCompleto).ToListAsync();
        }

        public async Task<ClienteNovo?> BuscarDestinoPorIdAsync(int id)
        {
            return await _mySqlContext.Clientes.FindAsync(id);

        }
    }
}
