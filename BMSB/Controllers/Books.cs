using Microsoft.AspNetCore.Mvc;
using BMSB.ADb;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace BMSB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApDb _db;
        private readonly IMapper _map;
        private readonly ILogger<BooksController> _logger;
        private readonly IMemoryCache _cache;

        public BooksController(ApDb db, IMapper mapper, ILogger<BooksController> logger, IMemoryCache cache)
        {
            _db = db;
            _map = mapper;
            _logger = logger;
            _cache = cache;
        }

        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            _logger.LogInformation("GetBooks endpoint called.");

            string cacheKey = "books_cache";

            if (_cache.TryGetValue(cacheKey, out var cachedBooks))
            {
                _logger.LogInformation("Books retrieved from cache.");
                return Ok(cachedBooks);

            }

            try
            {
                var books = await _db.Books.Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Category,
                    AName = b.AuthCred.Name
                }).ToListAsync();

                if (books == null || !books.Any())
                {
                    _logger.LogWarning("No books found in the database.");
                    return NotFound(new { m = "No books found" });
                }

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                _cache.Set(cacheKey, books, cacheOptions);

                _logger.LogInformation("Books retrieved from DB and cached. Count: {Count}", books.Count);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching books.");
                return StatusCode(500, new { m = "Internal server error" });
            }
        }
        [HttpGet("GetOp")]
        public async Task<IActionResult> Getop()
        {
            var opts = await _db.Books.Select(p => p.Category).Distinct().ToListAsync();
            return Ok(opts);
        }
        [HttpGet("GetC")]
        public async Task<IActionResult> GetC([FromQuery]string cat)
        {
            var ca = await _db.Books.Where(c => c.Category == cat).Include(a=>a.AuthCred).ToListAsync();
            var catg = ca.Select(c => new
            {
                c.Id,
                AName = c.AuthCred.Name,
                c.Category,
                c.Title
            });
            return Ok(catg);
        }
    }
}
