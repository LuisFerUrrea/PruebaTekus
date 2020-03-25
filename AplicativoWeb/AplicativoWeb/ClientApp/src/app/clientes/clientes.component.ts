import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../Interfaces';
import Swal from 'sweetalert2';

import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material';
import { MatTable } from '@angular/material/table';


@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html'
})

export class ClientesComponent implements OnInit {
  cliente: Cliente;
  clientes: Cliente[] = [];
  dataSource = null; 
  cargando = false;   
  displayedColumns: string[] = ['id', 'nombre', 'correo','acciones'];
  
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  

     
  constructor(private clienteService: ClienteService) { }


  ngOnInit() {  
    this.cargando = true;
    this.clienteService.GetClientes()
      .subscribe(resp =>{     
        this.dataSource = new MatTableDataSource<Cliente>(resp);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  onRowClicked(row) {
    console.log('Row clicked: ', row);
  }

  //borrarCliente(id: number) {
  //  alert(id);
  //  //  Swal.fire({
  //  //    title: '¿Está seguro?',
  //  //    text: `Está seguro que desea borrar a ${cliente.Nombre}`,
  //  //    showConfirmButton: true,
  //  //    showCancelButton: true
  //  //  }).then(resp => {

  //  //    if (resp.value) {
  //  //      this.clientes.splice(i, 1);
  //  //      this.clienteService.delete(cliente);
  //  //    }
  //  //  });
  //}

  borrarCliente(id:number,nombre:string) {
    //alert(id);
    //this.clientes.splice(id, 1);
    
      //this.cliente.Id =id;
      //this.cliente.Nombre = nombre;
      Swal.fire({
        title: '¿Está seguro?',
        text: `Está seguro que desea borrar a ${nombre}`,
        showConfirmButton: true,
        showCancelButton: true
      }).then(resp => {

        if (resp.value) {
          //alert(id);
          this.cliente.Id = id;
          //this.clientes.splice(id, 1);          
          this.clienteService.delete(this.cliente);
        }
      });
  }
}
