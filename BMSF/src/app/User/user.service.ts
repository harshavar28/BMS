import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  private url = 'https://localhost:7065/api';
  getUC(id:any): Observable<any> {
    return this.http.get(`${this.url}/User/GetUCarts/${id}`);
  }
getUB(id:any): Observable<any> {
    return this.http.get(`${this.url}/User/UBooks/${id}`);
  }
  getp(): Observable<any> {
    return this.http.get(`${this.url}/Books/GetOp`);
  }
}
