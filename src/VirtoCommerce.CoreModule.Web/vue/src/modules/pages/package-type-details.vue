<template>
  <VcBlade
    :title="isNew ? $t('CORE.PACKAGE_TYPES.NEW_TITLE') : item.name"
    :subtitle="$t('CORE.PACKAGE_TYPES.DETAILS_SUBTITLE')"
    :toolbar-items="toolbar"
    :loading="loading"
    :modified="form.isModified.value"
    width="50%"
  >
    <VcContainer>
      <VcForm class="core-form">
        <VcInput
          v-model="item.name"
          :label="$t('CORE.PACKAGE_TYPES.NAME')"
          required
          :error-message="item.name ? undefined : $t('CORE.COMMON.REQUIRED')"
        />
        <VcSelect
          v-model="item.measureUnit"
          :label="$t('CORE.PACKAGE_TYPES.MEASURE_UNIT')"
          :hint="$t('CORE.PACKAGE_TYPES.MEASURE_UNIT_HINT')"
          :options="measureUnits"
          required
          :error-message="item.measureUnit ? undefined : $t('CORE.COMMON.REQUIRED')"
        />
        <VcRow class="tw-gap-4">
          <VcCol
            v-for="dimension in DIMENSIONS"
            :key="dimension"
          >
            <VcInput
              v-model="item[dimension]"
              type="number"
              step="any"
              :label="$t(`CORE.PACKAGE_TYPES.${dimension.toUpperCase()}`)"
              required
              :error-message="(item[dimension] ?? 0) > 0 ? undefined : $t('CORE.PACKAGE_TYPES.DIMENSION_INVALID')"
            />
          </VcCol>
        </VcRow>
      </VcForm>
    </VcContainer>
  </VcBlade>
</template>

<script setup lang="ts">
import {
  notification,
  useAsync,
  useBlade,
  useBladeForm,
  useLoading,
  usePermissions,
  usePopup,
  type IBladeToolbar,
} from "@vc-shell/framework";
import { VcBlade, VcCol, VcContainer, VcForm, VcInput, VcRow, VcSelect } from "@vc-shell/framework/ui";
import { computed, ref } from "vue";
import { useI18n } from "vue-i18n";
import { api, packageTypeApi, type PackageType } from "../api";

defineBlade({
  url: "/package-type",
  name: "CorePackageTypeDetails",
  // the package type comes only in options: a reload would reopen it as a new, empty one
  routable: false,
});

const DIMENSIONS = ["height", "width", "length"] as const;

const { t } = useI18n({ useScope: "global" });
const { options, closeSelf, callParent } = useBlade<{ packageType?: PackageType }>();
const { hasAccess } = usePermissions();
const { showConfirmation } = usePopup();

const isNew = computed(() => !options.value?.packageType);
const item = ref<PackageType>(options.value?.packageType ? JSON.parse(JSON.stringify(options.value.packageType)) : {});
const measureUnits = ref<{ id: string; title: string }[]>([]);

const valid = computed(() => !!item.value.name && !!item.value.measureUnit && DIMENSIONS.every((d) => (item.value[d] ?? 0) > 0));
const form = useBladeForm({
  data: item,
  canSaveOverride: computed(() => valid.value && hasAccess(isNew.value ? "core:packageType:create" : "core:packageType:update")),
  closeConfirmMessage: computed(() => t("CORE.COMMON.CLOSE_CONFIRMATION")),
});
form.setBaseline();

// legacy va-setting-value-select over VirtoCommerce.Core.General.MeasureUnits (settings/values: no setting permission needed)
const { loading: unitsLoading, action: loadUnits } = useAsync(async () => {
  const units = await api<unknown[] | null>("GET", "/api/platform/settings/values/VirtoCommerce.Core.General.MeasureUnits").catch(() => []);
  measureUnits.value = (units ?? []).map((x) => ({ id: String(x), title: String(x) }));
});

const { loading: saveLoading, action: save } = useAsync(async () => {
  await (isNew.value ? packageTypeApi.create(item.value) : packageTypeApi.update(item.value));
  notification.success(t("CORE.COMMON.SAVED"));
  form.setBaseline();
  await callParent("reload");
  await closeSelf();
});

const loading = useLoading(unitsLoading, saveLoading);

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
    permissions: ["core:packageType:delete"],
    isVisible: !isNew.value,
    async clickHandler() {
      if (await showConfirmation(t("CORE.PACKAGE_TYPES.DELETE_CONFIRM", { name: item.value.name }))) {
        await packageTypeApi.remove([item.value.id!]);
        form.setBaseline();
        await callParent("reload");
        await closeSelf();
      }
    },
  },
]);

loadUnits();
</script>
