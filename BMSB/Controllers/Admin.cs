using Microsoft.AspNetCore.Mvc;
using BMSB.ADb;
using BMSB.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BMSB.Dto;

namespace BMSB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApDb _db;
        private readonly IMapper _map;
        public AdminController(ApDb db,IMapper map)
        {
            _db = db;
            _map = map;
        }
        [HttpGet("AuthReq")]
        public async Task<IActionResult> AppA()
        {
            var user = await _db.AuthCreds.Where(u => u.Approval == null).ToListAsync();
            if(user == null || !user.Any())
            {
                return NotFound(new { m = "No pending approvals" });
            }
            return Ok(user);
        }

        [HttpPut("Appro/{id}")]
        public async Task<IActionResult> Appr([FromRoute] int id)
        {
            var user = await _db.AuthCreds.FirstOrDefaultAsync(u => u.Id == id);
            user.Approval = "Approved" ;
            _db.AuthCreds.Update(user);
            await _db.SaveChangesAsync();
            return Ok(new { m = "Approved" });
        }
        [HttpGet("userReqs")]
        public async Task<IActionResult> GetUserReqs()
        {
            var reqs = await _db.Approvals.Where(a => a.Status == "Pending").Select(a => new
            {
                a.Id,
                a.BId,
                a.UId,
                a.Status,
                BookTitle = a.Book.Title,
                AuthName = a.Book.AuthCred.Name,
                CUname = a.Cred.Uname 
            }).ToListAsync();
            if (reqs == null || !reqs.Any())
            {
                return NotFound(new { m = "No pending requests found" });
            }
            return Ok(reqs);
        }
        [HttpPut("Approving/{sid}/{bid}")]
        public async Task<IActionResult> ApproveBook([FromRoute] int sid, [FromRoute] int bid)
        {
            var app = await _db.Approvals.FirstOrDefaultAsync(b => b.BId == bid && b.UId==sid);
            
            app.Status = "Approved";
            _db.Approvals.Update(app);
            await _db.SaveChangesAsync();
            return Ok(new { m = "Book approval status updated" });
        }

    }
}
