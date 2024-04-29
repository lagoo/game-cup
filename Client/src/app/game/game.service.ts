import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { AvaliableGames, Competitors} from './game';

@Injectable()
export class GameService {
    private url: string = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getGames(): Observable<AvaliableGames> {
        return this.http.get<AvaliableGames>(this.url + "Game")
    }

    getTournamentResult(games: string[]) : Observable<Competitors>{
        return this.http.post<Competitors>(this.url + "Tournament", games)
    }
}