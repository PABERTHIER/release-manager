export interface ITask {
  id?: string
  name: string
  linkKey: string
  isDone: boolean
  nbDaysBeforeRelease?: number
}

export interface ITaskInfo {
  releaseId?: string
  task: ITask
}

export interface IRelease {
  id?: string
  name: string
  releaseDate: string
  tasks: ITask[]
}

export interface IReleaseName {
  id: string
  name: string
}

export interface ILink {
  id: string
  key: string
}
