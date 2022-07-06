import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IBrand } from '../shared/modules/brand';
import { IPagination } from '../shared/modules/pagination';
import { Params } from '../shared/modules/Params';
import { IProductType } from '../shared/modules/productType';

@Injectable({
  providedIn: 'root'
})

export class ShopService {

  baseUrl = 'https://localhost:44389/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams:Params ) {

     let params = new HttpParams();

     if (shopParams.brandId !==0) {
       params = params.append('brandId', shopParams.brandId.toString());
     }
     
     if (shopParams.typeId !==0) {
       params = params.append("typeId",shopParams.typeId.toString());
     }

     if (shopParams.search ) {
       params = params.append("search",shopParams.search);
     }
 
     
       params = params.append("sort",shopParams.sort);
       params = params.append("pageIndex",shopParams.pageNumber.toString());
       params = params.append("pageIndex",shopParams.pageSize.toString());

     return this.http.get<IPagination>(this.baseUrl+'Products',{observe:"response",params})
    .pipe(
      map(response => {
       return response.body;
      })
    );

  }

  getBrands(){
    return this.http.get<IBrand[]>(this.baseUrl+'Products/productbrand');
  }

  getProductType(){
    return this.http.get<IProductType[]>(this.baseUrl+'Products/productstype')
  }

}