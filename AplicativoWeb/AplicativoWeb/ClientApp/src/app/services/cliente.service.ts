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

  public GetCliente(id): Observable<Cliente>{    
    return this.http.get<Cliente>(this.baseUrl + "api/Cliente/GetCliente?id="+id);    
  }

  public Add(cliente: Cliente): Observable<MyResponse>{
    return this.http.post<MyResponse>(this.baseUrl + "api/Cliente/Add", { 'Nombre': cliente.Nombre, 'Correo': cliente.Correo, 'tipoAlmacenamiento': cliente.tipoAlmacenamiento}, httpOptions);
      //subscribe(result => {
      // return result;
      //},
      //  error => console.error(error)
      //);
  }
  public Update(cliente: Cliente): Observable<MyResponse> {
    return this.http.post<MyResponse>(this.baseUrl + "api/Cliente/Edit", { 'Id': cliente.Id, 'Nombre': cliente.Nombre, 'Correo': cliente.Correo, 'tipoAlmacenamiento': cliente.tipoAlmacenamiento}, httpOptions);
    //subscribe(result => {
    // return result;
    //},
    //  error => console.error(error)
    //);
  }

  public delete(cliente:Cliente) {
    return this.http.post<MyResponse>(this.baseUrl + "api/Cliente/Delete", { 'Id': cliente.Id }, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.error(error)
      );
  }

}
