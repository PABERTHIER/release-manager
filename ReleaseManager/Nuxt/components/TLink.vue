<template>
  <div class="link-container">
    <NuxtLink v-t="title" :to="route" class="underlined after" />
  </div>
</template>

<script setup lang="ts">
import type { ILink } from '~/api/api.type'

const props = defineProps({
  id: {
    type: String,
    required: true,
  },
  link: {
    type: Object as PropType<ILink>,
    required: true,
  },
})

const title = computed(() => `links.${props.link.key}`)
const isHomepage = computed(() => props.link.key === 'homepage')

const route = computed(() => {
  if (isHomepage.value) {
    return '/'
  } else {
    return `/${props.link.key.charAt(0).toUpperCase() + props.link.key.slice(1)}/${props.id}`
  }
})
</script>

<style lang="scss" scoped>
.link-container {
  a,
  a:visited,
  a:hover,
  a:active {
    -webkit-backface-visibility: hidden;
    backface-visibility: hidden;
    position: relative;
    transition: 0.5s color ease;
    text-decoration: none;
    font-size: 25px;
  }
  a:hover {
    color: $light-green-color;
  }
  a.before:before,
  a.after:after {
    content: '';
    transition: 0.5s all ease;
    -webkit-backface-visibility: hidden;
    backface-visibility: hidden;
    position: absolute;
  }
  a.before:before {
    top: -0.25em;
  }
  a.after:after {
    bottom: -0.25em;
  }
  a.before:before,
  a.after:after {
    height: 2px;
    width: 0;
    background: $light-green-color;
  }

  a.underlined:after {
    left: 50%;
    -webkit-transform: translateX(-50%);
    transform: translateX(-50%);
  }

  a.before:hover:before,
  a.after:hover:after {
    width: 100%;
  }
}
</style>
