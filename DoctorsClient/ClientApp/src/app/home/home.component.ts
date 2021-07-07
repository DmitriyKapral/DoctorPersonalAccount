import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { AuthService } from '../auth.service';
import { Patient } from './patient';

@Component({
  selector: 'app-login',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  patient: Patient = new Patient();

  constructor(private http: HttpClient, private router: Router) { }
  login() {
    this.http.post('/api/home' + '/auth', (this.patient.login, this.patient.password))
      .subscribe((resp: any) => {

        this.router.navigate(['counter']);

      });

  }
}
