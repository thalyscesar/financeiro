import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-tabela-padrao',
  templateUrl: './tabela-padrao.component.html',
  styleUrls: ['./tabela-padrao.component.css']
})
export class TabelaPadraoComponent implements OnInit {

  constructor() { }

  @Input() colunas: string[];
  @Input() linhas: string[][];
  @Input() rotaEditar;
  @Output() aoSelecionarId = new EventEmitter();
  // tslint:disable-next-line: no-output-rename
  @Output('select-index') aoSelecionarIndex = new EventEmitter();

  ngOnInit() {
  }

  aoClicar(event: MouseEvent , linha: number, tabela: HTMLTableElement, index: number) {
    for (let i = 0; i < tabela.rows.length; i++) {
      tabela.rows[i].className = '';
   }

   this.aoSelecionarId.emit(linha[0]);
   this.aoSelecionarIndex.emit(index);
   (<HTMLElement>event.currentTarget).className = 'bg-light';
  }

}
