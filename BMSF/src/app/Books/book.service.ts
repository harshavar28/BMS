import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private url = 'https://localhost:7065/api/Books';

  constructor(private http: HttpClient) { }

  getBooks(): Observable<any> {
    return this.http.get(`${this.url}/GetBooks`);
  }  
  addToCart( bid: string,sid:string): Observable<any> {
    return this.http.post(`https://localhost:7065/api/User/RequestUBooks/${bid}/${sid}`, {});
  }
  getC(drpval : string): Observable<any> {
    const params = new HttpParams().set('cat', drpval);
    return this.http.get(`${this.url}/GetC`, { params });
  }
}
