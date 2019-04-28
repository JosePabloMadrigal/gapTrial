using System;

namespace InsuranceExamGAP_ORM.Utils.Exceptions
{
    public class CostRiskException : Exception
    {
        public CostRiskException()
        {
        }


        public CostRiskException(string message)
            : base(message)
        {
        }

        public CostRiskException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}