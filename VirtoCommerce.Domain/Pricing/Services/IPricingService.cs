using System.Collections.Generic;
using VirtoCommerce.Domain.Pricing.Model;

namespace VirtoCommerce.Domain.Pricing.Services
{
    public interface IPricingService
    {
        Price GetPriceById(string id);
        IEnumerable<Price> GetPricesById(IEnumerable<string> ids);
        Pricelist GetPricelistById(string id);
        PricelistAssignment GetPricelistAssignmentById(string id);

        IEnumerable<Pricelist> GetPriceLists();
        IEnumerable<PricelistAssignment> GetPriceListAssignments();

        void SavePrices(Price[] prices);
        void SavePricelists(Pricelist[] priceLists);
        void SavePricelistAssignments(PricelistAssignment[] assignments);    

        void DeletePricelists(string[] ids);
        void DeletePrices(string[] ids);
        void DeletePricelistsAssignments(string[] ids);

        IEnumerable<Pricelist> EvaluatePriceLists(PriceEvaluationContext evalContext);
        IEnumerable<Price> EvaluateProductPrices(PriceEvaluationContext evalContext);
    }
}
