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
            try
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Successfully added a new client!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditClient([FromBody] Client updatedClient)
        {
            try
            {
                var client = await _context.Clients.FirstOrDefaultAsync(c => c.CompanyCode == updatedClient.CompanyCode);

                client.CompanyCode = updatedClient.CompanyCode;
                client.GstNumber = updatedClient.GstNumber;
                client.Name = updatedClient.Name;
                client.Address = updatedClient.Address;
                client.City = updatedClient.City;
                client.Zip = updatedClient.Zip;
                client.Email = updatedClient.Email;
                client.Phone = updatedClient.Phone;

                await _context.SaveChangesAsync();
                return Ok(new { message = "Client details updated succesfully" });
            }
            catch(Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}
