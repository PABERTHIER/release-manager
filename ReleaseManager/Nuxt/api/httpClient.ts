export function handleServerError(error: any): void {
  const response = 'response'

  if (response in error) {
    const data = error.response?._data
    throw createError({ statusCode: data?.status, statusMessage: data?.title })
  }

  throw createError({ statusCode: 500, statusMessage: 'Server Error' })
}
