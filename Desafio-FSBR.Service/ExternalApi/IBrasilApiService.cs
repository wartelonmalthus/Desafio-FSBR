using Desafio_FSBR.Model.ExternalModels;
using Refit;

namespace Desafio_FSBR.Service.ExternalApi;

public interface IBrasilApiService
{
    [Get("/ibge/uf/v1")]
    Task<List<UfResponse>> GetUfsAsync();
}
