# VirtoCommerce.Core
Current module represent common eCommerce domain model and base abstractions which can be used and implemented in derived modules.
Also expose some common eCommerce API for storefront security, SEO, fulmilments, payments and tax evaluation.
<a href="http://demo.virtocommerce.com/admin/docs/ui/index#!/Commerce_core_module" target="_blank">Commerce core module API online documentation</a>
# Installation
Install the module.
* Automaticaly: go to VC Manager Configuration -> Modules -> Commerce core module -> Install
* Manualy: download module zip archive from <a href="https://github.com/VirtoCommerce/vc-module-core/releases" target="_blank">vc-module-core/releases</a>  then go to VC Manager Configuration->Modules->Advanced-> upload module archive and install.

# Settings
* **VirtoCommerce.Core.General.TaxTypes** -  manual defined tax categories which can be used for assign to any objects (category, products etc)
* **VirtoCommerce.Core.General.WeightUnits** - contains  weight units 
* **VirtoCommerce.Core.General.Languages** - list of supported  language culture names (en-US, ru-RU etc)
* **VirtoCommerce.Core.FixedRateShippingMethod.Rate** - fixed rate for 'fixed rate' shipping method
* **VirtoCommerce.Core.FixedTaxRateProvider.Rate** - fixed rate for 'fixed rate' tax provider

# Module development
Add to you VC project module
https://www.nuget.org/packages/VirtoCommerce.Domain  NuGet package

# API
Online API documentation
http://demo.virtocommerce.com/admin/docs/ui/index#!/Commerce_core_module
C# API client NuGet package
*place url here*

# Licence
Copyright (c) Virtosoftware Ltd.  All rights reserved.

Licensed under the Virto Commerce Open Software License (the "License"); you
may not use this file except in compliance with the License. You may
obtain a copy of the License at

http://virtocommerce.com/opensourcelicense

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied.
