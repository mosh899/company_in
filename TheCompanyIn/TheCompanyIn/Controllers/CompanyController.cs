using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCompanyIn.Interfaces;
using TheCompanyIn.Models;

namespace TheCompanyIn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IEntityDatabase<Company> _companyDBService;

        public CompanyController(IEntityDatabase<Company> companyDBService)
        {
            _companyDBService = companyDBService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string companyDomain)
        {
            try
            {
                var compayDetails = await _companyDBService.Get(companyDomain);
                if (compayDetails is null)
                    return NotFound();
                return Ok(compayDetails);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

        }
    }
}