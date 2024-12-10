import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { OrderService } from 'src/app/shared/order.service';

@Component({
  selector: 'app-orders-page',
  templateUrl: './orders-page.component.html',
  styleUrls: ['./orders-page.component.scss']
})
export class OrdersPageComponent {

  orders = []
  pSub: Subscription
  rSub: Subscription

  constructor(
    private orderServ: OrderService
  ) {}
  
  
  ngOnInit(): void {
    this.pSub = this.orderServ.getAll().subscribe(orders => {
      this.orders = orders;
    })
  }

  getProductList(order){
    return order.products.map(pr => pr.title);
  }

  remove(id) {
    this.rSub = this.orderServ.remove(id).subscribe(() => {
      this.orders = this.orders.filter(order => order.id !== id);
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

