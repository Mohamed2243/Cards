import { Component, OnInit } from '@angular/core';
import { card } from './Models/card.model';
import { CardsService } from './service/cards.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'cards';
  cards: card[] = [];
  card: card = {
    id: '',
    cardNumber: '',
    cardholderName: '',
    expiryMonth: '',
    expiryYear: '',
    cvc: ''
  }
  constructor(private cardsService: CardsService) {

  }
  ngOnInit(): void {
    this.getAllCards();
  }
  getAllCards() {
    this.cardsService.getAllCards()
      .subscribe(
        response => {
          this.cards = response;
          this.card = {
            id: '',
            cardNumber: '',
            cardholderName: '',
            expiryMonth: '',
            expiryYear: '',
            cvc: ''

          }
        }
      );
  }
  onSubmit() {


    if (this.card.id === '') {
      this.cardsService.addCard(this.card)
        .subscribe(
          response => {
            this.getAllCards();
            this.card = {
              id: '',
              cardNumber: '',
              cardholderName: '',
              expiryMonth: '',
              expiryYear: '',
              cvc: ''
            }
          }
        );

    }
  }

  deleteCard(id: string) {
    this.cardsService.deleteCard(id)
      .subscribe(
        response => {
          this.getAllCards();
        }
      );
  }
  populateForm(card: card) {
    this.card = card;
  }
}
