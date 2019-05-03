using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using InsuranceExamGAP_ORM.Utils;
using InsuranceExamGAP_ORM.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace InsuranceExamGAP_ORM.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly InsuranceContext _context;

        
        public PolicyRepository(InsuranceContext context)
        {
            _context = context;
        }

        public async Task<List<Policy>> GetPolicies()
        {
            List<Policy> policies = await _context.Policies.Include(policy => policy.PolicyType).Include(policy => policy.RiskType).ToListAsync();
            return policies;
        }

        public async Task<Policy> CreatePolicy(Policy policy)
        {
            try
            {
                policy.PolicyId = null;
                if (CostRiskValidation.CostRiskValidator(policy)) { 
                    _context.Policies.Add(new Policy
                    {
                        Description = policy.Description,
                        Name = policy.Name,
                        PolicyCost = policy.PolicyCost,
                        PolicyDateBegin = policy.PolicyDateBegin,
                        PolicyId = policy.PolicyId,
                        PolicyMonthsPeriod = policy.PolicyMonthsPeriod,
                        PolicyTypeId = policy.PolicyTypeId,
                        RiskTypeId = policy.RiskTypeId

                    });
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return policy;
        }

        public async Task<Policy> UpdatePolicy(Policy policy)
        {
            try
            {
                if (CostRiskValidation.CostRiskValidator(policy))
                {
                    _context.Policies.Update(policy);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return policy;
        }

        public async Task DeletePolicy(Policy policy)
        {
            try
            {
                _context.Remove(policy);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Policy> FindPolicy(int policyId)
        {
            return await _context.Policies.FindAsync(policyId);
        }
    }
}