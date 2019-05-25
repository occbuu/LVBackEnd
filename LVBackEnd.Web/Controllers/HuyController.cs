using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKG.Req;

namespace LVBackEnd.Web.Controllers
{
    using BLL;

    [Route("api/[controller]")]
    [ApiController]
    public class HuyController : ControllerBase
    {
        public HuyController(HuyLogSvc svc)
        {
            _svc = svc;
        }

        [AllowAnonymous]
        [HttpPost("read")]
        public IActionResult Read([FromBody]SimpleReq req)
        {
            var res = _svc.Read(req.Id);
            return Ok(res);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="req">Request</param>
        /// <returns>Return the result</returns>
        [AllowAnonymous]
        [HttpPost("search-log")]
        public IActionResult Read([FromBody] PagingReq req)
        {
            //req.UserId = UserId;
            var res = _svc.Read(req);
            return Ok(res);
        }

        #region -- Fields --

        /// <summary>
        /// Repository to handle the database
        /// </summary>
        private HuyLogSvc _svc;

        #endregion
    }
}