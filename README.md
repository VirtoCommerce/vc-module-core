# VirtoCommerce Core Module

[![Latest release](https://img.shields.io/github/release/VirtoCommerce/vc-module-core.svg)](https://github.com/VirtoCommerce/vc-module-core/releases/latest) [![Total downloads](https://img.shields.io/github/downloads/VirtoCommerce/vc-module-core/total.svg?colorB=007ec6)](https://github.com/VirtoCommerce/vc-module-core/releases) [![License](https://img.shields.io/badge/license-VC%20OSL-blue.svg)](https://virtocommerce.com/open-source-license)

[![CI status](https://github.com/VirtoCommerce/vc-module-core/workflows/Module%20CI/badge.svg?branch=dev)](https://github.com/VirtoCommerce/vc-module-core/actions?query=workflow%3A"Module+CI") [![Quality gate](https://sonarcloud.io/api/project_badges/measure?project=VirtoCommerce_vc-module-core&metric=alert_status&branch=dev)](https://sonarcloud.io/dashboard?id=VirtoCommerce_vc-module-core) [![Reliability rating](https://sonarcloud.io/api/project_badges/measure?project=VirtoCommerce_vc-module-core&metric=reliability_rating&branch=dev)](https://sonarcloud.io/dashboard?id=VirtoCommerce_vc-module-core) [![Security rating](https://sonarcloud.io/api/project_badges/measure?project=VirtoCommerce_vc-module-core&metric=security_rating&branch=dev)](https://sonarcloud.io/dashboard?id=VirtoCommerce_vc-module-core) [![Sqale rating](https://sonarcloud.io/api/project_badges/measure?project=VirtoCommerce_vc-module-core&metric=sqale_rating&branch=dev)](https://sonarcloud.io/dashboard?id=VirtoCommerce_vc-module-core)

## Overview
Represents common eCommerce domain model and base abstractions, which can be used and implemented in derived modules.
It also exposes some common eCommerce APIs for frontend security, SEO, fulfilment, payments and tax evaluation.

## Installation
Installing the module:
* Automatically: in VC Manager go to Configuration -> Modules -> Commerce core module -> Install
* Manually: download module zip package from <a href="https://github.com/VirtoCommerce/vc-module-core/releases" target="_blank">vc-module-core/releases</a>. In VC Manager go to Configuration -> Modules -> Advanced -> upload module package -> Install.

## Settings
* **VirtoCommerce.Core.General.TaxTypes** -  manually defined tax categories which can be assigned to eligible objects (category, product, etc.)
* **VirtoCommerce.Core.General.WeightUnits** - mass units available for physical goods weighting
* **VirtoCommerce.Core.General.Languages** - supported  languages (culture names) (en-US, ru-RU, etc.)
* **VirtoCommerce.Core.FixedRateShippingMethod.Rate** - amount (rate) for “Fixed rate” shipping method
* **VirtoCommerce.Core.FixedTaxRateProvider.Rate** - percentage (rate) for “Fixed rate” tax provider

## References
* Home: https://virtocommerce.com
* Documantation: https://docs.virtocommerce.org
* Community: https://www.virtocommerce.org

## License
Copyright (c) Virto Solutions LTD.  All rights reserved.

This software is licensed under the Virto Commerce Open Software License (the "License"); you
may not use this file except in compliance with the License. You may
obtain a copy of the License at http://virtocommerce.com/opensourcelicense.

Unless required by the applicable law or agreed to in written form, the software
distributed under the License is provided on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied.
