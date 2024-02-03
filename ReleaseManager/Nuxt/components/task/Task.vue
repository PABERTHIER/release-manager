<template>
  <div class="task-container" :class="{ 'is-updating': isUpdating }" @click="updateTaskStatus">
    <div class="task" :class="taskStatusClass">
      <div class="line-1">
        <div class="name">
          {{ task.name }}
        </div>
      </div>
      <div class="line-2">
        <div class="days">
          <div v-t="'components.task.daysLeft'" class="days-left" />
          <div class="nb-days">
            {{ daysLeft }}
          </div>
          <div v-t="'components.task.days'" />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { ITask } from '~/api/api.type'
import { getDaysLeft } from '~/helpers/date'
import { isTaskLate } from '~/helpers/task'

const props = defineProps({
  task: {
    type: Object as PropType<ITask>,
    required: true,
  },
  releaseDate: {
    type: String,
    required: true,
  },
  isUpdating: {
    type: Boolean,
    required: false,
    default: false,
  },
})

const daysLeft = computed(() => {
  return getDaysLeft(props.releaseDate, props.task.nbDaysBeforeRelease ?? 0)
})
const isLate = computed(() => {
  return isTaskLate(daysLeft.value)
})

const taskStatusClass = computed((): string => {
  if (props.task.isDone) {
    return 'is-done'
  } else if (isLate.value) {
    return 'is-late'
  }
  return 'is-not-done'
})

const emit = defineEmits(['updateTaskStatus'])

function updateTaskStatus(): void {
  if (!props.isUpdating) {
    emit('updateTaskStatus', !props.task.isDone, props.task)
  }
}
</script>

<style lang="scss" scoped>
.task-container {
  position: relative;
  z-index: $links-home-z-index;
  background: rgba(255, 255, 255, 0.3);
  padding: 15px;
  border-radius: 15px;
  cursor: pointer;
  .is-late {
    color: $red-text-color;
  }

  .is-not-done {
    color: $primary-text-color;
  }

  .is-done {
    color: $light-green-color;
  }

  .task {
    display: flex;
    flex-direction: column;
    justify-content: center;
    flex-wrap: wrap;
    align-items: center;

    .line-1 {
      display: flex;
      align-items: center;
      justify-content: center;
      .name {
        text-align: center;
        margin-right: 5px;
      }
    }

    .line-2 {
      .days {
        display: flex;
        .days-left,
        .nb-days {
          margin-right: 5px;
        }
      }
    }
  }
}

.is-updating {
  cursor: wait;
}
</style>
