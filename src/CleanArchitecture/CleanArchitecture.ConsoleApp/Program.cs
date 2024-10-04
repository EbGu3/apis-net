using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();
await AddNewDirectorWithVideo();

async Task AddNewDirectorWithVideo ()
{
    Director director = new()
    {
        Name = "Liseth",
        LastName = "Coy",
        VideoId = 9,
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorVideo ()
{
    Actor actor = new()
    {
        Name = "Jisca",
        LastName = "Guerra",
    };
    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    VideoActor videoActor = new()
    {
        ActorId = actor.Id,
        VideoId = 4
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{
    Video video = new()
    {
        Name = "The best doctor",
        StreamerId = 9
    };

    await dbContext.AddAsync(video);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo ()
{
    Streamer streamer = new()
    {
        Name = "Daniel",
        Url = "http://www.twitch.tv/daniel"
    };

    Video video = new()
    {
        Name = "The best bro",
        Streamer = streamer
    };

    await dbContext.AddAsync(video);
    await dbContext.SaveChangesAsync();
}

async Task TrackingAndNotTracking ()
{

    // Traking por deaful incorporado
    // Se mantiene en memoria
    // Para ejecutar el update or delete
    Streamer? streamerTraking = await dbContext.Streamers
                                               .FirstOrDefaultAsync(record =>
                                                   record.Name == "Rubiely"
                                               );

    // No dejar usar el metodo FindAsync
    // Libera el objeto de memoria temporal
    // No deja actualizar el objeto
    
    // Usar este metodo cuando sea una alta demanda
    // a la base de datos. Y no se requiera que estos
    // despues sean actualizados o eliminar 
    Streamer? streamerNotTraking = await dbContext.Streamers
                                                  .AsNoTracking()
                                                  .FirstOrDefaultAsync(record =>
                                                     record.Name == "Ivanna"
                                                  );

    streamerTraking.Name = "Rubiely Princess";
    streamerNotTraking.Name = "Ivanna Queen";

    await dbContext.SaveChangesAsync();
}

async Task QueryLinqWhere()
    => await (
            from i in dbContext.Streamers
            where EF.Functions.Like(i.Name, "%I%")
            select i
       )
       .ForEachAsync(record =>
       {
           Console.WriteLine($"Streamer: {record.Name}");
       });

async Task QueryLinq ()
    => await (
            from i in dbContext.Streamers
            select i
       )
       .ForEachAsync(record =>
       {
            Console.WriteLine($"Streamer: {record.Name}");
       });

async Task QueryMethods()
{
    DbSet<Streamer> streamers = dbContext!.Streamers!;

    // No usar '' da error mejor usar "", ya que da error el primero

    // Devuelve el primer registro
    // Si no lo encuentra tira una excepcion
    Streamer firstAsync = await streamers
                                    .Where(record =>
                                        record!.Name!.Contains("I")
                                    )
                                    .FirstAsync();

    // Devuelve el primer registro que cumple con la condición
    // o devuelve null
    Streamer? firstOrDeafulAsync = await streamers
                                            .Where(record =>
                                                record!.Name!.Contains("I")
                                            )
                                            .FirstOrDefaultAsync();

    // Devuelve el primer registro que cumpla con la condicion
    // o devuelve null
    Streamer? firstOrDefaultV2 = await streamers
                                        .FirstOrDefaultAsync(record =>
                                            record!.Name!.Contains("I")
                                        );

    // SingleAsync vs FirstOrDefaultAsync
    // SingleAsync, el resultado de la condicion aplicada solo puede devolver un valor, si detecta una coleccion tira error
    // Si no encuentra ningun registro que cumpla con la condicion tira error
    var singleAsync = await streamers
                            .Where(record => record.Id == 1)
                            .SingleAsync();

    // Devuelve el primer registro que cumple con la condición
    // no tira excepcion
    var singleOrDefaultAsync = await streamers
                                        .Where(record => record.Id == 1)
                                        .SingleOrDefaultAsync();

    // Busqueda por id
    var findAsync = streamers.FindAsync(1);

}

async Task QueryFilterPartialResult () 
    => await dbContext!.Streamers!
              .Where(record =>
                  EF.Functions.Like(record!.Name, $"%Rubi%")
              )
              .ForEachAsync(record =>
              {
                  Console.WriteLine($"Streamer: {record.Name}");
              });

async Task QueryFilterContains ()
    => await dbContext!.Streamers!
              .Where(record =>
                record!.Name!.Contains("Rubi")
              )
              .ForEachAsync(record =>
              {
                  Console.WriteLine($"Streamer: {record.Name}");
              });

async Task QueryFilterEquals ()
    => await dbContext!.Streamers!
              .Where(record =>
                record!.Name!.Equals("Rubiely")
              )
              .ForEachAsync(record =>
              {
                  Console.WriteLine($"Streamer: {record.Name}");
              });

async Task QueryFilter ()
    => await dbContext!.Streamers!
              .Where(record => 
                record.Name == "Rubiely"
              )
              .ForEachAsync(record =>
              {
                  Console.WriteLine($"Streamer: {record.Name}");
              });

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