import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { ClienteService } from '../services/cliente.service';
import { Cliente, MyResponse } from '../Interfaces';

import Swal from 'sweetalert2';
import { log } from 'util';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html' 
})

export class ClienteComponent implements OnInit {

  cliente: Cliente=new Cliente();
  nombreControl = new FormControl('');
  correoControl = new FormControl('');

  constructor(private clienteService: ClienteService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id !== 'nuevo') {    
      this.clienteService.GetCliente(id)
        .subscribe((resp: Cliente) => {          
          var json = JSON.parse(JSON.stringify(resp));        
          this.cliente.Id = json["id"];
          this.cliente.Nombre = json["nombre"];
          this.cliente.Correo = json["correo"];
        });
    }
  }

  guardar(form: NgForm) {
    if (form.invalid) {
      console.log('Formulario no válido');
      return;
    }

    Swal.fire({
      title: 'Espere',
      text: 'Guardando información',      
      allowOutsideClick: false        
    });
    Swal.showLoading();

    //this.clienteService.Add(this.cliente);

    let peticion: Observable<MyResponse>;

    if (this.cliente.Id > 0) {
      console.log("update" + this.cliente.Id);      
      peticion = this.clienteService.Update(this.cliente);

      peticion.subscribe(resp => {
        Swal.fire({
          title: this.cliente.Nombre,
          text: 'Se actualizó correctamente'
        });
      });
    } else {
      console.log("nuevo");
      peticion = this.clienteService.Add(this.cliente);
      peticion.subscribe(resp => {
        Swal.fire({
          title: this.cliente.Nombre,
          text: 'Se inserto correctamente'
        });
      });
    }

    this.cliente.Id = 0;
    this.cliente.Nombre = "";
    this.cliente.Correo = "";  
  
  }

}
