import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Book {
  title: string;
  category: string;
}
@Injectable({
  providedIn: 'root'
})
export class AuthorService {
 data: Book = {title: '', category: ''};
  constructor(private http: HttpClient) { }
  private url = 'https://localhost:7065/api/Author';

  AddB(id:string, data: Book): Observable<any> {
    return this.http.post(`${this.url}/AddBooks/${id}`, data);
  }
  getB(id: string): Observable<any> {
    return this.http.get(`${this.url}/GetABooks/${id}`);
  }
  UpB(aid: string,bid: string, data: Book): Observable<any> {
    return this.http.put(`${this.url}/UpdateBook/${aid}/${bid}`, data);
  }
}
