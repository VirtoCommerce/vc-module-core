<template>
  <VcWidget
    icon="lucide-package"
    :title="$t('CORE.PACKAGE_TYPES.TITLE')"
    :value="count ?? '…'"
    @click="openBlade({ name: 'CorePackageTypes' })"
  />
</template>

<script setup lang="ts">
// Widget on the platform's module details blade (registered for PlatformModuleDetails, shown for VirtoCommerce.Core)
import { useBlade } from "@vc-shell/framework";
import { VcWidget } from "@vc-shell/framework/ui";
import { ref, watch } from "vue";
import { packageTypeApi, packageTypeRevision } from "../api";

const { openBlade } = useBlade();
const count = ref<number>();

const refresh = async () => {
  count.value = (await packageTypeApi.list())?.length ?? 0;
};
refresh();
watch(packageTypeRevision, refresh);
</script>
