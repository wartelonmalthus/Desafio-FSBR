using Desafio_FSBR.Model.ViewModel.Processo;
using Desafio_FSBR.Model.ViewModel.Processo.Request;
using Desafio_FSBR.Service.ExternalApi;
using Desafio_FSBR.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_FSBR.Controllers;

public class ProcessoController(IProcessoService processoService) : Controller
{
    private readonly IProcessoService _processoService = processoService;

    [HttpGet]
    public async Task<IActionResult> IndexAsync()
    {
        var viewModel = new ProcessoIndexViewModel
        {
            Processos = await _processoService.GetAllAsync(),
            Ufs  = await _processoService.GetUfsAsync(),

        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProcessoCreateRequest request)
    {
        if (ModelState.IsValid)
        {
            await _processoService.AddAsync(request);
            return RedirectToAction(nameof(Index));
        }

        var viewModel = new ProcessoIndexViewModel
        {
            Processos = await _processoService.GetAllAsync(),
            NovoProcesso = request
        };

        return View("Index", viewModel);
    }
}
