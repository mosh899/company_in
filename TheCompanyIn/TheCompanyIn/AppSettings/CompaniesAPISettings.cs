using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCompanyIn.AppSettings
{
    public class CompaniesAPISettings : ICompaniesAPISettings
    {
        public string Url { get; set; }
        public string CompanyNamePlaceHolder { get; set; }
        
        public string AuthorizationHeaderName { get; set; }
        public string AuthorizationHeaderValue { get; set; }

    }
    public interface ICompaniesAPISettings
    {
        string Url { get; set; }
        string CompanyNamePlaceHolder { get; set; }
        string AuthorizationHeaderName { get; set; }
        string AuthorizationHeaderValue { get; set; }
    }
}
