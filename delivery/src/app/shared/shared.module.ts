import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabelaPadraoComponent } from './tabela-padrao/tabela-padrao.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  declarations: [TabelaPadraoComponent],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  exports: [TabelaPadraoComponent]
})
export class SharedModule { }
