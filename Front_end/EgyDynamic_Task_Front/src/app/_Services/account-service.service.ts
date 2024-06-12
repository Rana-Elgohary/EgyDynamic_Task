import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AccountServiceService {

  r: { name:string, id:string } = { name:"", id:"" };
  constructor(public http:HttpClient, private router: Router) 
  { 
    this.CheckToken()
  }

  isAuthenticated=false;
  apiUrl = 'https://localhost:7114/api/Account';

  private CheckToken(): void {
    const token = localStorage.getItem("token");
    if (token) {
      this.isAuthenticated = true;
      this.r = jwtDecode(token);
    } else {
      this.isAuthenticated = false;
    }
  }

  Login(name: string, password: string) {
    const params = new HttpParams().set('userName', name).set('password', password);
    
    this.http.get(`${this.apiUrl}?userName=${name}&password=${password}`, { params, responseType: 'text' })
    .subscribe(d => {
      this.isAuthenticated = true;
      localStorage.setItem("token", d);
      try {
        this.r = jwtDecode(d);
        this.router.navigateByUrl("/CustomerList");
      } catch (error) {
        console.error('Failed to decode token:', error);
      }
    })
  }

  logout(){
    this.isAuthenticated=false;
    localStorage.removeItem("token");
    this.router.navigateByUrl("");
  }
}
