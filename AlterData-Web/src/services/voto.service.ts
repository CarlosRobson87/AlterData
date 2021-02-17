import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Recurso } from 'src/models/Recurso';
import { Funcionario } from 'src/models/Funcionario';
import { Voto } from 'src/models/Voto';


@Injectable({
    providedIn: 'root'
})
export class VotoService {
    baseUrl = `${environment.api}/Voto`;
    public voto: Voto = new Voto;
    constructor(private http: HttpClient) {    }

    async create(recurso: Recurso, funcionario: Funcionario, dataLocal: string, comentario: string) {
        this.voto.comentario = comentario;
        this.voto.data_votacao = dataLocal;
        this.voto.Funcionario_Id = funcionario.funcionario_Id;
        this.voto.Recurso_Id = recurso.recurso_Id;

        return await this.http.post<any>(`${this.baseUrl}/Votar`, this.voto).toPromise();
    }

}