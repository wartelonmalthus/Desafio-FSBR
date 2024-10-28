using Desafio_FSBR.Model.Entity;
using Desafio_FSBR.Model.ViewModel.Processo.Request;
using Desafio_FSBR.Model.ViewModel.Processo.Response;

namespace Desafio_FSBR.Service.Mappers;

public static class ProcessoMapper
{
    public static ProcessoResponse ToResponse(this Processo processo) => new() 
    {   
        DataCadastro = processo.DataCadastro,
        Id = processo.Id,
        Municipio = processo.Municipio,
        MunicipioCodigo = processo.MunicipioCodigo,
        NomeProcesso = processo.NomeProcesso,
        NPU = processo.NPU,
        UF = processo.UF
    };

    public static IEnumerable<ProcessoResponse> ToResponse(this IEnumerable<Processo> processos) => processos.Select(processo => processo.ToResponse());

    public static Processo ToEntity(this ProcessoCreateRequest request) => new() 
    {
        Municipio = request.Municipio,
        MunicipioCodigo = request.MunicipioCodigo,
        NomeProcesso = request.NomeProcesso,
        NPU = request.NPU,
        UF= request.UF
    };
}
