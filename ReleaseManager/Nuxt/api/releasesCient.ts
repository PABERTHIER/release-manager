import type { IRelease, IReleaseName, ITaskInfo } from './api.type'
import { handleServerError } from './httpClient'
import json from '~/sample/toto.json'

const useAPICall = true

export async function getReleasesName(): Promise<IReleaseName[]> {
  let result = [] as IReleaseName[]
  const runtimeConfig = useRuntimeConfig()
  if (useAPICall) {
    try {
      result = (await $fetch(
        `${runtimeConfig.public.apiBase}/release/names`
      )) as IReleaseName[]
    } catch (error: any) {
      handleServerError(error)
    }
  } else {
    result.push({ id: json.id, name: json.name })
    result.push({ id: json.id, name: 'toto' })
    result.push({ id: json.id, name: 'titi' })
    result.push({ id: json.id, name: 'tutu' })
    result.push({ id: json.id, name: 'tata' })
    result.push({ id: json.id, name: 'tyty' })
    result.push({ id: json.id, name: json.name })
    result.push({ id: json.id, name: 'toto' })
    result.push({ id: json.id, name: 'titi' })
    result.push({ id: json.id, name: 'tutu' })
    result.push({ id: json.id, name: 'tata' })
    result.push({ id: json.id, name: 'tyty' })
    result.push({ id: json.id, name: json.name })
    result.push({ id: json.id, name: 'toto' })
    result.push({ id: json.id, name: 'titi' })
    result.push({ id: json.id, name: 'tutu' })
    result.push({ id: json.id, name: 'tata' })
    result.push({ id: json.id, name: 'tyty' })
    result.push({ id: json.id, name: json.name })
    result.push({ id: json.id, name: 'toto' })
    result.push({ id: json.id, name: 'titi' })
    result.push({ id: json.id, name: 'tutu' })
    result.push({ id: json.id, name: 'tata' })
    result.push({ id: json.id, name: 'tyty' })
    result.push({ id: json.id, name: json.name })
    result.push({ id: json.id, name: 'toto' })
    result.push({ id: json.id, name: 'titi' })
    result.push({ id: json.id, name: 'tutu' })
    result.push({ id: json.id, name: 'tata' })
    result.push({ id: json.id, name: 'tyty' })
  }
  return result
}

export async function getRelease(id?: string): Promise<IRelease> {
  let result = {} as IRelease
  const runtimeConfig = useRuntimeConfig()
  if (useAPICall) {
    try {
      result = (await $fetch(
        `${runtimeConfig.public.apiBase}/release/${id}`
      )) as IRelease
    } catch (error: any) {
      handleServerError(error)
    }
  } else {
    result = json as IRelease
  }
  return result
}

export async function createRelease(release: IRelease): Promise<IRelease> {
  let result = {} as IRelease
  const runtimeConfig = useRuntimeConfig()
  if (useAPICall) {
    try {
      result = (await $fetch(`${runtimeConfig.public.apiBase}/release/new`, {
        method: 'POST',
        body: release,
      })) as IRelease
    } catch (error: any) {
      handleServerError(error)
    }
  } else {
    result = json as IRelease
  }
  return result
}

export async function updateTask(taskinfo: ITaskInfo): Promise<ITaskInfo> {
  let result = {} as ITaskInfo
  const runtimeConfig = useRuntimeConfig()
  if (useAPICall) {
    try {
      result = (await $fetch(
        `${runtimeConfig.public.apiBase}/release/task`,
        {
          method: 'POST',
          body: taskinfo,
        }
      )) as ITaskInfo
    } catch (error: any) {
      handleServerError(error)
    }
  } else {
    result = { id: json.id, task: json.tasks[0] } as ITaskInfo
  }
  return result
}
