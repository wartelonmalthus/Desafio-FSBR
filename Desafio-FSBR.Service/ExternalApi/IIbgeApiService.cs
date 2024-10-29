using Desafio_FSBR.Model.ExternalModels;
using Refit;

namespace Desafio_FSBR.Service.ExternalApi;

public interface IIbgeApiService
{
    [Get("/localidades/estados")]
    Task<List<UfResponse>> GetUfsAsync();
}
