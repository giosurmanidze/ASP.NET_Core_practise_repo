using GameStore.Api.Entities;


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

app.Run();
