import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../Interfaces';
//import Swal from 'sweetalert2';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html'
})

export class ClientesComponent implements OnInit {

  clientes: Cliente[] = [];
  cargando = false;


  constructor(private clienteService: ClienteService) { }

  ngOnInit() {
    this.cargando = true;
    this.clienteService.GetClientes()
      .subscribe(resp => {
        this.clientes = resp;
        this.cargando = false;
      });
  }

  //borrarCliente(cliente: Cliente, i: number) {

  //  Swal.fire({
  //    title: '¿Está seguro?',
  //    text: `Está seguro que desea borrar a ${cliente.Nombre}`,
  //    type: 'question',
  //    showConfirmButton: true,
  //    showCancelButton: true
  //  }).then(resp => {

  //    if (resp.value) {
  //      this.clientes.splice(i, 1);
  //      this.clienteService.borrarCliente(cliente.Id).subscribe();
  //    }

  //  });



  }

