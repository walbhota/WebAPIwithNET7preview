using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIwithNET7preview.Models;

namespace WebAPIwithNET7preview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public static List<Contact> Contacts = new List<Contact>
        {
            new Contact { Id=1, Name="Bruce Wayne",BirthDate= new DateTime(1915, 4, 17)},
            new Contact { Id=2, Name="Peter Parker",BirthDate= new DateTime(2001, 8, 10)}
        };

        [HttpGet]
        public ActionResult<List<Contact>> GetAllContacts()
        {
            return Ok(Contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(int id)
        {
            var contact = Contacts.Find(x => x.Id == id);
            if (contact == null)
                return NotFound("Nope.");
            return Ok(contact);
        }

        [HttpPost]
        public ActionResult<List<Contact>> CreateContact(Contact contact)
        {
            Contacts.Add(contact);
            return Ok(Contacts);
        }

        [HttpPut]
        public ActionResult<List<Contact>> UpdateContact(Contact Updatedcontact)
        {
            var contact = Contacts.Find(x => x.Id == Updatedcontact.Id);
            if (Updatedcontact == null)
                return NotFound("Nope.");
            contact.Name = Updatedcontact.Name;
            contact.BirthDate = Updatedcontact.BirthDate;

            return (Contacts);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Contact>> DeleteContact(int id)
        {
            var contact = Contacts.Find(x => x.Id == id);
            if (contact == null)
                return NotFound("Nope.");
            Contacts.Remove(contact);

            return Ok(Contacts);
        }
    }
}
