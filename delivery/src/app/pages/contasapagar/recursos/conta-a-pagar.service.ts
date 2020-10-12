import { BaseService } from '../../../shared/base.service';
import { Injectable, Injector } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ContaAPagar } from './conta-a-pagar.model';


@Injectable({
  providedIn: 'root'
})
export class ContaAPagarService extends BaseService<ContaAPagar> {

  constructor(protected injector: Injector) {
    super(environment.baseUrl + '/contaapagar', injector);
  }
}
