import { Routes } from "@angular/router";
import { CatalogueComponent } from "./game/catalogue/catalogue.component";
import { TournamentComponent } from "./game/tournament/tournament.component";

export const rootRounterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: TournamentComponent },    
];