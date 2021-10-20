using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StockAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[Action]")]
    public class ContentController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Get()
        {
            return Ok();

        }
    }
}
// call the Monitor in the Get 
// read the article on API


    