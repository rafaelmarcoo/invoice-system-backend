using System.Text.Json;
using invoice_system_backend.Data;
using invoice_system_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoice_system_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly AppDbContext _context;

        public InvoiceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody] Invoice newInvoice)
        {
            try
            {
                _context.Invoices.Add(newInvoice);
                await _context.SaveChangesAsync();

                //foreach (var eachItem in newInvoice.Items)
                //{
                //    eachItem.Id = 0;  // Ensure ID is not set so EF can handle it automatically
                //    eachItem.InvoiceId = newInvoice.Id;  // Link InvoiceId to the newly created Invoice
                //    _context.InvoiceItems.Add(eachItem);
                //}

                await _context.SaveChangesAsync();

                return Ok(new { message = "Succesfully made a new invoice!" });

            }
            catch(Exception E)
            {
                return BadRequest(new { error = E.Message});
            }
            
        }
    }
}
