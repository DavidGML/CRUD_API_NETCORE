using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAItalika.Models;
using WAItalika.Models.Services;

namespace WAItalika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _IUsuarioService;

        /*public UsuarioController( IUsuarioService usuarioService )
        {
            _IUsuarioService = usuarioService;
        }*/

        [HttpPost("login")]
        public IActionResult Atentication([FromBody] AuthRequest auth)
        {
            Response response = new Response();
            var userresponse = _IUsuarioService.Response(auth);

            if (userresponse == null)
            {
                response.Success = false;
                response.Message = "Invalid User or Password";
                return BadRequest(response);
            }

            response.Success = true;
            response.Data = userresponse;
            return Ok(response);
        }
    }
}
