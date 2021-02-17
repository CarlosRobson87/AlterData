import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Funcionario } from 'src/models/Funcionario';
import { Recurso } from 'src/models/Recurso';
import { Votacao } from 'src/models/Votacao';
import { Voto } from 'src/models/Voto';
import { RecursoService } from 'src/services/recurso.service';
import { VotoService } from 'src/services/voto.service';
import { AccountService } from '../account/shared/account.service';
import { AuthGuard } from '../account/shared/auth.guard';

@Component({
  selector: 'app-votacao',
  templateUrl: './votacao.component.html',
  styleUrls: ['./votacao.component.css']
})
export class VotacaoComponent implements OnInit {

 public recursos: Recurso[] = [];
 public recurso: Recurso = new Recurso;
 public recursoSelecionado: string | undefined;
 public votacao: Votacao = new Votacao;
 public funcionarioLogin: Funcionario = new Funcionario;
 public time!: Date;

  constructor(
    private recursoService: RecursoService,
    private votoService: VotoService,
    private accountService: AccountService
  ) { }

  ngOnInit(): void {
    this.carregarRecursos();
  }

  carregarRecursos() {
    this.funcionarioLogin.email = this.accountService.usuario.email;

    this.recursoService.getAll(this.funcionarioLogin).subscribe(
      (recursos: Recurso[]) => {
        this.recursos = recursos;
      },
      (erro: any) => {
        console.error
      }
    );
  }

  recursoSelect(recurso: Recurso) {
    this.recurso = recurso;
    this.recursoSelecionado = recurso.nome;
    console.error();

  }

  cancelar()
  {
    this.recursoSelecionado = '';
    this.votacao.comentario = '';
    this.recurso = new Recurso;
  }

  async onSubmit() {
    try {
      var result = await this.votoService.create(this.recurso,this.accountService.usuario , new Date().toLocaleTimeString(), this.votacao.comentario);
      this.votacao.comentario = '';
      if(result)
      {
        this.carregarRecursos();
        this.cancelar();
      }

    } catch (error) {
      console.error(error);
    }
  }
}
