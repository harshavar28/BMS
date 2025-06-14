import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Cred{
  uname: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthSService {

  constructor(private http: HttpClient) { }
  url = 'https://localhost:7065/api/Auth';
  cred : Cred = {uname: '',  password: ''};

  login(cred : Cred): Observable<any> {
    return this.http.post(`${this.url}/log`,cred);
  }
  registeru(cred : Cred): Observable<any> {
    return this.http.post(this.url,cred);
  }
  registera(cred : Cred): Observable<any> {
    return this.http.post(`${this.url}/AuthR`, cred);
  }
  logAu(cred : Cred): Observable<any> {
    return this.http.post(`${this.url}/logA`, cred);
  }
}
