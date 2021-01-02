/* Options:
Date: 2021-01-02 09:49:10
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

// @ts-nocheck

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
    // @Required()
    id: string;

    // @DataMember
    // @Required()
    ranking: number;

    // @DataMember
    // @Required()
    name: string;

    // @DataMember
    subname?: string|null;

    // @DataMember
    // @Required()
    countryId: string;

    // @DataMember
    // @Required()
    statusDate: string;

    // @DataMember
    turnoverCurrencyId?: string|null;

    // @DataMember
    turnoverAmount?: number|null;

    // @DataMember
    employeeCount?: number|null;

    // @DataMember
    note?: string|null;
}

// @DataContract
interface ResponseError
{
    // @DataMember(Order=1)
    errorCode?: string|null;

    // @DataMember(Order=2)
    fieldName?: string|null;

    // @DataMember(Order=3)
    message?: string|null;

    // @DataMember(Order=4)
    meta?: { [index: string]: string; }|null;
}

// @DataContract
interface ResponseStatus
{
    // @DataMember(Order=1)
    errorCode?: string|null;

    // @DataMember(Order=2)
    message?: string|null;

    // @DataMember(Order=3)
    stackTrace?: string|null;

    // @DataMember(Order=4)
    errors?: ResponseError[]|null;

    // @DataMember(Order=5)
    meta?: { [index: string]: string; }|null;
}

interface CompanyResponse
{
    result?: Company|null;
    responseStatus?: ResponseStatus|null;
}

// @Route("/company", "GET")
// @Route("/company/{Name}", "GET")
interface GetCompany extends IReturn<CompanyResponse>
{
    name?: string|null;
}

