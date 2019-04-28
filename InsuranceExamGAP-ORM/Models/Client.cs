using System.Collections.Generic;

namespace InsuranceExamGAP_ORM.Core.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public List<ClientPolicy> ClientPolicies { get; set; }
    }
}