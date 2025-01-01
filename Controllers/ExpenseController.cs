using invoice_system_backend.Data;
using Microsoft.AspNetCore.Mvc;
using invoice_system_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace invoice_system_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly string _fileUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

        public ExpenseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(
            [FromForm] IFormFile? file,
            [FromForm] string title,
            [FromForm] string? description,
            [FromForm] string date,
            [FromForm] decimal amount,
            [FromForm] string category,
            [FromForm] decimal gstRate)
        {
            if (file != null)
            {
                try
                {
                    if (!Directory.Exists(_fileUploadPath))
                    {
                        Directory.CreateDirectory(_fileUploadPath);
                    }

                    var filePath = Path.Combine(_fileUploadPath, file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var expense = new Expense
                    {
                        Title = title,
                        Description = description,
                        FilePath = file.FileName,
                        Date = date,
                        Amount = Math.Round(amount, 2),
                        Category = category,
                        GstRate = gstRate,
                    };

                    if(expense.Description == null)
                    {
                        expense.Description = "---";
                    }

                    _context.Expenses.Add(expense);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Successfully added a new expense!" });
                }
                catch (Exception E)
                {
                    return BadRequest(new { error = E.Message });
                } 
            }
            else
            {
                try
                {
                    var expense = new Expense
                    {
                        Title = title,
                        Description = description,
                        FilePath = "NO FILES UPLOADED",
                        Date = date,
                        Amount = Math.Round(amount, 2),
                        Category = category,
                        GstRate = gstRate,
                    };

                    if (expense.Description == null)
                    {
                        expense.Description = "---";
                    }

                    _context.Expenses.Add(expense);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Successfully added a new expense!" });
                }
                catch (Exception E)
                {
                    return BadRequest(new { error = E.Message });
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            try
            {
                var expenseList = await _context.Expenses.ToListAsync();
                return Ok(expenseList);
            }
            catch (Exception E)
            {
                return BadRequest(new { message = E.Message });
            }
        }

        [HttpGet("view/{fileName}")]
        public IActionResult ViewExpense(string fileName)
        {
            var filePath = Path.Combine(_fileUploadPath, fileName);

            if(System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/pdf", fileName);
            }

            return NotFound("File not found!");
        }
    }
}
