using Desafio_FSBR.Data.Interfaces;
using Desafio_FSBR.Model.ExternalModels;
using Desafio_FSBR.Model.ViewModel.Processo;
using Desafio_FSBR.Service.Cache;
using Desafio_FSBR.Service.ExternalApi;
using Desafio_FSBR.Service.Interfaces;
using Desafio_FSBR.Service.Mappers;
using Microsoft.Extensions.Caching.Memory;

namespace Desafio_FSBR.Service.Services;

public class ProcessoService(IProcessoRepository processoRepository, IBrasilApiService brasilApiService, IMemoryCache memoryCache, CacheOptionsProvider cacheOptionsProvider) : BaseService(memoryCache), IProcessoService
{
    private readonly IProcessoRepository _processoRepository = processoRepository;
    private readonly IBrasilApiService _brasilApiService = brasilApiService;
    private readonly CacheOptionsProvider _cacheOptionsProvider = cacheOptionsProvider;

    public async Task AddAsync(ProcessoCreateRequest request)
    {
        ClearCache();
        await _processoRepository.AddAsync(request.ToEntity());
    }

    public async Task DeleteAsync(int id)
    {
        ClearCache();
        await _processoRepository.DeleteAsync(id);
    }

    public async Task<(IEnumerable<ProcessoResponse> Items, int TotalCount)> GetAllAsync(int page, int pageSize )
    {
        if (!_memoryCache.TryGetValue($"processos:{page}", out (IEnumerable<ProcessoResponse> Items, int TotalCount) cachedData))
        {
            var (processos, totalCount) = await _processoRepository.GetAllAsync(page, pageSize);
            var processosResponse = processos.ToResponse();
            _memoryCache.Set($"processos:{page}", (processosResponse, totalCount), _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey($"processos:{page}");

            return (processosResponse, totalCount);
        }

        return cachedData;
    }

    public async Task<ProcessoResponse> GetByIdAsync(int id)
    {
        if (!_memoryCache.TryGetValue("processo", out ProcessoResponse processo))
        {
            processo = (await _processoRepository.GetByIdAsync(id)).ToResponse();
            _memoryCache.Set("processo", processo, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey("processo");
        }
        return processo;
    }

    public async Task<IEnumerable<UfResponse>> GetUfsAsync() 
    {
        if (!_memoryCache.TryGetValue("ufs", out IEnumerable<UfResponse> ufs))
        {
            ufs = await _brasilApiService.GetUfsAsync();
            _memoryCache.Set("ufs", ufs, _cacheOptionsProvider.GetCacheOptions());
            AddCacheKey("ufs");
        }
        return ufs;
    }
   
      
    public async Task<bool> UpdateAsync(int id, ProcessoUpdateRequest request)
    {
        var processo = await _processoRepository.GetByIdAsync(id);

        if (processo is null)
            return false;

        if(request.NomeProcesso is not null) processo.NomeProcesso = request.NomeProcesso;

        if(request.Municipio is not null) processo.Municipio = request.Municipio;
       
        if(request.NPU is not null) processo.NPU = request.NPU;

        if(request.UF is not null) processo.UF = request.UF;

        if(request.DataVisualizacao is not null) processo.DataVisualizacao = request.DataVisualizacao;

        processo.DataAlteracao = DateTime.Now;


        ClearCache();
        await _processoRepository.UpdateAsync(processo);

        return true;

    }
}
