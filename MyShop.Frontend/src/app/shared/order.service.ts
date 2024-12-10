import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { FbResponse } from './interfaces';
import { compileNgModule } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  create(order) {
    console.log(order)
    return this.http.post(`${environment.apiUrl}/orders`, order)
    .pipe(map((res: FbResponse) => {
      return {
        ...order,
        id: res.name,
        date: new Date(order.date)
      }
    }))
  }

  getAll() {
    return this.http.get(`${environment.apiUrl}/orders`)
    .pipe(map(res => {
      if(!res) return [];
      return Object.keys(res)
      .map( key => ({
        ...res[key],
        id: res[key],
        date: new Date(res[key].date),
        products: res[key].products,
        address: res[key].customer.address,
        name: res[key].customer.name,
        phone: res[key].customer.phone
      }))
    }))
  }

  remove(order) {
    console.log(order.id)
    return this.http.delete(`${environment.apiUrl}/orders/${order.id}`)
  }

  
}
