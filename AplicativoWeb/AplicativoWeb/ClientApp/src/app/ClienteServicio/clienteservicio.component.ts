import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';


@Component({
  selector: 'app-clienteservicio',
  templateUrl: './clienteservicio.component.html',
  styleUrls: ['./clienteservicio.component.css']
})


export class ClienteServicioComponent {
  columnas: string[] = ['codigo', 'descripcion', 'precio', 'borrar'];

  datos: Articulo[] = [new Articulo(1, 'papas', 55),
  new Articulo(2, 'manzanas', 53),
  new Articulo(3, 'naranjas', 25),
  ];

  articuloselect: Articulo = new Articulo(0, "", 0);

  @ViewChild(MatTable, { static: true }) tabla1: MatTable<Articulo>;

  borrarFila(cod: number) {
    if (confirm("Realmente quiere borrarlo?")) {
      this.datos.splice(cod, 1);
      this.tabla1.renderRows();
    }
  }

  agregar() {
    this.datos.push(new Articulo(this.articuloselect.codigo, this.articuloselect.descripcion, this.articuloselect.precio));
    this.tabla1.renderRows();
    this.articuloselect = new Articulo(0, "", 0);
  }


}








export class Articulo {
  constructor(public codigo: number, public descripcion: string, public precio: number) {
  }
}



