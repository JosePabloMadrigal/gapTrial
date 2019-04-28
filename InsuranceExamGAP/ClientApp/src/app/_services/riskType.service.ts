import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { RiskType } from '../_models';
@Injectable({ providedIn: 'root' })
export class RiskTypeService {
  constructor(private http: HttpClient) { }
  getRiskTypes() {
    return this.http.get<RiskType[]>(`/api/risktype/`);
  }

}
