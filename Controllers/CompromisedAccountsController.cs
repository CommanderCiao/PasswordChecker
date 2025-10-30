using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordChecker.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PasswordChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompromisedAccountsController : ControllerBase
    {

        private readonly AppDbContext _context;
        private const int MIN_PREFIX_LENGTH = 5;
        private const int MAX_RESULTS = 1000;

        public CompromisedAccountsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("search")]
        public async Task<IActionResult> PostSubHash([FromBody] SearchRequest request)
        {
            var subHash = request.SubHash;
            if (subHash == null || subHash.Length < MIN_PREFIX_LENGTH)
            {
                return BadRequest($"Minimal prefix length is {MIN_PREFIX_LENGTH}");
            }

            List<string> hashesList = await _context.CompromisedAccounts.Where(x => x.PasswordHash.StartsWith(subHash)).Select(x => x.PasswordHash).ToListAsync();

            if (hashesList.Count >= MAX_RESULTS)
            {
                return BadRequest($"Too many results ({hashesList.Count}). Please provide a longer prefix (current: {subHash.Length} chars)");
            }
            return Ok(hashesList);
        }

    }
}


