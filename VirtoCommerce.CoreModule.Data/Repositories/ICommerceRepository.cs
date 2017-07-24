﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using VirtoCommerce.CoreModule.Data.Model;

namespace VirtoCommerce.CoreModule.Data.Repositories
{
    public interface IСommerceRepository : Platform.Core.Common.IRepository
    {
        IQueryable<FulfillmentCenter> FulfillmentCenters { get; }
        IQueryable<SeoUrlKeyword> SeoUrlKeywords { get; }
        IQueryable<Sequence> Sequences { get; }
        IQueryable<Currency> Currencies { get; }
        IQueryable<PackageType> PackageTypes { get; }

        SeoUrlKeyword[] GetSeoByIds(string[] ids);
        SeoUrlKeyword[] GetObjectSeoUrlKeywords(string objectType, string objectId);

        DbContextTransaction BeginTransaction(IsolationLevel serializable);
    }
}
