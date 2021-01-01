using MinWebApp.ServiceModel.Types;
using ServiceStack;

namespace MinWebApp.ServiceModel
{
    [Route("/company", "GET")]
    [Route("/company/{Name}", "GET")]
    public class GetCompany : IReturn<CompanyResponse>
    {
        public string? Name { get; set; } = null;
    }

    public class CompanyResponse
    {
        public Company? Result { get; set; } = null;
        public ResponseStatus? ResponseStatus { get; set; } = null;
    }
}
