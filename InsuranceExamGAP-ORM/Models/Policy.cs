using System;

namespace InsuranceExamGAP_ORM.Core.Models
{
    public class Policy
    {

        public int? PolicyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PolicyTypeId { get; set; }
        public PolicyType PolicyType { get; set; }
        public DateTime PolicyDateBegin { get; set; }
        public int PolicyMonthsPeriod { get; set; }
        public double PolicyCost { get; set; }
        public int RiskTypeId { get; set; }
        public RiskType RiskType { get; set; }

    }
}