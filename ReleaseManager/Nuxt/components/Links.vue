<template>
  <div class="links">
    <div v-for="link in links" :key="link.id" class="link">
      <TLink :id="id" :link="link" />
    </div>
  </div>
</template>

<script setup lang="ts">
import type { ILink } from '~/api/api.type'

defineProps({
  id: {
    type: String,
    required: true,
  },
  links: {
    type: Array as PropType<ILink[]>,
    required: false,
    default: () => [],
  },
})
</script>

<style lang="scss" scoped>
.links {
  display: flex;
  flex-wrap: wrap;

  .link {
    background: rgba(255, 255, 255, 0.3);
    text-align: center;
    margin-right: 10px;
    margin-bottom: 10px;
    padding: 10px;
    border-radius: 15px;
    :deep(a) {
      font-size: 15px;
      font-weight: bold;
    }
  }
}
</style>
