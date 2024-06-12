import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Call } from '../_Model/call';
import { CallAdd } from '../_Model/call-add';

@Injectable({
  providedIn: 'root'
})
export class CallServiceService {

  private apiUrl = 'https://localhost:7114/api';

  constructor(private http: HttpClient) { }

  getCalls(pageNumber: number, pageSize: number){
    let params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<any>(`${this.apiUrl}/calls`, { params });
  }
  
  deleteCall(id:number){
    return this.http.delete(`${this.apiUrl}/calls/${id}`);
  }

  editCall(call:Call){
    return this.http.put(`${this.apiUrl}/calls`, call)
  }

  getCallById(id:number){
    return this.http.get<any>(`${this.apiUrl}/calls/${id}`); 
  }

  addCall(call:CallAdd){
    return this.http.post(`${this.apiUrl}/calls`, call)
  }
}
