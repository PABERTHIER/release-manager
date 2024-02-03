<template>
  <div class="task18-page">
    <div v-if="isLoaded">
      <NavigationTask
        :release-id="releaseSelectedId"
        :previous-task="previousTask"
        :next-task="nextTask" />
    </div>
    <TLink :id="''" :link="link" class="link" />
    <div class="infos">
      <div v-if="isLoaded" class="task-container">
        <TaskInfo :task="currentTask" :release-date="releaseSelected.releaseDate" @update-task-status="updateTaskStatus" />
      </div>
      <div v-if="isFunkyModeEnabled" class="picture">
        <NuxtPicture format="gif" src="gif/minions-bleh.gif" :width="250" :height="250" />
      </div>
      <div class="text">
        <div v-t="'pages.task18.info1'" class="info1" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { storeToRefs } from 'pinia'
import type { ITask } from '~/api/api.type'
import { guidEmpty } from '~/constant'
import { handleError } from '~/helpers/error'
import { extractLinkName } from '~/helpers/regex'

useHead({
  title: 'Task 18',
})

const releaseStore = useReleaseStore()
const {
  releaseSelected,
  isReleaseSelected,
  isCurrentTaskSelected,
  currentTask,
  previousTask,
  nextTask,
  isFunkyModeEnabled,
} = storeToRefs(releaseStore)

const link = { id: '', key: 'homepage' }
const releaseSelectedId = computed(() => {
  return releaseSelected.value.id!
})

const isLoaded = computed(() => {
  return isReleaseSelected.value &&
    releaseSelectedId.value &&
    isCurrentTaskSelected.value &&
    currentTask?.value.id
})

onMounted(() => {
  init()
})

async function init(): Promise<void> {
  releaseStore.dispatchResetIsCurrentTaskSelected()
  try {
    const route = useRoute()
    if (!isReleaseSelected.value) {
      await releaseStore.dispatchReleaseSelected(route.params.id?.toString() ?? guidEmpty)
    }

    if (!isCurrentTaskSelected.value) {
      const linkKey = extractLinkName(route.path)
      releaseStore.dispatchCurrentTaskOnLoad(linkKey)
    }
  } catch (error) {
    handleError(error)
  }
}

async function updateTaskStatus(status: boolean, task: ITask): Promise<void> {
  try {
    await releaseStore.dispatchTaskStatus(status, task, releaseSelected.value.id!)
  } catch (error) {
    handleError(error)
  }
}
</script>

<style lang="scss" scoped>
.task18-page {
  .link {
    margin: 20px;
  }

  .infos {
    .task-container {
      margin: 50px 0px;
    }

    .picture {
      margin-bottom: 15px;
      text-align: center;
    }

    .text {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;

      .info1 {
        margin-bottom: 10px;
      }
    }
  }
}
</style>
