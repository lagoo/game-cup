import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { Game } from '../game';

@Component({
  selector: 'app-game-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})

export class CardComponent implements OnInit {
  isSelected = false;
  
  @Input('selectable') selectable: boolean = true;
  @Input('hoverable') hoverable: boolean = true;
  @Input('fit-image') fitImage: boolean = true;
  @Input('game') game: Game = new Game();  
  @Output('click') change = new EventEmitter();

  constructor(){}

  ngOnInit(){
  }      
  
  onSelect() {
    if(this.selectable){
      this.isSelected = !this.isSelected;
      this.change.emit({isSelected: this.isSelected, Id: this.game?.id });
    }    
  }
}

export interface GameCardOnSelectEventArgs {
    isSelected: boolean
    Id :string 
}
