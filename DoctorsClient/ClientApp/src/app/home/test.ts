export class Test {
  constructor(
    public id?: number,
    public name?: string,
    public accountid?: number,
    public account?: {
      id?: number,
      email?: string,
      password?: string,
      role?: string
    },
    public testtwo?: {
      id?: number,
      name?: string
    }
  ) { }
}
