using Desafio_FSBR.Model.ViewModel.Processo;
using Desafio_FSBR.Service.Interfaces;
using Desafio_FSBR.Service.Mappers;
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
    public async Task<IActionResult> Create(ProcessoIndexViewModel request)
    {
        try
        {
            await _processoService.AddAsync(request.Processo.ToRequest());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
       
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var processo = await _processoService.GetByIdAsync(id); 
        if (processo == null)
            return NotFound();
        
        var viewModel = new ProcessoIndexViewModel
        {
            Processo = processo.ToEntity(),
            Ufs = await _processoService.GetUfsAsync(),
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProcessoIndexViewModel request)
    {
        try
        {
            await _processoService.UpdateAsync(request.Processo.Id, request.Processo.ToUpdate());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        var processo = await _processoService.GetByIdAsync(id);

        if (processo is null)
            return NotFound();

        return View(processo.ToDeleteModel());
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async  Task<IActionResult> DeleteConfirmed(int id)
    {
        await _processoService.DeleteAsync(id); 
        return RedirectToAction(nameof(Index)); 
    }
}
