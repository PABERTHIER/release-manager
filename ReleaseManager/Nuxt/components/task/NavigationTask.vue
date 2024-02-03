<template>
  <div class="navigation-task-container">
    <div v-if="previousTask.id" class="previous-link">
      <TLink :id="releaseId" :link="previousTaskLink" />
    </div>
    <div v-if="nextTask.id" class="next-link">
      <TLink :id="releaseId" :link="nextTaskLink" />
    </div>
  </div>
</template>

<script setup lang="ts">
import type { ITask } from '~/api/api.type'

const props = defineProps({
  releaseId: {
    type: String,
    required: true,
  },
  previousTask: {
    type: Object as PropType<ITask>,
    required: true,
  },
  nextTask: {
    type: Object as PropType<ITask>,
    required: true,
  },
})

const previousTaskLink = computed(() => {
  return { id: props.previousTask.id!, key: props.previousTask.linkKey }
})

const nextTaskLink = computed(() => {
  return { id: props.nextTask.id!, key: props.nextTask.linkKey }
})
</script>

<style lang="scss" scoped>
.navigation-task-container {
  position: absolute;
  .previous-link,
  .next-link {
    position: fixed;
    top: 30px;
    z-index: $links-navigation-z-index;
  }
  .previous-link {
    left: 40px;
  }
  .next-link {
    right: 40px;
  }
}
</style>
