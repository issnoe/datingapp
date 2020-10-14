using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {

            return "Secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {

            var thing = _context.Users.Find(-1);
            if (thing == null) return NotFound();
            return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {

            var thing = _context.Users.Find(-1);
            var thingToreturn = thing.ToString();
            if (thing == null) return NotFound();
            return Ok(thing);
            /*
            // This is when is not used a middleware error 
            try
            {
                var thing = _context.Users.Find(-1);
                var thingToreturn = thing.ToString();
                if (thing == null) return NotFound();
                return Ok(thing);
            }
            catch (System.Exception exception)
            {

                return StatusCode(500, "Error");
            }*/
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {

            return BadRequest("This was not a good request");
        }

    }
}