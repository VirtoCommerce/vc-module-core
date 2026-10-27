import * as blades from "./pages";
import * as locales from "./locales";
import { defineAppModule, registerExternalWidget } from "@vc-shell/framework";
import { markRaw } from "vue";
import CurrenciesWidget from "./widgets/CurrenciesWidget.vue";
import PackageTypesWidget from "./widgets/PackageTypesWidget.vue";
import "./styles.scss";

// Legacy: currencyWidget is registered into 'moduleDetail' and shown when the module is VirtoCommerce.Core.
// The platform plugin's module details blade (PlatformModuleDetails) exposes the module as its blade context.
const onCoreModule = (blade?: { param?: string }) => blade?.param === "VirtoCommerce.Core";

registerExternalWidget({
  id: "CoreCurrencies",
  title: "Currencies",
  component: markRaw(CurrenciesWidget),
  targetBlades: ["PlatformModuleDetails"],
  isVisible: onCoreModule,
});
// Package types: legacy opens them from Catalog's product dimensions (packageTypeUtils.editPackageTypes);
// the Catalog plugin opens the "CorePackageTypes" blade, and this widget makes them reachable from Core's details too.
registerExternalWidget({
  id: "CorePackageTypes",
  title: "Package types",
  component: markRaw(PackageTypesWidget),
  targetBlades: ["PlatformModuleDetails"],
  isVisible: onCoreModule,
});

export default defineAppModule({
  blades,
  locales,
});

export * from "./pages";
