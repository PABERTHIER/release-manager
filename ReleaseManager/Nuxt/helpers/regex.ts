export function extractLinkName(path: string): string {
  return path.match(/\/(.*)\//)?.pop() ?? ''
}
