import path from "node:path";
import { getDynamicModuleConfiguration } from "@vc-shell/mf-module";

// Builds the Commerce core module's admin UI (currencies, package types) as a Module Federation remote of the
// Admin Shell host. Output: <module>/plugins/admin-shell/, served at /modules/$(VirtoCommerce.Core)/plugins/admin-shell/.
const base = "/modules/$(VirtoCommerce.Core)/plugins/admin-shell/";
process.env.APP_BASE_PATH = base;

export default getDynamicModuleConfiguration({
  appId: "admin-shell",
  moduleRoot: path.resolve(__dirname, ".."),
  entry: "./src/modules/index.ts",
  remoteName: "core_admin",
  base,
});
