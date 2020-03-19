import { Injectable, Inject } from '@angular/core';
import { Cliente } from '../Interfaces';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MyResponse } from '../Interfaces';

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

  public GetCliente(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl + "api/Cliente/ListCliente");
  }

  public Add(nombre, correo) {
    this.http.post<MyResponse>(this.baseUrl + "api/Cliente/Add", { 'Name': name, 'Correo': correo }, httpOptions).
      subscribe(result => {
        console.log(result);
      },
        error => console.error(error)
      );
  }

}
