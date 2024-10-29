using Desafio_FSBR.Model.ExternalModels;

namespace Desafio_FSBR.Model.ViewModel.Processo;

public class ProcessoIndexViewModel
{
    public IEnumerable<ProcessoResponse> Processos { get; set; }
    public Entity.Processo Processo { get; set; } = new Entity.Processo();
    public IEnumerable<UfResponse>? Ufs { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}
