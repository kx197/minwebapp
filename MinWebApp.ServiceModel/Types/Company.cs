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
        [DataMember, Required] 
        public Guid Id { get; set; } = Guid.Empty;

        [DataMember, Required] 
        public int Ranking { get; set; } = 0;

        [DataMember, Required] 
        public string Name { get; set; } = string.Empty;

        [DataMember] 
        public string? Subname { get; set; } = null;

        [DataMember, Required] 
        public Guid CountryId { get; set; } = Guid.Empty;

        [DataMember, Required] 
        public DateTime StatusDate { get; set; } = DateTime.UtcNow;

        [DataMember] 
        public Guid? TurnoverCurrencyId { get; set; } = null;

        [DataMember] 
        public decimal? TurnoverAmount { get; set; } = null;

        [DataMember] 
        public int? EmployeeCount { get; set; } = null;

        [DataMember] 
        public string? Note { get; set; } = null;
    }
}
