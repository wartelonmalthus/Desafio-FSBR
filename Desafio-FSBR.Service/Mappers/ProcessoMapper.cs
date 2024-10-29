using Desafio_FSBR.Model.Entity;
using Desafio_FSBR.Model.ViewModel.Processo;

namespace Desafio_FSBR.Service.Mappers;

public static class ProcessoMapper
{
    public static ProcessoResponse ToResponse(this Processo processo) => new() 
    {   
        DataCadastro = processo.DataCadastro,
        Id = processo.Id,
        Municipio = processo.Municipio,
        NomeProcesso = processo.NomeProcesso,
        NPU = processo.NPU,
        UF = processo.UF
    };

    public static IEnumerable<ProcessoResponse> ToResponse(this IEnumerable<Processo> processos) => processos.Select(processo => processo.ToResponse());

    public static Processo ToEntity(this ProcessoCreateRequest request) => new() 
    {
        Municipio = request.Municipio,
        NomeProcesso = request.NomeProcesso,
        NPU = request.NPU,
        UF= request.UF
    };

    public static Processo ToEntity(this ProcessoResponse response) => new()
    {
        Municipio = response.Municipio,
        NomeProcesso = response.NomeProcesso,
        NPU = response.NPU,
        UF = response.UF,
        Id = response.Id,
        DataCadastro = response.DataCadastro
    };

    public static ProcessoCreateRequest ToRequest(this ProcessoResponse processo) => new()
    {
        Municipio = processo.Municipio,
        NomeProcesso = processo.NomeProcesso,
        NPU = processo.NPU,
        UF = processo.UF
    };

    public static ProcessoCreateRequest ToRequest(this Processo processo) => new()
    {
        Municipio = processo.Municipio,
        NomeProcesso = processo.NomeProcesso,
        NPU = processo.NPU,
        UF = processo.UF
        
    };

    public static ProcessoUpdateRequest ToUpdate(this ProcessoCreateRequest request) => new()
    {
        Municipio = request.Municipio,
        NomeProcesso= request.NomeProcesso,
        NPU= request.NPU,
        UF= request.UF  
    };

    public static ProcessoUpdateRequest ToUpdate(this Processo processo) => new()
    {
        Municipio = processo.Municipio,
        NomeProcesso = processo.NomeProcesso,
        NPU = processo.NPU,
        UF = processo.UF
    };

    public static ProcessoDeleteViewModel ToDeleteModel(this ProcessoResponse processo) => new() 
    {
        Id = processo.Id,
        NomeProcesso = processo.NomeProcesso,
        NPU = processo.NPU,
    };
}
