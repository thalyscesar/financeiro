import { ContaAPagarService } from './../recursos/conta-a-pagar.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as  moment from 'moment';
import 'moment/locale/pt-br';

@Component({
  selector: 'app-lista-contaapagar',
  templateUrl: './lista-contaapagar.component.html',
  styleUrls: ['./lista-contaapagar.component.css']
})
export class ListaContaapagarComponent implements OnInit {

  constructor(protected contaApagarService: ContaAPagarService , protected router: Router, protected route: ActivatedRoute  ) { }

  colunas: string[] = ['Id', 'Nome', 'Valor Original' , 'Valor Corrigido', 'Quantidade de dias em atraso' , 'Data de Pagamento'];
  linhas: string[][] = [];
  idSelecioanado: string;

  ngOnInit() {
    this.preencherListaProdutos();
  }

  preencherListaProdutos() {
    this.contaApagarService.getAll(1).subscribe(produtos => {
      produtos.forEach(c => this.linhas.push(
        [ c.id.toString(),
          c.nome,
          c.valorOriginal.toFixed(2),
          c.valorCorrigido.toFixed(2),
          c.quantidadeDiasAtraso.toString(),
          moment(c.dataPagamento).format('DD/MM/YYYY')
        ]));
    });
  }

  aoSelecionarId(value) {
    this.idSelecioanado = value;
  }

  atualizar(event) {

    if (!this.idSelecioanado || this.idSelecioanado === '') {

      alert("Selecione um item da lista");
      return;
    }
    this.router.navigateByUrl(`contasapagar/atualizar/${ this.idSelecioanado }`);
  }

  excluir(event) {

    if (!this.idSelecioanado || this.idSelecioanado === '') {
      alert("Selecione um item da lista");
      return;

    }

    const ehPraExcluir = confirm('Deseja realmente excluir este item?');

    if (ehPraExcluir) {
      const index = this.linhas.findIndex(l => l[0] === this.idSelecioanado);
      this.linhas.splice(index, 1);
    }

    this.contaApagarService.delete(this.idSelecioanado).subscribe(p => {
      alert('Exclusão realizada com sucesso');
    });

  }

  novo() {  this.router.navigateByUrl('contasapagar/novo'); }

}
