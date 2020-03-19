import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../Interfaces';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html' 
})

export class ClienteComponent {

  public lstmensaje: Observable<Cliente[]>;
  nameControl = new FormControl('');
  textoControl = new FormControl('');

  constructor(http: HttpClient, protected chatService: ClienteService) {
    this.GetInfo();
  }

  public GetInfo() {
    this.lstmensaje = this.chatService.GetCliente();
  }

  public SendCliente() {
    this.chatService.Add(this.nameControl.value, this.textoControl.value);

    setTimeout(() => {
      this.GetInfo()
    }, 300);

    this.nameControl.setValue('');
    this.textoControl.setValue('');
  }
}
