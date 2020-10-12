import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListaContaapagarComponent } from './lista-contaapagar/lista-contaapagar.component';
import { FrmContaapagarComponent } from './frm-contaapagar/frm-contaapagar.component';

const routes: Routes = [
  { path: '', component: ListaContaapagarComponent },
  { path: 'novo', component: FrmContaapagarComponent },
   { path: 'atualizar/:id', component: FrmContaapagarComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContasapagarRoutingModule { }
