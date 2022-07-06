import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/modules/brand';
import { Params } from '../shared/modules/Params';
import { IProduct } from '../shared/modules/products';
import { IProductType } from '../shared/modules/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
   @ViewChild('search',{static:true}) searchTerm:ElementRef;
  products: IProduct[];
  brands: IBrand[];
  productstype: IProductType[];
  Params = new Params();
  totalCount: number;

  sortOptions = [{name:'أبجدي',value:'nameAr'},
                 {name:'السعر: من الارخص للاعلى',value:'priceAsc'},
                 {name:'السعر: من الاعلى الى الادنى',value:'priceDesc'}]

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {

    this.getProducts();
    this.getBrands();
    this.getProductsType();

  }

  getProducts(){
    this.shopService.getProducts(this.Params).subscribe({

      next:  (response) => {
        this.products = response.data;
        this.Params.pageNumber = response.pageIndex;
        this.Params.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error: (error) => {
        console.log(error);
      }
 
     });
  }

  getBrands(){
    this.shopService.getBrands().subscribe({

      next:  (response) => {
        this.brands = [{id:0, nameEn:'All', nameAr:'الكل'},...response];
      },
      error: (error) => {
        console.log(error);
      }
 
     });
  }

  getProductsType(){
    this.shopService.getProductType().subscribe({

      next:  (response) => {
        this.productstype = [{id:0, nameEn:'All', nameAr:'الكل'},...response];
      },
      error: (error) => {
        console.log(error);
      }
 
     });

  }

  onBrandSelected(brandId: number){
    this.Params.brandId = brandId;
    this.Params.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: number){
    this.Params.typeId = typeId;
    this.Params.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort:string){
    this.Params.sort = sort;
    this.getProducts();
  }

  onPageChanged(event:any){
    if (this.Params.pageNumber !== event) {
      this.Params.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch(){
    this.Params.search = this.searchTerm.nativeElement.value;
    this.Params.pageNumber =1;
    this.getProducts();

  }

  onReset(){
    this.searchTerm.nativeElement.value = '';
    this.Params = new Params();
    this.getProducts();
  }
}
