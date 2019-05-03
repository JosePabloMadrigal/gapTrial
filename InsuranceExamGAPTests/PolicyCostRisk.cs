using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using InsuranceExamGAP_ORM.Utils;
using InsuranceExamGAP_ORM.Utils.Exceptions;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RiskCostTest()
        {
            
            Policy policy = new Policy { RiskType = new RiskType{ Name ="Alto" },PolicyType = new PolicyType {PolicyCover = 0.7}};
            
            
            Assert.Throws<CostRiskException>(()=> CostRiskValidation.CostRiskValidator(policy));
        }
    }
}