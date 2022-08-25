using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RandevumAPI.Interface;
using RandevumAPI.Objects.DTO;
using Repository;
using Repository.EntitiyModels;

namespace RandevumAPI.Service
{
    public class CompanyService : ICompanyService
    {

        private readonly IMongoRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(IMongoRepository<Company> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<Company> GetCompany(string id)
        {
            return await _companyRepository.FindByIdAsync(id);
        }

        public Task<List<Company>> GetCompanyList()
        {
            return Task.FromResult(new List<Company>());
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await _companyRepository.ToListAsync();
        }

        public async Task<string> SaveCompany(CompanyDTO company)
        {
            Company newCompany = new Company();
            newCompany = _mapper.Map<Company>(company);

            await _companyRepository.InsertOneAsync(newCompany);

            return newCompany.Id.ToString();
        }

        public async Task<string> UpdateCompany(CompanyDTO company)
        {
            Company newCompany = new Company();
            newCompany = _mapper.Map<Company>(company);

            await _companyRepository.ReplaceOneAsync(newCompany);

            return newCompany.Id.ToString();
        }

        public async Task<bool> DeleteCompany(string id)
        {
            return await _companyRepository.DeleteByIdAsync(id);
        }

    }
}