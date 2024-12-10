using System.Text.Json;
using invoice_system_backend.Data;
using invoice_system_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

                return Ok(new { message = "Succesfully made a new invoice!" });

            }
            catch(Exception E)
            {
                return BadRequest(new { error = E.Message});
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            try
            {
                var invoiceList = await _context.Invoices.ToListAsync();
                return Ok(invoiceList);
            }
            catch (Exception E)
            {
                return BadRequest(new { error = E.Message });
            }
        }

        [HttpPut("{editId}")]
        public async Task<IActionResult> EditInvoice(int editId)
        {
            try
            {
                var invoice = await _context.Invoices.FirstOrDefaultAsync(inv => inv.Id == editId);
                invoice.Status = "Paid";

                String currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                invoice.DatePaid = currentDate;

                await _context.SaveChangesAsync();
                return Ok(new { message = "Invoice marked as paid!" });
            }
            catch(Exception E)
            {
                return BadRequest(new { error = E.Message });
            }
        }
    }
}
