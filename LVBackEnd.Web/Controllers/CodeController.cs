using Microsoft.AspNetCore.Mvc;
using SKG.Req;
using System.Collections.Generic;

namespace LVBackEnd.Web.Controllers
{
    using BLL;

    /// <summary>
    /// Code controller
    /// </summary>
    public class CodeController : BaseController
    {
        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="svc">Service</param>
        public CodeController(CodeSvc svc)
        {
            _svc = svc;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="req">Request</param>
        /// <returns>Return the result</returns>
        //[HttpPost("create")]
        //public IActionResult Create([FromBody]CodeReq req)
        //{
        //    var m = req.ToModel();
        //    m.CreatedBy = UserId;

        //    var res = _svc.Create(m);
        //    return Ok(res);
        //}

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="req">Request</param>
        /// <returns>Return the result</returns>
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
        [HttpPost("search")]
        public IActionResult Read([FromBody]PagingReq req)
        {
            req.UserId = UserId;
            var res = _svc.Read(req);
            return Ok(res);
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="req">Request</param>
        /// <returns>Return the result</returns>
        [HttpPost("read-by-keyword1")]
        public IActionResult ReadByKeyWord1([FromBody]PagingReq req)
        {
            req.UserId = UserId;
            var res = _svc.Read(req);
            return Ok(res);
        }

        /// <summary>
        /// Read code table
        /// </summary>
        /// <param name="req">Request</param>
        /// <returns>Return the result</returns>
        [HttpPost("read-by-keyword1")]
        public IActionResult ReadCodeTable([FromBody]PagingReq req)
        {
            req.UserId = UserId;
            var res = _svc.Read(req);
            return Ok(res);
        }

        /// <summary>
        /// Get all code
        /// </summary>
        /// <param name="req">Request (Keyword is year value)</param>
        /// <returns>Return the result</returns>
        [HttpPost("read-by-code-type")]
        public IActionResult ReadByCodeType(List<string> codeType)
        {
            var res = _svc.ReadByCodeType(codeType);
            return Ok(res);
        }

        /// <summary>
        /// Read code type
        /// </summary>
        /// <param name="req">Request</param>
        /// <returns>Return the result</returns>
        [HttpGet("read-type")]
        public IActionResult ReadType()
        {
            var res = _svc.ReadType();
            return Ok(res);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="req">Request</param>
        /// <returns>Return the result</returns>
        //[HttpPut("update")]
        //public IActionResult Update([FromBody]CodeReq req)
        //{
        //    var m = req.ToModel();
        //    m.ModifiedBy = UserId;

        //    var res = _svc.Update(m);
        //    return Ok(res);
        //}

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="req">Request</param>
        /// <returns>Return the result</returns>
        //[HttpDelete("delete")]
        //public IActionResult Delete([FromBody]SimpleReq req)
        //{
        //    var res = _svc.Delete(req.Id);
        //    return Ok(res);
        //}

        #endregion

        #region -- Fields --

        /// <summary>
        /// Repository to handle the database
        /// </summary>
        private CodeSvc _svc;

        #endregion
    }
}