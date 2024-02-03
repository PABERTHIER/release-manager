<template>
  <div class="coming-soon-container">
    <div v-t="'components.comingSoon.title'" class="title" />
    <div v-t="'components.comingSoon.infos'" class="infos" />
  </div>
</template>

<script setup lang="ts">
</script>

<style lang="scss" scoped>
.coming-soon-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  .title {
    font-size: 40px;
    font-weight: bold;
    font-family: papyrus, "Comic Sans MS", Arial, Helvetica, sans-serif;
    background: linear-gradient(to right, #ED46EB, #7371B2, #4BACBD, #4CF7BF);
    -webkit-text-fill-color: transparent;
    background-clip: text;
    -webkit-background-clip: text;
    position: absolute;
    top: 50%;
    text-transform: uppercase;
  }

  .infos {
    position: absolute;
    top: 60%;
  }
}
</style>
