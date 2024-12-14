using Microsoft.AspNetCore.Mvc;
using invoice_system_backend.Models;
using Microsoft.EntityFrameworkCore;
using invoice_system_backend.Data;
using invoice_system_backend.Migrations;

namespace invoice_system_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        private readonly AppDbContext _context;

        public AssetController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsset([FromBody] Asset asset)
        {
            try
            {
                _context.Assets.Add(asset);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Successfully added a new asset!" });
            }
            catch (Exception E)
            {
                return BadRequest(new { error = E.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            try
            {
                var assetList = await _context.Assets.ToListAsync();
                return Ok(assetList);
            }
            catch (Exception E)
            {
                return BadRequest(new { error = E.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepreciation(int id)
        {
            List<DepreciationData> depreciationData = new List<DepreciationData>();
            try
            {
                var asset = await _context.Assets.FirstOrDefaultAsync(i => i.Id == id);
                decimal ogValue = asset.OriginalValue;
                decimal depRate = asset.DepreciationRate;

                if (asset.DepreciationType == "straight-line")
                {
                    decimal depClaimed = ogValue * depRate;
                    decimal adjTaxVal = ogValue;

                    for (int year = 1; adjTaxVal > 0; year++)
                    {
                        adjTaxVal -= depClaimed;

                        depreciationData.Add(new DepreciationData
                        {
                            Year = year,
                            OriginalValue = ogValue,
                            DepreciationRate = depRate,
                            DepreciationClaimed = Math.Round(depClaimed, 2),
                            AdjustedTaxValue = Math.Round(adjTaxVal, 2),
                        });

                        if (adjTaxVal < depClaimed)
                        {
                            depClaimed = adjTaxVal;
                            adjTaxVal = 0;

                            depreciationData.Add(new DepreciationData
                            {
                                Year = year + 1,
                                OriginalValue = ogValue,
                                DepreciationRate = depRate,
                                DepreciationClaimed = Math.Round(depClaimed, 2),
                                AdjustedTaxValue = Math.Round(adjTaxVal, 2),
                            });
                        }
                    }

                    return Ok(depreciationData);
                }
                else
                {
                    decimal adjTaxVal = ogValue;
                    int usefulLife = asset.UsefulLife;

                    for (int year = 1; year <= usefulLife; year++)
                    {
                        decimal depClaimed = adjTaxVal * depRate;
                        adjTaxVal -= depClaimed;

                        depreciationData.Add(new DepreciationData
                        {
                            Year = year,
                            OriginalValue = ogValue,
                            DepreciationRate = depRate,
                            DepreciationClaimed = Math.Round(depClaimed, 2),
                            AdjustedTaxValue = Math.Round(adjTaxVal, 2),
                        });
                    }

                    return Ok(depreciationData);
                }
            }
            catch (Exception E)
            {
                return BadRequest(new { error = E.Message });
            }
        }
    }
}
