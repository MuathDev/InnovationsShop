import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './modules/pagination';
import { IProduct } from './modules/products';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'InnovationShop';

  products: IProduct[];

  constructor(private http: HttpClient){};
     
  ngOnInit(): void {
    
    this.http.get('https://localhost:44389/api/Products').subscribe((resp: IPagination) => {

     // console.log(resp);
     this.products = resp.data;

    }, error => {
       console.log(error);
    });
    
  }

}
