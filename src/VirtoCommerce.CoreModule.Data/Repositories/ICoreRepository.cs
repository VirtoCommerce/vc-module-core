using System;
using System.Linq;
using VirtoCommerce.CoreModule.Data.Currency;
using VirtoCommerce.CoreModule.Data.Model;
using VirtoCommerce.CoreModule.Data.Package;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Data.Repositories
{
    public interface ICoreRepository : IRepository
    {
        IQueryable<SequenceEntity> Sequences { get; }
        IQueryable<NumberGeneratorDescriptorEntity> NumberGenerators { get; }
        IQueryable<CurrencyEntity> Currencies { get; }
        IQueryable<PackageTypeEntity> PackageTypes { get; }

        /// <summary>
        /// Gets next database sequence value by name.
        /// </summary>
        /// <param name="name">Sequence name.</param>
        /// <returns>Sequence value</returns>
        long GetNextSequenceValue(string name);
        /// <summary>
        /// Creates or updates sequence. Always reset current value to <paramref name="startWith"/>.
        /// </summary>
        /// <param name="name">Sequence name.</param>
        /// <param name="startWith">Starting number.</param>
        /// <param name="incrementBy">Increment.</param>
        void CreateOrUpdateSequence(string name, long startWith = 1, int incrementBy = 1);
        /// <summary>
        /// Resets sequence if <see cref="NumberGeneratorDescriptorEntity.LastResetDate"/> of descriptor is lesser than <paramref name="desiredResetDate"/>.
        /// Sets <see cref="NumberGeneratorDescriptorEntity.LastResetDate"/> to <paramref name="desiredResetDate"/> if reset is performed.
        /// </summary>
        /// <param name="descriptorId">Template generator descriptor id.</param>
        /// <param name="desiredResetDate">Date which is used to check it the sequence should be reset.</param>
        void ResetSequenceForDescriptor(string descriptorId, DateTime? desiredResetDate);
        /// <summary>
        /// Drops the sequence from database.
        /// </summary>
        /// <param name="name">Sequence name</param>
        void DeleteSequence(string name);
    }
}
