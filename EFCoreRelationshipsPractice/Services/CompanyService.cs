using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Models;
using EFCoreRelationshipsPractice.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext companyDbContext;

        public CompanyService(CompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            var companyModels = await this.companyDbContext.Companies
                .Include(company => company.Profile)
                .Include(company => company.Employees)
                .ToListAsync();

            return companyModels.Select(model => new CompanyDto(model)).ToList();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var companyModel = await this.companyDbContext.Companies
                .Include(company => company.Profile)
                .Include(company => company.Employees)
                .FirstOrDefaultAsync(model => model.Id == id);
            return new CompanyDto(companyModel);
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            CompanyModel company = new CompanyModel(companyDto);

            await this.companyDbContext.Companies.AddAsync(company);
            await this.companyDbContext.SaveChangesAsync();
            return company.Id;
        }

        public async Task DeleteCompany(int id)
        {
            var foundCompany = await this.companyDbContext.Companies.FirstOrDefaultAsync(company => company.Id == id);
            if (foundCompany != null)
            {
                this.companyDbContext.Remove(foundCompany);
                await this.companyDbContext.SaveChangesAsync();
            }
        }
    }
}