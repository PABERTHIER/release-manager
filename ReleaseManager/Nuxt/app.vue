<!-- This file is optionnal: if removed, it will take the default entry -->
<template>
  <NuxtLayout>
    <NuxtErrorBoundary @error="someErrorLogger">
      <NuxtPage />
      <template #error="{ error }">
        <div class="nuxt-error">
          <div class="error-container">
            <div v-t="'miscellaneous.error'" class="title" />
            <div class="message">
              {{ error }}
            </div>
          </div>
          <div class="link">
            <TLink :id="''" :link="link" @click="recoverFromError(error)" />
          </div>
        </div>
      </template>
    </NuxtErrorBoundary>
  </NuxtLayout>
</template>

<script setup lang="ts">

const link = { id: '', key: 'homepage' }
const errorLogged = ref()

function someErrorLogger(error: any): void {
  errorLogged.value = error
}

function recoverFromError(error: any): void {
  error.value = null
}

</script>

<style lang="scss" scoped>
.nuxt-error {
  .error-container {
    display: flex;
    justify-content: center;
    margin-top: 250px;
    margin-bottom: 250px;
    color: $red-text-color;
    font-size: 30px;

    .title {
      font-weight: bold;
    }

    .message {
      margin-left: 10px;
      font-weight: bold;
    }
  }

  .link {
    display: flex;
    justify-content: center;
  }
}
</style>
