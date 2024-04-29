export class Game{
    id!: string;
    title!: string;
    imageUrl!: string;
    console!: string;
}

export class GamesByYear {
    year!: number;
    games!: Game[]; 
}

export class AvaliableGames {
    years!: GamesByYear[]
}

export class Competitors{    
    firstPlace!: Game;
    secondPlace!: Game;
}
