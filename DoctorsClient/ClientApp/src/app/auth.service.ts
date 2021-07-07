import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

 
@Injectable({
  providedIn: 'root'
})
 
export class AuthService {
  invocation = new XMLHttpRequest();
 
  uri = '/api/home';
  token: any;
 
  constructor(private http: HttpClient,private router: Router) { }
  login(email: string, password: string) {
    this.http.post(this.uri + '/auth', {email: email,password: password})
    .subscribe((resp: any) => {
     
      this.router.navigate(['counter']);
      localStorage.setItem('auth_token', resp.token);
      
      });
       
    }
 
}
