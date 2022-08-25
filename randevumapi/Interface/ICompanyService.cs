using System.Collections.Generic;
using System.Threading.Tasks;
using RandevumAPI.Objects.DTO;
using Repository.EntitiyModels;

namespace RandevumAPI.Interface
{
    public interface ICompanyService
    {
        Task<string> SaveCompany (CompanyDTO company);
        Task<string> UpdateCompany (CompanyDTO company);
        Task<List<Company>> GetCompanyList ();
        Task<List<Company>> GetCompaniesAsync ();
        Task<Company> GetCompany (string Id);
        Task<bool> DeleteCompany (string id);
    }
}