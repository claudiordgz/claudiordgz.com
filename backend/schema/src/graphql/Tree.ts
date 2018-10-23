import { Object } from './Object'
import * as assert from 'assert'

export class Node {
  public children: Node[] = []
}

export class RootNode extends Node {
  constructor () {
    super()
  }
}

export class ObjNode extends Node {
  public parent?: RootNode | Node
  public value: Object

  constructor (obj: Object) {
    super()
    this.value = obj
  }
}

export interface ObjectMap {
  [key: string]: ObjNode
}

export class Tree {
  public root: RootNode
  public map: ObjectMap = {}
  constructor () {
    this.root = new RootNode()
  }

  addObjectToParent (parentName: string, node: ObjNode) {
    assert(!this.map.hasOwnProperty(parentName), `${parentName} must be in tree already`)
    node.parent = this.map[parentName]
    node.parent.children.push(node)
    this.map[node.value.name] = node
  }

  addObject (node: ObjNode) {
    node.parent = this.root
    node.parent.children.push(node)
  }
}
