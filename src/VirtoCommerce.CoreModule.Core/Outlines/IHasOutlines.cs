using System;
using System.Collections.Generic;

namespace VirtoCommerce.CoreModule.Core.Outlines
{
    [Obsolete("Interface is deprecated.", DiagnosticId = "VC0011", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
    public interface IHasOutlines
    {
        IList<Outline> Outlines { get; set; }
    }
}
