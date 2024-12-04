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
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            decimal totalAmt = 0;
            foreach (var item in newInvoice.Items)
            {
                decimal price = Convert.ToDecimal(item.Price);
                decimal quantity = Convert.ToDecimal(item.Quantity);

                totalAmt += quantity * price;
            }

            try
            {
                newInvoice.DateSent = currentDate;
                newInvoice.Amount = totalAmt;

                _context.Invoices.Add(newInvoice);
                await _context.SaveChangesAsync();

                foreach (var eachItem in newInvoice.Items)
                {
                    decimal price = Convert.ToDecimal(eachItem.Price);
                    decimal quantity = Convert.ToDecimal(eachItem.Quantity);
                    eachItem.Price = price;
                    eachItem.Quantity = quantity;
                    eachItem.InvoiceId = newInvoice.Id;
                    _context.InvoiceItems.Add(eachItem);
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
