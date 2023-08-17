using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller 
    {
        // Private field to hold an instance of ContactsAPIDbContext
        private readonly ContactsAPIDbContext _dbContext;

        public ContactsController(ContactsAPIDbContext dbcontext) 
        {
            // Assign the injected instance of ContactsAPIDbContext to the private field _dbContext.
            this._dbContext = dbcontext;
        }

        // This action method handles HTTP GET requests for retrieving contacts.

        // Return an OkObjectResult (HTTP status code 200) containing a list of Contact entities from the database.
        // _dbContext.Contacts.ToList() retrieves all contacts from the DbSet<Contact> named "Contacts".
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {

            return Ok(await _dbContext.Contacts.ToListAsync());

        }

        // This action method handles HTTP POST requests for adding a new contact.

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            // Create a new Contact instance using data from the received AddContactRequest.
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };

            // Add the newly created contact to the DbSet in the database context.
            // and Save the changes made to the database.
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();

            return Ok(contact); // Return an OkObjectResult (status code 200) containing the newly added contact.

        }

    }
}
