using invoice_system_backend.Data;
using Microsoft.AspNetCore.Http.HttpResults;
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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCompanyDetails(int id, [FromBody] Company updatedCompany)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var existingCompany = await _context.Companies.FindAsync(id);

        //    if(existingCompany == null)
        //    {
        //        return NotFound(new { message = "Company not found" });
        //    }

        //    existingCompany.Name = updatedCompany.Name;
        //    existingCompany.GST = updatedCompany.GST;
        //    existingCompany.Address = updatedCompany.Address;
        //    existingCompany.City = updatedCompany.City;
        //    existingCompany.Zip = updatedCompany.Zip;
        //    existingCompany.Phone = updatedCompany.Phone;
        //    existingCompany.Email = updatedCompany.Email;
        //}
    }
}
