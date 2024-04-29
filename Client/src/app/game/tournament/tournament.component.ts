import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Competitors } from '../game';
import { GameService } from '../game.service';

@Component({
  selector: 'app-game-tournament',
  templateUrl: './tournament.component.html'
})
export class TournamentComponent implements OnInit {    
  haveWinnerAndLoser: boolean = false;
  competidors: Competitors = new Competitors();
  
  constructor(private gameService: GameService) { }

  ngOnInit(): void {}  

  getWinnerAndLoser(gamesIds: string[]) {
    this.gameService.getTournamentResult(gamesIds)
      .subscribe(
        comp => {          
          this.competidors = comp;          
          this.haveWinnerAndLoser = true;
        },
        error => console.log(error)
      )
  }  

  resetTournament() {
    this.haveWinnerAndLoser = false;
  }
}
