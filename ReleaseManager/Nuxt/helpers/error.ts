import type { NuxtError } from 'nuxt/app'

export function handleError(error: any): void {
  if (error as NuxtError) {
    alert('Status code: ' + error.statusCode + '\nMessage: ' + error.message)
  } else {
    alert(error)
  }
}
