import { Component, OnInit } from '@angular/core';
import { Patient } from './patient';
import { HttpClient } from '@angular/common/http';
import { Test } from './test';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  private url = "/api/home/get";
  private urls = "/api/home/geting";
  patient: Patient = new Patient();   // изменяемый товар
  patients: Patient[];                // массив товаров
  tests: Test[];

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.loadTest();
  }
  // получаем данные через сервис
  loadPatients() {
    this.http.get(this.url).subscribe((data: Patient[]) => this.patients = data);
  }
  loadTest() {
    this.http.get(this.urls).subscribe((data: Test[]) => this.tests = data);
  }
}
