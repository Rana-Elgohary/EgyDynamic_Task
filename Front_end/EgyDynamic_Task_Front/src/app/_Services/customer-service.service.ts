import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../_Model/customer';
import { CustomerAdd } from '../_Model/customer-add';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  private apiUrl = 'https://localhost:7114/api';

  constructor(private http: HttpClient) { }

  getCustomers(pageNumber: number, pageSize: number){
    let params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<any>(`${this.apiUrl}/customer`, { params });
  }
  
  deleteCustomer(id:number){
    return this.http.delete(`${this.apiUrl}/customer/${id}`);
  }

  editCustomer(customer:Customer){
    return this.http.put(`${this.apiUrl}/customer`, customer)
  }

  getCustomerById(id:number){
    return this.http.get<any>(`${this.apiUrl}/customer/${id}`); 
  }

  addCustomer(customer:CustomerAdd){
    return this.http.post(`${this.apiUrl}/customer`, customer)
  }
}
