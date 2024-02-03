<template>
  <div class="datepicker-container">
    <VueDatePicker
      v-model="date"
      auto-apply
      :enable-time-picker="false"
      input-class-name="datepicker-calendar-input"
      @update:model-value="updateDate"
      @cleared="clear" />
  </div>
</template>

<script setup lang="ts">
import VueDatePicker from '@vuepic/vue-datepicker'
import '@vuepic/vue-datepicker/dist/main.css'
import '@vuepic/vue-datepicker/src/VueDatePicker/style/main.scss'

const date = ref('')

const emit = defineEmits(['updateDate'])

function updateDate(): void {
  emit('updateDate', date.value)
}

function clear(): void {
  date.value = ''
  emit('updateDate', '')
}
</script>

<style lang="scss">
.datepicker-calendar-input {
  width: 180px;
  height: 25px;
  border-radius: 9999em;
}
</style>

<style lang="scss" scoped>
.datepicker-container {
  position: relative;
  background: linear-gradient(21deg, #10abff, #1beabd);
  padding: 2px;
  display: inline-block;
  border-radius: 9999em;
}
</style>
