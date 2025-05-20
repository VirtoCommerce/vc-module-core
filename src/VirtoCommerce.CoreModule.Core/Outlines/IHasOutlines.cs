using System;
using System.Collections.Generic;

namespace VirtoCommerce.CoreModule.Core.Outlines
{
    [Obsolete("Interface is deprecated. Use the interface from the Catalog module.", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
    public interface IHasOutlines
    {
        IList<Outline> Outlines { get; set; }
    }
}
