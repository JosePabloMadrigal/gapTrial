namespace InsuranceExamGAP_ORM.Core.Models
{
    public class ClientPolicy
    {
        public int ClientPolicyId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }
    }
}