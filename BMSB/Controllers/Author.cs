using Microsoft.AspNetCore.Mvc;
using BMSB.ADb;
using BMSB.Models;
using Microsoft.EntityFrameworkCore;
using BMSB.Dto;
using AutoMapper;

namespace BMSB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ApDb _db;
        private readonly IMapper _map;
        public AuthorController(ApDb db, IMapper mapper)
        {
            _db = db;
            _map = mapper;
        }
        [HttpPost("AddBooks/{id}")]
        public async Task<IActionResult> AddBook([FromBody] data d, [FromRoute] int id)
        {
            var b = await _db.Books.FirstOrDefaultAsync(b => b.Title == d.Title );
            if (b != null)
            {
                return BadRequest(new { m = "Book Name already exists" });
            }
            b = _map.Map<Book>(d);
            b.AId = id;
            await _db.Books.AddAsync(b);
            await _db.SaveChangesAsync();
            return Ok(new { m = "Book added successfully" });
        }

        [HttpGet("GetABooks/{id}")]
        public async Task<IActionResult> GetBooks([FromRoute] int id)
        {
            var books = await _db.Books.Where(b => b.AId == id).Select(b => new
            {
                b.Id,
                b.Title,
                b.Category,
            }).ToListAsync();
            if (books == null || !books.Any())
            {
                return NotFound(new { m = "No books found" });
            }
            
            return Ok(books);

        }

        [HttpPut("UpdateBook/{Aid}/{Bid}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int Aid, [FromRoute]int Bid, [FromBody] data d)
        {
            var book = await _db.Books.FirstOrDefaultAsync(b => b.AId == Aid && b.Id==Bid);
            if (book == null)
            {
                return NotFound(new { m = "Book not found" });
            }
            _map.Map(d, book);
            _db.Books.Update(book);
            await _db.SaveChangesAsync();
            return Ok(new { m = "Book updated successfully" });
        }
    }

}
