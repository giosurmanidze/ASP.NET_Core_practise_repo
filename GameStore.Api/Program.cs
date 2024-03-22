using GameStore.Api.Entities;

const string GetGameEndpointName = "GetGame";

List <Game> games = new()
{
    new Game()
    {
        Id = 1,
        Name = "GTA 5",
        Genre = "Open World",
        Price = 49.99M,
        ReleaseDate = new DateTime(2013,9,17),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 2,
        Name = "Far cry 6",
        Genre = "Adventure",
        Price = 59.99M,
        ReleaseDate = new DateTime(2021,8,7),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 3,
        Name = "FIFA 23",
        Genre = "Sports",
        Price = 69.99M,
        ReleaseDate = new DateTime(2022,9,27),
        ImageUri = "https://placehold.co/100"
    },

};


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/games", () => games);

app.MapGet("/games/{id}", (int id) => {
     
     Game? game = games.Find(game => game.Id == id);

     if(game is null){
        return  Results.NotFound();
     }
     return Results.Ok(game);
}).WithName(GetGameEndpointName);


app.MapPost("/games", (Game game) => {
    
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});


app.MapPut("/games/{id}", (int id, Game updatedGame) => {

    Game? existingGame = games.Find(game => game.Id == id);

    if(existingGame is null) {
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.Price = updatedGame.Price;
    existingGame.ImageUri = updatedGame.ImageUri;

    return Results.NoContent();
});

app.Run();
