import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Funcionario } from 'src/models/Funcionario';
import { environment } from './../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
   usuario: Funcionario = new Funcionario;
  
  constructor(private http: HttpClient) { }

 async login(funcionario: Funcionario) {
    const result = await this.http.post<Funcionario>(`${environment.api}/Login/login`, funcionario).toPromise();
   
    if(result != null)
    {
      this.usuario.email = result.email;
      this.usuario.nome = result.nome;
      this.usuario.funcionario_Id = result.funcionario_Id;
      return true;
    }

    return false;
  }
}
