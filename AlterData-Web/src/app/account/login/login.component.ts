import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../shared/account.service';
import { NgModule } from '@angular/core';
import { Funcionario } from 'src/models/Funcionario';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public FuncionarioLogin: Funcionario = new Funcionario;
  public error: string = '';
  constructor(
    private accountService: AccountService,
    private router: Router
    ) {

     }

  ngOnInit(): void {
  }

  async onSubmit() {
    try {
      await this.accountService.login(this.FuncionarioLogin);
      this.error = '';
      this.router.navigate(['']);
    } catch (error) {
      this.error = 'Erro ao tentar logar';
    }
  }
}
