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
  }
  // получаем данные через сервис
}
