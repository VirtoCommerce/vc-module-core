using System;
using System.Collections.Generic;

namespace VirtoCommerce.CoreModule.Core.Outlines
{
    [Obsolete("Use VirtoCommerce.CatalogModule.Core.Outlines.IHasOutline", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
    public interface IHasOutlines
    {
        IList<Outline> Outlines { get; set; }
    }
}
