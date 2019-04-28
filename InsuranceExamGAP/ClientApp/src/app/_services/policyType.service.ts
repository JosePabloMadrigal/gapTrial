import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { PolicyType } from '../_models';
@Injectable({ providedIn: 'root' })
export class PolicyTypeService {
  constructor(private http: HttpClient) { }

  getPolicyTypes() {
    return this.http.get<PolicyType[]>(`/api/policytype/`);
  }
}
