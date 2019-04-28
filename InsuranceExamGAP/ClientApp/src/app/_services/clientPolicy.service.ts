import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ClientPolicy } from '../_models';

@Injectable({ providedIn: 'root' })
export class ClientPolicyService {
  constructor(private http: HttpClient) { }

  addClientPolicy(clientPolicy: ClientPolicy) {
    return this.http.post(`/api/ClientPolicy/`, clientPolicy);
  }
}
