import { Injectable, Inject } from '@angular/core';
import { Cliente } from '../Interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MyResponse } from '../Interfaces';
import { map, delay } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
}

@Injectable({
  providedIn: 'root'
})

export class ClienteService {

  public baseUrl: string;

  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public GetClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl + "api/Cliente/ListCliente");
  }

  public GetCliente(id:number): Observable<Cliente> {
    return this.http.get<Cliente>(`this.baseUrl + "api/Cliente/GetCliente/"${id}.json`);
  }

  //public Add(cliente: Cliente){
  //  this.http.post<MyResponse>(this.baseUrl + "api/Cliente/Add", { 'model': cliente }, httpOptions).
  //    subscribe(result => {
  //      console.log(result);
  //    },
  //      error => console.error(error)
  //    );
  //}

  public Add(cliente: Cliente) {
    console.log(cliente.Nombre);
    this.http.post<MyResponse>(this.baseUrl + "api/Cliente/Add",  cliente, httpOptions).
      pipe(
        map((resp: any) => {
          //cliente.Id = resp.name;
          return cliente;
        })
      );
  }

  //public Add(cliente: Cliente) {
  //  return this.http.post(`${this.baseUrl}/api/Cliente/Add`, cliente)
  //    .pipe(
  //      map((resp: any) => {
  //        //cliente.Id = resp.name;
  //        return cliente;
  //      })
  //    );
  //}





  public delete(cliente:Cliente) {
    return this.http.post<MyResponse>(this.baseUrl + "api/Cliente/Delete", { 'model': cliente }, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.error(error)
      );
  }

}
