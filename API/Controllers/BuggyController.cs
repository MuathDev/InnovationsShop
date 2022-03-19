using Infrastructure.Data;
using Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {

        private readonly InnovationShopContext _context;
        public BuggyController(InnovationShopContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {

            var thing = _context.Tbproducts.Find(50);

            if(thing == null)
            {
                return NotFound( new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {

            var thing = _context.Tbproducts.Find(50);
            var thingToReturn = thing.ToString();

            return Ok();

        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {

            return BadRequest(new ApiResponse(400));

        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {

            return Ok();

        }


    }
}
