using System;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice;
using EFCoreRelationshipsPractice.Models;
using EFCoreRelationshipsPractice.Repository;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EFCoreRelationshipsPracticeTest
{
    public class CompanyControllerTest : TestBase
    {
        public CompanyControllerTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_create_company_employee_profile_success()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();

            await context.Companies.AddAsync(new CompanyModel());
            await context.SaveChangesAsync();

            var companies = context.Companies.ToList();
        }
    }
}