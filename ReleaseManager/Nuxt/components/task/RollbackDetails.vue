<template>
  <div class="rollback-details-container">
    <div v-if="isFunkyModeEnabled" class="picture">
      <NuxtPicture format="gif" src="gif/wewew-minions.gif" :width="250" :height="250" />
    </div>
    <div>
      <div v-t="'components.rollbackDetails.text1'" class="text1" />
      <div class="sub-infos">
        <li v-t="'components.rollbackDetails.text2'" class="text2" />
        <li v-t="'components.rollbackDetails.text3'" class="text3" />
        <li v-t="'components.rollbackDetails.text4'" class="text4" />
        <li v-t="'components.rollbackDetails.text5'" class="text5" />
      </div>
    </div>
    <div v-if="isFunkyModeEnabled" class="picture">
      <NuxtPicture format="gif" src="gif/wewew-minions.gif" :width="250" :height="250" />
    </div>
  </div>
</template>

<script setup lang="ts">
defineProps({
  isFunkyModeEnabled: {
    type: Boolean,
    required: false,
    default: false,
  },
})
</script>

<style lang="scss" scoped>
.rollback-details-container {
  display: flex;
  justify-content: space-around;
  align-items: center;
  background: rgba(255, 255, 255, 0.3);
  padding: 15px;
  border-radius: 15px;

  .text1 {
    font-weight: bold;
    font-size: 17px;
    margin-bottom: 25px;
  }

  .sub-infos {
    .text2,
    .text3,
    .text4 {
      margin-bottom: 5px;
    }
  }
}
</style>
