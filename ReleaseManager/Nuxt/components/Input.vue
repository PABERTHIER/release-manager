<template>
  <div class="input-container">
    <div class="input">
      <input v-model="inputValue">
    </div>
  </div>
</template>

<script setup lang="ts">
const props = defineProps({
  value: {
    type: String,
    required: true,
  },
})

const emit = defineEmits(['updateValue'])

const inputValue = computed({
  get() {
    return props.value
  },
  set(value) {
    emit('updateValue', value)
  },
})

</script>

<style lang="scss" scoped>
.input-container {
  width: 100%;
  height: 100%;

  .input {
    position: relative;
    display: inherit;
    margin: 0;
    outline: none;
    position: relative;
    background: linear-gradient(21deg, #10abff, #1beabd);
    padding: 2px;
    display: inline-block;
    border-radius: 9999em;
  }
}

input {
  padding: 5px;
  background: none;
  border: none;
  outline: none;
  -webkit-appearance: none;
  -moz-appearance: none;
  appearance: none;
  background-color: $white-text-color;
  border-radius: 9999em;
}
</style>
