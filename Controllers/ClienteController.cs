using DataBridge.Models;
using DataBridge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataBridge.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly IntegracaoService _integracaoService;
        private readonly ViaCepService _viaCepService;

        public ClienteController(
            ClienteService clienteService,
            IntegracaoService integracaoService,
            ViaCepService viaCepService)
        {
            _clienteService = clienteService;
            _integracaoService = integracaoService;
            _viaCepService = viaCepService;
        }

        public async Task<IActionResult> Index(string? filtro)
        {
            var clientes = await _clienteService.ListarAsync(filtro);
            ViewBag.Filtro = filtro;
            return View(clientes);
        }

       public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ClienteAntigo cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            await _clienteService.CriarAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteService.BuscarPorIdAsync(id);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClienteAntigo cliente)
        {
            if(!ModelState.IsValid)
                return View(cliente);

            await _clienteService.AtualizarAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Integrated(int id)
        {
            var origem = await _integracaoService.BuscarOrigemPorIdAsync(id);

            if (origem == null)
                return NotFound();

            var destino = new ClienteNovo
            {
                NomeCompleto = origem.NomeCompleto,
                Telefone = origem.Telefone,
                CEP = origem.CEP,
                Endereco = origem.Endereco,
                Cidade = origem.Cidade,
                Estado = origem.Estado,
                DataCadastro = origem.DataCadastro,
                Ativo = origem.Ativo
            };

            return View(destino);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Integrated(ClienteNovo cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            await _integracaoService.TransferirAsync(cliente);
            return RedirectToAction(nameof(IntegratedFiles));
        }

        public async Task<IActionResult> IntegratedFiles(string? filtro)
        {
            var clientes = await _integracaoService.ListarDestinoAsync(filtro);
            ViewBag.Filtro = filtro;
            return View(clientes);
        }

        public async Task<IActionResult> EditFiles(int id)
        {
            var cliente = await _integracaoService.BuscarDestinoPorIdAsync(id);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFiles(ClienteNovo cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            await _integracaoService.AtualizarDestinoAsync(cliente);
            return RedirectToAction(nameof(IntegratedFiles));
        }

        [HttpGet]
        public async Task<IActionResult> GetEnderecoPorCep(string cep)
        {
            var endereco = await _viaCepService.BuscarEnderecoPorCepAsync(cep);

            if (endereco == null)
                return NotFound();

            return Json(endereco);
        }
    }
}
