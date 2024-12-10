import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FbResponse, Product } from './interfaces';
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  type: string = 'Phone'
  cartProducts: Product[] = []

  constructor(private http: HttpClient) { }

  create(product) {
    return this.http.post(`${environment.apiUrl}/products`, product)
   
  }

  getAll() {
    return this.http.get(`${environment.apiUrl}/products`)
    .pipe(map(res => {
      return Object.keys(res)
      .map( key => ({
        ...res[key],
        date: new Date(res[key].date)
      }))
    }))
  }

  getById(id) {
    return this.http.get(`${environment.apiUrl}/products/${id}`)
    .pipe( map((res: Product) => {
      return {
        ...res,
        id,
        date: new Date(res.date)
      }
    }))
  }

  remove(id) {
    return this.http.delete(`${environment.apiUrl}/products/${id}`)
  }

  update(product:Product) {
    return this.http.patch(`${environment.apiUrl}/products/${product.id}`, product)
  }

  setType(type: string){
    this.type = type
  }

  addProduct(product:Product) {
    this.cartProducts.push(product)
  }

}
