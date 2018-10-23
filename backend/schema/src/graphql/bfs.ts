import { ObjNode, RootNode } from './Tree'

export type bfsFn = (node: ObjNode) => void

export function bfs (root: RootNode, cbs: bfsFn[]) {
  if (root === undefined) {
    return
  }
  const queue = Array.from(root.children)
  while (queue) {
    const s = queue.shift()
    if (s === undefined) {
      break
    }
    cbs.forEach(cb => cb(s as ObjNode))
    queue.concat(s.children)
  }
}
