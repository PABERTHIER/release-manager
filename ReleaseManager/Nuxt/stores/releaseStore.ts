import type { ILink, IRelease, IReleaseName, ITask, ITaskInfo } from '~/api/api.type'
import {
  createRelease,
  getRelease,
  getReleasesName,
  updateTask,
} from '~/api/releasesCient'

export interface State {
  releasesName: IReleaseName[]
  releaseSelected: IRelease
  isLoaded: boolean
  isReleaseSelected: boolean
  isCurrentTaskSelected: boolean
  currentTask: ITask
  previousTask: ITask
  nextTask: ITask
  isFunkyModeEnabled: boolean
}

export const useReleaseStore = defineStore({
  id: 'releases',
  state: (): State => {
    return {
      releasesName: [],
      releaseSelected: {
        id: '',
        name: '',
        releaseDate: '',
        tasks: [],
      },
      isLoaded: false,
      isReleaseSelected: false,
      isCurrentTaskSelected: false,
      currentTask: {
        id: '',
        name: '',
        linkKey: '',
        isDone: false,
        nbDaysBeforeRelease: 0,
      },
      previousTask: {
        id: '',
        name: '',
        linkKey: '',
        isDone: false,
        nbDaysBeforeRelease: 0,
      },
      nextTask: {
        id: '',
        name: '',
        linkKey: '',
        isDone: false,
        nbDaysBeforeRelease: 0,
      },
      isFunkyModeEnabled: false,
    }
  },
  getters: {
    links(state): ILink[] {
      return state.releaseSelected.tasks.map((x: ITask) => {
        return { id: x.id!, key: x.linkKey }
      })
    },
  },
  actions: {
    async dispatchReleasesName(): Promise<void> {
      const releasesName = await getReleasesName()
      this.$state.isLoaded = true
      this.$state.releasesName = releasesName
    },
    async dispatchReleaseSelected(id: string): Promise<void> {
      const releaseSelected = await getRelease(id)
      this.$state.releaseSelected = releaseSelected
      this.$state.isReleaseSelected = true
    },
    async dispatchCreateRelease(release: IRelease): Promise<void> {
      const releaseSelected = await createRelease(release)
      this.$state.releaseSelected = releaseSelected
    },
    dispatchCurrentTaskOnLoad(linkKey: string): void {
      const linkKeyFormatted = `${
        linkKey.charAt(0).toLowerCase() + linkKey.slice(1)
      }`
      const index = this.$state.releaseSelected.tasks.findIndex(
        x => x.linkKey === linkKeyFormatted
      )

      this.setCurrentTask(index)
    },
    setCurrentTask(index: number): void {
      this.dispatchResetIsCurrentTaskSelected()

      if (index !== -1) {
        this.$state.currentTask = this.$state.releaseSelected.tasks[index]!

        if (index !== 0) {
          this.$state.previousTask =
            this.$state.releaseSelected.tasks[index - 1]!
        } else {
          this.dispatchResetPreviousTask()
        }

        if (index + 1 < this.$state.releaseSelected.tasks.length) {
          this.$state.nextTask = this.$state.releaseSelected.tasks[index + 1]!
        } else {
          this.dispatchResetNextTask()
        }

        this.$state.isCurrentTaskSelected = true
      } else {
        this.$state.currentTask = this.$state.releaseSelected.tasks[0]!
        this.dispatchResetIsCurrentTaskSelected()
        this.dispatchResetPreviousTask()
        this.dispatchResetNextTask()
      }
    },
    async dispatchTaskStatus(
      status: boolean,
      task: ITask,
      releaseId: string
    ): Promise<void> {
      task.isDone = status
      const taskInfo = await updateTask({ releaseId, task } as ITaskInfo)

      const index = this.$state.releaseSelected.tasks.findIndex(
        x => x.id === taskInfo?.task.id
      )
      if (index !== -1) {
        this.$state.releaseSelected.tasks[index] = taskInfo.task
      }
    },
    dispatchResetCurrentTask(): void {
      this.$state.currentTask = {
        id: '',
        name: '',
        linkKey: '',
        isDone: false,
        nbDaysBeforeRelease: 0,
      }
    },
    dispatchResetIsCurrentTaskSelected(): void {
      this.$state.isCurrentTaskSelected = false
    },
    dispatchResetPreviousTask(): void {
      this.$state.previousTask = {
        id: '',
        name: '',
        linkKey: '',
        isDone: false,
        nbDaysBeforeRelease: 0,
      }
    },
    dispatchResetNextTask(): void {
      this.$state.nextTask = {
        id: '',
        name: '',
        linkKey: '',
        isDone: false,
        nbDaysBeforeRelease: 0,
      }
    },
    dispatchClear(): void {
      this.$state.releasesName = []
      this.$state.releaseSelected = {
        id: '',
        name: '',
        releaseDate: '',
        tasks: [],
      }
      this.$state.isLoaded = false
      this.$state.isReleaseSelected = false
      this.dispatchResetIsCurrentTaskSelected()
      this.dispatchResetCurrentTask()
      this.dispatchResetPreviousTask()
      this.dispatchResetNextTask()
    },
    dispatchToggleFunkyMode(isFunkyModeEnabled: boolean): void {
      this.$state.isFunkyModeEnabled = isFunkyModeEnabled
    },
  },
})
