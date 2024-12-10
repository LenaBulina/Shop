import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/shared/interfaces';
import { ProductService } from 'src/app/shared/product.service';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent implements OnInit, OnDestroy{
  
  products: Product[]
  pSub: Subscription
  rSub: Subscription
  productName: string;

  constructor(
    private productServ: ProductService
  ) {}
  
  
  ngOnInit(): void {
    this.pSub = this.productServ.getAll().subscribe(products => {
      this.products = products;
    })
  }

  remove(id) {
    this.rSub = this.productServ.remove(id).subscribe(() => {
      this.products = this.products.filter(product => product.id !== id);
    })
  }

  ngOnDestroy() {
    if(this.pSub) {
      this.pSub.unsubscribe();
    }

    if(this.rSub) {
      this.rSub.unsubscribe();
    }
  }

}