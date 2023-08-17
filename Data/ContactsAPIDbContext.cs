using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options): base(options) {

        }


        // Declare a public property of type DbSet<Contact> named Contacts.
        // DbSet represents a collection of entities of the specified type in the database.
        // In this case, it represents a collection of Contact entities.
        public DbSet<Contact> Contacts { get; set; }
    }
}
