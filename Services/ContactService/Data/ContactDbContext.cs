namespace ContactService.Data
{
    using Microsoft.EntityFrameworkCore;
    using ContactService.Models;

    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasMany(c => c.ContactDetails)
                .WithOne(cd => cd.Contact)
                .HasForeignKey(cd => cd.ContactId)
                .OnDelete(DeleteBehavior.Cascade);}
    }
    
}