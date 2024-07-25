import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../shared/product.service';
import { Observable, switchMap } from 'rxjs';
import { Product } from '../shared/interfaces';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.scss']
})
export class ProductPageComponent implements OnInit{

  product$: Observable<Product>

  constructor(
    private route: ActivatedRoute,
    private productServ: ProductService
  ) {}
  ngOnInit(): void {
    this.product$ = this.route.params
    .pipe( switchMap( params => {
      return this.productServ.getById(params['id'])
    }))
  }


}
