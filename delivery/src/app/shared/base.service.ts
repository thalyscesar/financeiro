import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import * as toastr from 'toastr';

@Injectable({
  providedIn: 'root'
})
export class BaseService<T> {

  protected http: HttpClient

  constructor(protected apiPath: string, protected injector: Injector) {
    this.http = injector.get(HttpClient);
  }

  getAll(currentPage?: number): Observable<any[]> {
    const url = this.apiPath;
    return this.http.get<any[]>(url);
  }

  getById(id: number): Observable<T> {
    const url = `${this.apiPath}/${id}`;

    return this.http.get(url).pipe(
      catchError(this.handleError), map(this.jsonDataToModel)
    );
  }

  update(model: T): Observable<T> {
    const url = `${this.apiPath}`;

    return this.http.put(url, model).pipe(
      catchError(this.handleError), map(this.jsonDataToModel));
  }

  delete(id: string): Observable<T> {
    const url = `${this.apiPath}/${id}`;

    return this.http.delete(url).pipe(
      map((e) => {
          console.log(e);
      } ),
      catchError(this.handleError)
    );
  }

  create(model: T): Observable<T> {
    return this.http.post(this.apiPath, model).pipe(
      catchError(this.handleError), map(this.jsonDataToModel));
  }

  protected handleError(erro: any): Observable<any> {
    console.log('Erro na requisicao => ', erro);
    toastr.error(erro.error.text);
    return throwError(erro);
  }

  protected jsonDataToModels(jsonData: any[]): T[] {
    const modelos = [];
    jsonData.forEach(el => modelos.push(el as T));
    return modelos;
  }

  protected jsonDataToModel(jsonData: any): T {
    return jsonData as T;
  }

}
