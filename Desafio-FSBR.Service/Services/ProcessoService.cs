using Desafio_FSBR.Data.Interfaces;
using Desafio_FSBR.Model.ViewModel.Processo.Request;
using Desafio_FSBR.Model.ViewModel.Processo.Response;
using Desafio_FSBR.Service.Interfaces;
using Desafio_FSBR.Service.Mappers;

namespace Desafio_FSBR.Service.Services;

public class ProcessoService(IProcessoRepository processoRepository) : IProcessoService
{
    private readonly IProcessoRepository _processoRepository = processoRepository;

    public async Task AddAsync(ProcessoCreateRequest request)
    {
       await _processoRepository.AddAsync(request.ToEntity());
    }

    public async Task DeleteAsync(int id)
    {
       await _processoRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProcessoResponse>> GetAllAsync()
    {
       return (await _processoRepository.GetAllAsync()).ToResponse();
    }

    public async Task<ProcessoResponse> GetByIdAsync(int id)
    {
        return (await _processoRepository.GetByIdAsync(id)).ToResponse();
    }

    public async Task<bool> UpdateAsync(int id, ProcessoUpdateRequest request)
    {
        var processo = await _processoRepository.GetByIdAsync(id);

        if (processo != null)
            return false;

        if(request.NomeProcesso is not null) processo.NomeProcesso = request.NomeProcesso;

        if(request.Municipio is not null) processo.Municipio = request.Municipio;
        
        if(request.MunicipioCodigo > 0) processo.MunicipioCodigo = request.MunicipioCodigo;

        if(request.NPU is not null) processo.NPU = request.NPU;

        if(request.UF is not null) processo.UF = request.UF;

        processo.DataAlteracao = DateTime.Now;

        await _processoRepository.UpdateAsync(processo);

        return true;

    }
}
