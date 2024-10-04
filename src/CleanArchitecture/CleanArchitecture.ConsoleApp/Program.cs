using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();

await AddNewRecords();
QueryStreaming();

void QueryStreaming ()
    => dbContext!.Streamers!
              .ToList()
              .ForEach(record =>
              {
                  Console.WriteLine($"Streamer: {record.Name}");
              });

async Task AddNewRecords ()
{
    // Insertar solo una
    Streamer streamer = new()
    {
        Name = "Rubiely",
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
        Name = "Beautiful Princess",
        StreamerId = streamer.Id
    },
    new Video
    {
        Name = "The love history",
        StreamerId = streamer.Id
    },
    new Video {
        Name = "The best Girl",
        StreamerId = streamer.Id
    }
    ];

    await dbContext!.AddRangeAsync(videos);
    await dbContext!.SaveChangesAsync();

}