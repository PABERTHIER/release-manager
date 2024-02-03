<template>
  <div class="toggle-container">
    <Toggle v-model="isEnabled" class="custom-toggle " />
  </div>
</template>

<script setup lang="ts">
// eslint-disable-next-line import/default
import Toggle from '@vueform/toggle'
import '@vueform/toggle/themes/default.css'

const props = defineProps({
  isToggled: {
    type: Boolean,
    required: true,
  },
})

const emit = defineEmits(['updateToggleValue'])

const isEnabled = computed({
  get() {
    return props.isToggled
  },
  set(value) {
    emit('updateToggleValue', value)
  },
})

</script>

<style lang="scss" scoped>
.toggle-container {
  .custom-toggle {
    --toggle-bg-on: linear-gradient(21deg, #10abff, #1beabd);
    --toggle-border-on: #1beabd;
    &:focus {
      box-shadow: none;
    }
  }
}
</style>
