/* Options:
Date: 2021-01-01 14:21:06
Version: 5.103
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://localhost:5001

//GlobalNamespace: 
//MakePropertiesOptional: False
//AddServiceStackTypes: True
//AddResponseStatus: False
//AddImplicitVersion: 
//AddDescriptionAsComments: True
//IncludeTypes: 
//ExcludeTypes: 
//DefaultImports: 
*/


export interface IReturn<T>
{
    createResponse(): T;
}

export interface IReturnVoid
{
    createResponse(): void;
}

// @DataContract
export class Company
{
    // @DataMember
    public id: string;

    // @DataMember
    // @Required()
    public ranking: number;

    // @DataMember
    // @Required()
    public name: string;

    // @DataMember
    public subname: string;

    // @DataMember
    // @Required()
    public countryId: string;

    // @DataMember
    // @Required()
    public statusDate: string;

    // @DataMember
    public turnoverCurrencyId: string;

    // @DataMember
    public turnoverAmount: number;

    // @DataMember
    public employeeCount: number;

    // @DataMember
    public note: string;

    public constructor(init?: Partial<Company>) { (Object as any).assign(this, init); }
}

// @DataContract
export class ResponseError
{
    // @DataMember(Order=1)
    public errorCode: string;

    // @DataMember(Order=2)
    public fieldName: string;

    // @DataMember(Order=3)
    public message: string;

    // @DataMember(Order=4)
    public meta: { [index: string]: string; };

    public constructor(init?: Partial<ResponseError>) { (Object as any).assign(this, init); }
}

// @DataContract
export class ResponseStatus
{
    // @DataMember(Order=1)
    public errorCode: string;

    // @DataMember(Order=2)
    public message: string;

    // @DataMember(Order=3)
    public stackTrace: string;

    // @DataMember(Order=4)
    public errors: ResponseError[];

    // @DataMember(Order=5)
    public meta: { [index: string]: string; };

    public constructor(init?: Partial<ResponseStatus>) { (Object as any).assign(this, init); }
}

export class CompanyResponse
{
    public result: Company;
    public responseStatus: ResponseStatus;

    public constructor(init?: Partial<CompanyResponse>) { (Object as any).assign(this, init); }
}

// @Route("/company", "GET")
// @Route("/company/{Name}", "GET")
export class GetCompany implements IReturn<CompanyResponse>
{
    public name: string;

    public constructor(init?: Partial<GetCompany>) { (Object as any).assign(this, init); }
    public createResponse() { return new CompanyResponse(); }
    public getTypeName() { return 'GetCompany'; }
}

