import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { card } from '../Models/card.model';

@Injectable({
  providedIn: 'root'
})
export class CardsService {
  baseUrl ='https://localhost:7046/api/cards';

  constructor(private http: HttpClient){}

  //Get All cards
  getAllCards() :Observable<card[]> {
    return this.http.get<card[]>(this.baseUrl);

  }

  addCard(card: card){
    card.id = " 00000000-0000-0000-0000-000000000000";
   return this.http.post(this.baseUrl,card);
  }
  deleteCard(id:string): Observable<card>{
  return this.http.delete<card>(this.baseUrl + '/' + id);
}
}
