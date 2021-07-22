using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Threading.Tasks;
using TheCompanyIn.AppSettings;
using TheCompanyIn.Interfaces;
using TheCompanyIn.Models;
using TheCompanyIn.Utils;

namespace TheCompanyIn.Services
{
    public class CompaniesAPI : IEntityDatabase<Company>
    {
        private readonly ICompaniesAPISettings _apiSettings;
        public CompaniesAPI(ICompaniesAPISettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public async Task<Company> Get(string companyId)
        {
            var url = buildUrl(companyId);
            using(HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(_apiSettings.AuthorizationHeaderName, _apiSettings.AuthorizationHeaderValue);

                var companyResponse = await http.GetAsync(url);
                if (!companyResponse.IsSuccessStatusCode)
                    return null;
                var responseContent = await companyResponse.Content.ReadAsStringAsync();
                var companyDetails = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);
                return buildCompanyObject(companyDetails);
            }
        }
        public Task<bool> Delete(Company obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Company obj)
        {
            throw new NotImplementedException();
        }

        private string buildUrl(string companyName) => _apiSettings.Url.Replace(_apiSettings.CompanyNamePlaceHolder, companyName);
        private Company buildCompanyObject(Dictionary<string, object> responseObj) =>
            new Company
            {
                Name = responseObj.GetKey("name").ToString(),
                Description = responseObj.GetKey("description").ToString(),
                Domain = responseObj.GetKey("domain").ToString(),
                Industry = responseObj.GetNestedObject("category", "industry"),
                Location = responseObj["location"]?.ToString(),
                Logo = responseObj.GetKey("logo").ToString(),
                AnnualRevenue = responseObj.GetNestedObject("metrics", "annualRevenue"),
                MarketCap = responseObj.GetNestedObject("metrics", "marketCap"),
                MoneyRaised = responseObj.GetNestedObject("metrics", "raised"),
                NumOfEmployees = responseObj.GetNestedObject("metrics", "employees")
            };
        

    }
}
