import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Funcionario } from 'src/models/Funcionario';
import { AccountService } from '../account/shared/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
 
  public nomeFuncionario!: string;

  constructor(
    private router: Router,
    private accountService: AccountService
  ) { 
    this.nomeFuncionario = accountService.usuario.nome;
  }

  ngOnInit(): void {
  }

  sair(){
    this.accountService.usuario = new Funcionario;
    this.router.navigate(['login']);
  }

}
