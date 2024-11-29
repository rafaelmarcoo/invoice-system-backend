using invoice_system_backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using invoice_system_backend.Models;

namespace invoice_system_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientList()
        {
            var clientList = await _context.Clients.ToListAsync();
            return Ok(clientList);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {

            Console.WriteLine($"Incoming client: {System.Text.Json.JsonSerializer.Serialize(client)}");

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return Ok(new { message="Succefully added a new client!" });
        }
    }
}
