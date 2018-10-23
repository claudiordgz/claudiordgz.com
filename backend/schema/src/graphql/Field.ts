import { Arg } from './Arg'

export class Field {
  public name: string
  public args?: Arg[]
  public returnType: string
  public description?: string

  constructor (name: string, returnType: string, description?: string, args?: Arg[]) {
    this.name = name
    this.args = args
    this.returnType = returnType
    this.description = description
  }

  toString () {
    const description = this.description !== undefined ? `# ${this.description}` : undefined
    const args = this.args !== undefined ? `(${this.args.join(', ')})` : ''
    const t = `${this.name}${args}: ${this.returnType}`
    if (description !== undefined) {
      return `${description}\n${t}`
    }
    return t
  }

  private _checkReturnType (returnType: string) {
    this.returnType = returnType
    if (!(/(Int|String|Float|Boolean|ID|Connection)/.test(returnType))) {
      console.log('true')
    }
  }

}
