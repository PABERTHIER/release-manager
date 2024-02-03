import moment from 'moment'

export function formatDate(date: string): string {
  return moment(date).format('DD/MM/YYYY')
}

export function getDaysLeft(date: string, daysBeforeRelease: number): number {
  const today = moment().toDate()
  const endDate = moment(date).toDate()
  const diff = moment(endDate).diff(today, 'days')
  return diff - daysBeforeRelease
}
