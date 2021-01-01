using System;
using ServiceStack;
using MinWebApp.ServiceModel;
using MinWebApp.ServiceModel.Types;

namespace MinWebApp.ServiceInterface
{
    public class CompanyServices : Service
    {
        public CompanyResponse Get(GetCompany request)
        {
            Company? company = null;

            if (request.Name is not null)
            {
                company = new Company
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Subname = null,
                    Ranking = 0,
                    CountryId = Guid.NewGuid(),
                    StatusDate = DateTime.UtcNow,
                    TurnoverCurrencyId = null,
                    TurnoverAmount = null,
                    EmployeeCount = 42,
                    Note = "simple note"
                };
            }

            return new CompanyResponse { Result = company };
        }
    }
}
