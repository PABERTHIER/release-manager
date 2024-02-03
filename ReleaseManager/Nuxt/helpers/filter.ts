import type { IReleaseName } from '~/api/api.type'

export function sortByNameDesc(releasesName: IReleaseName[]): IReleaseName[] {
  return releasesName
    .sort((a, b) => a.name.localeCompare(b.name))
    .reverse()
    .slice(0, 15)
}
