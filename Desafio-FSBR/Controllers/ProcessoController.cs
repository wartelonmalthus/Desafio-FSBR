using Desafio_FSBR.Model.ViewModel.Processo;
using Desafio_FSBR.Model.ViewModel.Processo.Response;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_FSBR.Controllers
{
    public class ProcessoController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new ProcessoIndexViewModel
            {
                //Processos = _context.Processos.ToList()
                Processos = new List<ProcessoResponse>()
            };
            return View(viewModel);
        }
    }
}
