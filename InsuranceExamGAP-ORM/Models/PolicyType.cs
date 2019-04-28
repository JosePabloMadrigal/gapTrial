using System.Reflection.Metadata.Ecma335;

namespace InsuranceExamGAP_ORM.Core.Models
{
    public class PolicyType
    {
        public int PolicyTypeId { get; set; }
        public string Name { get; set; }
        public double PolicyCover { get; set; }
    }
}