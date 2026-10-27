<template>
  <VcBlade
    :title="$t('CORE.PACKAGE_TYPES.TITLE')"
    :subtitle="$t('CORE.SUBTITLE')"
    :toolbar-items="toolbar"
    :loading="loading"
    width="50%"
  >
    <VcDataTable
      :items="packageTypes"
      :total-count="packageTypes.length"
      :state-key="'CORE_PACKAGE_TYPES'"
      :active-item-id="activeId"
      :empty-state="{ icon: 'lucide-package', title: $t('CORE.PACKAGE_TYPES.EMPTY') }"
      @row-click="(e: { data: PackageType }) => openPackageType(e.data)"
    >
      <VcColumn
        id="name"
        :title="$t('CORE.PACKAGE_TYPES.NAME')"
        always-visible
      />
      <VcColumn
        id="size"
        :title="$t('CORE.PACKAGE_TYPES.SIZE')"
      >
        <template #body="{ data }">{{ size(data) }}</template>
      </VcColumn>
    </VcDataTable>
  </VcBlade>
</template>

<script setup lang="ts">
import { useAsync, useBlade, type IBladeToolbar } from "@vc-shell/framework";
import { VcBlade, VcColumn, VcDataTable } from "@vc-shell/framework/ui";
import { ref } from "vue";
import { useI18n } from "vue-i18n";
import { packageTypeApi, type PackageType } from "../api";

defineBlade({
  url: "/package-types",
  name: "CorePackageTypes",
});

const { t } = useI18n({ useScope: "global" });
const { openBlade, exposeToChildren } = useBlade();

const packageTypes = ref<PackageType[]>([]);
const activeId = ref<string>();

// "30 × 20 × 10 cm" (height × width × length, as the legacy detail lists them)
const size = (p: PackageType) => `${[p.height, p.width, p.length].map((x) => x ?? "?").join(" × ")} ${p.measureUnit ?? ""}`.trim();

const { loading, action: load } = useAsync(async () => {
  packageTypes.value = (await packageTypeApi.list()) ?? [];
});

function openPackageType(packageType?: PackageType) {
  openBlade({
    name: "CorePackageTypeDetails",
    options: { packageType },
    onOpen: () => (activeId.value = packageType?.id),
    onClose: () => (activeId.value = undefined),
  });
}

const toolbar = ref<IBladeToolbar[]>([
  { id: "refresh", title: t("CORE.COMMON.REFRESH"), icon: "lucide-refresh-cw", clickHandler: () => load() },
  { id: "add", title: t("CORE.COMMON.ADD"), icon: "lucide-plus", permissions: ["core:packageType:create"], clickHandler: () => openPackageType() },
]);

load();

exposeToChildren({ reload: () => load() });
</script>
