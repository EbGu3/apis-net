using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=Streamer;User Id=sa;Password=eguerra;TrustServerCertificate=True")
                .LogTo
                (
                    Console.WriteLine, 
                    new[] { 
                        DbLoggerCategory.Database.Command.Name 
                    }, 
                    Microsoft.Extensions.Logging.LogLevel.Information
                )
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentAPI
            //De uno a muchos
            //Utilizar cuando usas una llave foranea
            //que no utiliza la convension de EntityFramework
            //Es una buena practica usarlo tambien :)
            modelBuilder.Entity<Streamer>()
                        .HasMany(m => m.Videos)
                        .WithOne(m => m.Streamer)
                        .HasForeignKey(m => m.StreamerId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);

            // Relacion muchos a muchos
            modelBuilder.Entity<Video>()
                        .HasMany(p => p.Actors)
                        .WithMany(t => t.Videos)
                        .UsingEntity<VideoActor>(
                            pt => pt.HasKey(
                                e => new
                                {
                                    e.ActorId,
                                    e.VideoId
                                }
                            )
                        );
        }

        public DbSet<Streamer>? Streamers    { get; set; }
        public DbSet<Video>? Videos          { get; set; }
    }
}
