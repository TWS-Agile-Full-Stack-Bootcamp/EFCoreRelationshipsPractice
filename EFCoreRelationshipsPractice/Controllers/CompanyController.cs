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
            var companyModels = await this.companyDbContext.Companies.Include(company => company.Profile).ToListAsync();

            var companyDtos = companyModels.Select(model =>
            {
                return new CompanyDto()
                {
                    Name = model.Name,
                    Profile = new ProfileDto()
                    {
                        RegisteredCapital = model.Profile.RegisteredCapital,
                        CertId = model.Profile.CertId,
                    }
                };
            });

            return Ok(companyDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetById(int id)
        {
            var companyModel = await this.companyDbContext.Companies.Include(company => company.Profile).FirstOrDefaultAsync(model => model.Id == id);
            var companyDto = new CompanyDto()
            {
                Name = companyModel.Name,
                Profile = new ProfileDto()
                {
                    RegisteredCapital = companyModel.Profile.RegisteredCapital,
                    CertId = companyModel.Profile.CertId,
                }
            };

            return Ok(companyDto);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> Add(CompanyDto companyDto)
        {
            ProfileModel profile = new ProfileModel()
            {
                RegisteredCapital = companyDto.Profile.RegisteredCapital,
                CertId = companyDto.Profile.CertId,
            };
            CompanyModel company = new CompanyModel()
            {
                Name = companyDto.Name,
                Profile = profile,
            };

            await this.companyDbContext.Companies.AddAsync(company);
            await this.companyDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = company.Id }, companyDto);
        }
    }
}