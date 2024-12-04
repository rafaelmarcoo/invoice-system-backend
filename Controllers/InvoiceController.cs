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
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            try
            {
                var invoice = new Invoice
                {
                    Name = newInvoice.Name,
                    Frequency = newInvoice.Frequency,
                    DateSent = currentDate.ToString(),
                    DateDue = newInvoice.DateDue,
                    Amount = newInvoice.Items.Sum(i => i.Quantity * i.Price),
                    Items = newInvoice.Items
                };

                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();

                foreach (var eachItem in invoice.Items)
                {
                    var item = new InvoiceItem
                    {
                        InvoiceId = invoice.Id,
                        Description = eachItem.Description,
                        Quantity = eachItem.Quantity,
                        Price = eachItem.Price,
                    };
                    _context.InvoiceItems.Add(item);
                }

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
