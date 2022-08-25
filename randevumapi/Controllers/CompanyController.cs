using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandevumAPI.Interface;
using RandevumAPI.Objects.DTO;
using Repository.EntitiyModels;

namespace RandevumAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet, Route("{id}")]
        public async Task<Company> GetCompany(string id)
        {
            return await _companyService.GetCompany(id);
        }

        [AllowAnonymous]
        [HttpGet, Route("companylist")]
        public async Task<List<Company>> GetCompanyList()
        {
            return await _companyService.GetCompaniesAsync();
        }

        [Authorize(Roles = "admin,user")]
        [HttpPost, Route("add")]
        public async Task<string> CreateCompany(CompanyDTO company)
        {
            return await _companyService.SaveCompany(company);
        }


        [HttpPut, Route("update")]
        public async Task<string> UpdateCompany(CompanyDTO company)
        {
            return await _companyService.UpdateCompany(company);
        }

        [HttpDelete, Route("{id}")]
        public async Task<bool> DeleteCompany(string id)
        {
            return await _companyService.DeleteCompany(id);
        }
    }
}