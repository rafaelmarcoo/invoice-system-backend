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
        private readonly string _invoiceDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Invoices");

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

                var createdInv = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == newInvoice.Id);

                //return Ok(new { message = "Succesfully made a new invoice!" });
                //return Ok(new { id = newInvoice.Id });
                return Ok(createdInv);

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

        [HttpPost("save-pdf/{invoiceId}")]
        public async Task<IActionResult> SavePdf([FromForm] IFormFile pdf, int invoiceId)
        {
            try
            {
                if(!Directory.Exists(_invoiceDirectory))
                {
                    Directory.CreateDirectory(_invoiceDirectory);
                }

                var filePath = Path.Combine(_invoiceDirectory, pdf.FileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    await pdf.CopyToAsync(stream);
                }

                var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == invoiceId);
                invoice.FilePath = pdf.FileName;
                await _context.SaveChangesAsync();

                //return Ok(new { message = "Invoice saved successfully!", FilePath = filePath });
                return Ok(new { message = "Invoice saved successfully!" });
            }
            catch(Exception E)
            {
                return BadRequest(new { error = E.Message });
            }
        }

        [HttpGet("view/{fileName}")]
        public IActionResult ViewInvoice(string fileName)
        {
            var filePath = Path.Combine(_invoiceDirectory, fileName);

            if(System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/pdf", fileName);
            }

            return NotFound("File not found!");
        }
    }
}
