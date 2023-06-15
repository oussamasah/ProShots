using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProShots.Areas.Identity.Data;
using ProShots.Models;

namespace ProShots.Data;

public class ProShotsContext : IdentityDbContext<User>
{
    public ProShotsContext(DbContextOptions<ProShotsContext> options)
        : base(options)
    {
    }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Media> Medias { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)

      
    {
        var s1 = new Sector { Id = 1, Name = "Wedding and Events" };
        var s2 = new Sector { Id = 2, Name = "Portrait and Studio" };
        var s3 = new Sector { Id = 3, Name = "Street Photography" };
        var s4 = new Sector { Id = 4, Name = "Fashion and Beauty" };
        var s5 = new Sector { Id = 5, Name = "Fine Art and Conceptual" };
        var s6 = new Sector { Id = 6, Name = "Travel and Landscape" };
        var s7 = new Sector { Id = 7, Name = "Photojournalism and Documentary" };
        var s8 = new Sector { Id = 8, Name = "Sports and Action" };
        var s9 = new Sector { Id = 9, Name = "Wildlife and Nature" };
        var s10 = new Sector { Id = 10, Name = "Food and Culinary" };
        var s11 = new Sector { Id = 11, Name = "Commercial and Advertising" };
        var s12 = new Sector { Id = 12, Name = "Pet and Animal" };
        var s13 = new Sector { Id = 13, Name = "Medical and Scientific" };
        var s14 = new Sector { Id = 14, Name = "Astrophotography" };
        var s15 = new Sector { Id = 15, Name = "Automotive" };
        var s16 = new Sector { Id = 16, Name = "Aerial" };
        var s17 = new Sector { Id = 17, Name = "Architectural and Interior" };
        var s18 = new Sector { Id = 18, Name = "Other" };

        builder.Entity<Sector>().HasData(s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18);
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

}
