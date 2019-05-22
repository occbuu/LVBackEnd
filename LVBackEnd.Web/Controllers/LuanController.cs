using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SKG.Req;

namespace LVBackEnd.Web.Controllers
{
    using BLL;

    [Route("api/[controller]")]
    [ApiController]    
    public class LuanController : ControllerBase
    {
        public LuanController()
        {
            _svcRule = new RuleSvc();
            _svcSymp = new SymptomSvc();
            _svcDise = new DiseaseSvc();
            _svcPatie = new PatientDataSvc();
        }

        [AllowAnonymous]
        [HttpPost("read-disease")]
        public IActionResult ReadDisease([FromBody]PagingReq req)
        {
            //req.UserId = UserId;
            var res = _svcDise.Read(req);
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("read-rule")]
        public IActionResult ReadRule([FromBody]PagingReq req)
        {
            //req.UserId = UserId;
            var res = _svcRule.Read(req);
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("read-sympton")]
        public IActionResult ReadSympton([FromBody]PagingReq req)
        {
            //req.UserId = UserId;
            var res = _svcSymp.Read(req);
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("read-patient-data")]
        public IActionResult ReadPatientData([FromBody]PagingReq req)
        {
            //req.UserId = UserId;
            var res = _svcPatie.Read(req);
            return Ok(res);
        }

        #region -- Fields --

        /// <summary>
        /// Repository to handle the database
        /// </summary>
        private RuleSvc _svcRule;
        private SymptomSvc _svcSymp;
        private DiseaseSvc _svcDise;
        private PatientDataSvc _svcPatie;

        #endregion
    }
}