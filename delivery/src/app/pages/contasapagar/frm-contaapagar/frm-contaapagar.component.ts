import { ContaAPagarService } from './../recursos/conta-a-pagar.service';
import { Component, Injector } from '@angular/core';
import { Validators } from '@angular/forms';
import { FrmBase } from '../../frm-base/frm-base.component';
import { ContaAPagar } from '../recursos/conta-a-pagar.model';
import * as  moment from 'moment';
import 'moment/locale/pt-br';

@Component({
  selector: 'app-frm-contaapagar',
  templateUrl: './frm-contaapagar.component.html',
  styleUrls: ['./frm-contaapagar.component.css']
})
export class FrmContaapagarComponent extends FrmBase<ContaAPagar> {
  constructor(injector: Injector, protected contaapagarService: ContaAPagarService) {
    super(injector, contaapagarService);
  }

  imaskConfig = {
    mask: Number,
    scale: 2,
    thousandsSeparator: '',
    padFractionalZeros: true,
    normalizeZeros: false,
    radix: ','
  };

  protected construaModelForm() {

    const hoje = moment(new Date()).format('YYYY-MM-DD');

    this.modelForm = this.formBuilder.group({
      id: [0],
      nome: [null, [Validators.required, Validators.maxLength(60), Validators.minLength(1)]],
      valorOriginal: [null, Validators.required],
      dataPagamento: [hoje, Validators.required],
      dataVencimento: [hoje, Validators.required]
    });

  }

  protected cancelar() {
    this.router.navigateByUrl('/contasapagar');
  }

  getObjeto(): ContaAPagar {
    const model: ContaAPagar = this.modelForm.value;
    // tslint:disable-next-line: radix
    model.valorOriginal = parseFloat(this.modelForm.value.valorOriginal.replace(',', '.'));
    return model;
  }

  protected carregueModelCustomEmEdicao(): void {

    const { id, nome, valorOriginal, dataPagamento, dataVencimento } = this.modelBase;

    this.modelForm.patchValue({
       id,
       nome,
       valorOriginal: valorOriginal.toString().replace('.', ','),
       dataPagamento: moment(dataPagamento).format('YYYY-MM-DD'),
       dataVencimento: moment(dataVencimento).format('YYYY-MM-DD')
      });

  }



}
