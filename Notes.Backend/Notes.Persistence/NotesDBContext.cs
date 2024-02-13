using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfiguration;

namespace Notes.Persistence
{
    public class NotesDBContext : DbContext, INotesDBContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDBContext(DbContextOptions<NotesDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration((new NoteConfiguration()));
            base.OnModelCreating(builder);
        }
    }
}