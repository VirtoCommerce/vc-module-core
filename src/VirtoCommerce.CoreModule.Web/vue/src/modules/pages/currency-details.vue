<template>
  <VcBlade
    :title="isNew ? $t('CORE.CURRENCIES.NEW_TITLE') : item.name || item.code"
    :subtitle="$t('CORE.CURRENCIES.DETAILS_SUBTITLE')"
    :toolbar-items="toolbar"
    :loading="loading"
    :modified="form.isModified.value"
    width="50%"
  >
    <VcContainer>
      <VcForm class="core-form">
        <VcRow class="tw-gap-4">
          <VcCol>
            <VcInput
              v-model="item.code"
              :label="$t('CORE.CURRENCIES.CODE')"
              :placeholder="$t('CORE.CURRENCIES.CODE_PLACEHOLDER')"
              maxlength="3"
              required
              :disabled="!isNew"
              :error-message="item.code ? undefined : $t('CORE.COMMON.REQUIRED')"
            />
          </VcCol>
          <VcCol>
            <VcInput
              v-model="item.name"
              :label="$t('CORE.CURRENCIES.NAME')"
              required
              :error-message="item.name ? undefined : $t('CORE.COMMON.REQUIRED')"
            />
          </VcCol>
        </VcRow>
        <VcSwitch
          v-model="item.isPrimary"
          :label="$t('CORE.CURRENCIES.PRIMARY')"
          :hint="$t('CORE.CURRENCIES.PRIMARY_HINT')"
        />
        <VcRow class="tw-gap-4">
          <VcCol>
            <VcInput
              v-model="item.exchangeRate"
              type="number"
              step="0.0001"
              :label="$t('CORE.CURRENCIES.EXCHANGE_RATE')"
              required
              :error-message="(item.exchangeRate ?? 0) > 0 ? undefined : $t('CORE.CURRENCIES.RATE_INVALID')"
            />
          </VcCol>
          <VcCol>
            <VcInput
              v-model="item.symbol"
              :label="$t('CORE.CURRENCIES.SYMBOL')"
            />
          </VcCol>
          <VcCol>
            <VcInput
              v-model="item.decimalDigits"
              type="integer"
              :label="$t('CORE.CURRENCIES.DECIMAL_DIGITS')"
            />
          </VcCol>
        </VcRow>
        <VcInput
          v-model="item.customFormatting"
          :label="$t('CORE.CURRENCIES.CUSTOM_FORMATTING')"
          :hint="$t('CORE.CURRENCIES.CUSTOM_FORMATTING_HINT')"
        />
        <VcRow class="tw-gap-4">
          <VcCol>
            <VcSelect
              v-model="item.midpointRounding"
              :label="$t('CORE.CURRENCIES.MIDPOINT_ROUNDING')"
              :options="MIDPOINT_ROUNDINGS.map((x) => ({ id: x, title: x }))"
            />
          </VcCol>
          <VcCol>
            <VcSelect
              v-model="item.roundingType"
              :label="$t('CORE.CURRENCIES.ROUNDING_TYPE')"
              :options="ROUNDING_TYPES.map((x) => ({ id: x, title: x }))"
            />
          </VcCol>
        </VcRow>
      </VcForm>
    </VcContainer>
  </VcBlade>
</template>

<script setup lang="ts">
import { notification, useAsync, useBlade, useBladeForm, usePermissions, usePopup, type IBladeToolbar } from "@vc-shell/framework";
import { VcBlade, VcCol, VcContainer, VcForm, VcInput, VcRow, VcSelect, VcSwitch } from "@vc-shell/framework/ui";
import { computed, ref } from "vue";
import { useI18n } from "vue-i18n";
import { MIDPOINT_ROUNDINGS, ROUNDING_TYPES, currencyApi, type Currency } from "../api";

defineBlade({
  url: "/currency",
  name: "CoreCurrencyDetails",
});

const { t } = useI18n({ useScope: "global" });
const { options, closeSelf, callParent } = useBlade<{ currency?: Currency }>();
const { hasAccess } = usePermissions();
const { showConfirmation } = usePopup();

const isNew = computed(() => !options.value?.currency);
// legacy defaults for a new currency
const item = ref<Currency>(
  options.value?.currency ? JSON.parse(JSON.stringify(options.value.currency)) : { code: "", exchangeRate: 1, decimalDigits: 2 },
);

const valid = computed(() => !!item.value.code && !!item.value.name && (item.value.exchangeRate ?? 0) > 0);
const form = useBladeForm({
  data: item,
  canSaveOverride: computed(() => valid.value && hasAccess(isNew.value ? "core:currency:create" : "core:currency:update")),
  closeConfirmMessage: computed(() => t("CORE.COMMON.CLOSE_CONFIRMATION")),
});
form.setBaseline();

const { loading, action: save } = useAsync(async () => {
  await (isNew.value ? currencyApi.create(item.value) : currencyApi.update(item.value));
  notification.success(t("CORE.COMMON.SAVED"));
  form.setBaseline();
  await callParent("reload");
  await closeSelf();
});

const toolbar = ref<IBladeToolbar[]>([
  {
    id: "save",
    title: isNew.value ? t("CORE.COMMON.CREATE") : t("CORE.COMMON.SAVE"),
    icon: "lucide-save",
    disabled: computed(() => !form.canSave.value),
    clickHandler: () => save(),
  },
  {
    id: "reset",
    title: t("CORE.COMMON.RESET"),
    icon: "lucide-undo-2",
    isVisible: !isNew.value,
    disabled: computed(() => !form.isModified.value),
    clickHandler: () => form.revert(),
  },
  {
    id: "delete",
    title: t("CORE.COMMON.DELETE"),
    icon: "lucide-trash-2",
    permissions: ["core:currency:delete"],
    isVisible: !isNew.value,
    // the primary currency can't be deleted
    disabled: !!options.value?.currency?.isPrimary,
    async clickHandler() {
      if (await showConfirmation(t("CORE.CURRENCIES.DELETE_CONFIRM", { code: item.value.code }))) {
        await currencyApi.remove([item.value.code]);
        form.setBaseline();
        await callParent("reload");
        await closeSelf();
      }
    },
  },
]);
</script>
