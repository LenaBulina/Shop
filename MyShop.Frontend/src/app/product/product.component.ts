import { Component, Input, OnInit } from '@angular/core';
import { ProductService } from '../shared/product.service';
import { Product } from '../shared/interfaces';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  @Input() product

  constructor(
    private productServ: ProductService
  ) {}

  ngOnInit() {}

  addToCart(product: Product) {
    this.productServ.addProduct(product);  
  }
}
