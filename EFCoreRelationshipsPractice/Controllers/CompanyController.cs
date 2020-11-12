using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
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
        public async Task<ActionResult<IEnumerable<CompanyDto>>> List()
        {
            var companyModels = await this.companyDbContext.Companies
                .Include(company => company.Profile)
                .Include(company => company.Employees)
                .ToListAsync();

            var companyDtos = companyModels.Select(model => new CompanyDto(model));

            return Ok(companyDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetById(int id)
        {
            var companyModel = await this.companyDbContext.Companies
                .Include(company => company.Profile)
                .Include(company => company.Employees)
                .FirstOrDefaultAsync(model => model.Id == id);
            var companyDto = new CompanyDto(companyModel);

            return Ok(companyDto);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> Add(CompanyDto companyDto)
        {
            CompanyModel company = new CompanyModel(companyDto);

            await this.companyDbContext.Companies.AddAsync(company);
            await this.companyDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = company.Id }, companyDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var foundCompany = await this.companyDbContext.Companies.FirstOrDefaultAsync(company => company.Id == id);
            if (foundCompany != null)
            {
                this.companyDbContext.Remove(foundCompany);
                await this.companyDbContext.SaveChangesAsync();
            }

            return this.NoContent();
        }
    }
}