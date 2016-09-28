using Ldme.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ldme.EF.Setup
{
    //public class LdmeContext : DbContext
    //{
    //    private IConfigurationRoot _config;

    //    public LdmeContext(IConfigurationRoot config)
    //    {
    //        _config = config;
    //    }

    //    public DbSet<Player> Players { get; set; }
    //    public DbSet<Quest> Quests { get; set; }
    //    public DbSet<Activity> Activities { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        base.OnConfiguring(optionsBuilder);

    //        optionsBuilder.UseSqlServer(_config["ConnectionStrings:EfContexConnection"]);
    //    }
    //}
}
