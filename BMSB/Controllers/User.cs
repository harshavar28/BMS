using Microsoft.AspNetCore.Mvc;
using BMSB.ADb;
using AutoMapper;
using BMSB.Models;
using BMSB.Dto;
using Microsoft.EntityFrameworkCore;

namespace BMSB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApDb _db;
        private readonly IMapper _map;
        public UserController(ApDb db,IMapper mapper) 
        {
            _db = db;
            _map = mapper;
        }


        [HttpPost("RequestUBooks/{bid}/{sid}")]
        public async Task<IActionResult> ReqUBooks([FromRoute] int bid, [FromRoute] int sid)
        {
            var Req = await _db.Approvals.AddAsync(new Approval
            {
                BId = bid,
                UId = sid,
                Status = "Pending"
            });
            await _db.SaveChangesAsync();
            return Ok(new {m="requested"});
        }
        [HttpGet("GetUCarts/{id}")]
        public async Task<IActionResult> GetUCarts([FromRoute] int id)
        {
            var carts = await _db.Approvals.Where(a => a.UId == id && a.Status == "Pending").Include(a=>a.Book).ThenInclude(b=>b.AuthCred).ToListAsync();

            if (carts == null || !carts.Any())
            {
                return NotFound(new { m = "No pending requests found" });
            }
            var cartDtos = _map.Map<List<Udata>>(carts);
            return Ok(cartDtos);
        }
        [HttpGet("UBooks/{id}")]
        public async Task<IActionResult> UBooks([FromRoute] int id)
        {
            var books = await _db.Approvals.Where(a => a.UId == id && a.Status == "Approved").Include(a => a.Book).ThenInclude(b => b.AuthCred).ToListAsync();
            if (!books.Any())
            {
                return NotFound(new { m = "Books not found" });
            }
            var BDtos = _map.Map<List<Udata>>(books);
            return Ok(BDtos);
        }

    }
}
