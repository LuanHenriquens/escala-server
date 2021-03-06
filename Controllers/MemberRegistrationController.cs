using System;
using System.Threading.Tasks;
using escala_server.Data.DTO;
using escala_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace escala_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberRegistrationController : Controller
    {
        readonly IMemberService _memberService;
        public MemberRegistrationController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpPost]
        public async Task<ActionResult<LoginReturnDTO>> RegistrationMember(MemberRegistrationDTO memberRegistration)
        {
            try
            {
                return await _memberService.Registration(memberRegistration);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            
    }
}