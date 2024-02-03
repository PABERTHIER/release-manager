<template>
  <div class="create-release-modal-overlay">
    <div class="modal">
      <div v-if="!isDone" class="init">
        <div v-t="'components.createReleaseModal.title'" class="title" />
        <div class="fields">
          <div class="name">
            <div v-t="'components.createReleaseModal.name'" class="text" />
            <div class="input-container">
              <Input :value="name" @update-value="updateReleaseName" />
            </div>
          </div>
          <div class="date">
            <div v-t="'components.createReleaseModal.date'" class="text" />
            <DatePicker @update-date="updateDate" />
          </div>
        </div>
        <div class="create-button-container">
          <div class="create-button ">
            <Button :name="buttonName" :is-disabled="isButtonDisabled" :width="'330px'" @click="createRelease" />
          </div>
        </div>
      </div>
      <div v-else class="success">
        <SVGIcons :name="'validate'" class="check" />
        <h6 v-t="'components.createReleaseModal.success'" />
        <div v-t="'components.createReleaseModal.created'" />
      </div>
    </div>
    <div v-if="!isDone" class="close">
      <SVGIcons :name="'cancel'" class="close-img" @click="closeModal()" />
    </div>
  </div>
</template>

<script setup lang="ts">
import type { IRelease } from '~/api/api.type'

const { t } = useI18n()

const name = ref('')
const date = ref('')
const isButtonDisabled = computed(() => {
  if (!name.value || name.value === '') {
    return true
  }
  if (!date.value || date.value === '') {
    return true
  }
  return false
})

const isDone = ref(false)

const buttonName = t('components.createReleaseModal.create')

const emit = defineEmits(['createRelease', 'closeModalReleaseCreation'])

function updateReleaseName(value: string): void {
  name.value = value
}

function updateDate(dateUpdated: string): void {
  date.value = dateUpdated
}

function createRelease(): void {
  isDone.value = true
  setTimeout(() => {
    emit('createRelease', { name: name.value, releaseDate: date.value } as IRelease)
  }, 1000)
}

function closeModal(): void {
  emit('closeModalReleaseCreation')
}
</script>

<style lang="scss">
.create-release-modal-overlay {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  background-color: rgb(100, 100, 100, 0.8);
  z-index: $modal-z-index;

  .modal {
    text-align: center;
    background-color: $white-text-color;
    height: 300px;
    width: 500px;
    margin-top: 10%;
    border-radius: 20px;
    border-style: solid;
    border-color: rgba(100, 100, 100, 0.7);
    padding: 25px;
    position: relative;

    .check {
      width: 150px;
      height: 150px;
      fill: $green-text-color;
    }

    .init {
      .title {
        font-weight: bold;
        margin-top: 20px;
        font-size: 25px;
      }

      .fields {
        height: 200px;
        width: 100%;
        display: flex;
        flex-direction: column;
        justify-content: center;

        .name,
        .date {
          display: flex;
          align-self: center;
          align-items: center;
          font-weight: bold;

          .text {
            margin-right: 20px;
          }
        }

        .name {
          margin-bottom: 40px;
        }
      }

      .create-button-container {
        display: flex;
        justify-content: center;
        align-items: center;

        .create-button {
          position: absolute;
          bottom: 20px;
        }
      }
    }
  }

  .success {
    h6 {
      font-weight: 500;
      font-size: 28px;
      margin: 20px 0;
    }
  }

  .close {
    margin: 10% 0 0 16px;
    height: 25px;
  }

  .close-img {
    width: 25px;
    height: 25px;
    cursor: pointer;
    fill: $red-text-color;
  }
}
</style>
