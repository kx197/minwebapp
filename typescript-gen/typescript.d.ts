/* Options:
Date: 2021-01-01 14:21:23
Version: 5.103
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://localhost:5001

//GlobalNamespace: 
//MakePropertiesOptional: True
//AddServiceStackTypes: True
//AddResponseStatus: False
//AddImplicitVersion: 
//AddDescriptionAsComments: True
//IncludeTypes: 
//ExcludeTypes: 
//DefaultImports: 
*/


interface IReturn<T>
{
}

interface IReturnVoid
{
}

// @DataContract
interface Company
{
    // @DataMember
    id: string;

    // @DataMember
    // @Required()
    ranking: number;

    // @DataMember
    // @Required()
    name: string;

    // @DataMember
    subname: string;

    // @DataMember
    // @Required()
    countryId: string;

    // @DataMember
    // @Required()
    statusDate: string;

    // @DataMember
    turnoverCurrencyId: string;

    // @DataMember
    turnoverAmount: number;

    // @DataMember
    employeeCount: number;

    // @DataMember
    note: string;
}

// @DataContract
interface ResponseError
{
    // @DataMember(Order=1)
    errorCode: string;

    // @DataMember(Order=2)
    fieldName: string;

    // @DataMember(Order=3)
    message: string;

    // @DataMember(Order=4)
    meta: { [index: string]: string; };
}

// @DataContract
interface ResponseStatus
{
    // @DataMember(Order=1)
    errorCode: string;

    // @DataMember(Order=2)
    message: string;

    // @DataMember(Order=3)
    stackTrace: string;

    // @DataMember(Order=4)
    errors: ResponseError[];

    // @DataMember(Order=5)
    meta: { [index: string]: string; };
}

interface CompanyResponse
{
    result: Company;
    responseStatus: ResponseStatus;
}

// @Route("/company", "GET")
// @Route("/company/{Name}", "GET")
interface GetCompany extends IReturn<CompanyResponse>
{
    name: string;
}

