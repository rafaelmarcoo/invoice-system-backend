using invoice_system_backend.Data;
using invoice_system_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace invoice_system_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompanyDetails([FromBody] Company updatedCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCompany = await _context.Companies.FindAsync(1);

            if (existingCompany == null)
            {
                return NotFound(new { message = "Company not found" });
            }

            existingCompany.Name = updatedCompany.Name;
            existingCompany.GstNumber = updatedCompany.GstNumber;
            existingCompany.Address = updatedCompany.Address;
            existingCompany.City = updatedCompany.City;
            existingCompany.Zip = updatedCompany.Zip;
            existingCompany.Phone = updatedCompany.Phone;
            existingCompany.Email = updatedCompany.Email;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Company details updated successfully!" });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { message = "Database error occurred", error = ex.Message });
            }
        }

        [HttpGet("{getId}")]
        public async Task<IActionResult> GetCompanyDetails(int getId)
        {
            try
            {
                var details = await _context.Companies.FirstOrDefaultAsync(i => i.Id == getId);
                return Ok(details);
            }
            catch(Exception E)
            {
                return BadRequest(new { error = E.Message });
            }
        }
    }
}
