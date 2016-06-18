[![Build Status](http://ci.virtocommerce.com:8080/buildStatus/icon?job=vc-2-org/vc-module-core/master)](http://ci.virtocommerce.com:8080/job/vc-2-org/job/vc-module-core/job/master)

# VirtoCommerce.Core
VirtoCommerce.Core module represents common eCommerce domain model and base abstractions, which can be used and implemented in derived modules.
It also exposes some common eCommerce API for storefront security, SEO, fulfillments, payments and taxes evaluation.

# Installation
Installing the module:
* Automatically: in VC Manager go to Configuration -> Modules -> Commerce core module -> Install
* Manually: download module zip package from <a href="https://github.com/VirtoCommerce/vc-module-core/releases" target="_blank">vc-module-core/releases</a>. In VC Manager go to Configuration -> Modules -> Advanced -> upload module package -> Install.

# Settings
* **VirtoCommerce.Core.General.TaxTypes** -  manually defined tax categories which can be assigned to eligible objects (category, product, etc.)
* **VirtoCommerce.Core.General.WeightUnits** - mass units available for physical goods weighting
* **VirtoCommerce.Core.General.Languages** - supported  languages (culture names) (en-US, ru-RU, etc.)
* **VirtoCommerce.Core.FixedRateShippingMethod.Rate** - amount (rate) for “Fixed rate” shipping method
* **VirtoCommerce.Core.FixedTaxRateProvider.Rate** - percentage (rate) for “Fixed rate” tax provider

# Available resources
* eCommerce domain model and service interfaces as a <a href="https://www.nuget.org/packages/VirtoCommerce.Domain" target="_blank">NuGet package</a>
* core eCommerce service implementations as a <a href="https://www.nuget.org/packages/VirtoCommerce.CoreModule.Data" target="_blank">NuGet package</a>
* core eCommerce C# API client as a <a href="https://www.nuget.org/packages/VirtoCommerce.CoreModule.Client" target="_blank">NuGet package</a>
* API client documentation http://demo.virtocommerce.com/admin/docs/ui/index#!/Commerce_core_module

# License
Copyright (c) Virtosoftware Ltd.  All rights reserved.

Licensed under the Virto Commerce Open Software License (the "License"); you
may not use this file except in compliance with the License. You may
obtain a copy of the License at

http://virtocommerce.com/opensourcelicense

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied.
