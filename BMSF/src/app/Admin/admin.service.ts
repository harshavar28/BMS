import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private url = 'https://localhost:7065/api/Admin';

  constructor(private http: HttpClient) { }

  getAReq(): Observable<any> {
    return this.http.get(`${this.url}/AuthReq`);
  }

  AppAuth(id: string): Observable<any> {
    return this.http.put(`${this.url}/Appro/${id}`,{});
  }
  getUReq(): Observable<any> {
    return this.http.get(`${this.url}/userReqs`);
  }
  AppUser(sId: string,bId: string): Observable<any> {
    return this.http.put(`${this.url}/Approving/${sId}/${bId}`,{});
  }
}
