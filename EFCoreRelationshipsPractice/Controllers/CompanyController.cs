using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreRelationshipsPractice.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyDbContext companyDbContext;

        public CompanyController(CompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> List()
        {
            return await this.companyDbContext.Companies.ToListAsync();
        }

        [HttpPost]
        public async Task<Company> Add(Company company)
        {
            using (companyDbContext)
            {
                await this.companyDbContext.Companies.AddAsync(company);
                await this.companyDbContext.SaveChangesAsync();
                return company;
            }
        }
    }
}