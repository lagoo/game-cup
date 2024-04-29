import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { APP_BASE_HREF } from '@angular/common';

import { AppComponent } from './app.component';
import { HomeComponent } from './navigation/home/home.component';
import { FooterComponent } from './navigation/footer/footer.component';
import { HeaderComponent } from './navigation/header/header.component';
import { CardComponent } from './game/card/card.component';
import { CatalogueComponent } from './game/catalogue/catalogue.component';
import { GameService } from './game/game.service';
import { RouterModule } from '@angular/router';
import { rootRounterConfig } from './app.route';
import { TournamentComponent } from './game/tournament/tournament.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    HeaderComponent,
    CardComponent,
    CatalogueComponent,
    TournamentComponent    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    [RouterModule.forRoot(rootRounterConfig, { useHash: false})]
  ],
  providers: [
    {provide: APP_BASE_HREF, useValue:'/'},
    GameService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
