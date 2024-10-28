using Desafio_FSBR.Model.ViewModel.Processo.Request;
using Desafio_FSBR.Model.ViewModel.Processo.Response;

namespace Desafio_FSBR.Model.ViewModel.Processo;

public class ProcessoIndexViewModel
{
    public IEnumerable<ProcessoResponse> Processos { get; set; }
    public ProcessoCreateRequest NovoProcesso { get; set; } = new ProcessoCreateRequest();
}
