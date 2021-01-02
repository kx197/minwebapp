# Purpose

This repository shows customisation of typescript generation by ServiceStack from a DataContract, such that:

-  `?` is used for optional properties 
- `|null` is appended for non-required properties.

## C# DTO

```csharp 
using ServiceStack.DataAnnotations;
using System;
using System.Runtime.Serialization;

namespace MinWebApp.ServiceModel.Types
{
    [Schema("Customer")]
    [DataContract]
    public class Company
    {
        [AutoId]
        [DataMember, Required] public Guid Id { get; set; } = Guid.Empty;

        [DataMember, Required] public int Ranking { get; set; } = 0;
        [DataMember, Required] public string Name { get; set; } = string.Empty;
        [DataMember] public string? Subname { get; set; } = null;
    
        [DataMember, Required] public Guid CountryId { get; set; } = Guid.Empty;
        [DataMember, Required] public DateTime StatusDate { get; set; } = DateTime.UtcNow;
    
        [DataMember] public Guid? TurnoverCurrencyId { get; set; } = null;
        [DataMember] public decimal? TurnoverAmount { get; set; } = null;
    
        [DataMember] public int? EmployeeCount { get; set; } = null;
    
        [DataMember] public string? Note { get; set; } = null;
    }
}
```


## Generated Typescript

The default generated ambient declaration file (typescript.d), without any customisations:

```TypeScript
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

```

# Project creation
Project was generated  from the following:

.NET 5.0 Empty Web Template

[![](https://raw.githubusercontent.com/ServiceStack/Assets/master/csharp-templates/web.png)](http://web.web-templates.io/)

> Browse [source code](https://github.com/NetCoreTemplates/web), view live demo [web.web-templates.io](http://web.web-templates.io) and install with [dotnet-new](https://docs.servicestack.net/dotnet-new):

    $ dotnet tool install -g x
    
    $ x new web MiniWebApp



