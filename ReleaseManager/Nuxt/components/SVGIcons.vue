<template>
  <span>
    <client-only>
      <component :is="currentIcon" :class="attrs.class" />
      <template #fallback />
    </client-only>
  </span>
</template>

<script setup lang="ts">
const props = defineProps({
  name: {
    type: String,
    required: false,
    default: '',
  },
})

const currentIcon = computed(() =>
  defineAsyncComponent({
    loader: () => import(`~/assets/svg/${props.name}.svg`),
    loadingComponent: {
      template: '<span></span>',
    },
    errorComponent: {
      template: '<span>error</span>',
    },
    delay: 200,
    timeout: 3000,
    suspensible: true,
  })
)
const attrs = useAttrs()
</script>
