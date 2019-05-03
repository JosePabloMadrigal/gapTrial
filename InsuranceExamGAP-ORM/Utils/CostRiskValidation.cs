using System;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Utils.Exceptions;

namespace InsuranceExamGAP_ORM.Utils
{
    public static class CostRiskValidation
    {

        private const string HIGHERRISK = "Alto";
        private const double HIGHERPERCENTAGE = 0.5;
        public static bool CostRiskValidator(Policy policy)
        {
            if (String.CompareOrdinal(policy.RiskType.Name, HIGHERRISK) != 0 &&
                HIGHERPERCENTAGE <= policy.PolicyType.PolicyCover)
            {
                return true;
            }
            else
            {
                throw new CostRiskException("El riesgo y la covertura de la poliza son muy altos.");
            }
        }
    }
}