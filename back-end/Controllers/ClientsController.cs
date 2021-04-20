using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var clients = _context.Clients.ToList();
            if (clients.Count == 0) return NotFound();
            return Ok(clients);
        }
        [HttpPost]
        public IActionResult CreateNote(Client client)
        {
            _context.Add(client);
            _context.SaveChanges();
            return StatusCode(201, client);
        }
        [HttpPut("{id}")]
        public ActionResult EditNote(int id, Client client)
        {
            var existingClient = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (existingClient == null) return NotFound();

            existingClient.Value = client.Value;
            existingClient.CustomerNumber = client.CustomerNumber;
            existingClient.FirstName = client.FirstName;
            existingClient.LastName = client.LastName;
            existingClient.PhoneNumber = client.PhoneNumber;
            existingClient.Company = client.Company;
            existingClient.Description = client.Description;

            _context.SaveChanges();
            return Ok(existingClient);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteNoteById(int Id)
        {
            var note = _context.Clients.FirstOrDefault(x => x.Id == Id);
            if (note == null) return NotFound();
            _context.Clients.Remove(note);
            _context.SaveChanges();
            return Ok();
        }
    }
}
