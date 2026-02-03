# VirtoCommerce Core Module

[![Latest release](https://img.shields.io/github/release/VirtoCommerce/vc-module-core.svg)](https://github.com/VirtoCommerce/vc-module-core/releases/latest) [![Total downloads](https://img.shields.io/github/downloads/VirtoCommerce/vc-module-core/total.svg?colorB=007ec6)](https://github.com/VirtoCommerce/vc-module-core/releases) [![License](https://img.shields.io/badge/license-VC%20OSL-blue.svg)](https://virtocommerce.com/open-source-license)

[![CI status](https://github.com/VirtoCommerce/vc-module-core/workflows/Module%20CI/badge.svg?branch=dev)](https://github.com/VirtoCommerce/vc-module-core/actions?query=workflow%3A"Module+CI") [![Quality gate](https://sonarcloud.io/api/project_badges/measure?project=VirtoCommerce_vc-module-core&metric=alert_status&branch=dev)](https://sonarcloud.io/dashboard?id=VirtoCommerce_vc-module-core) [![Reliability rating](https://sonarcloud.io/api/project_badges/measure?project=VirtoCommerce_vc-module-core&metric=reliability_rating&branch=dev)](https://sonarcloud.io/dashboard?id=VirtoCommerce_vc-module-core) [![Security rating](https://sonarcloud.io/api/project_badges/measure?project=VirtoCommerce_vc-module-core&metric=security_rating&branch=dev)](https://sonarcloud.io/dashboard?id=VirtoCommerce_vc-module-core) [![Sqale rating](https://sonarcloud.io/api/project_badges/measure?project=VirtoCommerce_vc-module-core&metric=sqale_rating&branch=dev)](https://sonarcloud.io/dashboard?id=VirtoCommerce_vc-module-core)

## Overview
Virto Commerce Core module provides **shared commerce domain models**, **cross-cutting abstractions**, and **core operational services** used by other Virto Commerce modules.

It is the foundation for common functionality such as currencies, package types, SEO abstractions, conditions infrastructure, money rounding policies, and unique number generation.

## Key Features
- **Common commerce domain models**: shared types for money/currency, tax, addresses, outlines, SEO.
- **Currency management API**: list/create/update/delete currencies.
- **Package types management API**: list/create/update/delete package types.
- **Money rounding**: default rounding policy with an extension point to override it via DI.
- **Unique number generator**: sequence-based generator with configurable retry policy and counter reset rules.
- **Conditions engine foundation**: condition tree types, JSON converter, and a set of built-in conditions (geo, language, URL, etc.).
- **Multi-database support**: EF Core database provider selection (SQL Server / PostgreSQL / MySQL).
- **Export/Import support**: integrates with platform export/import pipeline for module data.
- **Back office assets**: scripts/templates and localization resources for admin UI scenarios.

## Configuration

### Sequence number generator options
The unique number generator binds options from `VirtoCommerce:SequenceNumberGenerator`:

```json
{
  "VirtoCommerce": {
    "SequenceNumberGenerator": {
      "RetryCount": 15,
      "RetryDelay": 5,
      "UseGlobalTenantId": false
    }
  }
}
```

Notes:
- `RetryDelay` is applied by the default implementation as a delay **in milliseconds** between retries.

### Platform settings
The module exposes operational settings via the Virto Commerce settings system:
- **VirtoCommerce.Core.General.TaxTypes** - manually defined tax categories which can be assigned to eligible objects (category, product, etc.)
- **VirtoCommerce.Core.General.WeightUnits** - mass units available for physical goods weighting
- **VirtoCommerce.Core.General.MeasureUnits** - measure units (dimensions) for physical goods
- **VirtoCommerce.Core.FixedTaxRateProvider.Rate** - percentage (rate) for “Fixed rate” tax provider

### Permissions
Admin APIs are secured by module permissions:
- `core:currency:create`, `core:currency:update`, `core:currency:delete`
- `core:packageType:create`, `core:packageType:update`, `core:packageType:delete`

### Project Structure
```text
vc-module-core/
├── src/
│   ├── VirtoCommerce.CoreModule.Core/            # Domain models, abstractions, settings, permissions
│   ├── VirtoCommerce.CoreModule.Data/            # EF Core repositories/entities/services
│   ├── VirtoCommerce.CoreModule.Data.SqlServer/  # SQL Server provider wiring/migrations
│   ├── VirtoCommerce.CoreModule.Data.PostgreSql/ # PostgreSQL provider wiring/migrations
│   ├── VirtoCommerce.CoreModule.Data.MySql/      # MySQL provider wiring/migrations
│   ├── VirtoCommerce.CoreModule.Web/             # Module bootstrap, Web API, back office assets & localization
│   └── VirtoCommerce.Tools/                      # Shared tooling utilities (used across platform/modules)
└── tests/
    ├── VirtoCommerce.CoreModule.Tests/           # Core module tests
    └── VirtoCommerce.Tools.Tests/                # Tools tests
```

### Key Components
- **`ICurrencyService` / `CurrencyService`**: currency management operations used by API and other modules.
- **`IPackageTypesService` / `PackageTypesService`**: package type management operations.
- **`IMoneyRoundingPolicy`**: extension point for money rounding strategy (default: `DefaultMoneyRoundingPolicy`).
- **`IUniqueNumberGenerator` / `ITenantUniqueNumberGenerator`**: sequence-based unique number generator services.

## References
* Home: https://virtocommerce.com
* Documentation: https://docs.virtocommerce.org
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
