<template>
  <div class="releases-container">
    <div v-if="isLoaded && !releaseSelected.id" class="release-names-container">
      <div class="creator-button">
        <ReleaseCreator @create-release="createRelease" />
      </div>
      <div v-if="releasesName.length" class="release-list-container">
        <div class="title-container">
          <div class="search-icon">
            <SVGIcons :name="'search'" @click="toggleSearchBar" />
          </div>
          <div v-t="'pages.default.releasesNameList'" class="title" />
        </div>
        <div v-if="isSearchBarOpened" class="search-input-container">
          <SearchRelease :releases-name="releasesName" @update-releases-name="updateReleasesNameFiltered" />
        </div>
        <div class="releases-name">
          <ReleasesName :releases-name="releasesNameFiltered" @select-release="selectRelease" />
        </div>
      </div>
      <div v-else>
        <div v-t="'pages.default.noRelease'" class="empty" />
      </div>
    </div>
    <div v-if="isReleaseSelected" class="release-infos-container">
      <ReleaseInfo
        :release-data="releaseSelected"
        :is-task-updating="isTaskUpdating"
        :is-funky-mode-enabled="isFunkyModeEnabled"
        @update-task-status="updateTaskStatus"
        @toggle-funky-mode="toggleFunkyMode" />
    </div>
    <div v-if="isReleaseSelected" class="links-container">
      <Links :id="releaseSelected.id!" :links="links" />
    </div>
  </div>
</template>

<script setup lang="ts">
import type { NuxtError } from 'nuxt/app'
import { storeToRefs } from 'pinia'
import type { IRelease, IReleaseName, ITask } from '~/api/api.type'
import { handleError } from '~/helpers/error'
import { sortByNameDesc } from '~/helpers/filter'

const releaseStore = useReleaseStore()

onMounted(() => {
  init()
})

const { isLoaded, releaseSelected, isCurrentTaskSelected, releasesName, links, isFunkyModeEnabled } = storeToRefs(releaseStore)

const { t } = useI18n()
const isSearchBarOpened = ref(false)
const releasesNameFiltered = ref([] as IReleaseName[])
const isTaskUpdating = ref(false)

const isReleaseSelected = computed(() => {
  return isLoaded.value && releaseSelected.value.id
})

async function init(): Promise<void> {
  try {
    if (!isReleaseSelected.value) {
      await releaseStore.dispatchReleasesName()
      releasesNameFiltered.value = sortByNameDesc(releasesName.value)
    }

    if (isCurrentTaskSelected) {
      releaseStore.dispatchResetCurrentTask()
      releaseStore.dispatchResetIsCurrentTaskSelected()
      releaseStore.dispatchResetPreviousTask()
      releaseStore.dispatchResetNextTask()
    }
  } catch (error) {
    handleError(error)
  }
}

async function selectRelease(id: string): Promise<void> {
  try {
    await releaseStore.dispatchReleaseSelected(id)
  } catch (error: any) {
    if (error as NuxtError) {
      error.message = t('pages.default.errorNoRelease')
    }
    handleError(error)
  }
}

async function updateTaskStatus(status: boolean, task: ITask, releaseId: string): Promise<void> {
  try {
    isTaskUpdating.value = true
    await releaseStore.dispatchTaskStatus(status, task, releaseId)
  } catch (error) {
    handleError(error)
  } finally {
    isTaskUpdating.value = false
  }
}

async function createRelease(release: IRelease): Promise<void> {
  try {
    await releaseStore.dispatchCreateRelease(release)
  } catch (error) {
    handleError(error)
  }
}

function toggleSearchBar(): void {
  isSearchBarOpened.value = !isSearchBarOpened.value
  if (!isSearchBarOpened.value) {
    releasesNameFiltered.value = sortByNameDesc(releasesName.value)
  }
}

function updateReleasesNameFiltered(namesFiltered: IReleaseName[]): void {
  releasesNameFiltered.value = namesFiltered
}

function toggleFunkyMode(isFunkyModeEnabled: boolean) {
  releaseStore.dispatchToggleFunkyMode(isFunkyModeEnabled)
}
</script>

<style lang="scss" scoped>
.releases-container {
  .release-names-container {
    .release-list-container {
      display: flex;
      align-items: center;
      justify-content: center;
      flex-direction: column;

      .title-container {
        display: flex;
        align-items: center;
        justify-content: center;
        margin-bottom: 15px;

        .search-icon {
          width: 18px;
          height: 18px;
          cursor: pointer;
          fill: $grey-text-color;
          fill-opacity: 0.6;
          margin-right: 5px;
        }

        .title {
          font-weight: bold;
          font-size: 20px;
        }
      }

      .search-input-container {
        margin-bottom: 25px;
      }

      .releases-name {
        text-align: center;
      }
    }

    .empty {
      text-align: center;
      font-weight: bold;
      font-size: 20px;
      margin-top: 250px;
    }

    .creator-button {
      margin-bottom: 50px;
    }
  }

  .links-container {
    position: relative;
    display: flex;
    z-index: $links-home-z-index;
    margin-top: 5%;
  }
}
</style>
