using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreRelationshipsPractice.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Company>> List()
        {
            return null;
        }

        [HttpPost]
        public async Task<Company> Add(Company company)
        {
            return null;
        }
    }
}