using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using VirtoCommerce.CoreModule.Core.NumberGenerators;
using VirtoCommerce.CoreModule.Core.Services;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace VirtoCommerce.CoreModule.Data.NumberGenerators
{
    public class NumberGeneratorService : INumberGeneratorService
    {
        private readonly Func<ICoreRepository> _repositoryFactory;
        private readonly IPlatformMemoryCache _platformMemoryCache;

        public NumberGeneratorService(Func<ICoreRepository> repositoryFactory, IPlatformMemoryCache platformMemoryCache)
        {
            _repositoryFactory = repositoryFactory;
            _platformMemoryCache = platformMemoryCache;
        }

        public async Task<NumberGeneratorDescriptor[]> GetByTenantIdAsync(string tenantId)
        {
            var cacheKey = CacheKey.With(GetType(), nameof(GetByTenantIdAsync), tenantId);
            return await _platformMemoryCache.GetOrCreateExclusive(cacheKey, async (cacheEntry) =>
            {
                cacheEntry.AddExpirationToken(NumberGeneratorCacheRegion.CreateChangeToken());
                using var repository = _repositoryFactory();
                repository.DisableChangesTracking();

                var items = await repository.NumberGenerators.Where(x => x.TenantId == tenantId).ToArrayAsync();

                return items.Select(x => x.ToModel(AbstractTypeFactory<NumberGeneratorDescriptor>.TryCreateInstance())).ToArray();
            });
        }

        public async Task<NumberGeneratorDescriptor> GetAsync(string tenantId, string targetType)
        {
            var tenantNumberGenerators = await GetByTenantIdAsync(tenantId);
            return tenantNumberGenerators.FirstOrDefault(x => x.TargetType == targetType);
        }

        public async Task SaveChangesAsync(NumberGeneratorDescriptor[] items)
        {
            if (!items.IsNullOrEmpty())
            {
                await ValidateItems(items);

                using (var repository = _repositoryFactory())
                {
                    foreach (var item in items)
                    {
                        var originalEntity = repository.NumberGenerators.FirstOrDefault(x => x.TargetType.EqualsInvariant(item.TargetType) && x.TenantId.EqualsInvariant(item.TenantId));

                        var modifiedEntity = AbstractTypeFactory<NumberGeneratorDescriptorEntity>.TryCreateInstance().FromModel(item);

                        if (originalEntity != null)
                        {
                            repository.TrackModifiedAsAddedForNewChildEntities(originalEntity);
                            modifiedEntity?.Patch(originalEntity);
                            repository.ResetSequence(item.Template, false, item.Start, item.Increment);
                        }
                        else
                        {
                            repository.Add(modifiedEntity);
                            repository.ResetSequence(item.Template, false, item.Start, item.Increment);
                        }
                    }

                    await repository.UnitOfWork.CommitAsync();
                }

                NumberGeneratorCacheRegion.ExpireRegion();
            }
        }

        private async Task ValidateItems(NumberGeneratorDescriptor[] items)
        {
            var validator = AbstractTypeFactory<NumberGeneratorDescriptorValidator>.TryCreateInstance();
            foreach (var item in items)
            {
                await validator.ValidateAndThrowAsync(item);
            }
        }
    }
}
