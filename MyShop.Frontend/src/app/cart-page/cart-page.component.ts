import { Component, OnInit } from '@angular/core';
import { ProductService } from '../shared/product.service';
import { Product } from '../shared/interfaces';
import { fromEventPattern } from 'rxjs';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { OrderService } from '../shared/order.service';

@Component({
  selector: 'app-cart-page',
  templateUrl: './cart-page.component.html',
  styleUrls: ['./cart-page.component.scss']
})
export class CartPageComponent implements OnInit{

  cartProducts:Product[] = []
  totalPrice:number = 0

  form: FormGroup
  submitted = false
  added = ''

  constructor(
    private productServ: ProductService,
    private orderServ: OrderService
  ) {}

  ngOnInit(): void {
    this.cartProducts = this.productServ.cartProducts;
    for(let i = 0; i < this.cartProducts.length; i++) {
      this.totalPrice += +this.cartProducts[i].price;
    }

    this.form = new FormGroup({
      name: new FormControl(null, Validators.required),
      phone: new FormControl(null, [Validators.required, Validators.pattern('[0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2}')]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      address: new FormControl(null, Validators.required),
      payment: new FormControl('Cash'),
    })
  }

  submit() {
    if(this.form.invalid) {
      return;      
    }

    this.submitted = true;

    const order = {
      customer: {
        name: this.form.value.name,
        phone: this.form.value.phone,
        email: this.form.value.email,
      },       
      deliveryAddress: this.form.value.address,     
      payment: this.form.value.payment,
      products: this.cartProducts,
      price: this.totalPrice,
      date: new Date()
    }

    this.orderServ.create(order).subscribe(res => {     
      this.added = 'Delivery is framed'
      this.submitted = false;
    })
  }

  delete(product:Product){
    this.totalPrice =-product.price;
    this.cartProducts.splice(this.cartProducts.indexOf(product), 1)
  }

}
