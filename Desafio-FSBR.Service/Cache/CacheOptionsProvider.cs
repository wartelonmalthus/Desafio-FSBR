using Desafio_FSBR.Model.Utils;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Desafio_FSBR.Service.Cache;

public class CacheOptionsProvider
{
    private readonly CacheSettings _cacheSettings;

    public CacheOptionsProvider(IOptions<CacheSettings> cacheSettings)
    {
        _cacheSettings = cacheSettings.Value;
    }

    public MemoryCacheEntryOptions GetCacheOptions()
    {
        return new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(_cacheSettings.AbsoluteExpirationInMinutes))
            .SetSlidingExpiration(TimeSpan.FromMinutes(_cacheSettings.SlidingExpirationInMinutes));
    }
}
