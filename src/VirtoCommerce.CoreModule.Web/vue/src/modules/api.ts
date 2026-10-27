import { ref, type Ref } from "vue";

/** bumped after every currency / package type change, so the widgets on the module blade can refresh their counts */
export const currencyRevision = ref(0);
export const packageTypeRevision = ref(0);
const changed = <T>(revision: Ref<number>, promise: Promise<T>) =>
  promise.then((result) => {
    revision.value++;
    return result;
  });

// Same-origin fetch for the Commerce core API (api/currencies, api/packageTypes); cookie auth applies.
export async function api<T = unknown>(method: string, url: string, body?: unknown): Promise<T> {
  const response = await fetch(url, {
    method,
    headers: body === undefined ? undefined : { "Content-Type": "application/json" },
    body: body === undefined ? undefined : JSON.stringify(body),
  });
  const text = await response.text();
  if (!response.ok) {
    const detail = text ? `: ${text}` : "";
    throw new Error(`${response.status} ${response.statusText}${detail}`);
  }
  return (text ? JSON.parse(text) : undefined) as T;
}

const query = (name: string, values: string[]) => values.map((v) => `${name}=${encodeURIComponent(v)}`).join("&");

/** CommerceController: currencies */
export interface Currency {
  code: string;
  name?: string;
  isPrimary?: boolean;
  exchangeRate?: number;
  symbol?: string | null;
  customFormatting?: string | null;
  roundingType?: string | null;
  midpointRounding?: string | null;
  decimalDigits?: number;
}

export const ROUNDING_TYPES = ["Rounding001", "Rounding005Up", "Rounding005Down", "Rounding01Up", "Rounding01Down", "Rounding05", "Rounding1", "Rounding1Up"];
export const MIDPOINT_ROUNDINGS = ["ToEven", "AwayFromZero", "ToZero", "ToNegativeInfinity", "ToPositiveInfinity"];

export const currencyApi = {
  list: () => api<Currency[]>("GET", "/api/currencies"),
  create: (currency: Currency) => changed(currencyRevision, api("POST", "/api/currencies", currency)),
  update: (currency: Currency) => changed(currencyRevision, api("PUT", "/api/currencies", currency)),
  remove: (codes: string[]) => changed(currencyRevision, api("DELETE", `/api/currencies?${query("codes", codes)}`)),
};

/** CommerceController: package types */
export interface PackageType {
  id?: string;
  name?: string;
  length?: number;
  width?: number;
  height?: number;
  measureUnit?: string | null;
}

export const packageTypeApi = {
  list: () => api<PackageType[]>("GET", "/api/packageTypes"),
  create: (packageType: PackageType) => changed(packageTypeRevision, api("POST", "/api/packageTypes", packageType)),
  update: (packageType: PackageType) => changed(packageTypeRevision, api("PUT", "/api/packageTypes", packageType)),
  remove: (ids: string[]) => changed(packageTypeRevision, api("DELETE", `/api/packageTypes?${query("ids", ids)}`)),
};
