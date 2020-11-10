using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.DTO;
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
        public async Task<IEnumerable<ListCompanyResponse>> List()
        {
            await using (companyDbContext)
            {
                var companies = await companyDbContext.Companies.Include(c => c.Profile).ToListAsync();
                return companies.Select(company =>
                {
                    return new ListCompanyResponse()
                    {
                        Name = company.Name,
                        Profile = new ListProfileResponse()
                        {
                            RegisteredCapital = company.Profile.RegisteredCapital,
                            CertId = company.Profile.CertId
                        }
                    };
                }).ToList();
            }
        }

        [HttpPost]
        public async Task<CreateCompanyResponse> Add(CreateCompanyRequest request)
        {
            var company = new Company()
            {
                Name = request.Name,
                Profile = new Profile()
                {
                    CertId = request.Profile.CertId,
                    RegisteredCapital = request.Profile.RegisteredCapital
                }
            };
            await using (companyDbContext)
            {
                await companyDbContext.Companies.AddAsync(company);
                await companyDbContext.SaveChangesAsync();

                return new CreateCompanyResponse()
                {
                    Name = request.Name,
                    Profile = new CreateProfileResponse()
                    {
                        CertId = request.Profile.CertId,
                        RegisteredCapital = request.Profile.RegisteredCapital
                    }
                };
            }
        }
    }
}