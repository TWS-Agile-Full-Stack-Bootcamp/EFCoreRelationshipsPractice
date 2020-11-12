using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreRelationshipsPractice.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> List()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetById(int id)
        {
            return null;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> Add(CompanyDto companyDto)
        {
            return null;
        }
    }
}