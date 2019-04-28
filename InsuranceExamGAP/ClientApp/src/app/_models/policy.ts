import { PolicyType, RiskType, } from '../_models';
export class Policy {
  policyId: number;
  name: string;
  description: string;
  policyTypeId: number;
  policyDateBegin: string;
  policyMonthsPeriod: number;
  policyCost: number;
  riskTypeId: number;
  riskType: RiskType;
  policyType: PolicyType;
}
