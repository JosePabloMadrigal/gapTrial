using System.Collections.Generic;

namespace InsuranceExamGAP_ORM.Core.Models
{
    public class ClientPolicies
    {
        public int ClientId { get; set; }
        public List<int> PoliciesIds { get; set; }
    }
}