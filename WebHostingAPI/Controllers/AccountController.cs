using AutoMapper;
using DataAccessLayer.Repository;
using WebHosting.EntityLayer.DTO;
using WebHosting.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace WebHostingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("GetAllAccounts", Name = "GetAllAccounts")]
        public IActionResult GetAllAccounts()
        {
            try
            {
                HostingRepo hostingRepo = new HostingRepo();
                var model = hostingRepo.GetListAll();
                ICollection<string> HostingDomainNames = new List<string>();

                foreach (var item in model)
                {
                    var HostingDomainName = item.HostingDomainName;
                    HostingDomainNames.Add(HostingDomainName);
                }

                return Ok(HostingDomainNames);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpGet("GetAccount", Name = "GetAccount")]
        public IActionResult GetAccount(string HostingDomainName)
        {
            try
            {
                HostingRepo hostingRepo = new HostingRepo();
                var model = _mapper.Map<HostingDetailDto>(hostingRepo.GetById(HostingDomainName));
                return Ok(model);

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("CreateAccount", Name = "CreateAccount")]
        public IActionResult CreateAccount([FromBody] HostingDto dto)
        {
            MessageDto messageDto = new MessageDto();
            try
            {

                Hosting hosting = new Hosting()
                {
                    HostingDomainName = dto.HostingDomainName,
                    HostingPackage = dto.HostingPackage
                };

                HostingRepo hostingRepo = new HostingRepo();
                hostingRepo.Add(hosting);
                messageDto.Message = "Success";
                return Ok(messageDto);
               
            }
            catch (SqlException ex)
            {
                messageDto.Message = "Failure";
                return BadRequest(messageDto.Message);
            }

        }

        [HttpPost("DeleteAccount", Name = "DeleteAccount")]
        public IActionResult DeleteAccount([FromBody] HostingDto dto)
        {
            MessageDto messageDto = new MessageDto();

            try
            {
                Hosting host = new Hosting()
                {
                    HostingDomainName = dto.HostingDomainName,
                    HostingPackage = dto.HostingPackage
                };

                HostingRepo hostingRepo = new HostingRepo();

                hostingRepo.Delete(host);
                messageDto.Message = "Success";
                return Ok(messageDto);

            }
            catch (SqlException ex)
            {
                messageDto.Message = "Failure";
                return BadRequest(messageDto.Message);
            }

        }


    }
}
