import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../Interfaces';
import { Cliente1 } from '../Interfaces';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html' 
})

export class ClienteComponent implements OnInit {

  cliente: Cliente1=new Cliente1();


  constructor(private clienteService: ClienteService,
    private route: ActivatedRoute) { }

  ngOnInit() {

    const id = this.route.snapshot.paramMap.get('id');

    if (id !== 'nuevo') {

      this.clienteService.GetCliente(Number(id))
        .subscribe((resp: Cliente) => {
          this.cliente = resp;
          this.cliente.Id = Number(id);
        });

    }

  }

  guardar(form: NgForm) {

    if (form.invalid) {
      console.log('Formulario no válido');
      return;
    }

    //Swal.fire({
    //  title: 'Espere',
    //  text: 'Guardando información',      
    //  allowOutsideClick: false        
    //});
    //Swal.showLoading();

    this.clienteService.Add(this.cliente);

    //let peticion: Observable<any>;

    //if (this.cliente.Id) {
    //  peticion = this.clienteService.Add(this.cliente);
    //} else {
    //  peticion = this.clienteService.Add(this.cliente);
    //}

    //peticion.subscribe(resp => {
    //  Swal.fire({
    //    title: this.cliente.Nombre,
    //    text: 'Se actualizó correctamente'  
    //  });
    //});
  }


  //public lstmensaje: Observable<Cliente[]>;
  //nameControl = new FormControl('');
  //textoControl = new FormControl('');

  //constructor(http: HttpClient, protected chatService: ClienteService) {
  //  this.GetInfo();
  //}

  //public GetInfo() {
  //  this.lstmensaje = this.chatService.GetClientes();
  //}

  //public SendCliente() {
  //  this.chatService.Add(this.nameControl.value, this.textoControl.value);

  //  setTimeout(() => {
  //    this.GetInfo()
  //  }, 300);

  //  this.nameControl.setValue('');
  //  this.textoControl.setValue('');
  //}
}
