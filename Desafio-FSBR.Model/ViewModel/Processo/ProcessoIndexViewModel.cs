using Desafio_FSBR.Model.ExternalModels;
using Desafio_FSBR.Model.ViewModel.Processo.Request;
using Desafio_FSBR.Model.ViewModel.Processo.Response;

namespace Desafio_FSBR.Model.ViewModel.Processo;

public class ProcessoIndexViewModel
{
    public IEnumerable<ProcessoResponse> Processos { get; set; }
    public ProcessoCreateRequest NovoProcesso { get; set; } = new ProcessoCreateRequest();
    public IEnumerable<UfResponse>? Ufs { get; set; }
}
