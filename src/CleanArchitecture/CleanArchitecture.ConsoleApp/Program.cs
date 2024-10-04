using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();

// Insertar solo una
Streamer streamer = new()
{
    Name = "Ivanna",
    Url = "https://www.twitch.tv/IR"
};

//! me indica que esta instanciado
dbContext!.Streamers!.Add(streamer);
await dbContext!.SaveChangesAsync();

// Insertar varias peliculas
List<Video> videos =
[
    new Video
    {
        Name = "Mi love",
        StreamerId = streamer.Id
    },
    new Video
    {
        Name = "Mi beautiful girl",
        StreamerId = streamer.Id
    },
    new Video {
        Name = "Mi life con Ella <3",
        StreamerId = streamer.Id
    }
];

await dbContext!.AddRangeAsync(videos);
await dbContext!.SaveChangesAsync();