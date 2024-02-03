<template>
  <div class="task-status">
    <div v-if="!isDone" class="validate">
      <SVGIcons :name="'validate'" @click="updateTaskStatus()" />
    </div>
    <div v-if="isDone" class="cancel">
      <SVGIcons :name="'cancel'" @click="updateTaskStatus()" />
    </div>
  </div>
</template>

<script setup lang="ts">
const props = defineProps({
  isDone: {
    type: Boolean,
    required: true,
  },
  iconSize: {
    type: String,
    required: false,
    default: '20px',
  },
})

const emit = defineEmits(['updateTaskStatus'])

function updateTaskStatus(): void {
  emit('updateTaskStatus', !props.isDone)
}
</script>

<style lang="scss" scoped>
.task-status {
  .status {
    cursor: pointer;
  }
  .cancel,
  .validate {
    height: v-bind(iconSize);
    width: v-bind(iconSize);
    cursor: pointer;
  }
  .cancel {
    fill: $red-text-color;
  }
  .validate {
    fill: $light-green-color;
  }
}
</style>
