export class ContaAPagar {

  /**
   *
   */
  constructor(public id?: number,
              public  nome?: string,
              public valorOriginal?: number,
              public dataVencimento?: Date,
              public  dataPagamento?: Date) {

  }
}
