import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Recurso } from 'src/models/Recurso';
import { Funcionario } from 'src/models/Funcionario';


@Injectable({
    providedIn: 'root'
})
export class RecursoService {
    baseUrl = `${environment.api}/recurso`;

    constructor(private http: HttpClient) {    }

    getAll(funcionarioLogin: Funcionario): Observable<Recurso[]> {
        return this.http.post<Recurso[]>(`${this.baseUrl}/ListarParaVoto`, funcionarioLogin);
    }

    getAllOrderByVote(): Observable<Recurso[]> {
        return this.http.get<Recurso[]>(`${this.baseUrl}/ListarOrdemMaisVotadas`);
    }

}