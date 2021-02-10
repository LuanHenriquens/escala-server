using System;
using System.Threading.Tasks;
using escala_server.Data.DTOs;
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
        public async Task<ActionResult<MemberLoginDTO>> RegistrationMember(MemberRegistrationDTO memberRegistration) =>
            await _memberService.Registration(memberRegistration);
    }
}