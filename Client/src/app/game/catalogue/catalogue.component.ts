import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { GameCardOnSelectEventArgs } from '../card/card.component';
import { AvaliableGames } from '../game';
import { GameService } from '../game.service';

@Component({
  selector: 'app-game-catalogue',
  templateUrl: './catalogue.component.html'
})

export class CatalogueComponent implements OnInit {
  avaliableGames: AvaliableGames = new AvaliableGames;
  selectedGames: string[] = [];
  haveAnyGames: boolean = true;  
  
  @Output() canSubmit = new EventEmitter();

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    this.gameService.getGames()
      .subscribe(
        games => {          
          this.avaliableGames = games;          
          this.haveAnyGames = this.avaliableGames.years.length > 0
        },
        error => {
          console.log(error);
          this.haveAnyGames = false
        }
      )             
  }

  onSelectChange(gameEvent: GameCardOnSelectEventArgs) {
    if (gameEvent.isSelected == true)
      this.addToSelected(gameEvent.Id);

    if (gameEvent.isSelected == false)
      this.removeFromSelected(gameEvent.Id);
  }  

  addToSelected(id: string) {
    this.selectedGames.push(id);
  }

  removeFromSelected(id: string) {
    let index = this.selectedGames.indexOf(id);
    this.selectedGames.splice(index, 1);
  }    

  selectedEnoughGames() { return this.selectedGames.length != 8};

  sendGames(){    
    this.canSubmit.emit(this.selectedGames);
  }
}

