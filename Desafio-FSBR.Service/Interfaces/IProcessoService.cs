using Desafio_FSBR.Model.ExternalModels;
using Desafio_FSBR.Model.ViewModel.Processo;

namespace Desafio_FSBR.Service.Interfaces;

public interface IProcessoService
{
    Task<(IEnumerable<ProcessoResponse> Items, int TotalCount)> GetAllAsync(int page, int pageSize);
    Task<ProcessoResponse> GetByIdAsync(int id);
    Task AddAsync(ProcessoCreateRequest request);
    Task<bool> UpdateAsync(int id, ProcessoUpdateRequest request);
    Task DeleteAsync(int id);
    Task<IEnumerable<UfResponse>> GetUfsAsync(); 
}
