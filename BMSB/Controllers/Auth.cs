using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BMSB.ADb;
using BMSB.Models;
using BMSB.Dto;
using AutoMapper;

namespace BMSB.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApDb _db;
        private readonly IMapper _map;
        public AuthController(ApDb db, IMapper map )
        {
            _db = db;
            _map = map;
        }

        [HttpPost]
        public async  Task<ActionResult> Register([FromBody] Adata d)
        {
            if (ModelState.IsValid)
            {

                var user = await _db.Creds.FirstOrDefaultAsync(u => u.Uname == d.Uname);
                if (user == null)
                {
                    var ma = _map.Map<Cred>(d);
                    _db.Creds.Add(ma);
                    await _db.SaveChangesAsync();
                    return Ok(new { m = "succ" });
                }
                return BadRequest(new { m = "exists" });
            }
            return BadRequest(ModelState);
        }
        [HttpPost("log")]
        public async Task<IActionResult> Login([FromBody] Adata d)
        {
            var user = await _db.Creds.FirstOrDefaultAsync(u => u.Uname == d.Uname && u.Password == d.Password);
            if (user == null)
            {
                return BadRequest(new { m = "not found" });
            }
            return Ok(user);
        }

        [HttpPost("AuthR")]
        public async Task<ActionResult> RegisterA([FromBody] Adata ad)
        {
            if (ModelState.IsValid)
            {

                var user = await _db.AuthCreds.FirstOrDefaultAsync(u => u.Name == ad.Uname);
                if (user == null)
                {
                    var m = _map.Map<AuthCred>(ad);
                    _db.AuthCreds.Add(m);
                    await _db.SaveChangesAsync();
                    return Ok(new { m = "succ" });
                }
                return BadRequest(new { m = "exists" });
            }
            return BadRequest(ModelState);
        }

        [HttpPost("logA")]
        public async Task<IActionResult> LoginA([FromBody] Adata ad)
        {
            var user = await _db.AuthCreds.FirstOrDefaultAsync(u => u.Name == ad.Uname && u.Password == ad.Password);
            if (user.Approval==null)
            {
                return BadRequest(new { m = "not found" });
            }

            return Ok(user);
        }
    }
    
}
