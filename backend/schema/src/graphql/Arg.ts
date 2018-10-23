
export class Arg {
  public name: string
  public returnType: string
  public defaultValue?: string | number

  constructor (name, returnType, defaultValue?) {
    this.name = name
    this.returnType = returnType
    this.defaultValue = defaultValue
  }
}
