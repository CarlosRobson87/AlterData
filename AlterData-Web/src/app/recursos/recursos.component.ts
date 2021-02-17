import { Component, OnInit } from '@angular/core';
import { Recurso } from 'src/models/Recurso';
import { RecursoService } from 'src/services/recurso.service';

@Component({
  selector: 'app-recursos',
  templateUrl: './recursos.component.html',
  styleUrls: ['./recursos.component.css']
})
export class RecursosComponent implements OnInit {

  public recursos: Recurso[] = [];
  
  constructor(
    private recursoService: RecursoService,
  ) { }

  ngOnInit(): void {
    this.carregarRecursosOrdenadosPorVotos();
  }

  carregarRecursosOrdenadosPorVotos() {
    this.recursoService.getAllOrderByVote().subscribe(
      (recursos: Recurso[]) => {
        this.recursos = recursos;
      },
      (erro: any) => {
        console.error
      }
    );
  }
}
