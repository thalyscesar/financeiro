import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FrmContaapagarComponent } from './frm-contaapagar/frm-contaapagar.component';
import { ListaContaapagarComponent } from './lista-contaapagar/lista-contaapagar.component';
import { ContasapagarRoutingModule } from './contasapagar-routing.module';
import {IMaskModule} from 'angular-imask';

@NgModule({
  declarations: [FrmContaapagarComponent, ListaContaapagarComponent],
  imports: [
    CommonModule,
    ContasapagarRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
    HttpClientModule,
    IMaskModule
  ],
  bootstrap: [FrmContaapagarComponent]
})
export class ContasapagarModule { }
