using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionFormation.Models.Repositories
{
    public class ParticipantsContext : IdentityDbContext
    {
        public ParticipantsContext(DbContextOptions<ParticipantsContext> options) : base(options)
        {
        }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Formation> Formations { get; set; }

    }
}
