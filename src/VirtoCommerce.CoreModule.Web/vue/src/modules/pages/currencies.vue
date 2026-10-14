<template>
  <VcBlade
    :title="$t('CORE.CURRENCIES.TITLE')"
    :subtitle="$t('CORE.CURRENCIES.SUBTITLE')"
    :toolbar-items="toolbar"
    :loading="loading"
    width="50%"
  >
    <VcDataTable
      :items="currencies"
      :total-count="currencies.length"
      :state-key="'CORE_CURRENCIES'"
      :active-item-id="activeId"
      :empty-state="{ icon: 'lucide-banknote', title: $t('CORE.CURRENCIES.EMPTY') }"
      @row-click="(e: { data: CurrencyRow }) => openCurrency(e.data)"
    >
      <VcColumn
        id="code"
        :title="$t('CORE.CURRENCIES.CODE')"
        width="100px"
        always-visible
      />
      <VcColumn
        id="name"
        :title="$t('CORE.CURRENCIES.NAME')"
      />
      <VcColumn
        id="symbol"
        :title="$t('CORE.CURRENCIES.SYMBOL')"
        width="100px"
      />
      <VcColumn
        id="exchangeRate"
        :title="$t('CORE.CURRENCIES.EXCHANGE_RATE')"
        width="140px"
      >
        <template #body="{ data }">{{ data.exchangeRate }}</template>
      </VcColumn>
      <VcColumn
        id="isPrimary"
        :title="$t('CORE.CURRENCIES.PRIMARY')"
        width="120px"
      >
        <template #body="{ data }">
          <VcIcon
            v-if="data.isPrimary"
            icon="lucide-check"
            size="s"
            :aria-label="$t('CORE.CURRENCIES.PRIMARY')"
          />
        </template>
      </VcColumn>
    </VcDataTable>
  </VcBlade>
</template>

<script setup lang="ts">
import { useAsync, useBlade, type IBladeToolbar } from "@vc-shell/framework";
import { VcBlade, VcColumn, VcDataTable, VcIcon } from "@vc-shell/framework/ui";
import { ref } from "vue";
import { useI18n } from "vue-i18n";
import { currencyApi, type Currency } from "../api";

defineBlade({
  url: "/currencies",
  name: "CoreCurrencies",
});

type CurrencyRow = Currency & { id: string };

const { t } = useI18n({ useScope: "global" });
const { openBlade, exposeToChildren } = useBlade();

const currencies = ref<CurrencyRow[]>([]);
const activeId = ref<string>();

const { loading, action: load } = useAsync(async () => {
  currencies.value = (await currencyApi.list()).map((c) => ({ ...c, id: c.code }));
});

function openCurrency(currency?: CurrencyRow) {
  openBlade({
    name: "CoreCurrencyDetails",
    options: { currency },
    onOpen: () => (activeId.value = currency?.code),
    onClose: () => (activeId.value = undefined),
  });
}

const toolbar = ref<IBladeToolbar[]>([
  { id: "refresh", title: t("CORE.COMMON.REFRESH"), icon: "lucide-refresh-cw", clickHandler: () => load() },
  { id: "add", title: t("CORE.COMMON.ADD"), icon: "lucide-plus", permissions: ["core:currency:create"], clickHandler: () => openCurrency() },
]);

load();

exposeToChildren({ reload: () => load() });
</script>
