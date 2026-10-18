<template>
  <VcWidget
    icon="lucide-banknote"
    :title="$t('CORE.CURRENCIES.TITLE')"
    :value="count ?? '…'"
    @click="openBlade({ name: 'CoreCurrencies' })"
  />
</template>

<script setup lang="ts">
// Widget on the platform's module details blade (registered for PlatformModuleDetails, shown for VirtoCommerce.Core)
import { useBlade } from "@vc-shell/framework";
import { VcWidget } from "@vc-shell/framework/ui";
import { ref, watch } from "vue";
import { currencyApi, currencyRevision } from "../api";

const { openBlade } = useBlade();
const count = ref<number>();

const refresh = async () => {
  count.value = (await currencyApi.list())?.length ?? 0;
};
refresh();
watch(currencyRevision, refresh);
</script>
