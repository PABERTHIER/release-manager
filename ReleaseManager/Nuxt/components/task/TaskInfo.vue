<template>
  <div class="task-container">
    <div class="task" :class="taskStatusClass">
      <div class="days">
        <div v-t="'components.task.daysLeft'" class="days-left" />
        <div class="nb-days">
          {{ daysLeft }}
        </div>
        <div v-t="'components.task.days'" />
      </div>
      <div class="name">
        {{ task.name }}
      </div>
      <div class="status">
        <TaskStatus :is-done="task.isDone" :icon-size="iconSize" @update-task-status="updateTaskStatus" />
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

const iconSize = '30px'

const emit = defineEmits(['updateTaskStatus'])

function updateTaskStatus(isDone: boolean): void {
  emit('updateTaskStatus', isDone, props.task)
}
</script>

<style lang="scss" scoped>
.task-container {
  text-align: left;
  background-color: white;
  padding: 20px 30px;
  border-radius: 50px;

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
    align-items: center;

    .name {
      font-weight: bold;
      font-size: 20px;
      width: 100%;
      text-align: center;
    }

    .days {
      display: flex;
      width: 250px;

      .days-left {
        text-decoration: underline;
      }

      .days-left,
      .nb-days {
        margin-right: 5px;
      }
    }

    .status {
      width: 250px;
      display: flex;
      justify-content: right;
    }
  }
}
</style>
