import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { IProduct } from './models/Product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'client';
  products:IProduct;

  constructor(private http: HttpClient){}
  ngOnInit(): void {
      this.http.get('https://localhost:5001/api/Product')
      .subscribe((response:IProduct)=>{
this.products=response;
      },error=>{
        console.log(error);
      });
    }
}
