using Desafio_FSBR.Model.ExternalModels;
using Desafio_FSBR.Model.ViewModel.Processo.Request;
using Desafio_FSBR.Model.ViewModel.Processo.Response;

namespace Desafio_FSBR.Service.Interfaces;

public interface IProcessoService
{
    Task<IEnumerable<ProcessoResponse>> GetAllAsync();
    Task<ProcessoResponse> GetByIdAsync(int id);
    Task AddAsync(ProcessoCreateRequest request);
    Task<bool> UpdateAsync(int id, ProcessoUpdateRequest request);
    Task DeleteAsync(int id);
    Task<IEnumerable<UfResponse>> GetUfsAsync(); 
}
