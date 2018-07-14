namespace Pasty.Core.Entities
{
    using Microsoft.EntityFrameworkCore;

    public class PastyDbContext : DbContext
    {
        DbSet<Paste> Pastes { get; set; }
    }
}