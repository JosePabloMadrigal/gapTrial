import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Policy } from '../_models';
@Injectable({ providedIn: 'root' })
export class PolicyService {
  constructor(private http: HttpClient) { }

  getPolicies() {
    return this.http.get<Policy[]>(`/api/Policies/`);
  }

  deletePolicy(id: number) {
    return this.http.delete(`/api/Policies/delete/` + id);
  } 
  addPolicy(policy: Policy) {
    return this.http.post(`/api/Policies/create`, policy);
  }
  updatePolicy(policy: Policy) {
    return this.http.post(`/api/Policies/update`, policy);
  }
  checkPolicyRiskCover(policyTypeId: number, riskTypeId: number) {
    return this.http.get(`/api/Policies/checkPolicyRisk/` + policyTypeId + '/' + riskTypeId);
  }
}


//this.userService.getAll().pipe(first()).subscribe(users => {
//    this.users = users;
//});
